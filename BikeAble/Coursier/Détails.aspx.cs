using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Configuration;

namespace BikeAble.Coursier
{
    public partial class Détails : System.Web.UI.Page
    {
        int id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            Alert.Visible = false;
            if (Session["connected"] != null) // Redirect to home if not connected
            {
                User user = (User)Session["user"];
                IDCoursier.Value = user.ID_User.ToString();
                if (!Page.IsCallback)
                {
                    if (Request.QueryString["id"] != null)
                    {
                        id = Convert.ToInt32(Request.QueryString["id"]);
                        FillForm(id);
                    }
                }
            }
            else
            {
                Response.Redirect("../GlobalPages/Home.aspx");
            }            
        }

        protected void FillForm(int id)
        {
            string cnnstr = ConfigurationManager.ConnectionStrings["cnn1"].ConnectionString;
            ColisFactory CF = new ColisFactory(cnnstr);
            LivraisonFactory LF = new LivraisonFactory(cnnstr);
            CommandeFactory CMF = new CommandeFactory(cnnstr);
            AddressFactory AD = new AddressFactory(cnnstr);

            Livraison livraison = LF.GetbyId(id);
            Commande commande = CMF.GetByLivraisonID(id);
            Colis colis = CF.GetByLivrasonID(livraison.ID);
            Address depart = AD.GetByUserID(commande.IDClient_Commande);
            Address arrive;
            if(commande.IDClientRec_Commande != 0)
            {
                arrive = AD.GetByUserID(commande.IDClientRec_Commande);
            }
            else
            {
                arrive = AD.GetByID(commande.IDAddress_commande);
            }

            GrosseurColis.InnerText = colis.Size;
            Distance.InnerText = livraison.Distance.ToString() + "Km";
            IDcommande.Value = commande.ID_Commande.ToString();
            IDLivraison.Value = livraison.ID.ToString();           
            AdresseDépart.InnerText = GetAdresse(depart);
            AdresseLivraison.InnerText = GetAdresse(arrive);
        }

        public string GetAdresse(Address address)
        {
            string adresse = "";

            if (address.App_Address != "")
                adresse += address.App_Address + " - ";

            adresse += address.No_Address + ", ";
            adresse += address.Street_Address + ", ";
            adresse += address.City_Address + ", ";
            adresse += address.Province_Address + ", ";
            adresse += address.PostalCode_Address;
            return adresse;
        }

        protected void RetourBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Livraisons.aspx");
        }

        protected void RéserverBtn_Click(object sender, EventArgs e)
        {
            string cnnstr = ConfigurationManager.ConnectionStrings["cnn1"].ConnectionString;
            CommandeFactory CMF = new CommandeFactory(cnnstr);
            if (!CMF.CheckIfReservation(Convert.ToInt32(IDCoursier.Value)))
            {
                CMF.ReserveCommande(Convert.ToInt32(IDCoursier.Value), Convert.ToInt32(IDcommande.Value), Convert.ToInt32(IDLivraison.Value));
                Response.Redirect("Livraisons.aspx");
            }else
            {
                Alert.Visible = true;
            }
            
            
        }
    }
}