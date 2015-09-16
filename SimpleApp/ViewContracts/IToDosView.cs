using System;
using System.Web.UI.WebControls;

namespace SimpleApp.ViewContracts
{
    /// <summary>
    /// Defines the contract between the view and the controller
    /// </summary>
    public interface IToDosView
    {
        event EventHandler CompletedChanged;

        event EventHandler ShowCompletedChanged;

        event RepeaterCommandEventHandler Deleted;

        Repeater ToDosRepeater { get; }
        
        string NewItemText { get; }

        Button AddButton { get; }

        bool IsPostBack { get; }

        CheckBox ShowCompleted { get; }

 //       CheckBox CompleteBox { get; }
    }
}
