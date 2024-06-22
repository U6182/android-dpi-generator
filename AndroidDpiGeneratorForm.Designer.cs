namespace AndroidDPIGenerator
{
    partial class AndroidDpiGeneratorForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.GeneratorBtn = new System.Windows.Forms.Button();
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.dpiSelectCmbBox = new System.Windows.Forms.ComboBox();
            this.ImagePahtLable = new System.Windows.Forms.Label();
            this.dpiLable = new System.Windows.Forms.Label();
            this.FileOpenBtn = new System.Windows.Forms.Button();
            this.listView = new System.Windows.Forms.ListView();
            this.fileNameHandler = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sizeHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // GeneratorBtn
            // 
            this.GeneratorBtn.Location = new System.Drawing.Point(564, 152);
            this.GeneratorBtn.Name = "GeneratorBtn";
            this.GeneratorBtn.Size = new System.Drawing.Size(127, 108);
            this.GeneratorBtn.TabIndex = 0;
            this.GeneratorBtn.Text = "生成";
            this.GeneratorBtn.UseVisualStyleBackColor = true;
            this.GeneratorBtn.Click += new System.EventHandler(this.GeneratorBtn_Click);
            // 
            // pathTextBox
            // 
            this.pathTextBox.Location = new System.Drawing.Point(114, 24);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.ReadOnly = true;
            this.pathTextBox.Size = new System.Drawing.Size(352, 19);
            this.pathTextBox.TabIndex = 3;
            this.pathTextBox.TabStop = false;
            // 
            // dpiSelectCmbBox
            // 
            this.dpiSelectCmbBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dpiSelectCmbBox.FormattingEnabled = true;
            this.dpiSelectCmbBox.Items.AddRange(new object[] {
            "xxxhdpi",
            "xxhdpi",
            "xhdpi",
            "hdpi",
            "mdpi",
            "ldpi"});
            this.dpiSelectCmbBox.Location = new System.Drawing.Point(24, 24);
            this.dpiSelectCmbBox.Name = "dpiSelectCmbBox";
            this.dpiSelectCmbBox.Size = new System.Drawing.Size(84, 20);
            this.dpiSelectCmbBox.TabIndex = 2;
            // 
            // ImagePahtLable
            // 
            this.ImagePahtLable.AutoSize = true;
            this.ImagePahtLable.Location = new System.Drawing.Point(114, 9);
            this.ImagePahtLable.Name = "ImagePahtLable";
            this.ImagePahtLable.Size = new System.Drawing.Size(48, 12);
            this.ImagePahtLable.TabIndex = 4;
            this.ImagePahtLable.Text = "画像パス";
            // 
            // dpiLable
            // 
            this.dpiLable.AutoSize = true;
            this.dpiLable.Location = new System.Drawing.Point(22, 9);
            this.dpiLable.Name = "dpiLable";
            this.dpiLable.Size = new System.Drawing.Size(86, 12);
            this.dpiLable.TabIndex = 5;
            this.dpiLable.Text = "画像のdpi(基準)";
            // 
            // FileOpenBtn
            // 
            this.FileOpenBtn.Location = new System.Drawing.Point(472, 22);
            this.FileOpenBtn.Name = "FileOpenBtn";
            this.FileOpenBtn.Size = new System.Drawing.Size(75, 23);
            this.FileOpenBtn.TabIndex = 6;
            this.FileOpenBtn.Text = "ファイル";
            this.FileOpenBtn.UseVisualStyleBackColor = true;
            this.FileOpenBtn.Click += new System.EventHandler(this.FileOpenBtn_Click);
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.fileNameHandler,
            this.sizeHeader});
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(24, 51);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(523, 354);
            this.listView.TabIndex = 7;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // fileNameHandler
            // 
            this.fileNameHandler.Text = "ファイル名";
            this.fileNameHandler.Width = 260;
            // 
            // sizeHeader
            // 
            this.sizeHeader.Text = "サイズ";
            this.sizeHeader.Width = 120;
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // AndroidDpiGeneratorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 417);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.FileOpenBtn);
            this.Controls.Add(this.dpiLable);
            this.Controls.Add(this.ImagePahtLable);
            this.Controls.Add(this.dpiSelectCmbBox);
            this.Controls.Add(this.pathTextBox);
            this.Controls.Add(this.GeneratorBtn);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(719, 456);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(719, 456);
            this.Name = "AndroidDpiGeneratorForm";
            this.Text = "Android用DPI密度別リソース生成";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button GeneratorBtn;
        private System.Windows.Forms.TextBox pathTextBox;
        private System.Windows.Forms.ComboBox dpiSelectCmbBox;
        private System.Windows.Forms.Label ImagePahtLable;
        private System.Windows.Forms.Label dpiLable;
        private System.Windows.Forms.Button FileOpenBtn;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader fileNameHandler;
        private System.Windows.Forms.ColumnHeader sizeHeader;
        private System.Windows.Forms.ImageList imageList;
    }
}

