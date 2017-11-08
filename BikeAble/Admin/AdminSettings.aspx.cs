using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BikeAble.Admin
{
    public partial class AdminSettings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Alert.Visible = false;
                string cnnStr = ConfigurationManager.ConnectionStrings["cnn1"].ConnectionString;
                TarifFactory TF = new TarifFactory(cnnStr);

                tarifLettre.Text = TF.Get().TarifLettre_Tarif.ToString();
                tarifPetit.Text = TF.Get().TarifPetit_Tarif.ToString();
                tarifMoyen.Text = TF.Get().TarifMoyen_Tarif.ToString();
                tarifGros.Text = TF.Get().TarifGros_Tarif.ToString();
                tarifKM.Text = TF.Get().TarifKM_Tarif.ToString();



            }


        }

        protected void tarifChange_OnClick(object sender, EventArgs e)
        {
            string cnnStr = ConfigurationManager.ConnectionStrings["cnn1"].ConnectionString;
            TarifFactory TF = new TarifFactory(cnnStr);

            tarifLettre.Text = tarifLettre.Text.Replace('.', ',');
            tarifPetit.Text = tarifPetit.Text.Replace('.', ',');
            tarifMoyen.Text = tarifMoyen.Text.Replace('.', ',');
            tarifGros.Text = tarifGros.Text.Replace('.', ',');
            tarifKM.Text = tarifKM.Text.Replace('.', ',');


            if (validateNewTarif())
            {
                Alert.Visible = false;
                TF.TarifEdit(TF.Get().ID_Tarif, Convert.ToDouble(tarifLettre.Text), Convert.ToDouble(tarifPetit.Text), Convert.ToDouble(tarifMoyen.Text), Convert.ToDouble(tarifGros.Text), Convert.ToDouble(tarifKM.Text));
            }
            else
            {
                tarifLettre.Text = TF.Get().TarifLettre_Tarif.ToString();
                tarifPetit.Text = TF.Get().TarifPetit_Tarif.ToString();
                tarifMoyen.Text = TF.Get().TarifMoyen_Tarif.ToString();
                tarifGros.Text = TF.Get().TarifGros_Tarif.ToString();
                tarifKM.Text = TF.Get().TarifKM_Tarif.ToString();
                Alert.Visible = true;
            }

        }

        protected bool validateNewTarif()
        {
            bool valid = true;
            float parsedValue;

            if(!float.TryParse(tarifLettre.Text, out parsedValue))
            {
                valid = false;
            }
            if (!float.TryParse(tarifPetit.Text, out parsedValue))
            {
                valid = false;
            }
            if (!float.TryParse(tarifMoyen.Text, out parsedValue))
            {
                valid = false;
            }
            if (!float.TryParse(tarifGros.Text, out parsedValue))
            {
                valid = false;
            }
            if (!float.TryParse(tarifKM.Text, out parsedValue))
            {
                valid = false;
            }
            return valid;
        }
    }
}