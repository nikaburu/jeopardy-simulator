using System.Windows.Controls;
using GalaSoft.MvvmLight;
using OwnGame.Infrastructure;

namespace OwnGame.Views
{
    /// <summary>
    /// Interaction logic for PopupView.xaml
    /// </summary>
    public partial class MessagePopupView : UserControl
    {
        public MessagePopupView()
        {
            ViewModelLocatorHelper.CreateStaticViewModelLocatorForDesigner(this, new ViewModelLocator());
            InitializeComponent();
        }
    }
}
