using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PetShopManagementSystem
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            RegisterMember registerMeber = new RegisterMember();
            registerMeber.FirstName = TxtFName.Text;
            registerMeber.MiddleName = TxtMName.Text;
            registerMeber.LastName = TxtLName.Text;
            registerMeber.EmailId = TxtEmailId.Text;
            registerMeber.MobileNumber =Convert.ToInt64( TxtMobileNo.Text);
            registerMeber.UserName = TxtUserName.Text;
            registerMeber.Password = TxtPassword.Text;
            registerMeber.ConfirmPassword = TxtConfirmPassword.Text;
            registerMeber.Address = TxtAddress.Text;
            registerMeber.Age = Convert.ToInt32(TxtAge.Text);
            registerMeber.Gender = DropDownList1.SelectedValue;
            registerMeber.Country = DropDownList2.SelectedValue;

            registerMeber.RegisterUser(registerMeber);

            RegistartionLabel.ForeColor = Color.Green;            
            RegistartionLabel.Text= "Registration Successful ! Click on Login to continue..";

            
        }
    }
}