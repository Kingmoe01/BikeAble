using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BikeAble.Coursier
{
    public partial class Options : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ParamAvancé_Click(object sender, EventArgs e)
        {
            Response.Redirect("../GlobalPages/SignUp.aspx?NewClient=False");
        }

        protected void Annuler_Click(object sender, EventArgs e)
        {
            Response.Redirect("Livraisons.aspx");
        }

        protected void Sauvegarder_Click(object sender, EventArgs e)
        {

        }
    }
}