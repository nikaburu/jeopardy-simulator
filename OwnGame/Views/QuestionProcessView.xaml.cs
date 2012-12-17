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

        private void Resizeble_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;
            if (textBlock != null)
            {
                textBlock.FontSize += e.Delta > 0 ? 1 : -1;
                return;
            }

            Image image = sender as Image;
            if (image != null)
            {
                image.Width += e.Delta > 0 ? 1 : -1;
                image.Height += e.Delta > 0 ? 1 : -1;
                return;
            }
        }
    }
}
