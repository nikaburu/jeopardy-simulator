using System.Windows.Controls;
using JeopardySimulator.Ui.Infrastructure;

namespace JeopardySimulator.Ui.Views
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