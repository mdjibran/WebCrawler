using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
public partial class _Default : System.Web.UI.Page
{

    string strConnString = ConfigurationManager.ConnectionStrings["DBcon"].ConnectionString;
    string str;
    SqlCommand com;
    SqlDataAdapter sqlda;
    DataSet ds;
    string search;



    protected void Page_Load(object sender, EventArgs e)
    {
        Div1.Visible = false;
        Div2.Visible = false;
        if (!IsPostBack)
        {
            //binddatalist();
        }
    }
    private void binddatalist(string search)
    {
        SqlConnection con = new SqlConnection(strConnString);
        con.Open();
        str = "SELECT * FROM test where text like '%" + search + "%'";
        com = new SqlCommand(str, con);
        sqlda = new SqlDataAdapter(com);
        ds = new DataSet();
        sqlda.Fill(ds, "employee");
        PagedDataSource Pds1 = new PagedDataSource();
        Pds1.DataSource = ds.Tables[0].DefaultView;
        Pds1.AllowPaging = true;
        Pds1.PageSize = 10;
        Pds1.CurrentPageIndex = CurrentPage;
        lbl1.Text = "Showing Page: " + (CurrentPage + 1).ToString() + " of " + Pds1.PageCount.ToString();
        btnPrevious.Enabled = !Pds1.IsFirstPage;
        btnNext.Enabled = !Pds1.IsLastPage;
        dl1.DataSource = Pds1;
        dl1.DataBind();
        con.Close();
        //CurrentPage = Pds1.FirstIndexInPage;
    }
    public int CurrentPage
    {
        get
        {
            object s1 = this.ViewState["CurrentPage"];
            if (s1 == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(s1);
            }
        }

        set { this.ViewState["CurrentPage"] = value; }
    }

    protected void btnPrevious_Click(object sender, EventArgs e)
    {
        CurrentPage -= 1;
        binddatalist(search);

    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        CurrentPage += 1;
        binddatalist(search);

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text != "")
        {
            
            search = TextBox1.Text;
            string[] removeWords = { " the ", " an ", " a ", " and ", ",", ".", "?", " is ", " was "," admission "};
            foreach (string item in removeWords)
            {
                search = search.Replace(item, "");
            }
            
            Label1.Text = search;
            binddatalist(search);
            btnNext.Visible = true;
            btnPrevious.Visible = true;
            Div1.Visible = true;
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        saveFeedBack("Yes");
    }

    private void saveFeedBack(string feedBack)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DBcon"].ToString();
        SqlConnection objcon = new SqlConnection(connectionString);
        objcon.Open();

        try
        {
            string comm = "insert into feedBack_table(feedBack, query) values ('" + feedBack + "', '" + TextBox1.Text + "') ";
            SqlCommand command = new SqlCommand(comm, objcon);
            command.ExecuteNonQuery();

            objcon.Close();
            Div1.Visible = false;
            Div2.Visible = true;
        }
        catch
        {
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        saveFeedBack("No");
    }


    protected void Button4_Click(object sender, EventArgs e)
    {
        int rate =0;
        if (RadioButton1.Checked == true)
            rate = 1;
        else if (RadioButton2.Checked == true)
            rate = 2;
        else if (RadioButton3.Checked == true)
            rate = 3;
        else if (RadioButton4.Checked == true)
            rate = 4;
        else if (RadioButton5.Checked == true)
            rate = 5;
        else if (RadioButton6.Checked == true)
            rate = 6;
        else if (RadioButton7.Checked == true)
            rate = 7;
        else if (RadioButton8.Checked == true)
            rate = 8;
        else if (RadioButton9.Checked == true)
            rate = 9;
        else if (RadioButton10.Checked == true)
            rate = 10;
        else  
            rate = 0;


        if (rate != 0)
            saveRate(rate);

    }

    private void saveRate(int rate)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DBcon"].ToString();
        SqlConnection objcon = new SqlConnection(connectionString);
        objcon.Open();

       // try
      //  {
            string comm = "insert into cutomerRatings(value, query) values ('" + rate + "', '" + TextBox1.Text + "') ";
            SqlCommand command = new SqlCommand(comm, objcon);
            command.ExecuteNonQuery();

            objcon.Close();
            
       //     Div2.Visible = false;
       // }
       // catch
       // {
       // }
    }
}
    
