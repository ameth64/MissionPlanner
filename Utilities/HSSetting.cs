using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;


namespace MissionPlanner.Utilities
{
    class HSSetting
    {
        static HSSetting _instance;

        public static HSSetting Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new HSSetting();
                }
                return _instance;
            }
        }
        // Structures
        public struct hsdatainfo
        {
            public string name;
            public double redminvalue;
            public double redmaxvalue;
            public double whiteminvalue;
            public double whitemaxvalue;
            public double greenminvalue;
            public double greenmaxvalue;
            public bool enablecolor;
            public bool enablevoice;
            public bool enableautoonlyvoice;
            public string voicecontent;
        }

        public static Dictionary<string, hsdatainfo> hsdatas = new Dictionary<string, hsdatainfo>();


        public HSSetting()
        {

        }

        public void xmlhsdata(bool write)
        {
            string filename = Settings.GetRunningDirectory() + "hsconfig.xml";
            bool exists = File.Exists(filename);

            if (write || !exists)
            {
                try
                {
                    XmlTextWriter xmlwriter = new XmlTextWriter(filename, Encoding.Unicode);
                    xmlwriter.Formatting = Formatting.Indented;

                    xmlwriter.WriteStartDocument();

                    xmlwriter.WriteStartElement("hsdatas");

                    foreach (string key in hsdatas.Keys)
                    {
                        try
                        {
                            if (key == "")
                                continue;
                            xmlwriter.WriteStartElement("hsdatainfo");
                            xmlwriter.WriteElementString("name", hsdatas[key].name);
                            xmlwriter.WriteElementString("redminvalue", hsdatas[key].redminvalue.ToString(new System.Globalization.CultureInfo("en-US")));
                            xmlwriter.WriteElementString("redmaxvalue", hsdatas[key].redmaxvalue.ToString(new System.Globalization.CultureInfo("en-US")));
                            xmlwriter.WriteElementString("whiteminvalue", hsdatas[key].whiteminvalue.ToString(new System.Globalization.CultureInfo("en-US")));
                            xmlwriter.WriteElementString("whitemaxvalue", hsdatas[key].whitemaxvalue.ToString(new System.Globalization.CultureInfo("en-US")));
                            xmlwriter.WriteElementString("greenminvalue", hsdatas[key].greenminvalue.ToString(new System.Globalization.CultureInfo("en-US")));
                            xmlwriter.WriteElementString("greenmaxvalue", hsdatas[key].greenmaxvalue.ToString(new System.Globalization.CultureInfo("en-US")));

                            xmlwriter.WriteElementString("enablecolor", hsdatas[key].enablecolor.ToString(new System.Globalization.CultureInfo("en-US")));
                            xmlwriter.WriteElementString("enablevoice", hsdatas[key].enablevoice.ToString(new System.Globalization.CultureInfo("en-US")));
                            xmlwriter.WriteElementString("enableautoonlyvoice", hsdatas[key].enableautoonlyvoice.ToString(new System.Globalization.CultureInfo("en-US")));
                            if(hsdatas[key].voicecontent!=null)
                            xmlwriter.WriteElementString("voicecontent", hsdatas[key].voicecontent);
                            xmlwriter.WriteEndElement();
                        }
                        catch { }
                    }

                    xmlwriter.WriteEndElement();

                    xmlwriter.WriteEndDocument();
                    xmlwriter.Close();

                }
                catch (Exception ex) { CustomMessageBox.Show(ex.ToString()); }
            }
            else
            {
                try
                {
                    using (XmlTextReader xmlreader = new XmlTextReader(filename))
                    {
                        while (xmlreader.Read())
                        {
                            xmlreader.MoveToElement();
                            try
                            {
                                switch (xmlreader.Name)
                                {
                                    case "hsdatainfo":
                                        {
                                            hsdatainfo hsdata = new hsdatainfo();

                                            while (xmlreader.Read())
                                            {
                                                bool dobreak = false;
                                                xmlreader.MoveToElement();
                                                switch (xmlreader.Name)
                                                {
                                                    case "name":
                                                        hsdata.name = xmlreader.ReadString();
                                                        break;
                                                    case "redminvalue":
                                                        hsdata.redminvalue = double.Parse(xmlreader.ReadString(), new System.Globalization.CultureInfo("en-US"));
                                                        break;
                                                    case "redmaxvalue":
                                                        hsdata.redmaxvalue = double.Parse(xmlreader.ReadString(), new System.Globalization.CultureInfo("en-US"));
                                                        break;
                                                    case "whiteminvalue":
                                                        hsdata.whiteminvalue = double.Parse(xmlreader.ReadString(), new System.Globalization.CultureInfo("en-US"));
                                                        break;
                                                    case "whitemaxvalue":
                                                        hsdata.whitemaxvalue = double.Parse(xmlreader.ReadString(), new System.Globalization.CultureInfo("en-US"));
                                                        break;
                                                    case "greenminvalue":
                                                        hsdata.greenminvalue = double.Parse(xmlreader.ReadString(), new System.Globalization.CultureInfo("en-US"));
                                                        break;
                                                    case "greenmaxvalue":
                                                        hsdata.greenmaxvalue = double.Parse(xmlreader.ReadString(), new System.Globalization.CultureInfo("en-US"));
                                                        break;
                                                    case "enablecolor":
                                                        hsdata.enablecolor = bool.Parse(xmlreader.ReadString());
                                                        break;
                                                    case "enablevoice":
                                                        hsdata.enablevoice = bool.Parse(xmlreader.ReadString());
                                                        break;
                                                    case "enableautoonlyvoice":
                                                        hsdata.enableautoonlyvoice = bool.Parse(xmlreader.ReadString());
                                                        break;
                                                    case "voicecontent":
                                                        hsdata.voicecontent = xmlreader.ReadString();
                                                        break;
                                                    case "hsdatainfo":
                                                        hsdatas[hsdata.name] = hsdata;
                                                        dobreak = true;
                                                        break;
                                                }
                                                if (dobreak)
                                                    break;
                                            }
                                            string temp = xmlreader.ReadString();
                                        }
                                        break;
                                    case "Config":
                                        break;
                                    case "xml":
                                        break;
                                    default:
                                        if (xmlreader.Name == "") // line feeds
                                            break;
                                        //config[xmlreader.Name] = xmlreader.ReadString();
                                        break;
                                }
                            }
                            catch (Exception ee) { Console.WriteLine(ee.Message); } // silent fail on bad entry
                        }
                    }
                }
                catch (Exception ex) { Console.WriteLine("Bad hsdata File: " + ex.ToString()); } // bad config file

            }
        }



    }
}
