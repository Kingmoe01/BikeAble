using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Configuration;
using System.Net;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace BikeAble.Client
{
    public partial class NewLivraison : System.Web.UI.Page
    {
        List<User> users;
        UserFactory factory = new UserFactory(ConfigurationManager.ConnectionStrings["cnn1"].ConnectionString);
        AddressFactory aFactory = new AddressFactory(ConfigurationManager.ConnectionStrings["cnn1"].ConnectionString);
        CommandeFactory cFactory = new CommandeFactory(ConfigurationManager.ConnectionStrings["cnn1"].ConnectionString);
        ColisFactory coFactory = new ColisFactory(ConfigurationManager.ConnectionStrings["cnn1"].ConnectionString);
        LivraisonFactory lFactory = new LivraisonFactory(ConfigurationManager.ConnectionStrings["cnn1"].ConnectionString);
        User user;

        private struct DropDownObj
        {
            public string Text { get; set; }
            public int ID { get; set; }

            public DropDownObj(string text, int id)
            {
                Text = text;
                ID = id;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["connected"] != null)
            {
                user = (User)Session["user"];


                if (!Page.IsPostBack)
                {
                    BindGrosseur();
                    BindClientRec();
                }
            }
            else
            {
                Response.Redirect("../GlobalPages/Home.aspx");
            }

        }

        private void BindClientRec()
        {
            users = factory.GetWithAddress(user.ID_User).ToList();
            users.Add(new User(0, "adresse", "Nouvelle", new Address()));
            Destinateur.DataSource = users;
            Destinateur.DataTextField = "NomEtPrenom";
            Destinateur.DataValueField = "ID_User";
            Destinateur.DataBind();

            adresseBox.Visible = users.Count == 1;
        }

        protected void BindGrosseur()
        {
            DropDownObj obj1 = new DropDownObj("Lettre", 1);
            DropDownObj obj2 = new DropDownObj("Petit", 2);
            DropDownObj obj3 = new DropDownObj("Moyen", 3);
            DropDownObj obj4 = new DropDownObj("Grand", 4);
            DropDownObj[] Objects = new DropDownObj[4];
            Objects[0] = obj1;
            Objects[1] = obj2;
            Objects[2] = obj3;
            Objects[3] = obj4;
            GrosseurColis.DataSource = Objects;
            GrosseurColis.DataTextField = "Text";
            GrosseurColis.DataValueField = "Text";
            GrosseurColis.DataBind();
        }

        protected void Annuler_Click(object sender, EventArgs e)
        {
            Response.Redirect("Livraisons.aspx");
        }

        protected void Ajouter_Click(object sender, EventArgs e) //mettre un required field validator
        {
            Address getAddress;
            if (int.Parse(Destinateur.SelectedValue) == 0)
            {
                Address newAdress = new Address(int.Parse(no.Text), app.Text, street.Text, postalCode.Text, city.Text, province.Text);
                //Redondance
                getAddress = aFactory.GetByAddress(newAdress.No_Address, newAdress.App_Address, newAdress.Street_Address, newAdress.PostalCode_Address);

                if (getAddress == null)
                {
                    aFactory.InsertAddress(int.Parse(no.Text), app.Text, street.Text, postalCode.Text, city.Text, province.Text);
                    getAddress = aFactory.GetByAddress(newAdress.No_Address, newAdress.App_Address, newAdress.Street_Address, newAdress.PostalCode_Address);
                }

                if (SetCommande(getAddress))
                {
                    RedirectToLivraison();
                }
                else
                {
                    //Une erreur c'est produite
                }


            }
            else
            {
                getAddress = aFactory.GetByUserID(int.Parse(Destinateur.SelectedValue));

                if (SetCommande(getAddress, int.Parse(Destinateur.SelectedValue)))
                {
                    RedirectToLivraison();
                }
                else
                {
                    //Une erreur c'est produite
                }
            }
        }

        bool SetCommande(Address destinationAddress)
        {
            try
            {
                //Récupere la ditance et la duree
                string url = "https://maps.googleapis.com/maps/api/distancematrix/xml?units=metrics&origins=" + GetOrigin() + "&destinations=" + destinationAddress.ToString() + "&key=AIzaSyCKT1an_V-Lxn_tKTVULovEa2arGAJK_4g&mode=bicycling";
                Itineraire itin = GetDistances(url);

                int idLivraison = lFactory.CreateLivraison(itin.Distance, "En Attente"); //Crée la livraison

                cFactory.CreateCommandeWithAddress(user.ID_User, destinationAddress.ID_Address, NomLivraison.Text, idLivraison); //Crée la commande

                coFactory.CreateColis(GrosseurColis.SelectedValue.ToString(), idLivraison); //Crée le colis

                CreatePaypalPayment(cFactory.GetByLivraisonID(idLivraison), coFactory.GetByLivrasonID(idLivraison));


                return true;
            } catch (Exception e)
            {
                return false;
            }
        }

        bool SetCommande(Address destinationAddress, int userRecID)
        {
                //Récupere la ditance et la duree
                string url = "https://maps.googleapis.com/maps/api/distancematrix/xml?units=metrics&origins=" + GetOrigin() + "&destinations=" + destinationAddress.ToString() + "&key=AIzaSyCKT1an_V-Lxn_tKTVULovEa2arGAJK_4g&mode=bicycling";
                Itineraire itin = GetDistances(url);

                int idLivraison = lFactory.CreateLivraison(itin.Distance, "En Attente"); //Crée la livraison

                cFactory.CreateCommandeWithIDs(user.ID_User, userRecID, NomLivraison.Text, idLivraison); //Crée la commande

                coFactory.CreateColis(GrosseurColis.SelectedValue.ToString(), idLivraison); //Crée le colis

                CreatePaypalPayment(cFactory.GetByLivraisonID(idLivraison), coFactory.GetByLivrasonID(idLivraison));

                return true;
            
        }

        protected PayPal.Api.Payment CreatePaypalPayment(Commande transaction, Colis colis)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.DefaultConnectionLimit = 9999;

            Dictionary<string, string> config = PayPal.Api.ConfigManager.Instance.GetProperties();
            string accessToken = new PayPal.Api.OAuthTokenCredential(config).GetAccessToken();
            PayPal.Api.APIContext apiContext = new PayPal.Api.APIContext(accessToken);
            apiContext.Config = PayPal.Api.ConfigManager.Instance.GetProperties();

            PayPal.Api.ItemList itemList = new PayPal.Api.ItemList()
            {
                items = new List<PayPal.Api.Item>()
            };

            itemList.items.Add(
                new PayPal.Api.Item()
                {
                    sku = Convert.ToString(transaction.IDLivraison_Commande),
                    name = transaction.Nom_commande,
                    currency = "CAD",
                    price = Convert.ToString(coFactory.GetPrice(colis.Size, colis.IDLivraison_Colis)).Replace(",", "."),
                    tax = Convert.ToString(Math.Round((0.15 * coFactory.GetPrice(colis.Size, colis.IDLivraison_Colis)), 2)).Replace(",", ".")
                });

            //Sommaire de la transaction
            double subtot = Math.Round(Convert.ToDouble(coFactory.GetPrice(colis.Size, colis.IDLivraison_Colis)), 2);
            double stolenMoney = Math.Round((subtot * 0.15), 2);
            double tot = subtot + stolenMoney;
            List<PayPal.Api.Transaction> transactionList = new List<PayPal.Api.Transaction>();
            transactionList.Add(new PayPal.Api.Transaction()
            {
                invoice_number = transaction.ID_Commande.ToString(),
                amount = new PayPal.Api.Amount()
                {
                    currency = "CAD",
                    total = Convert.ToString(tot).Replace(",", "."),
                    details = new PayPal.Api.Details()
                    {
                        subtotal = Convert.ToString(subtot).Replace(",", "."),
                        tax = Convert.ToString(stolenMoney).Replace(",", "."),
                    }
                },
                item_list = itemList
            });

            PayPal.Api.WebProfile webProfil = new PayPal.Api.WebProfile()
            {
                name = Guid.NewGuid().ToString(),
                input_fields = new PayPal.Api.InputFields()
                {
                    allow_note = false,
                    no_shipping = 1
                },
                presentation = new PayPal.Api.Presentation()
                {
                    brand_name = "Bike Able",
                    locale_code = "CA"
                }
            };

            PayPal.Api.CreateProfileResponse createProfileResponse = webProfil.Create(apiContext);

            string redirectUrl = Request.Url.Scheme + "://" + Request.Url.Authority + "/CodeQR.aspx";
            PayPal.Api.Payment payment = new PayPal.Api.Payment()
            {
                intent = "sale",
                payer = new PayPal.Api.Payer() { payment_method = "paypal" },
                transactions = transactionList,
                redirect_urls = new PayPal.Api.RedirectUrls()
                {
                    cancel_url = redirectUrl + "&cancel=true",
                    return_url = redirectUrl
                },
                experience_profile_id = createProfileResponse.id

            };

            return payment.Create(apiContext);
        }

        public Itineraire GetDistances(string url)
        {
            Itineraire nouvelItineraire = new Itineraire();
            XmlDocument dox = new XmlDocument();
            dox.Load(url);

            nouvelItineraire.Duree = dox.ChildNodes[1].ChildNodes[3].FirstChild.ChildNodes[1].ChildNodes[1].FirstChild.Value;
            nouvelItineraire.Distance = int.Parse(dox.ChildNodes[1].ChildNodes[3].FirstChild.ChildNodes[2].FirstChild.FirstChild.Value);

            return nouvelItineraire;
        }

        private void RedirectToLivraison()
        {
            Response.Redirect("CodeQR.aspx");
        }

        protected void Destinateur_SelectedIndexChanged(object sender, EventArgs e)
        {
            adresseBox.Visible = Destinateur.SelectedValue == "0";
        }

        protected void Calculer_Click(object sender, EventArgs e)
        {
            prix.InnerText = "5.00 $";
        }

        protected string GetOrigin()
        {
            Address userAddress = aFactory.GetByUserID(user.ID_User);

            return userAddress.ToString();
        }
    }
}