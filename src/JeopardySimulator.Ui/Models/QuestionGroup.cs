using System.Collections.Generic;

namespace JeopardySimulator.Ui.Models
{
	public sealed class QuestionGroup
	{
		public int Id { get; private set; }
		public string Name { get; set; }

		public IEnumerable<Question> Questions { get; }

		#region Constructors

		public QuestionGroup() : this(0, new Question[0])
		{
		}

		public QuestionGroup(int id) : this(id, new Question[0])
		{
		}

		public QuestionGroup(int id, IEnumerable<Question> questions)
		{
			Id = id;

			Questions = questions;
			foreach (var question in Questions)
			{
				question.QuestionGroup = this;
			}
		}

		#endregion
	}
}