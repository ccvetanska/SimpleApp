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
        public event EventHandler ShowCompletedChanged;

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

        public CheckBox ShowCompleted
        {
            get
            {
                return chbxShowCompl;
            }
        }
        
        protected void CheckBoxCompeleted_CheckedChanged(object sender, EventArgs e)
        {
            if (CompletedChanged != null)
            {
                CompletedChanged(sender, e);
            }
        }

        protected void chbxShowCompl_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowCompletedChanged!= null)
            {
                ShowCompletedChanged(sender, e);
            }
        }

        protected void rptToDos_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch(e.CommandName)
            {
                case "del":
                    if(Deleted!=null)
                    Deleted(source, e);                    
                    break;

            }
        }
    }
}
    