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
        }

        List<Section> sections = new List<Section>();
        private void dataGridView_DragDrop(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.None;
            string[] str = (string[])e.Data.GetData(DataFormats.FileDrop);
            MyHex2Bin.GetAddrInfo(Encoding.Default, ref sections, out string log, str);

            foreach (var item in sections)
            {
                DataGridViewRow dataGridViewRow = new DataGridViewRow();
                dataGridViewRow.CreateCells(dataGridView);
                dataGridViewRow.Cells[0].Value = item.filePath;
                dataGridViewRow.Cells[1].Value = item.data.Count().ToString();
                dataGridViewRow.Cells[2].Value = item.startAddr.ToString("X");
                dataGridViewRow.Cells[3].Value = item.endAddr.ToString("X");
                dataGridView.Rows.Add(dataGridViewRow);
            }
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

    }
}
