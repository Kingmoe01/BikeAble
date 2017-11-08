using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BikeAble.Admin
{
    public partial class ListeClients : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.BindRepeater();
            }
        }

        private void BindRepeater()
        {
            userList.DataSource = convertToDataTable();
            userList.DataBind();
        }

        public DataTable convertToDataTable()
        {
            string cnnStr = ConfigurationManager.ConnectionStrings["cnn1"].ConnectionString;
            UserFactory UF = new UserFactory(cnnStr);
            List<User> userList = new List<User>(UF.GetAllClients());

            DataTable userDT = new DataTable();
            userDT.Columns.Add("ID_usager", typeof(System.Int32));
            userDT.Columns.Add("lastName_usager", typeof(System.String));
            userDT.Columns.Add("firstName_usager", typeof(System.String));
            userDT.Columns.Add("email_usager", typeof(System.String));
            userDT.Columns.Add("isCoursier_usager", typeof(System.Boolean));
            userDT.Columns.Add("isAdmin_usager", typeof(System.Boolean));
            userDT.Columns.Add("createdDate_usager", typeof(System.DateTime));
            userDT.Columns.Add("deletedDate_usager", typeof(System.DateTime));
            int cpt = 0;

            foreach (User aUser in userList)
            {
                DataRow userEntry = userDT.NewRow();
                userEntry["ID_usager"] = aUser.ID_User.ToString();
                userEntry["lastName_usager"] = aUser.LastName_User;
                userEntry["firstName_usager"] = aUser.Firstname_User;
                userEntry["email_usager"] = aUser.Email_User;
                userEntry["isCoursier_usager"] = aUser.IsCoursier_User.ToString();
                userEntry["isAdmin_usager"] = aUser.IsAdmin_User.ToString();
                userEntry["createdDate_usager"] = aUser.CreatedDate_User.ToString();

                userDT.Rows.Add(userEntry);
                cpt++;
            }

            return userDT;
        }

        protected void delClient_OnClick(object sender, EventArgs e)
        {
            string cnnStr = ConfigurationManager.ConnectionStrings["cnn1"].ConnectionString;
            UserFactory UF = new UserFactory(cnnStr);

            UF.falseDeleteUser(Convert.ToInt32(((LinkButton)sender).CommandArgument.ToString()));
            Response.Redirect("ListeClients.aspx");

        }
    }
}