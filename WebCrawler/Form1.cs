using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading;

namespace WebCrawler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();          
        }

        string  mainLink;   //this variable stores the main domain or the URL of the web site entered in the textbox
        string titleLabel = "";     // stores the title of the web site to display next to textbox
               
        
        //this function is fired when the users hits the go button
        private void Go_Button_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show("Start Searching!!!", "Spider Search" , MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listBox1.Items.Clear();         // clears the content of listbox, third list on form
            globalLinksList.Items.Clear();  // clears the content of globallist, second list on form
            new_linksOnPage.Items.Clear();  // clears the content of unique, first list on form
            button1Task();                  // calls the function which performs button click tasks like getting the page and finding more links on the homepage of web site
            _title.Text = titleLabel;       // clears the title label to show the website title                        
        }


        // this function is called on GO button click
        private void button1Task()
        {
            if (textBox1.Text != "" && textBox1.Text != null)   // here we are checking if the user has entered a text in textbox or not, it cannot be left empty or if only spaces are given in it
            {
                mainLink = textBox1.Text.Trim();                // assign the URL entered by user to mainLink variable so that we can use it for further works
                if (!mainLink.EndsWith("/"))                    // if the entered by user does not ends with "/" then attach it to mainLink URL
                    mainLink = mainLink + "/";

                string sourceCode = Crawler.getSourceCode(mainLink);    // here we are calling a function stored in CRAWLER class called "getSourceCode();", this function will download source code of webpage and assign all the text tp variable "sourceCode"
                
                if (sourceCode != "skipped")    // if the value in the variable is not equal to skipped ie if had realy crawled a page and we have source of it
                    MakeLink(sourceCode);       // we will pass the downloaded source code to MakeLink() function as parameter.
                else
                    MessageBox.Show("Please enter a proper URL to Crawl", "Spider Search");     //if the value in sourceCode variable is SKIPPED then we will show a message box saying that the link cannot be crawled
            }
            else
            {
                MessageBox.Show("Plesse enter a URL to start crawling.", "Spider Search");      // if the text box is empty ie if user didnt ented any URl and pressed GO button then we are showing this message box
            }
        }

        private void getLinksOtherpage(string sourceCode)
        {
            string url = textBox1.Text;
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(sourceCode);                      
            int totalLinks = listBox1.Items.Count;
            string[] linksArray = new string[totalLinks];
            listBox1.Items.CopyTo(linksArray, 0);
            foreach (string link in listBox1.Items)
            {
                if (!globalLinksList.Items.Contains(link))
                    globalLinksList.Items.Add(link);
            }
        }


        // This function is fired when the user has received some links in the globallinklist 
        private void Crawling_Button_Click(object sender, EventArgs e)
        {
            button2Task();
        }

        // This function is called by the Start calling button click 
        private void button2Task()
        {
            if (listBox1.Items.Count > 0)    // check if we have links in the list or not
            {
                //File.WriteAllText(@"E:\test.txt", String.Empty);
                // uniqueLink();
               
                listBox1.Items.Clear();                             // clear all contents of 3rd list so that new links can be added
                foreach (string link in globalLinksList.Items)      // for crawling all unique links in globallist
                {
                    listBox1.Items.Add(link);                       // add all links to 3rd list so that we can crawl them
                }
                listBox1.Refresh();                       // refersh the contents in the list 
                new_linksOnPage.Items.Clear();            // clear the contents of second list
                foreach (string url in listBox1.Items)    // select single link from 3rd list so that it can be crawl
                {
                    string sourceCode = Crawler.getSourceCode(url); // send the url to getsourcecode() function to get the source code
                    MakeLink2(sourceCode);                          // send received source code to makelink() function so that we can format it
                    
                }
            }
            else
                MessageBox.Show("Please enter URL to crawl and hit GO ", "Spider Search");
        }


        // the objective of this function is to determine that we have only unique links in the globallinklist
        // this function is called in makeLink() function
        private void uniqueLink()
        {
            foreach (string link in listBox1.Items)                 //get al links in the listBox1 list
            {
                    if (link.StartsWith(mainLink))                  // check if the link we selected starts with the same main domain as that of the domain entered by the user, this will remove references to any external webiste so that we stay on only the site that we want to crawl only
                    {
                        if (!globalLinksList.Items.Contains(link))  // check if we have already added the link in the listbox1 
                            globalLinksList.Items.Add(link);        // if selected link is not found in the globallinklist then add it to list
                    }                
            }                                       
                _totLinks.Text = globalLinksList.Items.Count.ToString();    // count total links prsent in global linklist and display it in totalinks label
        }


        // the objective of this function is to determine that we have only unique links in the globallinklist
        // this function is called in makeLink2() function
        private void uniqueLink2()
        {
            foreach (string link in new_linksOnPage.Items)
            {               
                    if (link.StartsWith(mainLink))
                    {
                        if (!globalLinksList.Items.Contains(link))
                            globalLinksList.Items.Add(link);
                    }
            }
            _totLinks.Text =  globalLinksList.Items.Count.ToString();
        }
      

        // the objective of this function is to get the source code of the page and collect all links on a page and title of the website
        // the parameter txt is the source code of the webpage
        protected void MakeLink(string txt)
        {           
           HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();   // here we are creating an object of HTMLAgilityPack to work with the html text that we downloaded using this we are collting more URL's and playing with HTML tags.
           doc.LoadHtml(txt);                                                       // load the HTML text downloaded from web to work with it.
           string allLinks;                                                         // this variable will hold all the links found on page.
           string title = doc.DocumentNode.SelectSingleNode("//title").InnerText;   // search for title tag in HTML to get the title of the website.
           title = Regex.Replace(title, @"\r\n?|\n", "");                           // replace all line breaks in the text.
           title = Regex.Replace(title, @"\t", "");                                 // replace all tabs in the text.
           title.Trim();                                                            // to remove any space from title 
           titleLabel = title;                                                      // show the website title in the label on form
           
           foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]"))    // using this we are going to collect all the a href tags on the page ie links on page
           {
              HtmlAttribute att = link.Attributes["href"];
              allLinks = att.Value;             
              listBox1.Items.Add(formatLink(allLinks,mainLink));                    // send the collected link to formatlink() function to format it like a proper link and once the returns a properly formatted link then show that in LIstBox 1.
           }
           uniqueLink();           
        }

        // the objective of this function is to get the source code of the page and collect all links on a page and title of the website
        // the parameter txt is the source code of the webpage
        protected void MakeLink2(string txt)
        {            
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();      // get the HTML documner to read
            doc.LoadHtml(txt);
            string allLinks;                        
            try
            {
                foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]"))   // collect all links on page
                {                 
                        HtmlAttribute att = link.Attributes["href"];
                        allLinks = att.Value;
                        new_linksOnPage.Items.Add(formatLink(allLinks, mainLink));   
                }                
            }
            catch { }
            finally { uniqueLink2(); }          // check for uniquelinks in the collection
        }


        // objective of this function is to format the link coming from makelink() function
        // using the replace fumction we are going to remove all unwated characters from our link and and some charatres if necessary
        private string formatLink(string allLinks, string url)
        {
            allLinks.Trim();
            if (allLinks.StartsWith("/"))
                return (url + allLinks);

            if (allLinks.StartsWith("../"))
            {
                allLinks.Replace("../", "/");
                return (url + allLinks);
            }
            
            if (allLinks.StartsWith("~/"))            
                return (url + allLinks);
            
            if (allLinks.StartsWith("www."))            
                return ("http://" + allLinks); 
                                   
            if(allLinks.StartsWith("#"))
                return url;

            if(allLinks.StartsWith("http://"))
                return allLinks;
            else
            {
                allLinks.Replace("////", "//");
                return (url + allLinks);                
            }
        }


        // this function is fired when user selects links in the uniquelink list and hit this button to delete them from the list
        private void Delete_Button_Click(object sender, EventArgs e)
        {
            button3Task();          // this function is called to delete the links from list
            _totLinks.Text = globalLinksList.Items.Count.ToString();    // this will get the current total number of links in globallink list and assign it to unique link label
        }

        // this function will delete the selected links in the globalinklist 
       private void button3Task()
       {
           for (int i = 0; i < globalLinksList.SelectedItems.Count; i++)                    // get total numbers of selected links and loop that number of times 
           {
               globalLinksList.Items.Remove(globalLinksList.SelectedItems[i].ToString());   // remove() function will remove the links from the list
               i--;
           }     
       }
     


       private void saveLinks(string title, string text, string link)
       {
           string final;           
           string result = Regex.Replace(text, @"\r\n?|\n", "");
           Regex r = new Regex(@"\s+");
           final = r.Replace(result, @" ");
           final = final.Replace("&nbsp;", "");
           final.TrimStart();
           Regex rgx = new Regex("[^a-zA-Z0-9 -]");
           final = rgx.Replace(final, "");
           insertInDb(title, final, link);           
       }


        // objective of this function is to extarct text out of the web documnt
        // this function is fired when user has crawlled all the site and collected all links on the site
       private void Save_Button_Click(object sender, EventArgs e)
       {
           //if (!(File.Exists(@"D:\list.txt")))
           //    File.Create(@"D:\list.txt");
           //    //File.WriteAllText(@"D:\list.txt", "\n"+textBox1.Text);
           //    File.AppendAllText("D:\\list.txt", Environment.NewLine + textBox1.Text);
           int serial = 1;
           new_linksOnPage.Items.Clear();
           groupBox2.Text = "Alive Links";
           foreach (string link in globalLinksList.Items)
           {
               try
               {
                   WebClient client = new WebClient();
                   string downloadString = client.DownloadString(link);

                   HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
                   HtmlAgilityPack.HtmlDocument doc = web.Load(link);
                   var result = doc.DocumentNode.SelectNodes("//body//text()");//return HtmlCollectionNode
                   string AchivedText = "", text = "";
                   
                   string title = doc.DocumentNode.SelectSingleNode("//title").InnerText;
                   title = Regex.Replace(title, @"\r\n?|\n", "");
                   title = Regex.Replace(title, @"\t", "");
                   title.Trim();   

                   foreach (var node in result)
                   {
                       AchivedText = node.InnerText;    // Your desire text
                       text += AchivedText;             // text is the totat text on the page extrated
                   }
                   saveLinks(title, text, link);        // savelinks() function is called to save all links in DB
                   
                   new_linksOnPage.Items.Add(serial + " - " + link);
                   serial++;                   
               }
               catch { }               
           }
           MessageBox.Show("WebSite has been sucessfully added.", "Spider Search");
       }

       private void insertInDb(string title, string text, string url)
       {
           string connectionString = ConfigurationManager.ConnectionStrings["DBcon"].ToString();
           SqlConnection objcon = new SqlConnection(connectionString);
           objcon.Open();
           if (!exists(url))
           {
               try
               {
                   string comm = "insert into test (title, text, url) values ('" + title + "', '" + text + "','" + url + "') ";
                   SqlCommand command = new SqlCommand(comm, objcon);
                   command.ExecuteNonQuery();

                   objcon.Close();

               }
               catch
               {
                   MessageBox.Show("some Unkown error occured!!!.", "Student Database");
                   int S1Length = text.Length;
                   int half = S1Length / 2;
                   string S2 = text.Substring(0, half);
                   string S3 = text.Substring(half, half);

                   string comm = "insert into test (title, text, url) values ('" + title + "', '" + S2 + "','" + url + "') ";
                   SqlCommand command = new SqlCommand(comm, objcon);
                   command.ExecuteNonQuery();
                   objcon.Close();


                   string comm2 = "insert into test (title, text, url) values ('" + title + "', '" + S3 + "','" + url + "') ";
                   SqlCommand command2 = new SqlCommand(comm2, objcon);
                   command2.ExecuteNonQuery();
                   objcon.Close();
               }
           }
           else
           {
               try
               {
                   string comm = "update test set text = '" + text + "',where url='" + url + "'";
                   SqlCommand command = new SqlCommand(comm, objcon);
                   command.ExecuteNonQuery();

                   objcon.Close();
               }
               catch { }
           }
       }

       private void splitString(string text)
       {
           int S1Length = text.Length;
            int half = S1Length / 2;
            string S2 = text.Substring(0, half);
            string S3 = text.Substring(half, half);
       }

       private Boolean exists(string url)
       {
           string connectionString = ConfigurationManager.ConnectionStrings["DBcon"].ToString();
           SqlConnection conn = new SqlConnection(connectionString);

           SqlCommand cmd = new SqlCommand("Select Count(*)  from test where  url ='" + url +"'", conn);
           
           SqlDataReader sReader = null;
           Int32 numberOfRows = 0;

           try
           {
               conn.Open();
               sReader = cmd.ExecuteReader();
               while (sReader.Read())
               {
                   if (!(sReader.IsDBNull(0)))
                   {
                       numberOfRows = Convert.ToInt32(sReader[0]);
                       if (numberOfRows > 0)
                       {
                           return true;
                       }
                   }
               }

           }
           catch
           {
           }
           finally
           {
               conn.Close();
           }
           return false;
       }

      
       private void openToolStripMenuItem1_Click(object sender, EventArgs e)
       {
           OpenFileDialog ofd = new OpenFileDialog();
           string[] fileLinks ={};
           if(ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
           {
               fileLinks = File.ReadAllLines(@"D:\list.txt");

               StreamReader sr = new StreamReader(@"D:\list.txt");
               string text = sr.ReadToEnd();
               fileLinks =  text.Split(',');
           }

           foreach (var item in fileLinks)
           {

               globalLinksList.Items.Add(item);
               listBox1.Items.Add(item);
           }
       }
    }
}
