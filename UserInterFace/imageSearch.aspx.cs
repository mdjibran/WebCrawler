using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Google.API.Search;
using System.Data;
using System.IO;


public partial class imageSearch : System.Web.UI.Page
{
    string[] list;
    public List<String> files = new List<String>();
    string extension = "";
    IList<IImageResult> results;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dlSearch.DataSource = null;
            dlSearch.DataBind();
            TextBox1.Text = "";
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("Title", typeof(string)));
        dt.Columns.Add(new DataColumn("OriginalContextUrl", typeof(string)));
        dt.Columns.Add(new DataColumn("Url", typeof(string)));
        GimageSearchClient client = new GimageSearchClient("www.c-sharpcorner.com");
        IList<IImageResult> results = client.Search(TextBox1.Text, 30);
        foreach (IImageResult result in results)
        {
            DataRow dr = dt.NewRow();
            dr["Title"] = result.Title.ToString();
            dr["OriginalContextUrl"] = result.OriginalContextUrl;
            dr["Url"] = result.Url;
            dt.Rows.Add(dr);
        }
        dlSearch.DataSource = dt;
        dlSearch.DataBind();
    }
}