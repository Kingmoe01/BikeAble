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
    public partial class GestionLivraison : System.Web.UI.Page
    {
        int id = 0;
        LivraisonFactory factory = new LivraisonFactory(ConfigurationManager.ConnectionStrings["cnn1"].ConnectionString);
        CommandeFactory cFactory = new CommandeFactory(ConfigurationManager.ConnectionStrings["cnn1"].ConnectionString);
        AddressFactory aFactory = new AddressFactory(ConfigurationManager.ConnectionStrings["cnn1"].ConnectionString);
        UserFactory ufactory = new UserFactory(ConfigurationManager.ConnectionStrings["cnn1"].ConnectionString);
        List<User> users;
        User user;
        Address monAdresse, sonAdresse, address;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["connected"] != null)
            {
                user = (User)Session["user"];

                if (!this.IsPostBack)
                {
                    Alert.Visible = false;
                    GetId();
                    if (id != 0)
                    {
                        FillChamp();
                    }
                    else
                    {
                        Response.Redirect("../GlobalPages/Home.aspx");
                    }
                }
            }
            
        }

        void FillFriends()
        {
            users = ufactory.GetFriends(user.ID_User).ToList();
            person.DataSource = users;
            person.DataTextField = "NomEtPrenom";
            person.DataValueField = "ID_User";
            person.DataBind();
        }
        private void FillChamp()
        {
            BusinessLogic.Livraison maLivraison = factory.GetbyId(id);
            Commande maCommande = cFactory.GetByLivraisonID(id);
            NomLivraison.Text = maCommande.Nom_commande;
            if(maCommande.DeletedDate_commande.ToString() == "0001-01-01 00:00:00")
            {
                monAdresse = aFactory.GetByUserID(maCommande.IDClient_Commande);
                sonAdresse = aFactory.GetByUserID(maCommande.IDClientRec_Commande);
                if (sonAdresse == null)
                {
                    address = aFactory.GetByID(maCommande.IDAddress_commande);
                }

                TxtCommandeID.Value = maCommande.ID_Commande.ToString();
                FillFriends();
                FillChamp(monAdresse);

                if(maCommande.IDClientRec_Commande != 0)
                    person.SelectedValue = maCommande.IDClientRec_Commande.ToString();
                swap.Enabled = false;
                EnableOrNotTextBox(false);
            }         
        }

        private void GetId()//recuperer l'id de la livraison selectionner en POST et verifier le client connecter
        {
            if (Request.QueryString["id"] != null)
            {
                id = Convert.ToInt32(Request.QueryString["id"].ToString());
            }
            else
            {
                Response.Redirect("Livraisons.aspx");
            }
        }

        protected void Annuler_Click(object sender, EventArgs e)
        {
            Response.Redirect("Livraisons.aspx");
        }

        protected void Supprimmer_Click(object sender, EventArgs e)
        {
            cFactory.falseDeleteCommande(Convert.ToInt32(TxtCommandeID.Value));
            Response.Redirect("Livraisons.aspx");
        }

        protected void Sauvegarder_Click(object sender, EventArgs e)
        {
            if (cFactory.ClientAndCommandExists(user.ID_User, int.Parse(TxtCommandeID.Value)))
            {
                if (swapValue.Value == "Arr")
                {
                    if (NomLivraison.Text != cFactory.GetByLivraisonID(id).Nom_commande)
                    {
                        cFactory.UpdateName(int.Parse(TxtCommandeID.Value), NomLivraison.Text);
                    }

                    Response.Redirect("Livraisons.aspx");
                }
                else if (swapValue.Value == "Dep")
                {
                    if (adresseBox.Visible)
                    {

                    }
                    else
                    {

                    }
                } }
        }

        void FillChamp(Address addresse)
        {
            no.Text = addresse.No_Address.ToString();
            app.Text = addresse.App_Address.ToString();
            street.Text = addresse.Street_Address.ToString();
            postalCode.Text = addresse.PostalCode_Address.ToString();
            city.Text = addresse.City_Address.ToString();
            province.Text = addresse.Province_Address.ToString();
        }


        protected void arriver_Click(object sender, EventArgs e)
        {
            swapValue.Value = "Arr";
            Address newAdresse;
            Address tempAdd = aFactory.GetByUserID(cFactory.GetByID(int.Parse(TxtCommandeID.Value)).IDClientRec_Commande);
            if (tempAdd != null)
            {
                SetDisplayToFriend();
                newAdresse = GetAdresse(int.Parse(TxtCommandeID.Value), 's');
            }
            else
            {
                newAdresse = GetAdresse(int.Parse(TxtCommandeID.Value), 'a');
            }
            FillChamp(newAdresse);
            swap.Enabled = true;
            EnableOrNotTextBox(true);
        }
        protected void depart_Click(object sender, EventArgs e)
        {
            swapValue.Value = "Dep";
            Address newAdresse = GetAdresse(int.Parse(TxtCommandeID.Value),'m');
            FillChamp(newAdresse);
            swap.Enabled = false;
            SetDisplayToAddress();
            EnableOrNotTextBox(false);
        }

        void SetDisplayToFriend()
        {
            personBox.Visible = true;
            adresseBox.Visible = false;
        }
        void SetDisplayToAddress()
        {
            personBox.Visible = false;
            adresseBox.Visible = true;
        }

        void EnableOrNotTextBox(bool value)
        {
            no.Enabled = value;
            app.Enabled = value;
            street.Enabled = value;
            postalCode.Enabled = value;
            city.Enabled = value;
            province.Enabled = value;
        }
        protected void switch_Click(object sender, EventArgs e)
        {
            personBox.Visible = adresseBox.Visible;
            adresseBox.Visible = !adresseBox.Visible;
        }



        Address GetAdresse(int idCommande,char type)
        {
            Commande modifiedCommande = cFactory.GetByID(idCommande);
            Address newAdresse = null;
            switch (type)
            {
                case 'm':
                    newAdresse = aFactory.GetByUserID(modifiedCommande.IDClient_Commande);
                    break;
                case 's':
                    newAdresse = aFactory.GetByUserID(modifiedCommande.IDClientRec_Commande);
                    break;
                case 'a':
                    newAdresse = aFactory.GetByUserID(modifiedCommande.IDAddress_commande);
                    break;
            }

            return newAdresse;
        }
    }
}