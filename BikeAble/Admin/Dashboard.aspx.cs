using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;

namespace BikeAble.Admin
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string cnnStr = ConfigurationManager.ConnectionStrings["cnn1"].ConnectionString;
                TarifFactory tf = new TarifFactory(cnnStr);

                tarifKM.Text = tf.Get().TarifKM_Tarif.ToString("c2") + " /KM";
                tarifLettre.Text = tf.Get().TarifLettre_Tarif.ToString("c2");
                tarifPetit.Text = tf.Get().TarifPetit_Tarif.ToString("c2");
                tarifMoyen.Text = tf.Get().TarifMoyen_Tarif.ToString("c2");
                tarifGros.Text = tf.Get().TarifGros_Tarif.ToString("c2");
            }
        }
    }
}