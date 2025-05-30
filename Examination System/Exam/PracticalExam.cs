using Examination_System.Answer;
using Examination_System.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Exam
{
	public class PracticalExam : MyExam
	{
		public PracticalExam(int _totalQuestions, int _examinationTime, HashSet<MyQuestion> _questions) : base(_totalQuestions, _examinationTime, _questions)
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
				DispalyCorrectAnswer(question);

			}
			//DisplayStudentScore();
		}
		public void DispalyCorrectAnswer(MyQuestion question)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("Correct Answer is: ");
			for (int i = 0; i < question.CorrectAnswerId.Length; i++)
			{
				if (i < question.CorrectAnswerId.Length - 1)
				{
					Console.Write(question.CorrectAnswerId[i] + ",");
				}
				else
				{
					Console.Write(question.CorrectAnswerId[i]);
				}
			}

			Console.WriteLine();
			Console.ForegroundColor = ConsoleColor.White;
			Console.ReadKey();
		}
	}
}
