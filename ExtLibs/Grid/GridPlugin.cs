﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GMap.NET.WindowsForms;

namespace MissionPlanner
{
    public class GridPlugin : MissionPlanner.Plugin.Plugin
    {
        

        ToolStripMenuItem but;
        ToolStripMenuItem but2;

        public override string Name
        {
            get { return "Grid"; }
        }

        public override string Version
        {
            get { return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(); }
        }

        public override string Author
        {
            get { return "Michael Oborne"; }
        }

        public override bool Init()
        {
            return true;
        }

        public override bool Loaded()
        {
            Grid.Host2 = Host;

            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GridUI));
            var temp = (string)(resources.GetObject("$this.Text"));

            but = new ToolStripMenuItem(temp);
            but.Click += but_Click;

            bool hit = false;
            ToolStripItemCollection col = Host.FPMenuMap.Items;
            int index = col.Count;
            foreach (ToolStripItem item in col)
            {
                if (item.Text.Equals(Strings.AutoWP))
                {
                    index = col.IndexOf(item);
                    ((ToolStripMenuItem)item).DropDownItems.Add(but);
                    hit = true;
                    break;
                }
            }

            //用户菜单
            but2 = new ToolStripMenuItem("自动生成航线");
            but2.Click += but_Click;
            ToolStripItemCollection col2 = Host.FPMenuMap2.Items;
            index = col2.Count;
            foreach (ToolStripItem item in col2)
            {
                if (item.Text.Equals("生成航线"))
                {
                    index = col2.IndexOf(item);
                    ((ToolStripMenuItem)item).DropDownItems.Add(but2);
                    break;
                }
            }

            if (hit == false)
                col.Add(but);

            return true;
        }

        void but_Click(object sender, EventArgs e)
        {
            using (var gridui = new GridUI(this))
            {
                MissionPlanner.Utilities.ThemeManager.ApplyThemeTo(gridui);

                if (Host.FPDrawnPolygon != null && Host.FPDrawnPolygon.Points.Count > 2)
                {
                    gridui.ShowDialog();
                }
                else
                {
                    if (
                        CustomMessageBox.Show("没有选定范围，是否加载范围文件?", "范围文件", MessageBoxButtons.YesNo) ==
                        DialogResult.Yes)
                    {
                        gridui.LoadGrid();
                        gridui.ShowDialog();
                    }
                    else
                    {
                        CustomMessageBox.Show("请先添加范围.", "错误");
                    }
                }
            }
        }

        public override bool Exit()
        {
            return true;
        }
    }
}
