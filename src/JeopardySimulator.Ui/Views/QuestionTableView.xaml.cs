using System.Windows.Controls;
using JeopardySimulator.Ui.Infrastructure;

namespace JeopardySimulator.Ui.Views
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