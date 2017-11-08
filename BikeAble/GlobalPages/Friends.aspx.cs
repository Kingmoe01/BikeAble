using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BikeAble.Client
{
    public partial class Friends : System.Web.UI.Page
    {
        List<User> users;
        User user, connectedUser;
        UserFactory factory = new UserFactory(ConfigurationManager.ConnectionStrings["cnn1"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["connected"] != null)
            {
                connectedUser = (User)Session["user"];
                if (!IsPostBack)
                {
                    BindClientRec();
                }
            }
            else
            {
                Response.Redirect("../GlobalPages/Home.aspx");
            }
            
        }

        protected void Ajouter_Click(object sender, EventArgs e)
        {
            user = factory.GetByEmail(newFriends.Text);
            if(user != null && AmiFactory.AjouterAmi(connectedUser.ID_User, user.ID_User , ConfigurationManager.ConnectionStrings["cnn1"].ConnectionString))
            {
                Response.Redirect("Friends.aspx");
            }
            else
            {
                Alert.Visible = true;
            }
        }

        protected void Annuler_Click(object sender, EventArgs e)
        {

            if (connectedUser.IsCoursier_User)
                Response.Redirect("../Coursier/Livraisons.aspx");
            else
                Response.Redirect("../Client/Livraisons.aspx");
        }
        
        private void BindClientRec()
        {
            users = factory.GetFriends(connectedUser.ID_User).ToList();
            friends.DataSource = users;
            friends.DataTextField = "NomEtPrenom";
            friends.DataValueField = "ID_User";
            friends.DataBind();

            users = factory.GetPendingRequest(connectedUser.ID_User).ToList();
            tbFriendsPending.DataSource = users;
            tbFriendsPending.DataBind();
        }
        
        protected void actual_Click(object sender, EventArgs e)
        {

        }
        

        protected void tbFriendsPending_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void tbFriendsPending_PageIndexChanged(object sender, EventArgs e)
        {

        }

        protected void pending_Click(object sender, EventArgs e)
        {
            tableAmis.Visible = !tableAmis.Visible;
        }

        protected void tbFriendsPending_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "GererAmi")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                AmiFactory.AccepterAmi(connectedUser.ID_User,id, ConfigurationManager.ConnectionStrings["cnn1"].ConnectionString);

                BindClientRec();
            }
        }

    }
}