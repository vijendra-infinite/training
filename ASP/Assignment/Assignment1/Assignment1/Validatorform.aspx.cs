using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment1
{
    public partial class Validatorform : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            if (IsValid)
            {

                ScriptManager.RegisterStartupScript(this, GetType(), "checkDetails", "checkDetails();", true);
                lbl.Visible = true;
                lbl.Text = "Form submitted successfully!";
            }

        }

    }
}