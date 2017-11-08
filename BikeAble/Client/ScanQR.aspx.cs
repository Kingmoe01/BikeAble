using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Configuration;

namespace BikeAble.Client
{
    public partial class ScanQR : System.Web.UI.Page
    {
        protected User u;

        protected void Page_Load(object sender, EventArgs e)
        {
            Alert.Visible = false;
            this.Page.ClientScript.GetPostBackEventReference(this, "");
            if (Session["connected"] != null)
            {
                u = (User)Session["user"];
            }
            else
            {
                Response.Redirect("../GlobalPages/Home.aspx");
            }
        }

        protected void Retour_Click(object sender, EventArgs e)
        {
            Response.Redirect("Livraisons.aspx");
        }

        protected void Decode_Click(object sender, EventArgs e)
        {            
            if (Session["connected"] != null)
            {
                u = (User)Session["user"];
            }

            CommandeFactory CMM = new CommandeFactory(ConfigurationManager.ConnectionStrings["cnn1"].ConnectionString);
            int IDcommande;
            Int32.TryParse(ID_QR.Value, out IDcommande);
            if(IDcommande != 0)
            {
                if (CMM.GetByIDAndClientRec(u.ID_User, IDcommande))
                {
                    Commande c = CMM.GetByID(IDcommande);
                    CMM.CommandeLivreCoursier(c.IDLivraison_Commande);
                }
                else
                {
                    AlertText.InnerText = " Cette Livraison n'est pas la vôtre";
                    Alert.Visible = true;
                }
            }
            else
            {
                AlertText.InnerText = " Code invalide, désolé. Réessayez de prendre une photo plus claire";
                Alert.Visible = true;
            }            
        }
    }
}