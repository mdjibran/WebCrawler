using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace WebCrawler
{
    class Crawler
    {
        // objective of this function is to go to the link and get the source code and return it in the form of a string
        // this function is called in the button1 task, one parameter URL has to be given for this function to work
        public static string getSourceCode(string url)
        {
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);    // req is the object of buid in HttpWebRequest class to request a URL to be visietd we pass the desired url in the Create() function
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();      // resp is the object of build in HttpWebResponse to receive the response from the web server
                StreamReader sr = new StreamReader(resp.GetResponseStream());   // to read the response from server we need to create a object of StreamReader class
                string sourceCode = sr.ReadToEnd();                             // read all the source code of page and assign it to sourceCode variable
                sr.Close();             // close the stream reader object so that we can release the resources uesd by it.
                resp.Close();           // close the HttpWebRequest object so that we can release the resources uesd by it.
                return sourceCode;      // return the downloded source code to the calling function.
            }
            catch                       // if no sourceCode found that is if the execution faced any problem then we are retun the text as "skipped", this will help us to diffrentiatie the pages that are crawled and which are not
            {
                return "skipped";
            }
        }
    }
}
