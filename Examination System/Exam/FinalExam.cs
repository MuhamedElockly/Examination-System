using Examination_System.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Exam
{
	internal class FinalExam : MyExam
	{
		public FinalExam(int _totalQuestions, int _examinationTime, HashSet<MyQuestion> _questions) : base(_totalQuestions, _examinationTime, _questions)
		{
		}

		public override void DisplayExam()
		{
			foreach (var question in Questions)
			{
				Console.Clear();
				Console.WriteLine(question);
				string[] questionAnswer = GetStudentInput(question.MyAnswerList);
				QuestionsAnswer.Add(question, questionAnswer);
			}
			DisplayStudentScore();
		}
	}
}
