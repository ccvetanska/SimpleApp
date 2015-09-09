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

        Repeater ToDosRepeater { get; }

        string NewItemText { get; }

        Button AddButton { get; }

        bool IsPostBack { get; }

 //       CheckBox CompleteBox { get; }
    }
}
