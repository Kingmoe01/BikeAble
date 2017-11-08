using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BikeAble.Admin
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Alert.Visible = false;
            if (Session["connected"] != null)
            {
                if (Session["connected"].ToString() == "yes")
                {
                    Response.Redirect("Dashboard.aspx");
                }
            }
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            string login = txtUser.Text;
            string pwd = TxtPWD.Text;
            string cnnStr = ConfigurationManager.ConnectionStrings["cnn1"].ConnectionString;

            if (login == "" || pwd == "")
            {
                Response.Redirect("AdminLogin.aspx");
            }
            else
            {
                UserFactory UF = new UserFactory(cnnStr);

                User u = UF.GetAdminByLogin(login);

                if (u != null)
                {
                    if (ConfirmPassword(TxtPWD.Text, u.Salt_User, u.Hash_User))
                    {
                        Session["connected"] = "yes";
                        Response.Redirect("Dashboard.aspx");
                    }
                    else
                    {
                        AlertText.InnerText = "Nom d'utilisateur ou mot de passe invalide";
                        Alert.Visible = true;
                    }
                }
                else
                {
                    AlertText.InnerText = "Nom d'utilisateur ou mot de passe invalide";
                    Alert.Visible = true;
                }
            }
        }

        protected static byte[] GenerateHash(byte[] value, byte[] salt)
        {
            byte[] saltedValue = value.Concat(salt).ToArray();
            return new SHA256Managed().ComputeHash(saltedValue);
        }

        protected bool ConfirmPassword(string password, byte[] salt, byte[] hash)
        {
            byte[] passwordHash = GenerateHash(Encoding.ASCII.GetBytes(password), salt);

            return hash.SequenceEqual(passwordHash);
        }



    }
}