using System.Windows.Controls;
using JeopardySimulator.Ui.Infrastructure;

namespace JeopardySimulator.Ui.Views
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