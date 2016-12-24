using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dumpfilekiller
{
    public partial class configForm : Form
    {
        public configForm()
        {
            InitializeComponent();
            this.textBox1.ReadOnly = this.checkBox1.Checked;


        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.textBox1.ReadOnly = this.checkBox1.Checked;
        }

        private string getFileType()
        {
            if (this.checkBox1.Checked)
            { 
                return "alltype";
            }else
            {
                return this.textBox1.Text.ToString().Trim();
            }
        }
        private string getDupFileStandr()
        {
            string dupfiles = "";
            if (this.FileNamecheckBox.Checked)
            {
                dupfiles += "fileName;";
            }
            if (this.fileSizecheckBox.Checked)
            {
                dupfiles += "fileSize;";
            }
            if (this.fileCreateTimecheckBox.Checked)
            {
                dupfiles += "CreateTime;";
            }

            if (this.fileModifiTimecheckBox.Checked)
            {
                dupfiles += "ModifiTime;";
            }
            return dupfiles;
        }

        private void configForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            deleteConfig deleteConfiginstance = deleteConfig.Instance();
            deleteConfiginstance.DupFileStandr = getDupFileStandr();
            deleteConfiginstance.FileTypes = getFileType();
        }
    }
}
