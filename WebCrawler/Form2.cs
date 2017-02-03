using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;



namespace WebCrawler
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = @"C:\Users\jibran\Desktop\searching.gif";
            
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    string connectionString = ConfigurationManager.ConnectionStrings["DBcon"].ToString();
        //            SqlConnection objcon = new SqlConnection(connectionString);
        //            try
        //            {
        //                objcon.Open();
                        
        //                string comm = "insert into test (title, text, url) values ('" + _txtTitle.Text + "','"+_txtText.Text+"', '"+ _txtURL.Text+"') ";
        //                SqlCommand command = new SqlCommand(comm, objcon);
        //                command.ExecuteNonQuery();

        //                objcon.Close();
        //                MessageBox.Show("Success");
        //            }
        //            catch
        //            {
        //                MessageBox.Show("Failed!!!");
        //            }
        //}
    }
}
