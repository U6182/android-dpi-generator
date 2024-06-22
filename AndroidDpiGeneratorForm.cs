using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AndroidDPIGenerator
{
    public partial class AndroidDpiGeneratorForm : Form
    {

        //DPIの種類
        private string[] dpiNames = { "xxxhdpi", "xxhdpi", "xhdpi", "hdpi", "mdpi", "ldpi" };

        //選択したパスリスト
        private List<string> selectPathList = new List<string>();
        //変更されたファイル名
        private string convertPath = "";


        private enum DpiIndex
        {
            xxxhdpi,
            xxhdpi,
            xhdpi,
            hdpi,
            mdpi,
            ldpi,
        }

        public AndroidDpiGeneratorForm()
        {
            InitializeComponent();
            
        }

        /**
        <summary>ファイルを開くボタンの処理</summary>
        <remarks>sender オブジェクト</remarks>
        <remarks>e ボタンクリックのイベントの種類</remarks>
        */
        private void FileOpenBtn_Click(object sender, EventArgs e)
        {
            //System.Console.WriteLine(this.dpiSelectCmbBox.SelectedIndex);
            using (var fileDialog = new OpenFileDialog()
            {
                InitialDirectory = @"D:"
                ,
                Filter = "画像ファイル|*.png;*.jpg"
                ,
                Multiselect = true
                ,
                Title = "ファイルの選択"

            })
            {
                //ファイルが選択された場合
                if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //初期化
                    this.pathTextBox.Text = "";
                    this.convertPath = "";
                    this.listView.Items.Clear();
                    this.selectPathList.Clear();
                    //変換情報の設定
                    foreach(string path in fileDialog.FileNames)
                    {
                        //選択したファイルパスをテキストボックスに表示する
                        this.pathTextBox.Text += path + ", ";
                        //ListViewの設定
                        setListView(path);
                        this.selectPathList.Add(path);
                    }

                }

            }
        }

        /**
        <summary>ListViewの設定を行う</summary>
        <remarks>path 変換する画像パス</remarks>
        */
        private void setListView(string path)
        {

            //imageListの設定
            if (this.listView.SmallImageList == null)
            {
                ImageList imageList = new ImageList();
                imageList.ImageSize = new Size(64, 64);
                this.listView.SmallImageList = imageList;
                
            }

            //ListViewの変換情報の取得
            Bitmap bitmap = new Bitmap(path);
            string size = bitmap.Width.ToString() + "×" + bitmap.Height.ToString();
            string[] data = { path, size };


            //ListViewのアイコン取得
            imageList.Images.Add(Image.FromFile(path));
            int imageIndex = this.listView.SmallImageList.Images.Count;
            this.listView.SmallImageList.Images.Add(bitmap);

            //ListViewの変換情報の設定
            ListViewItem item = new ListViewItem(data, imageIndex);
            this.listView.Items.Add(item);

            
        }

        private void GeneratorBtn_Click(object sender, EventArgs e)
        {
            //画像が選択されていない場合
            if(this.selectPathList.Count == 0)
            {
                MessageBox.Show("画像が選択されていません", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //出力先のDPI種類別フォルダの作成
            CreateDpiDirectory();
            //DPI種類別画像出力
            foreach(string path in this.selectPathList)
            {
                if (!File.Exists(path))
                {
                    MessageBox.Show(path + "\nは存在しません。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    continue;
                }

                if (!CreateDpiImage(path))
                {
                    return;
                }
            }

            FlexibleMessageBox.Show(this.convertPath, "変更されたファイル名", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            MessageBox.Show("DPI種類別に画像の作成完了しました", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private bool CreateDpiImage(string path)
        {
            int dpiSelectNo = this.dpiSelectCmbBox.SelectedIndex;
            if(dpiSelectNo == -1)
            {
                MessageBox.Show("指定した画像のDPIの基準を選択してください", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //DPI種類別に計算と出力を行う
            OutDpiImage(dpiSelectNo, path);
            return true;

        }

        private void OutDpiImage(int dpiNo, string path)
        {
            //DPI種別ごとの倍率
            double[,] dpiRate = new double[,] { { 1.0, 0.75, 0.5, 0.375, 0.25, 0.1875 }, { 1.33, 1.0, 0.67, 0.5, 0.33, 0.25 }, { 2.0, 1.5, 1.0, 0.75, 0.5, 0.375 }, { 2.67, 2.0, 1.33, 1.0, 0.67, 0.5 }, { 4.0, 3.0, 2.0, 1.5, 1.0, 0.75 }, {5.33, 4.0, 2.67, 2.0, 1.33, 1.0} };

            Bitmap bitmap = new Bitmap(path);
            for(int i = 0;i < dpiRate.GetLength(1); i++)
            {
                //各DPI倍率ごとにリサイズ
                double widthResult = bitmap.Width * dpiRate[dpiNo, i];
                int width = (int)Math.Round(widthResult);

                double heightResult = bitmap.Height * dpiRate[dpiNo, i];
                int height = (int)Math.Round(heightResult);

                //指定のDPIを基準に計算された各画像がDPI種別ごとに格納
                string outFileName = Util.ConvertStr(Path.GetFileNameWithoutExtension(path));
                if(outFileName != Path.GetFileNameWithoutExtension(path))
                {
                    //ファイル名が変更された場合
                    this.convertPath += Path.GetFileNameWithoutExtension(path) + "→" + outFileName + "\n";
                }
                outFileName += Path.GetExtension(path);
                string outBitmapPaht = Directory.GetCurrentDirectory() + "\\drawable-" + this.dpiNames[i] + "\\" + outFileName;
                Bitmap outBitmap = new Bitmap(bitmap, width, height);
                string extension = Path.GetExtension(path);
                ImageFormat format = null;
                switch (extension)
                {
                    case ".png":
                        format = ImageFormat.Png;
                        break;

                    case ".jpg":
                        format = ImageFormat.Jpeg;
                        break;
                }
                outBitmap.Save(outBitmapPaht, format);
            }
            


        }
        private void CreateDpiDirectory()
        {
            //フォルダ作成
            foreach(string dpiName in this.dpiNames)
            {
                MyFile.safeCreateDirectory(Directory.GetCurrentDirectory() + "\\drawable-" + dpiName);
            }
            
        }
    }
}
