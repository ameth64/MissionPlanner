using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Collections;
using System.Threading;

using System.Drawing.Drawing2D;
using log4net;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using Meshomatic;

namespace MissionPlanner.Mesh
{
    public class _3DMesh : GLControl
    {
        public bool yawrotate = false;
        float _roll = 0;
        float _pitch = 0;
        float _heading = 0;
        ushort _aileron_l = 0;
        ushort _aileron_r = 0;

        [System.ComponentModel.Browsable(true), System.ComponentModel.Category("Values")]
        public float roll { get { return _roll; } set { if (_roll != value) { _roll = value; this.Invalidate(); } } }
        [System.ComponentModel.Browsable(true), System.ComponentModel.Category("Values")]
        public float pitch { get { return _pitch; } set { if (_pitch != value) { _pitch = value; this.Invalidate(); } } }
        [System.ComponentModel.Browsable(true), System.ComponentModel.Category("Values")]
        public float heading { get { return _heading; } set { if (_heading != value) { _heading = value; this.Invalidate(); } } }
        [System.ComponentModel.Browsable(true), System.ComponentModel.Category("Values")]
        public ushort aileron_l { get { return _aileron_l; } set { if (_aileron_l != value) { _aileron_l = value; this.Invalidate(); } } }

        [System.ComponentModel.Browsable(true), System.ComponentModel.Category("Values")]
        public ushort aileron_r { get { return _aileron_r; } set { if (_aileron_r != value) { _aileron_r = value; this.Invalidate(); } } }

        const float rotation_speed = 40.0f;
        float angle;

        private static System.Timers.Timer aTimer;

        MeshData m;
        uint dataBuffer;
        uint indexBuffer;
        uint tex;
        int vertOffset, normOffset, texcoordOffset;
        OpenTK.Vector3d up = new OpenTK.Vector3d(0.0, 1.0, 0.0);
        OpenTK.Vector3d viewDirection = new OpenTK.Vector3d(1.0, 1.0, 1.0);
        double viewDist = 370f;
        bool loaded = false;
        string vShaderSource = @"
void main() {
	gl_Position = ftransform();
	gl_TexCoord[0] = gl_MultiTexCoord0;
}
";
        string fShaderSource = @"
uniform sampler2D tex;
void main() {
	gl_FragColor = texture2D(tex, gl_TexCoord[0].st);
}
";

        DateTime countdate = DateTime.Now;
        DateTime starttime = DateTime.MinValue;

        public _3DMesh()
        {

            this.Name = "_3DMesh";

            //eps.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 50L); // or whatever other quality value you want

            //objBitmap.MakeTransparent();

            //InitializeComponent();

            //graphicsObject = this;
            //graphicsObjectGDIP = Graphics.FromImage(objBitmap);
        }

        int CompileShaders()
        {
            int programHandle, vHandle, fHandle;
            vHandle = GL.CreateShader(ShaderType.VertexShader);
            fHandle = GL.CreateShader(ShaderType.FragmentShader);
            GL.ShaderSource(vHandle, vShaderSource);
            GL.ShaderSource(fHandle, fShaderSource);
            GL.CompileShader(vHandle);
            GL.CompileShader(fHandle);
            Console.Write(GL.GetShaderInfoLog(vHandle));
            Console.Write(GL.GetShaderInfoLog(fHandle));

            programHandle = GL.CreateProgram();
            GL.AttachShader(programHandle, vHandle);
            GL.AttachShader(programHandle, fHandle);
            GL.LinkProgram(programHandle);
            Console.Write(GL.GetProgramInfoLog(programHandle));
            return programHandle;
        }

        void LoadBuffers(MeshData m)
        {
            float[] verts, norms, texcoords;
            uint[] indices;
            m.OpenGLArrays(out verts, out norms, out texcoords, out indices);
            GL.GenBuffers(1, out dataBuffer);
            GL.GenBuffers(1, out indexBuffer);

            // Set up data for VBO.
            // We're going to use one VBO for all geometry, and stick it in 
            // in (VVVVNNNNCCCC) order.  Non interleaved.
            int buffersize = (verts.Length + norms.Length + texcoords.Length);
            float[] bufferdata = new float[buffersize];
            vertOffset = 0;
            normOffset = verts.Length;
            texcoordOffset = (verts.Length + norms.Length);

            verts.CopyTo(bufferdata, vertOffset);
            norms.CopyTo(bufferdata, normOffset);
            texcoords.CopyTo(bufferdata, texcoordOffset);

            bool v = false;
            for (int i = texcoordOffset; i < bufferdata.Length; i++)
            {
                if (v)
                {
                    bufferdata[i] = 1 - bufferdata[i];
                    v = false;
                }
                else
                {
                    v = true;
                }
            }

            // Load geometry data
            GL.BindBuffer(BufferTarget.ArrayBuffer, dataBuffer);
            GL.BufferData<float>(BufferTarget.ArrayBuffer, (IntPtr)(buffersize * sizeof(float)), bufferdata,
                          BufferUsageHint.StaticDraw);

            // Load index data
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, indexBuffer);
            GL.BufferData<uint>(BufferTarget.ElementArrayBuffer,
                          (IntPtr)(indices.Length * sizeof(uint)), indices, BufferUsageHint.StaticDraw);
        }

        void DrawBuffer()
        {
            // Push current Array Buffer state so we can restore it later
            GL.PushClientAttrib(ClientAttribMask.ClientVertexArrayBit);

            GL.ClientActiveTexture(TextureUnit.Texture0);
            GL.BindTexture(TextureTarget.Texture2D, tex);

            GL.BindBuffer(BufferTarget.ArrayBuffer, dataBuffer);
            // Normal buffer
            GL.NormalPointer(NormalPointerType.Float, 0, (IntPtr)(normOffset * sizeof(float)));

            // TexCoord buffer
            GL.TexCoordPointer(2, TexCoordPointerType.Float, 0, (IntPtr)(texcoordOffset * sizeof(float)));

            // Vertex buffer
            GL.VertexPointer(3, VertexPointerType.Float, 0, (IntPtr)(vertOffset * sizeof(float)));

            // Index array
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, indexBuffer);
            GL.DrawElements(BeginMode.Triangles, m.Tris.Length * 3, DrawElementsType.UnsignedInt, IntPtr.Zero);

            // Restore the state
            GL.PopClientAttrib();
        }

        protected override void OnLoad(EventArgs e)
        {
            if (this.DesignMode)
            {
                //opengl = false;
                return;
            }
            base.OnLoad(e);
            //MeshData m = new ColladaLoader().LoadFile("dice.dae");
            m = new ObjLoader().LoadFile("FunJet.obj");
            tex = LoadTex("texture.jpg");

            if (m == null)
                return;

            //m = new Ms3dLoader().LoadFile("test.ms3d");
            //m = new ObjLoader().LoadFile("test.obj");
            //tex = LoadTex("test.png");

            // We do some heuristics to try to auto-zoom to a reasonable distance.  And it generally works!
            double w, l, h;
            double maxdim;
            m.Dimensions(out w, out l, out h);
            Console.WriteLine("Model dimensions: {0} x {0} x {0} (theoretically)", w, l, h);
            maxdim = Math.Max(Math.Max(w, l), h);
            //viewDist = (float)(maxdim * 2);
            try
            {
                GL.ClearColor(Color.MidnightBlue);
                GL.Enable(EnableCap.DepthTest);
                GL.Enable(EnableCap.Texture2D);
                GL.EnableClientState(ArrayCap.VertexArray);
                GL.EnableClientState(ArrayCap.NormalArray);
                GL.EnableClientState(ArrayCap.TextureCoordArray);

                GL.UseProgram(CompileShaders());
                LoadBuffers(m);

               // GL.Viewport(0, 0, Width, Height);

                double aspect_ratio = Width / (double)Height;

                OpenTK.Matrix4 perspective = OpenTK.Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)aspect_ratio, 0.1f, 64000f);
                GL.MatrixMode(MatrixMode.Projection);
                GL.LoadMatrix(ref perspective);
            }
            catch (Exception ex) { Console.WriteLine("HUD opengl onload 4 ", ex); }

            loaded = true;

        // Alternate method: create a Timer with an interval argument to the constructor. 
        //aTimer = new System.Timers.Timer(2000); 

        // Create a timer with a two second interval.
        aTimer = new System.Timers.Timer(34);

        // Hook up the Elapsed event for the timer. 
        aTimer.Elapsed += OnTimedEvent;

        // Have the timer fire repeated events (true is the default)
        aTimer.AutoReset = true;

        // Start the timer
        aTimer.Enabled = true;

        }

        protected  void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            using (Graphics gg = this.CreateGraphics())
            {
                OnPaint(new PaintEventArgs(gg, this.ClientRectangle));
            }
        }

      
        protected override void OnResize(EventArgs e)
        {
            
            if (loaded == false)
                return;

            int ht = (int)(this.Width / 1.333f);
            if (ht >= this.Height + 5 || ht <= this.Height - 5)
            {
                this.Height = ht;
                //return;
            }

            try
            {
               // GL.Viewport(0, 0, Width, Height);

                double aspect_ratio = Width / (double)Height;

                OpenTK.Matrix4 perspective = OpenTK.Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)aspect_ratio, 0.1f, 64000f);
                GL.MatrixMode(MatrixMode.Projection);
                GL.LoadMatrix(ref perspective);
            }
            catch (Exception ex) { Console.WriteLine("HUD opengl OnResize ", ex); }

            base.OnResize(e);
        }
      
        public static double ConvertDegreesToRadians(double degrees)
        {
            double radians = (Math.PI / 180) * degrees;
            return (radians);
        }
        /*
        protected override void OnResize(EventArgs e)
        {
            if (DesignMode || !IsHandleCreated || !loaded)
                return;

            base.OnResize(e);

            if (false)
            {
                int ht = (int)(this.Width / 1.777f);
                if (ht >= this.Height + 5 || ht <= this.Height - 5)
                {
                    this.Height = ht;
                    return;
                }
            }
            else
            {
                // 4x3
                int ht = (int)(this.Width / 1.333f);
                if (ht >= this.Height + 5 || ht <= this.Height - 5)
                {
                    this.Height = ht;
                    return;
                }
            }

            // GC.Collect();

            try
            {
               // if (opengl)
                {
                    MakeCurrent();
                    GL.LoadIdentity();
                    GL.Viewport(0, 0, Width, Height);

                    double aspect_ratio = Width / (double)Height;

                    OpenTK.Matrix4 perspective = OpenTK.Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)aspect_ratio, 0.1f, 64000f);
                    GL.MatrixMode(MatrixMode.Projection);
                    GL.LoadMatrix(ref perspective);

                    
                    GL.Ortho(0, Width, Height, 0, -1, 1);
                   // GL.MatrixMode(MatrixMode.Modelview);
                    GL.LoadIdentity();

                    GL.Viewport(0, 0, Width, Height);

                    //SwapBuffers();
                }
            }
            catch { }

            using (Graphics gg = this.CreateGraphics())
            {
                OnPaint(new PaintEventArgs(gg, this.ClientRectangle));
            }
        }
        */
        protected override void OnPaint(PaintEventArgs e)
        {
            if (this.DesignMode)
            {
                //opengl = false;
                return;
            }
            if (loaded == false)
                return;

            //DrawMesh();
            //return;
            try
            {

                MakeCurrent();

                GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

                GL.MatrixMode(MatrixMode.Modelview);
                GL.LoadIdentity();
                GL.Viewport(0, 0, Width, Height);
                // SET CAMERA, THEN DRAW STUFF DAMMIT
                Matrix4d camera = Matrix4d.LookAt(OpenTK.Vector3d.Multiply(viewDirection, viewDist),
                                                    OpenTK.Vector3d.Zero, up);
                GL.LoadMatrix(ref camera);

                GL.BindBuffer(BufferTarget.ArrayBuffer, dataBuffer);
                //GL.BufferSubData<float>(BufferTarget.ArrayBuffer, (IntPtr)0,(IntPtr)1, ref a);
                IntPtr data = GL.MapBuffer(BufferTarget.ArrayBuffer, BufferAccess.ReadWrite);
                unsafe
                {
                    float* vdata = (float*)data.ToPointer();
                    double lineAlpha = Math.Atan2(Math.Abs(m.Vertices[92].Y - m.Vertices[158].Y), Math.Abs(m.Vertices[92].X - m.Vertices[158].X));
                    double ldeg = (((float)_aileron_l - 255f) / 180f) * 90f ;
                    for (int tri = 44; tri <= 84; tri++)
                    {
                        double Alpha = Math.Atan2(Math.Abs(m.Vertices[92].Y - m.Vertices[m.Tris[tri].P1.Vertex].Y), Math.Abs(m.Vertices[92].X - m.Vertices[m.Tris[tri].P1.Vertex].X));
                        double x = (m.Vertices[92].X - m.Vertices[m.Tris[tri].P1.Vertex].X);
                        double y = (m.Vertices[92].Y - m.Vertices[m.Tris[tri].P1.Vertex].Y);
                        double z = (m.Vertices[92].Z - m.Vertices[m.Tris[tri].P1.Vertex].Z);
                        double lineAB = Math.Sqrt(y * y + x * x);
                        double lineF = lineAB * Math.Sin(Math.Abs(Alpha - lineAlpha));
                        double offY = lineF * Math.Cos(ConvertDegreesToRadians(ldeg));
                        offY = (lineF - offY) * Math.Cos(lineAlpha);
                        double offZ = lineF * Math.Sin(ConvertDegreesToRadians(ldeg));
                        double offX = Math.Tan(lineAlpha) * offY;
                        vdata[tri * 9 + 0] = (float)(m.Vertices[m.Tris[tri].P1.Vertex].X - offX);
                        vdata[tri * 9 + 1] = (float)(m.Vertices[m.Tris[tri].P1.Vertex].Y + offY);
                        vdata[tri * 9 + 2] = (float)(m.Vertices[m.Tris[tri].P1.Vertex].Z + offZ);

                        Alpha = Math.Atan2(Math.Abs(m.Vertices[92].Y - m.Vertices[m.Tris[tri].P2.Vertex].Y), Math.Abs(m.Vertices[92].X - m.Vertices[m.Tris[tri].P2.Vertex].X));
                        x = (m.Vertices[92].X - m.Vertices[m.Tris[tri].P2.Vertex].X);
                        y = (m.Vertices[92].Y - m.Vertices[m.Tris[tri].P2.Vertex].Y);
                        z = (m.Vertices[92].Z - m.Vertices[m.Tris[tri].P2.Vertex].Z);
                        lineAB = Math.Sqrt(y * y + x * x);
                        lineF = lineAB * Math.Sin(Math.Abs(Alpha - lineAlpha));
                        offY = lineF * Math.Cos(ConvertDegreesToRadians(ldeg));
                        offY = (lineF - offY) * Math.Cos(lineAlpha);
                        offZ = lineF * Math.Sin(ConvertDegreesToRadians(ldeg));
                        offX = Math.Tan(lineAlpha) * offY;
                        vdata[tri * 9 + 3] = (float)(m.Vertices[m.Tris[tri].P2.Vertex].X - offX);
                        vdata[tri * 9 + 4] = (float)(m.Vertices[m.Tris[tri].P2.Vertex].Y + offY);
                        vdata[tri * 9 + 5] = (float)(m.Vertices[m.Tris[tri].P2.Vertex].Z + offZ);

                        Alpha = Math.Atan2(Math.Abs(m.Vertices[92].Y - m.Vertices[m.Tris[tri].P3.Vertex].Y), Math.Abs(m.Vertices[92].X - m.Vertices[m.Tris[tri].P3.Vertex].X));
                        x = (m.Vertices[92].X - m.Vertices[m.Tris[tri].P3.Vertex].X);
                        y = (m.Vertices[92].Y - m.Vertices[m.Tris[tri].P3.Vertex].Y);
                        z = (m.Vertices[92].Z - m.Vertices[m.Tris[tri].P3.Vertex].Z);
                        lineAB = Math.Sqrt(y * y + x * x);
                        lineF = lineAB * Math.Sin(Math.Abs(Alpha - lineAlpha));
                        offY = lineF * Math.Cos(ConvertDegreesToRadians(ldeg));
                        offY = (lineF - offY) * Math.Cos(lineAlpha);
                        offZ = lineF * Math.Sin(ConvertDegreesToRadians(ldeg));
                        offX = Math.Tan(lineAlpha) * offY;
                        vdata[tri * 9 + 6] = (float)(m.Vertices[m.Tris[tri].P3.Vertex].X - offX);
                        vdata[tri * 9 + 7] = (float)(m.Vertices[m.Tris[tri].P3.Vertex].Y + offY);
                        vdata[tri * 9 + 8] = (float)(m.Vertices[m.Tris[tri].P3.Vertex].Z + offZ);

                    }

                    double rdeg = (((float)_aileron_r - 255f) / 180f) * -90f;
                    lineAlpha = Math.Atan2(Math.Abs(m.Vertices[256].Y - m.Vertices[233].Y), Math.Abs(m.Vertices[256].X - m.Vertices[233].X));
                    for (int tri = 85; tri <= 122; tri++)
                    {
                        double Alpha = Math.Atan2(Math.Abs(m.Vertices[256].Y - m.Vertices[m.Tris[tri].P1.Vertex].Y), Math.Abs(m.Vertices[256].X - m.Vertices[m.Tris[tri].P1.Vertex].X));
                        double x = (m.Vertices[256].X - m.Vertices[m.Tris[tri].P1.Vertex].X);
                        double y = (m.Vertices[256].Y - m.Vertices[m.Tris[tri].P1.Vertex].Y);
                        double z = (m.Vertices[256].Z - m.Vertices[m.Tris[tri].P1.Vertex].Z);
                        double lineAB = Math.Sqrt(y * y + x * x);
                        double lineF = lineAB * Math.Sin(Math.Abs(Alpha - lineAlpha));
                        double offY = lineF * Math.Cos(ConvertDegreesToRadians(rdeg));
                        offY = (lineF - offY) * Math.Cos(lineAlpha);
                        double offZ = lineF * Math.Sin(ConvertDegreesToRadians(rdeg));
                        double offX = Math.Tan(lineAlpha) * offY;
                        vdata[tri * 9 + 0] = (float)(m.Vertices[m.Tris[tri].P1.Vertex].X + offX);
                        vdata[tri * 9 + 1] = (float)(m.Vertices[m.Tris[tri].P1.Vertex].Y + offY);
                        vdata[tri * 9 + 2] = (float)(m.Vertices[m.Tris[tri].P1.Vertex].Z + offZ);

                        Alpha = Math.Atan2(Math.Abs(m.Vertices[256].Y - m.Vertices[m.Tris[tri].P2.Vertex].Y), Math.Abs(m.Vertices[256].X - m.Vertices[m.Tris[tri].P2.Vertex].X));
                        x = (m.Vertices[256].X - m.Vertices[m.Tris[tri].P2.Vertex].X);
                        y = (m.Vertices[256].Y - m.Vertices[m.Tris[tri].P2.Vertex].Y);
                        z = (m.Vertices[256].Z - m.Vertices[m.Tris[tri].P2.Vertex].Z);
                        lineAB = Math.Sqrt(y * y + x * x);
                        lineF = lineAB * Math.Sin(Math.Abs(Alpha - lineAlpha));
                        offY = lineF * Math.Cos(ConvertDegreesToRadians(rdeg));
                        offY = (lineF - offY) * Math.Cos(lineAlpha);
                        offZ = lineF * Math.Sin(ConvertDegreesToRadians(rdeg));
                        offX = Math.Tan(lineAlpha) * offY;
                        vdata[tri * 9 + 3] = (float)(m.Vertices[m.Tris[tri].P2.Vertex].X + offX);
                        vdata[tri * 9 + 4] = (float)(m.Vertices[m.Tris[tri].P2.Vertex].Y + offY);
                        vdata[tri * 9 + 5] = (float)(m.Vertices[m.Tris[tri].P2.Vertex].Z + offZ);

                        Alpha = Math.Atan2(Math.Abs(m.Vertices[256].Y - m.Vertices[m.Tris[tri].P3.Vertex].Y), Math.Abs(m.Vertices[256].X - m.Vertices[m.Tris[tri].P3.Vertex].X));
                        x = (m.Vertices[256].X - m.Vertices[m.Tris[tri].P3.Vertex].X);
                        y = (m.Vertices[256].Y - m.Vertices[m.Tris[tri].P3.Vertex].Y);
                        z = (m.Vertices[256].Z - m.Vertices[m.Tris[tri].P3.Vertex].Z);
                        lineAB = Math.Sqrt(y * y + x * x);
                        lineF = lineAB * Math.Sin(Math.Abs(Alpha - lineAlpha));
                        offY = lineF * Math.Cos(ConvertDegreesToRadians(rdeg));
                        offY = (lineF - offY) * Math.Cos(lineAlpha);
                        offZ = lineF * Math.Sin(ConvertDegreesToRadians(rdeg));
                        offX = Math.Tan(lineAlpha) * offY;
                        vdata[tri * 9 + 6] = (float)(m.Vertices[m.Tris[tri].P3.Vertex].X + offX);
                        vdata[tri * 9 + 7] = (float)(m.Vertices[m.Tris[tri].P3.Vertex].Y + offY);
                        vdata[tri * 9 + 8] = (float)(m.Vertices[m.Tris[tri].P3.Vertex].Z + offZ);

                    }

                }
                GL.UnmapBuffer(BufferTarget.ArrayBuffer);
                
                GL.Rotate(45, 0.0f, 1.0f, 0.0f);
                GL.Rotate(-125, 1.0f, 0.0f, 0.0f);
                if (yawrotate)
                GL.Rotate(-_heading, 0.0f, 0.0f, 1.0f);
                GL.Rotate(_roll, 0.0f, 1.0f, 0.0f);
                GL.Rotate(_pitch, 1.0f, 0.0f, 0.0f);
                
                
                DrawBuffer();

                SwapBuffers();
                Context.MakeCurrent(null);
            }
            catch (Exception ex) { Console.WriteLine("HUD opengl OnPaint ", ex); }
            Thread.Sleep(1);
        }

        protected  void OnUpdateFrame(FrameEventArgs e)
        {
            //base.OnUpdateFrame(e);
        }

        protected  void OnRenderFrame(FrameEventArgs e)
        {
            //base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();

            // SET CAMERA, THEN DRAW STUFF DAMMIT
            Matrix4d camera = Matrix4d.LookAt(OpenTK.Vector3d.Multiply(viewDirection, viewDist),
                                                OpenTK.Vector3d.Zero, up);
            GL.LoadMatrix(ref camera);

            //angle += rotation_speed * (float)e.Time;
            angle = 0;
            GL.Rotate(angle, 0.0f, 1.0f, 0.0f);
            DrawBuffer();

            SwapBuffers();
            Thread.Sleep(1);
        }

        // Example of how you would draw things in (deprecated) immediate mode.
        
        private void DrawMesh() {
            GL.BindTexture(TextureTarget.Texture2D, tex);
            GL.Begin(BeginMode.Triangles);
			
            foreach(Tri t in m.Tris) {
                foreach (Meshomatic.mPoint p in t.Points())
                {
                    Meshomatic.Vector3 v = m.Vertices[p.Vertex];
                    Meshomatic.Vector3 n = m.Normals[p.Normal];
                    Meshomatic.Vector2 tc = m.TexCoords[p.TexCoord];
                    GL.Normal3(n.X, n.Y, n.Z);
                    GL.TexCoord2(tc.X, 1- tc.Y);
                    GL.Vertex3(v.X, v.Y, v.Z);
                }
            }
			
            GL.End();
        }
        

        // XXX: TODO: Make this work
        static bool IsPowerOf2(Bitmap b)
        {
            //uint w = bitmap.Width;
            //uint h = bitmap.Height;

            return true;
        }

        // Maybe factor this out into another part of the library?
        // This loads the texture mirrored along one axis, but you can
        // easily fix this by changing all your UVs' second coordinate from 
        // v to 1-v
        static uint LoadTex(string file)
        {
            Bitmap bitmap = new Bitmap(file);
            uint texture;
            if (!IsPowerOf2(bitmap))
            {
                // XXX: FormatException isn't really the best here, buuuut...
                throw new FormatException("Texture sizes must be powers of 2!");
            }

            
    try
       {
           
            GL.Hint(HintTarget.PerspectiveCorrectionHint, HintMode.Nicest);

            GL.GenTextures(1, out texture);
            GL.BindTexture(TextureTarget.Texture2D, texture);

            BitmapData data = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0,
                OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
            bitmap.UnlockBits(data);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
            return texture;
        }catch (Exception ex) { Console.WriteLine("HUD opengl onload 2 ", ex); }
    return 0;
            
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // _3DMesh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.Name = "_3DMesh";
            this.ResumeLayout(false);

        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            base.OnHandleDestroyed(e);

            // Create a timer with a two second interval.
            //aTimer = new System.Timers.Timer(34);

            // Hook up the Elapsed event for the timer. 
            //aTimer.Elapsed += OnTimedEvent;

            // Have the timer fire repeated events (true is the default)
            //aTimer.AutoReset = true;

            // Start the timer
            aTimer.Enabled = false;
            aTimer.Stop();
            aTimer.Close();
            aTimer.Dispose();

        }

    }
}
