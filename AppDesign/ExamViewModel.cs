using Examination_System.Exam;
using ExaminationSystem;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDesign
{
	public class ExamViewModel
	{

		public ExamViewModel(MyExam myExam)
		{
			if (myExam != null && myExam is PracticalExam)
			{
				ExamType = "Practical";
			}
			else if (myExam != null && myExam is FinalExam)
			{
				ExamType = "Final";
			}
			WrappedQuestions = new ObservableCollection<QuestionWrapper>(myExam.Questions.Select(q => new QuestionWrapper(q)));
			ExamTime= myExam.ExaminationTime;
		}
		public string ExamType { get; set; }
		public int ExamTime { get; set; }
		public ObservableCollection<QuestionWrapper> WrappedQuestions { get; set; }

	}
}
