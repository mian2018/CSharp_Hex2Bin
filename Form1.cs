using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CSharp_Hex2Bin.MyHex2Bin;

namespace CSharp_Hex2Bin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SaveFilePath("");
        }

        /// <summary>
        /// 保存加载到内存的hex文件信息
        /// </summary>
        List<Section> sections = new List<Section>();
        /// <summary>
        /// 加hex文件信息加载到表格中
        /// </summary>
        /// <param name="sections">hex文件信息</param>
        /// <returns>日志信息</returns>
        string DataGridViewRefresh(List<Section> sections)
        {
            List<Section> errSections = new List<Section>();
            MyHex2Bin.CheckAddr(sections, out string log, ref errSections);
            dataGridView.Rows.Clear();
            foreach (var item in sections)
            {
                DataGridViewRow dataGridViewRow = new DataGridViewRow();
                dataGridViewRow.CreateCells(dataGridView);
                dataGridViewRow.Cells[0].Value = item.filePath;
                dataGridViewRow.Cells[1].Value = item.data.Count().ToString();
                dataGridViewRow.Cells[2].Value = "0x" + item.startAddr.ToString("X8");
                dataGridViewRow.Cells[3].Value = "0x" + item.endAddr.ToString("X8");
                if (errSections.IndexOf(item) != -1)
                {
                    dataGridViewRow.DefaultCellStyle.BackColor = Color.DarkRed;
                }
                dataGridView.Rows.Add(dataGridViewRow);
            }
            return log;
        }
        /// <summary>
        /// 记录历史文件信息
        /// </summary>
        /// <param name="path"></param>
        void SaveFilePath(params string[] path)
        {
            List<string> strList = new List<string>();

            strList.Add(Properties.Settings.Default.logPath1);
            strList.Add(Properties.Settings.Default.logPath2);
            strList.Add(Properties.Settings.Default.logPath3);
            strList.Add(Properties.Settings.Default.logPath4);
            strList.Add(Properties.Settings.Default.logPath5);
            foreach (var item in path)
            {
                if (!string.IsNullOrWhiteSpace(item))
                {
                    strList.Remove(item);
                    strList.Insert(0, item);
                }
            }

            ///* 保存当前路径 */
            Properties.Settings.Default.logPath1 = strList[0];
            Properties.Settings.Default.logPath2 = strList[1];
            Properties.Settings.Default.logPath3 = strList[2];
            Properties.Settings.Default.logPath4 = strList[3];
            Properties.Settings.Default.logPath5 = strList[4];
            Properties.Settings.Default.Save();

            /* 历史文件菜单 */
            toolStripMenuItem2.Text = strList[0];
            toolStripMenuItem3.Text = strList[1];
            toolStripMenuItem4.Text = strList[2];
            toolStripMenuItem5.Text = strList[3];
            toolStripMenuItem6.Text = strList[4];
        }
        /// <summary>
        /// 打开hex文件
        /// </summary>
        /// <param name="path"></param>
        void OpenHexFile(params string[] path)
        {
            MyHex2Bin.LoadHex(Encoding.Default, ref sections, out string log, path);
            log += DataGridViewRefresh(sections);
            txbLog.AppendText(log);
            SaveFilePath(path);
        }

        private void dataGridView_DragDrop(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.None;

            string[] str = (string[])e.Data.GetData(DataFormats.FileDrop);
            OpenHexFile(str);
        }

        private void dataGridView_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] path = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (var item in path)
                {
                    if (Path.GetExtension(item).ToLower() != ".hex")
                    {
                        e.Effect = DragDropEffects.None;
                        return;
                    }
                }
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dataGridView.SelectedRows)
            {
                sections.RemoveAt(item.Index);
                dataGridView.Rows.RemoveAt(item.Index);
            }
        }

        private void 生成binToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sections.Count > 0)
            {
                if (填充空段ToolStripMenuItem.Checked)
                {
                    MyHex2Bin.WriteBinFile(sections[0].filePath, 0, sections);
                }
                else
                {
                    MyHex2Bin.WriteBinFile(sections[0].filePath, 0xff, sections);
                }
            }
        }
        
        private void bin另存为ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sections.Count > 0)
            {
                saveBin.InitialDirectory = Path.GetDirectoryName(sections[0].filePath);
                saveBin.FileName = Path.GetFileNameWithoutExtension(sections[0].filePath);
                if (saveBin.ShowDialog() == DialogResult.OK)
                {
                    if (填充空段ToolStripMenuItem.Checked)
                    {
                        MyHex2Bin.WriteBinFile(saveBin.FileName, 0, sections);
                    }
                    else
                    {
                        MyHex2Bin.WriteBinFile(saveBin.FileName, 0xff, sections);
                    }
                }
            }
        }

        private void 打开文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openHex.ShowDialog() == DialogResult.OK)
            {
                OpenHexFile(openHex.FileNames);
            }
        }

        private void 填充空段ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            填充空段ToolStripMenuItem.Checked = !填充空段ToolStripMenuItem.Checked;
        }

        private void 清空文本框ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txbLog.Text = "";
        }

        private void toolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenHexFile(((ToolStripMenuItem)sender).Text);
        }
    }
}
