using System.Windows.Controls;
using OwnGame.Infrastructure;

namespace OwnGame.Views
{
    /// <summary>
    /// Interaction logic for TotalResultsView.xaml
    /// </summary>
    public partial class TotalResultsView : UserControl
    {
        public TotalResultsView()
        {
            ViewModelLocatorHelper.CreateStaticViewModelLocatorForDesigner(this, new ViewModelLocator());
            InitializeComponent();
        }
    }
}
