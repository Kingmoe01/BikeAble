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

namespace BikeAble
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Alert.Visible = false;
            if(Session["connected"] != null)
            {
                User user = (User)Session["user"];

                if (Session["connected"].ToString() == "coursier")
                {
                    Response.Redirect("../Coursier/Livraisons.aspx");
                }
                else if (Session["connected"].ToString() == "basicUser")
                {
                    Response.Redirect("../Client/Livraisons.aspx");
                }
            }
            
        }

        protected void login_Click(object sender, EventArgs e)
        {
            Connexion(txtUser.Text, TxtPWD.Text, "Client");
        }

        protected void Coursier_Click(object sender, EventArgs e)
        {
            Connexion(UsernameCoursier.Text,PasswordCoursier.Text, "Coursier");
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

        protected void SignUpClient_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignUp.aspx?type=Client&NewClient=True");
        }
        protected void SignUpCoursier_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignUp.aspx?type=Coursier&NewClient=True");
        }

        protected void Connexion(string login, string pwd, string BtnUsed)
        {
            string cnnStr = ConfigurationManager.ConnectionStrings["cnn1"].ConnectionString;

            if (login == "" || pwd == "")
            {
                Response.Redirect("Home.aspx");
            }
            else
            {
                UserFactory UF = new UserFactory(cnnStr);

                User u = UF.GetUserByLogin(login);

                if (u != null)
                {
                    //Vérifier que l'utilisateur n'est pas un utilisateur supprimé. Si l'utilisateur à été supprimé, affiche l'erreur d'informations de connexion.
                    if (u.DeletedDate_User.ToString() == "0001-01-01 00:00:00")
                    {
                        if (ConfirmPassword(pwd, u.Salt_User, u.Hash_User))
                        {
                            //ici ca fait em sprtsorte qu'un coursier peut seulement se connecter en coursier
                            if (u.IsCoursier_User == true && BtnUsed=="Coursier")
                            {
                                Session["connected"] = "coursier";
                                Session["user"] = u;
                                Response.Redirect("../Coursier/Livraisons.aspx");
                            }
                            else if (u.IsCoursier_User == false && BtnUsed == "Client")
                            {
                                Session["connected"] = "basicUser";
                                Session["user"] = u;
                                Response.Redirect("../Client/Livraisons.aspx");
                            }
                            else
                            {
                                AlertText.InnerText = " Vous devez utiliser l'onglet correspondant à votre type de compte";
                                Alert.Visible = true;
                            }
                        }
                        else
                        {
                            AlertText.InnerText = " Nom d'utilisateur ou mot de passe invalide";
                            Alert.Visible = true;
                        }
                    }
                    else
                    {
                        AlertText.InnerText = " Nom d'utilisateur ou mot de passe invalide";
                        Alert.Visible = true;
                    }
                }
                else
                {
                    AlertText.InnerText = " Nom d'utilisateur ou mot de passe invalide";
                    Alert.Visible = true;
                }

            }
        }
    }
}