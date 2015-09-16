using SimpleApp.BusinessServices;
using SimpleApp.BusinessServices.Contracts;
using SimpleApp.Model;
using SimpleApp.ViewContracts;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using SimpleApp.Controllers;
using System.Web.UI.WebControls;
using System.Linq;
using System.Web.Security;


namespace SimpleApp.Controllers
{
    /// <summary>
    /// Responsible for handling user events and controlling what the view displays
    /// </summary>
    public class ToDosController
    {
        public bool showCompl;
        /// <summary>
        /// The view controlled by this controller
        /// </summary>
        internal IToDosView _view { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="view">An object that implements the IToDosView interface</param>
        public ToDosController(IToDosView view)
        {
            _view = view;

            Page viewPage = _view as Page;
            if (viewPage == null)
            {
                throw new ArgumentException("The view must be of type Page!");
            }
            viewPage.Load += ViewLoad;
        }

        /// <summary>
        /// Rebind the todo items of the repeater
        /// </summary>
        private void RebindItems(bool showCompleted)
        {
            Page viewPage = _view as Page;
            _view.ToDosRepeater.DataSource = GetToDos(showCompleted);
            _view.ToDosRepeater.DataBind();
        }

        /// <summary>
        /// Handles view Load event
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">Event arguments</param>
        void ViewLoad(object sender, EventArgs e)
        {
            _view.AddButton.Click += AddButton_Click;
            _view.Deleted += deletebtn_Click;
            _view.ToDosRepeater.ItemDataBound += repeater_ItemDataBound;
            _view.CompletedChanged += cmplcheckBox_CheckedChanged;
            _view.ShowCompletedChanged += chbxShowCompl_CheckedChanged;
            if (!_view.IsPostBack) 
            {
                RebindItems(_view.ShowCompleted.Checked);
            }
        }

        /// <summary>
        /// Handles a click event on the AddButton of the view
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">Event arguments</param>
        void AddButton_Click(object sender, EventArgs e)
        {
            IToDoService todoService = ServiceFactory.Instance.GetService<IToDoService>();
            //check for logged in user
            MembershipUser mu = System.Web.Security.Membership.GetUser();
            todoService.AddToDo(_view.NewItemText, mu.UserName);
            RebindItems(_view.ShowCompleted.Checked);
        }

        void repeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem repeaterItem = e.Item as RepeaterItem;
            if (repeaterItem.DataItem == null)
            {
                return;
            }

            CheckBox cmplcheckBox = (CheckBox)repeaterItem.FindControl("CheckBoxCompeleted");

            if (cmplcheckBox != null)
            {
                cmplcheckBox.CheckedChanged += cmplcheckBox_CheckedChanged;
                if(cmplcheckBox.Checked) /*and if the ShowCompleted checkbox unchecked*/
                {
                    // hide this item
                }
            }       
        }

        void deletebtn_Click(object sender, RepeaterCommandEventArgs e)
        {
            IToDoService todoService = ServiceFactory.Instance.GetService<IToDoService>();
            int id;
            if (Int32.TryParse(e.CommandArgument.ToString(), out id))
            {
                todoService.DeleteToDo(id);
            }
            else
            {
                throw new ArgumentException("Cannot cast string to int!");
            }
            // RebindItems() refreshes the page after deleting.
            RebindItems(_view.ShowCompleted.Checked);
        }

        void cmplcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            IToDoService todoService = ServiceFactory.Instance.GetService<IToDoService>();
            CheckBox cb = sender as CheckBox;
            HiddenField hf = null;
            //cb.Parent.Controls is the collection of the cb's brothers in the tree.
            foreach(Control c in cb.Parent.Controls)
            {         
                
                if (c is HiddenField)
                {
                    hf = c as HiddenField;
                }

            }
            if (cb != null && hf != null)
            {
                int id;
                if (Int32.TryParse(hf.Value, out id))
                {
                    todoService.ChangeCompleted(id, cb.Checked);
                }
                else
                {
                    throw new ArgumentException("Cannot cast string to int!");
                }
            }
            RebindItems(_view.ShowCompleted.Checked);
        }

        void chbxShowCompl_CheckedChanged(object sender, EventArgs e)
        {
            IToDoService todoService = ServiceFactory.Instance.GetService<IToDoService>();
            CheckBox cb = sender as CheckBox;
            RebindItems(cb.Checked);

        }

        /// <summary>
        /// Retrieves the todo items
        /// </summary>
        /// <returns>A collection of ToDo items</returns>
        IEnumerable<ToDoItem> GetToDos(bool showCompleted)
        {
            IToDoService todoService = ServiceFactory.Instance.GetService<IToDoService>();
            if (todoService != null)
            {
                return todoService.GetToDosForUser(HttpContext.Current.User.Identity.Name, showCompleted);
            }
            return null;
        }
    }
}