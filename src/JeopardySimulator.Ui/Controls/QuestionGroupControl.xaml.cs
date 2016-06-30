using System.Windows.Controls;
using JeopardySimulator.Ui.Infrastructure;

namespace JeopardySimulator.Ui.Controls
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