using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
namespace dumpfilekiller
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int fileIndex;
        string dumpfilefolderName;
        Dictionary<string, long> fileInfo;
        long savebit;
        int dupfiles;
        private void button1_Click(object sender, EventArgs e)
        {
            //选择文件夹
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = "E:\\Music";
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                //this.textbox1.Text = ;
                DirectoryInfo theFolder = new DirectoryInfo(@"" + fbd.SelectedPath);
                fileIndex = 0;
                savebit = 0;
                dupfiles = 0;
                //dumpfilefolderName = ;
                dumpfilefolderName = fbd.SelectedPath + "\\dupfileToDelete";
                fileInfo = new Dictionary<string, long>();
                dealfile(theFolder);
                fileInfo.Clear();
                string finalOutput = "共搜索文件 " + fileIndex + " 个,重复文件" + dupfiles + "个,节省空间共约 " + savebit / (1024 * 1024) + "M.";
                this.textBox1.Text = finalOutput + "\r\n"+ this.textBox1.Text;
                MessageBox.Show(finalOutput);
            }
            savebit = 0;
            fileIndex = 0;
            dupfiles = 0;

        }
        private void dealfile(DirectoryInfo theFolder)
        {

            DirectoryInfo[] dirInfo = theFolder.GetDirectories();
            foreach (FileInfo NextFile in theFolder.GetFiles())  //遍历文件
            {
                fileIndex++;
                this.label1.Text = "正在处理第 " + fileIndex + " 个文件";
                System.Windows.Forms.Application.DoEvents();
                if (!fileInfo.Keys.Contains(NextFile.Name))
                {
                    fileInfo.Add(NextFile.Name, NextFile.Length);
                }
                else
                {
                    string text = "文件" + fileIndex + ":" + NextFile.Name + ",:大小" + NextFile.Length + "字节";
                    this.textBox1.Text += text+"重复文件\r\n";
                    if (Directory.Exists(dumpfilefolderName) == false)//如果不存在就创建file文件夹
                    {
                        Directory.CreateDirectory(dumpfilefolderName);
                    }
                    //将重复文件剪切到指定文件夹
                    try
                    {
                        WriteFile(dumpfilefolderName + @"\movelog.txt", text + "来自" + NextFile.FullName);
                        NextFile.MoveTo(dumpfilefolderName + @"\" + NextFile.Name);
                        dupfiles++;
                        savebit += NextFile.Length;
                    }
                    catch { }
                }

                // this.listBox2.Items.Add();
            }
            //递归遍历文件夹

            foreach (DirectoryInfo NextFolder in dirInfo)
            {
                dealfile(NextFolder);
            }

        }
        public void WriteFile(string filePath,string text)
        {
            FileStream fs = new FileStream(filePath, FileMode.Append);
            StreamWriter sw = new StreamWriter(fs, Encoding.Default);
            sw.WriteLine(text);
            sw.Close();
            fs.Close();
            Thread.Sleep(20);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
