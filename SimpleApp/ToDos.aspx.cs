using SimpleApp.Controllers;
using SimpleApp.ViewContracts;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SimpleApp
{
    public partial class ToDos : Page, IToDosView
    {
        protected ToDosController Controller { get; set; }
        public event EventHandler CompletedChanged;

        public ToDos()
        {
            Controller = new ToDosController(this);
        }

        public Repeater ToDosRepeater
        {
            get
            {
                return rptToDos;
            }
        }

        public string NewItemText
        {
            get
            {
                return tbAddNew.Text;
            }
        }

        public Button AddButton
        {
            get
            {
                return btnAdd;
            }
        }

        protected void CheckBoxCompeleted_CheckedChanged(object sender, EventArgs e)
        {
            if (CompletedChanged != null)
            {
                CompletedChanged(sender, e);
            }
        }
    }
}
    
    
    //    protected void btnDelete_Command(object sender, CommandEventArgs e)
    //    {

    //    }


    //    protected void rptToDos_ItemCommand(object source, RepeaterCommandEventArgs e)
    //    {
    //        //e.CommandName == "delete"
    //        int id = Convert.ToInt32(e.CommandArgument);
    //    }