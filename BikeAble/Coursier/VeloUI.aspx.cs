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
    public partial class VeloUI : System.Web.UI.Page
    {
        CommandeFactory factory = new CommandeFactory(ConfigurationManager.ConnectionStrings["cnn1"].ConnectionString);
        AddressFactory aFactory = new AddressFactory(ConfigurationManager.ConnectionStrings["cnn1"].ConnectionString);
        UserFactory uFactory = new UserFactory(ConfigurationManager.ConnectionStrings["cnn1"].ConnectionString);
        LivraisonFactory lFactory = new LivraisonFactory(ConfigurationManager.ConnectionStrings["cnn1"].ConnectionString);
        Livraison livraison;
        Commande commande;
        Address adresse;
        User user, connectedUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Session["connected"] != null) // Redirect to home if not connected
                {
                    connectedUser = (User)Session["user"];

                    if (!this.IsPostBack)
                    {
                        
                    }
                }
                else
                {
                    Response.Redirect("../GlobalPages/Home.aspx");
                }
            }
        }

        protected string GetDestination()
        {
            livraison = lFactory.GetAllByCoursier(connectedUser.ID_User);
            if (livraison != null)
            {
                commande = factory.GetByID(livraison.ID);
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
                return "Chicoutimi";
            }
        }
    }
}