using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using BusinessLogic;


namespace BikeAble.Client
{
    public partial class Livraison : System.Web.UI.Page
    {
        LivraisonFactory factory = new LivraisonFactory(ConfigurationManager.ConnectionStrings["cnn1"].ConnectionString);
        List<BusinessLogic.Livraison> clientLivraison;
        User user;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["connected"] != null)
            {
                user = (User)Session["user"];
                if (!this.IsPostBack)
                {
                    fillGrid(user.ID_User);
                }
            }
            else
            {
                Response.Redirect("../GlobalPages/Home.aspx");
            }
        }

        private void fillGrid(int id)
        {
            clientLivraison = factory.GetAllByClient(id).ToList();
            tblLivraison.DataSource = clientLivraison;
            tblLivraison.DataBind();
        }

        protected void tblLivraison_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void tblLivraison_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void tblLivraison_PageIndexChanged(object sender, EventArgs e)
        {

        }

        protected void tblLivraison_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName != "GererLivraison") return;
            int idCommande = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("GestionLivraison.aspx?id=" + idCommande.ToString());
        }
        
        protected void createLivr_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewLivraison.aspx");
        }

        protected void deconnexion_Click(object sender, EventArgs e)
        {
            Session["connected"] = null;
            Response.Redirect("../GlobalPages/Home.aspx");
        }

        protected void optionButt_Click(object sender, EventArgs e)
        {
            Response.Redirect("../GlobalPages/SignUp.aspx?NewClient=False&type=Client");
        }

        protected void friends_Click(object sender, EventArgs e)
        {
            Response.Redirect("../GlobalPages/Friends.aspx");
        }

        protected void ScanQR_Click(object sender, EventArgs e)
        {
            Response.Redirect("ScanQR.aspx");
        }
    }
}
