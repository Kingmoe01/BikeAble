using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BikeAble.AJAX
{
    public partial class FriendExists : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Clear();

            string email = Request.QueryString["email"];

            if (email != null)
            {
                string exist = new UserFactory(ConfigurationManager.ConnectionStrings["cnn1"].ConnectionString).UserExists(email);

                Response.Write(exist);
            }
            Response.End();
        }
    }
}