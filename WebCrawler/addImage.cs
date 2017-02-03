using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WebCrawler
{
    public partial class addImage : Form
    {
        public addImage()
        {
            InitializeComponent();
        }
        public List<String> files = new List<String>();
        string extension = "";

        
        private void button1_Click(object sender, EventArgs e)
        {
            if (extension != "")
            {
                //advanced avd = new advanced();
                //avd.Show();
                listBox1.Items.Clear();
                strtWork();
                MessageBox.Show("Operation Completed!!!","File Detective");
            }
            else
                MessageBox.Show("Please select a format to serach for!!!", "File Detective");           
        }       

        private void DirSearch(string sDir)
        {
            try
            {
                foreach (string f in Directory.GetFiles(sDir, extension))
                {
                    files.Add(f);
                }
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    DirSearch(d);
                }
            }
            catch { }
        }

        

        private void clearAllSeetions()
        {
            jpg.Checked = false;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            radioButton7.Checked = false;
            radioButton8.Checked = false;
            radioButton9.Checked = false;            
            radioButton11.Checked = false;
            radioButton12.Checked = false;
            radioButton13.Checked = false;
            radioButton14.Checked = false;
            radioButton15.Checked = false;
            radioButton19.Checked = false;
            radioButton20.Checked = false;
            
        }        

        private void Form1_Load(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            groupBox6.Enabled = false;
            pictureBox1.Visible = false;
            richTextBox1.Visible = false;
        }

        private void strtWork()
        {
            //pictureBox1.Visible = true;
            string[] drives = Directory.GetLogicalDrives();
            string[] name = { "" };

            foreach (string str in drives)
            {
                try
                {
                    DirSearch(str);
                }
                catch { }
            }
            //pictureBox1.Visible = false;
            listBox1.Items.Clear();
            foreach (string item in files)
            {
                listBox1.Items.Add(item);
            }
           
        }
        
        
        
        
        

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            clearAllSeetions();
            groupBox1.Enabled = true;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            groupBox6.Enabled = false;
        }
        private void radioButton16_CheckedChanged(object sender, EventArgs e)
        {
            clearAllSeetions();
            groupBox1.Enabled = false;
            groupBox2.Enabled = true;
            groupBox3.Enabled = false;
            groupBox6.Enabled = false;
        }
        private void radioButton17_CheckedChanged(object sender, EventArgs e)
        {
            clearAllSeetions();
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            groupBox3.Enabled = true;
            groupBox6.Enabled = false;
        }
        private void jpg_CheckedChanged(object sender, EventArgs e)
        {
            extension = "*.jpg";
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            extension = "*.jpg";
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            extension = "*.txt";
        }
        private void radioButton18_CheckedChanged(object sender, EventArgs e)
        {
            clearAllSeetions();
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            groupBox6.Enabled = true;
        }
        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            extension = "*.jpeg";
        }
        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            extension = "*.png";
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            extension = "*.gif";
        }
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            extension = "*.bmp";
        }
        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            extension = "*.mp4";
        }
        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            extension = "*.flv";
        }
        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            extension = "*.3gp";
        }
        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            extension = "*.avi";
        }
        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            extension = "*.mov";
        }
        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {
            extension = "*.txt";
        }
        private void radioButton12_CheckedChanged(object sender, EventArgs e)
        {
            extension = "*.doc";
        }
        private void radioButton13_CheckedChanged(object sender, EventArgs e)
        {
            extension = "*.xls";
        }
        private void radioButton14_CheckedChanged(object sender, EventArgs e)
        {
            extension = "*.pdf";
        }
        private void radioButton15_CheckedChanged(object sender, EventArgs e)
        {
            extension = "*.ppt";
        }

      

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            string text = listBox1.GetItemText(listBox1.SelectedItem);
            if(radioButton10.Checked == true)
            {
                pictureBox1.Visible = true;
                richTextBox1.Visible = false;
                pictureBox1.ImageLocation = text;
            }
            else if (radioButton16.Checked == true)
            {
                //code for video
            }
            else if (radioButton18.Checked == true)
            {
                //code for audio
            }
            else if (radioButton17.Checked == true)
            {
                try
                {
                    richTextBox1.Visible = true;
                    pictureBox1.Visible = false;
                    //StreamReader sr = new StreamReader(text);
                    //sr.ReadToEnd();
                    string receivedText = File.ReadAllText(text);
                    richTextBox1.Text = receivedText;
                }
                catch { }
            }

        }
        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            string text = listBox1.GetItemText(listBox1.SelectedItem);
            if (radioButton10.Checked == true)
            {
                pictureBox1.Visible = true;
                richTextBox1.Visible = false;
                pictureBox1.ImageLocation = text;
            }
            else if (radioButton16.Checked == true)
            {
                //code for video
            }
            else if (radioButton18.Checked == true)
            {
                //code for audio
            }
            else if (radioButton17.Checked == true)
            {
                try
                {
                    richTextBox1.Visible = true;
                    pictureBox1.Visible = false;
                    //StreamReader sr = new StreamReader(text);
                    //sr.ReadToEnd();
                    string receivedText = File.ReadAllText(text);
                    richTextBox1.Text = receivedText;
                }
                catch { }
            }
        }
        
        private void radioButton20_CheckedChanged(object sender, EventArgs e)
        {
            extension = "*.mp3";
        }
        private void radioButton19_CheckedChanged(object sender, EventArgs e)
        {
            extension = "*.wav";
        }       


        public void getFromAdvanceForm(string selection)
        {
            extension = selection;
            //DirSearch(extension);
            strtWork();

        }

        private void advancedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //advanced obj = new advanced();
            //obj.Show();
        }
    }
}
