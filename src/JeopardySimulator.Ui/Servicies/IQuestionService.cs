using System.Collections.Generic;
using JeopardySimulator.Ui.Models;

namespace JeopardySimulator.Ui.Servicies
{
	public interface IQuestionService
	{
		List<QuestionGroup> GetQuestionGroupList(int multi = 1);
	}
}