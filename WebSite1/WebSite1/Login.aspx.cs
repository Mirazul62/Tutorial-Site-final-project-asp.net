﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
      

        HttpCookie cookie = new HttpCookie("userInfo");
        cookie["Name"] = TextBoxUsername.Text;
        cookie.Expires = DateTime.Now.AddMinutes(2);
        Response.Cookies.Add(cookie);

        Session["Name"] = TextBoxUsername.Text;



        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegConnectionString"].ConnectionString);
        conn.Open();
        string checkuser = "select count(*) from [Table] where UserName='" + TextBoxUsername.Text + "'";
        SqlCommand com = new SqlCommand(checkuser, conn);
        int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
        conn.Close();
        
        if (temp == 1)
        { 
            conn.Open();
            string checkPasswordQuery = "select password from [Table] where UserName='" + TextBoxUsername.Text + "'";
            SqlCommand passComm = new SqlCommand(checkPasswordQuery, conn);
            string password = passComm.ExecuteScalar().ToString().Replace(" ","");
            if(password == TextBoxPassword.Text)
            {
                Session["New"] = TextBoxUsername.Text;
                Response.Write("Password is Correct !!");
                Response.Redirect("webpage.htm");
            }
            else
            {
                label1.Text = "Please check your username & password";
                /// Response.Write("Password is inCorrect !!");
            }
        }
        else
        {
           // Response.Write("UserName is inCorrect !!");
          // label1.Text ="Please check your username & password";

        }
    }

    protected void TextBoxUsername_TextChanged(object sender, EventArgs e)
    {

    }
}