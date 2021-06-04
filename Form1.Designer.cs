
namespace CSharp_Hex2Bin
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.FliePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartAddr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndAddr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataViewMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.打开文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.生成binToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bin另存为ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.填充空段ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txbLog = new System.Windows.Forms.TextBox();
            this.cmbLogMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.清空文本框ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openHex = new System.Windows.Forms.OpenFileDialog();
            this.saveBin = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.dataViewMenu.SuspendLayout();
            this.cmbLogMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowDrop = true;
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToOrderColumns = true;
            this.dataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("隶书", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FliePath,
            this.FileSize,
            this.StartAddr,
            this.EndAddr});
            this.dataGridView.ContextMenuStrip = this.dataViewMenu;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView.Location = new System.Drawing.Point(1, 1);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(800, 317);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.DragDrop += new System.Windows.Forms.DragEventHandler(this.dataGridView_DragDrop);
            this.dataGridView.DragEnter += new System.Windows.Forms.DragEventHandler(this.dataGridView_DragEnter);
            // 
            // FliePath
            // 
            this.FliePath.FillWeight = 55F;
            this.FliePath.HeaderText = "文件路径";
            this.FliePath.Name = "FliePath";
            this.FliePath.ReadOnly = true;
            // 
            // FileSize
            // 
            this.FileSize.FillWeight = 15F;
            this.FileSize.HeaderText = "文件大小";
            this.FileSize.Name = "FileSize";
            this.FileSize.ReadOnly = true;
            // 
            // StartAddr
            // 
            this.StartAddr.FillWeight = 15F;
            this.StartAddr.HeaderText = "起始地址";
            this.StartAddr.Name = "StartAddr";
            this.StartAddr.ReadOnly = true;
            // 
            // EndAddr
            // 
            this.EndAddr.FillWeight = 15F;
            this.EndAddr.HeaderText = "结束地址";
            this.EndAddr.Name = "EndAddr";
            this.EndAddr.ReadOnly = true;
            // 
            // dataViewMenu
            // 
            this.dataViewMenu.Font = new System.Drawing.Font("楷体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataViewMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开文件ToolStripMenuItem,
            this.生成binToolStripMenuItem,
            this.bin另存为ToolStripMenuItem,
            this.删除ToolStripMenuItem,
            this.打开记录ToolStripMenuItem,
            this.填充空段ToolStripMenuItem});
            this.dataViewMenu.Name = "dataViewMenu";
            this.dataViewMenu.Size = new System.Drawing.Size(181, 158);
            // 
            // 打开文件ToolStripMenuItem
            // 
            this.打开文件ToolStripMenuItem.Image = global::CSharp_Hex2Bin.Properties.Resources.打开;
            this.打开文件ToolStripMenuItem.Name = "打开文件ToolStripMenuItem";
            this.打开文件ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.打开文件ToolStripMenuItem.Text = "打开hex";
            this.打开文件ToolStripMenuItem.Click += new System.EventHandler(this.打开文件ToolStripMenuItem_Click);
            // 
            // 生成binToolStripMenuItem
            // 
            this.生成binToolStripMenuItem.Image = global::CSharp_Hex2Bin.Properties.Resources.生成;
            this.生成binToolStripMenuItem.Name = "生成binToolStripMenuItem";
            this.生成binToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.生成binToolStripMenuItem.Text = "生成bin";
            this.生成binToolStripMenuItem.Click += new System.EventHandler(this.生成binToolStripMenuItem_Click);
            // 
            // bin另存为ToolStripMenuItem
            // 
            this.bin另存为ToolStripMenuItem.Image = global::CSharp_Hex2Bin.Properties.Resources.另存为;
            this.bin另存为ToolStripMenuItem.Name = "bin另存为ToolStripMenuItem";
            this.bin另存为ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.bin另存为ToolStripMenuItem.Text = "bin另存为";
            this.bin另存为ToolStripMenuItem.Click += new System.EventHandler(this.bin另存为ToolStripMenuItem_Click);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Image = global::CSharp_Hex2Bin.Properties.Resources.清除;
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // 打开记录ToolStripMenuItem
            // 
            this.打开记录ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6});
            this.打开记录ToolStripMenuItem.Image = global::CSharp_Hex2Bin.Properties.Resources.历史记录;
            this.打开记录ToolStripMenuItem.Name = "打开记录ToolStripMenuItem";
            this.打开记录ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.打开记录ToolStripMenuItem.Text = "打开记录";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem2.Text = " ";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem3.Text = " ";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem4.Text = " ";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem5.Text = " ";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem6.Text = " ";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuItem_Click);
            // 
            // 填充空段ToolStripMenuItem
            // 
            this.填充空段ToolStripMenuItem.Image = global::CSharp_Hex2Bin.Properties.Resources.填充;
            this.填充空段ToolStripMenuItem.Name = "填充空段ToolStripMenuItem";
            this.填充空段ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.填充空段ToolStripMenuItem.Text = "填充空段";
            this.填充空段ToolStripMenuItem.ToolTipText = "勾选后，未指定具体值的flash地址填充0x00";
            this.填充空段ToolStripMenuItem.Click += new System.EventHandler(this.填充空段ToolStripMenuItem_Click);
            // 
            // txbLog
            // 
            this.txbLog.ContextMenuStrip = this.cmbLogMenu;
            this.txbLog.Location = new System.Drawing.Point(1, 324);
            this.txbLog.Multiline = true;
            this.txbLog.Name = "txbLog";
            this.txbLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txbLog.Size = new System.Drawing.Size(800, 122);
            this.txbLog.TabIndex = 1;
            this.txbLog.WordWrap = false;
            // 
            // cmbLogMenu
            // 
            this.cmbLogMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.清空文本框ToolStripMenuItem});
            this.cmbLogMenu.Name = "cmbLogMenu";
            this.cmbLogMenu.Size = new System.Drawing.Size(134, 26);
            // 
            // 清空文本框ToolStripMenuItem
            // 
            this.清空文本框ToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.清空文本框ToolStripMenuItem.Font = new System.Drawing.Font("楷体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.清空文本框ToolStripMenuItem.Image = global::CSharp_Hex2Bin.Properties.Resources.清除;
            this.清空文本框ToolStripMenuItem.Name = "清空文本框ToolStripMenuItem";
            this.清空文本框ToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.清空文本框ToolStripMenuItem.Text = "清空文本框";
            this.清空文本框ToolStripMenuItem.Click += new System.EventHandler(this.清空文本框ToolStripMenuItem_Click);
            // 
            // openHex
            // 
            this.openHex.DefaultExt = "hex";
            this.openHex.Filter = "hex文件|*.hex";
            this.openHex.Multiselect = true;
            this.openHex.Title = "打开hex文件";
            // 
            // saveBin
            // 
            this.saveBin.DefaultExt = "bin";
            this.saveBin.Filter = "bin文件|*.bin";
            this.saveBin.Title = "另存为";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 450);
            this.Controls.Add(this.txbLog);
            this.Controls.Add(this.dataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Opacity = 0.9D;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.dataViewMenu.ResumeLayout(false);
            this.cmbLogMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TextBox txbLog;
        private System.Windows.Forms.ContextMenuStrip dataViewMenu;
        private System.Windows.Forms.ContextMenuStrip cmbLogMenu;
        private System.Windows.Forms.ToolStripMenuItem 清空文本框ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn FliePath;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartAddr;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndAddr;
        private System.Windows.Forms.ToolStripMenuItem 打开文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 生成binToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bin另存为ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开记录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem 填充空段ToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openHex;
        private System.Windows.Forms.SaveFileDialog saveBin;
    }
}

