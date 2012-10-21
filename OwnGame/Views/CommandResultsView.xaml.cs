using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight;
using OwnGame.Infrastructure;

namespace OwnGame.Views
{
    /// <summary>
    /// Description for CommandResultsView.
    /// </summary>
    public partial class CommandResultsView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the CommandResultsView class.
        /// </summary>
        public CommandResultsView()
        {
            if (ViewModelBase.IsInDesignModeStatic)
            {
                ViewModelLocatorHelper.CreateStaticViewModelLocatorForDesigner(this, new ViewModelLocator());
            }
            InitializeComponent();
        }
    }
}