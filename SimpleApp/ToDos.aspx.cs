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
        public event RepeaterCommandEventHandler Deleted;

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

        protected void rptToDos_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch(e.CommandName)
            {
                case "del":
                    //==== Getting id of the selelected record(We have passed on link button's command argument property).
                 //int id = Convert.ToInt32(e.CommandArgument);
                    //==== Call delete method and pass id as argument.
                    if(Deleted!=null)
                    Deleted(source, e);
                    
                    break;
            }
        }
    }
}
    



    //    protected void rptToDos_ItemCommand(object source, RepeaterCommandEventArgs e)
    //    {
    //        //e.CommandName == "delete"
    //        int id = Convert.ToInt32(e.CommandArgument);
    //    }