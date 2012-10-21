using System.Windows.Controls;
using OwnGame.Infrastructure;

namespace OwnGame.Controls
{
    /// <summary>
    /// Interaction logic for QuestionGroupControl.xaml
    /// </summary>
    public partial class QuestionGroupControl : UserControl
    {
        public QuestionGroupControl()
        {
            ViewModelLocatorHelper.CreateStaticViewModelLocatorForDesigner(this, new ViewModelLocator());
            InitializeComponent();
        }
    }
}
