using System.Windows;
using GalaSoft.MvvmLight;

namespace JeopardySimulator.Ui.Infrastructure
{
	//Blend 4 buga resolution: http://mvvmlight.codeplex.com/discussions/82284
	public class ViewModelLocatorHelper
	{
		public static void CreateStaticViewModelLocatorForDesigner(FrameworkElement control, object viewModelLocator)
		{
			if (ViewModelBase.IsInDesignModeStatic)
				control.Resources.Add("Locator", viewModelLocator);
		}
	}
}