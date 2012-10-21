using System.Windows.Controls;
using GalaSoft.MvvmLight;
using OwnGame.Infrastructure;

namespace OwnGame.Views
{
    /// <summary>
    /// Description for QuestionTableView.
    /// </summary>
    public partial class QuestionTableView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the QuestionTableView class.
        /// </summary>
        public QuestionTableView()
        {
            ViewModelLocatorHelper.CreateStaticViewModelLocatorForDesigner(this, new ViewModelLocator());
            InitializeComponent();
        }
    }
}