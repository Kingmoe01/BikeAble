using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using BusinessLogic;
using System.Data;

/*
 Ne pas mettre d'itinéraire si il n'y a aucune destination disponible
     */

namespace BikeAble.Coursier
{
    public partial class Livraisons : System.Web.UI.Page
    {
        LivraisonFactory factory = new LivraisonFactory(ConfigurationManager.ConnectionStrings["cnn1"].ConnectionString);
        CommandeFactory cFactory = new CommandeFactory(ConfigurationManager.ConnectionStrings["cnn1"].ConnectionString);
        AddressFactory aFactory = new AddressFactory(ConfigurationManager.ConnectionStrings["cnn1"].ConnectionString);
        UserFactory uFactory = new UserFactory(ConfigurationManager.ConnectionStrings["cnn1"].ConnectionString);
        Address adresse;
        Livraison livraison;
        Commande commande;
        User connectedUser, user;

        string destination;
        protected string Destination { get { return this.destination; } }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Alert.Visible = false;
            if (Session["connected"] != null) // Redirect to home if not connected
            {
                connectedUser = (User)Session["user"];
                if (!this.IsPostBack)
                {
                    destination = GetDestination();
                    fillGrid();
                }
            }else
            {
                Response.Redirect("../GlobalPages/Home.aspx");
            }
        }

        private void fillGrid()
        {
            List<BusinessLogic.Livraison> Livraisons;

            string cnnstr = ConfigurationManager.ConnectionStrings["cnn1"].ConnectionString;
            ColisFactory CF = new ColisFactory(cnnstr);

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[4] { new DataColumn("LivraisonID", typeof(int)),
                            new DataColumn("Distance", typeof(string)),
                            new DataColumn("Grosseur",typeof(string)),
                            new DataColumn("Prix", typeof(string))});

            Livraisons = factory.GetAll().ToList();

            foreach(Livraison l in Livraisons)
            {
                Colis colis = CF.GetByLivrasonID(l.ID);
                dt.Rows.Add(l.ID, l.Distance.ToString() + " Km", colis.Size, colis.Price.ToString() + " $");
            }
            tblLivraison.DataSource = dt;
            tblLivraison.DataBind();
        }

        protected void tblLivraison_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(tblLivraison, "Select$" + e.Row.RowIndex.ToString()));
        }

        protected void tblLivraison_SelectedIndexChanged(object sender, EventArgs e) //définir la destination dans le googlemap
        {
            Livraison livraison;
            livraison = factory.GetbyId(int.Parse(tblLivraison.SelectedValue.ToString()));

            if(livraison!= null)
            {
                commande = cFactory.GetByLivraisonID(livraison.ID);

                if (commande.IDAddress_commande != 0)
                {
                    adresse = aFactory.GetByID(commande.IDAddress_commande);
                }
                else
                {
                    user = uFactory.GetByID(commande.IDClientRec_Commande);
                    adresse = aFactory.GetByUserID(user.ID_User);
                }
            }
        }

        protected void tblLivraison_PageIndexChanged(object sender, EventArgs e)
        {

        }

        protected void tblLivraison_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName != "DetailLivraison") return;
            int idCommande = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("Détails.aspx?id=" + idCommande.ToString());
        }

        protected void friends_Click(object sender, EventArgs e)
        {
            Response.Redirect("../GlobalPages/Friends.aspx");
        }

        protected void deconnexion_Click(object sender, EventArgs e)
        {
            if(Session["connected"] != null)
            {
                Session["connected"] = null;
            }

            Response.Redirect("../GlobalPages/Home.aspx");
        }

        protected void ModeVelo_Click(object sender, EventArgs e)
        {
            if (Session["connected"] != null) // Redirect to home if not connected
            {
                User user = (User)Session["user"];
                string cnnstr = ConfigurationManager.ConnectionStrings["cnn1"].ConnectionString;
                CommandeFactory CMMF = new CommandeFactory(cnnstr);
                if (CMMF.CheckIfReservation(user.ID_User))
                {
                    Response.Redirect("VeloUI.aspx");
                }else
                {
                    Alert.Visible = true;
                }
                
            }
        }
        

        protected void options_Click(object sender, EventArgs e)
        {
            Response.Redirect("Options.aspx");
        }

        protected string GetDestination()
        {
            livraison = factory.GetAllByCoursier(connectedUser.ID_User);
            if (livraison != null)
            {
                commande = cFactory.GetByID(livraison.ID);
                if (commande.IDAddress_commande != 0)
                {
                    adresse = aFactory.GetByID(commande.IDAddress_commande);
                }
                else
                {
                    user = uFactory.GetByID(commande.IDClientRec_Commande);
                    adresse = aFactory.GetByUserID(user.ID_User);
                }
                return adresse.ToString();
            }
            else
            {
                return aFactory.GetByUserID(connectedUser.ID_User).ToString();
            }
        }
    }
}