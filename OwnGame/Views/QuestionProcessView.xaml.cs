using System.Windows.Controls;
using GalaSoft.MvvmLight;
using OwnGame.Infrastructure;

namespace OwnGame.Views
{
    /// <summary>
    /// Interaction logic for QuestionProcessView.xaml
    /// </summary>
    public partial class QuestionProcessView : UserControl
    {
        public QuestionProcessView()
        {
            ViewModelLocatorHelper.CreateStaticViewModelLocatorForDesigner(this, new ViewModelLocator());
            InitializeComponent();
        }
    }
}
