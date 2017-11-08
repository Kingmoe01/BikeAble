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

namespace BikeAble.GlobalPages
{
    public partial class SignUp : System.Web.UI.Page
    {
        bool NewClient;
        User user;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["NewClient"] != null)
            {
                if (Request.QueryString["NewClient"] == "True")
                    NewClient = true;
                else if (Request.QueryString["NewClient"] == "False")
                {
                    NewClient = false;
                    if (Session["connected"] != null)
                    {
                        user = (User)Session["user"];
                        if (!Page.IsPostBack)
                        {
                            LoadInfo();
                        }
                    }
                }
            }
            else
            {
                Response.Redirect("../GlobalPages/Home.aspx");
            }

        }

        protected void Terminer_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                string cnnStr = ConfigurationManager.ConnectionStrings["cnn1"].ConnectionString;
                AddressFactory AF = new AddressFactory(cnnStr);
                bool isCoursier;

                if (Request.QueryString["type"] == "Client")
                {
                    isCoursier = false;
                }
                else
                {
                    isCoursier = true;
                }

                if (NewClient)
                {

                    byte[] salt = GenerateSalt();
                    byte[] hash = GenerateHash(Encoding.ASCII.GetBytes(MDP.Text), salt);

                    UserFactory UF = new UserFactory(cnnStr);
                    UF.InsertUser(LastName.Text, FirstName.Text, EmailUser.Text, isCoursier, false, salt, hash, DateTime.Now, TelNum.Text);

                    User user = UF.GetByEmail(EmailUser.Text);

                    AF.InsertAddress(Convert.ToInt32(Adresse.Text), App.Text, Rue.Text, CodePost.Text, Ville.Text, Province.Text, user.ID_User);

                    Response.Redirect("Home.aspx");
                }
                else
                {
                    UserFactory UF = new UserFactory(cnnStr);

                    if (MDP.Text == "")
                    {
                        UF.EditUser(user.ID_User, LastName.Text, FirstName.Text, EmailUser.Text, isCoursier, false, TelNum.Text);
                    }
                    else
                    {
                        byte[] salt = GenerateSalt();
                        byte[] hash = GenerateHash(Encoding.ASCII.GetBytes(MDP.Text), salt);

                        UF.EditUserAndPWD(user.ID_User, LastName.Text, FirstName.Text, EmailUser.Text, isCoursier, false, salt, hash, TelNum.Text);
                    }
                    Address ad = AF.GetByUserID(user.ID_User);
                    AF.EditAddress(ad.ID_Address, Convert.ToInt32(Adresse.Text), App.Text, Rue.Text, CodePost.Text, Ville.Text, Province.Text, user.ID_User, DateTime.Now, default(DateTime));
                    User u = UF.GetByID(user.ID_User);
                    Session["user"] = u;

                    if (!u.IsCoursier_User)
                    {
                        Response.Redirect("../Client/Livraisons.aspx");
                    }
                    else
                    {
                        Response.Redirect("../Coursier/Livraisons.aspx");
                    }
                }
            }
        }

        protected void LoadInfo()
        {                       
            if (!NewClient)
            {
                string cnnStr = ConfigurationManager.ConnectionStrings["cnn1"].ConnectionString;
                AddressFactory AF = new AddressFactory(cnnStr);

                LastName.Text = user.LastName_User;
                FirstName.Text = user.Firstname_User;
                EmailUser.Text = user.Email_User;

                Address address = AF.GetByUserID(user.ID_User);

                Adresse.Text = address.No_Address.ToString();
                App.Text = address.App_Address;
                Rue.Text = address.Street_Address;
                Ville.Text = address.City_Address;
                Province.Text = address.Province_Address;
                CodePost.Text = address.PostalCode_Address;
                TelNum.Text = user.NumTel;
            }
        }

        protected byte[] GenerateSalt()
        {
            byte[] salt = new byte[32];
            RNGCryptoServiceProvider.Create().GetBytes(salt);
            return salt;
        }

        protected static byte[] GenerateHash(byte[] value, byte[] salt)
        {
            byte[] saltedValue = value.Concat(salt).ToArray();
            return new SHA256Managed().ComputeHash(saltedValue);
        }

        protected void Annuler_Click(object sender, EventArgs e)
        {
            if(NewClient)
                Response.Redirect("../GlobalPages/Home.aspx");
            else
            {
                User user = (User)Session["user"];

                if (!user.IsCoursier_User)
                {
                    Response.Redirect("../Client/Livraisons.aspx");
                }
                else
                {
                    Response.Redirect("../Coursier/Livraisons.aspx");
                }
            }

        }
    }
}