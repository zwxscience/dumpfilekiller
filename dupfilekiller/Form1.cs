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
using System.Collections;

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
        Dictionary<string, string> fileInfo;//key,src
        long savebit;
        int dupfiles;
        private void button1_Click(object sender, EventArgs e)
        {
            //选择文件夹
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = "E:\\Music";
            this.textBox1.Text = "";
            fbd.Description = "请选择待检查文件夹";
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                //this.textbox1.Text = ;
                DirectoryInfo theFolder = new DirectoryInfo(@"" + fbd.SelectedPath);
                fileIndex = 0;
                savebit = 0;
                dupfiles = 0;
                //dumpfilefolderName = ;
                dumpfilefolderName = fbd.SelectedPath + "\\dupfileToDelete";
                fileInfo = new Dictionary<string, string>();
                dealfile(theFolder);
                fileInfo.Clear();
                string finalOutput = "共搜索文件 " + fileIndex + " 个,重复文件" + dupfiles + "个,节省空间共约 " + savebit / (1024 * 1024) + "M.";
                this.textBox1.Text = finalOutput + "\r\n" + this.textBox1.Text;
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
                string fileKey = NextFile.Name + "_" + NextFile.Length;//via fileName and size to identidy file
                if (!fileInfo.Keys.Contains(fileKey))
                {
                    fileInfo.Add(fileKey, NextFile.FullName);
                }
                else
                {
                    string text = "文件序号" + fileIndex + ":" + NextFile.Name + ",大小:" + NextFile.Length + "字节。";
                    this.textBox1.Text += text + "是重复文件。\r\n";
                    if (Directory.Exists(dumpfilefolderName) == false)//如果不存在就创建文件夹
                    {
                        Directory.CreateDirectory(dumpfilefolderName);
                    }
                    //将重复文件剪切到指定文件夹
                    try
                    {
                        WriteFile(dumpfilefolderName + @"\movelog.txt", text + "保留原始文件" + fileInfo[fileKey] + ",来自" + NextFile.FullName + "被移出。");
                        string fileNewName = NextFile.Name.Substring(0, NextFile.Name.IndexOf(".")) + NextFile.Length + NextFile.Name.Substring(NextFile.Name.IndexOf("."), NextFile.Name.Length - NextFile.Name.IndexOf("."));
                        NextFile.MoveTo(dumpfilefolderName + @"\" + fileNewName);
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
        public void WriteFile(string filePath, string text)
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

        Dictionary<string, long> fileSrcList;//key,src fileSrcList;
        void ReadLog(string path)
        {
            fileSrcList = new Dictionary<string, long>();
            try
            {
                FileStream aFile = new FileStream(path, FileMode.Open);
                StreamReader sr = new StreamReader(aFile, Encoding.GetEncoding("GB2312"));
                string strLine = sr.ReadLine();

                while (strLine != null)
                {
                    try {

                    string fileFullName = strLine.Substring(strLine.IndexOf(",来自") + 3, strLine.IndexOf("被移出。") - strLine.IndexOf(",来自") - 3);
                    long fileSize = long.Parse(strLine.Substring(strLine.IndexOf("大小:") + 3, strLine.IndexOf("字节。") - strLine.IndexOf("大小:") - 3));
                    fileSrcList.Add(fileFullName, fileSize);
                    }
                    catch { }
                    strLine = sr.ReadLine();
                }
                sr.Close();
            }
            catch (IOException ex)
            {
                Console.WriteLine("An IOException has been thrown!");
                return;
            }


        }

        ArrayList fileToDel;
        private void button2_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(dumpfilefolderName) == false )//如果不存在就选择
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.SelectedPath = "E:\\Music";
                fbd.Description = "请选择待恢复文件夹";
                this.textBox1.Text = "";
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    dumpfilefolderName = fbd.SelectedPath + "\\dupfileToDelete";
                }
            }
            if (Directory.Exists(dumpfilefolderName) == false || !File.Exists(dumpfilefolderName + "\\movelog.txt"))
            {
                dumpfilefolderName = "";
                MessageBox.Show("文件夹待恢复数据不存在或已删除。");
                return;
            }
                ReadLog(dumpfilefolderName + "\\movelog.txt");
                if (fileSrcList.Count != 0)
                {
                    int Rcount = 0;
                    fileToDel = new ArrayList();
                    foreach (KeyValuePair<string, long> fileP in fileSrcList)
                    {
                        try
                        {
                            string filePath = fileP.Key;
                            string fileName = filePath.Substring(filePath.LastIndexOf("\\")+1, filePath.Length - filePath.LastIndexOf("\\")-1);
                            string fileNameInFolder = fileName.Substring(0, fileName.IndexOf(".")) + fileP.Value + fileName.Substring(fileName.IndexOf("."), fileName.Length - fileName.IndexOf("."));
                            File.Copy(dumpfilefolderName + "\\"+fileNameInFolder, filePath);
                            fileToDel.Add(dumpfilefolderName + "\\" + fileNameInFolder);
                            Rcount++;
                        }
                        catch
                        {

                        }
                    }
                    MessageBox.Show("成功恢复文件 "+Rcount+" 个，失败 "+(fileSrcList.Count-Rcount) +"个。");
                    //删除恢复成功的备份文件
                    foreach (string file in fileToDel)
                    {
                        try
                        {
                            File.Delete(file);
                        }
                        catch { }
                    }
                //清空log文件
                try
                {
                    File.Delete(dumpfilefolderName + "\\movelog.txt");
                }catch { }
                
                
                if (fileToDel!=null)
                    fileToDel.Clear();

                }
                else
                {
                MessageBox.Show("未找到需要恢复的文件。");
            }
        
        if(fileSrcList!=null)
        fileSrcList.Clear(); 

        }
}
}
