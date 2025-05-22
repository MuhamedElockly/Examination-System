using Examination_System.Answer;
using Examination_System.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Exam
{
	internal abstract class MyExam
	{
		public MyExam(int _totalQuestions, int _examinationTime, HashSet<MyQuestion> _questions)
		{
			TotalQuestions = _totalQuestions;
			ExaminationTime = _examinationTime;
			Questions = _questions;
			QuestionsAnswer = new Dictionary<MyQuestion, string[]>();
		}
		public int TotalQuestions { get; set; }
		public int ExaminationTime { get; set; }
		public HashSet<MyQuestion> Questions { get; set; }
		protected Dictionary<MyQuestion, string[]> QuestionsAnswer { get; set; }
		protected bool IsStudentInputValid(string[] input, List<MyAnswer> answers)
		{

			foreach (string item in input)
			{
				string inputItem = item.Trim();
				for (int i = 0; i < answers.Count; i++)
				{
					if (answers[i].AnswerId.ToLower() == inputItem.ToLower())
					{
						break;
					}
					else if (i == answers.Count - 1)
					{
					//	Console.WriteLine($"input : {inputItem}, answerItem {answers[i].AnswerId}");
						return false;
					}
				}
			}
			
			return true;

		}
		protected string[] GetStudentInput(List<MyAnswer> answers)
		{
			Console.Write("Enter your Answer : ");
			string studentAnswer = Console.ReadLine();
			string[] answerArr = studentAnswer.Split(",");
			while (!IsStudentInputValid(answerArr, answers))
			{

				Console.ForegroundColor = ConsoleColor.Red;
				Console.Write("Enter valid input : ");
				Console.ForegroundColor = ConsoleColor.White;
				answerArr = Console.ReadLine().Split(",");
			}
			return answerArr;
		}
		protected double StudentScore { get; set; }
		public abstract void DisplayExam();
		void ExportStudentTotalScore(double score)
		{
			string projectRoot = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..");
			string fullPath = Path.GetFullPath(projectRoot);
			string filePath = Path.Combine(fullPath, "student.txt");
			using (StreamWriter writer = File.AppendText(filePath))
			{
				writer.WriteLine($"Student total score is : {score}%");
			}
		}
		void ExportStudentAnswer(KeyValuePair<MyQuestion, string[]> valuePair)
		{

			string projectRoot = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..");
			string fullPath = Path.GetFullPath(projectRoot);
			string filePath = Path.Combine(fullPath, "student.txt");
			using (StreamWriter writer = File.AppendText(filePath))
			{
				writer.WriteLine(valuePair.Key.ToString());
				string stAnswer = "";
				for (int i = 0; i < valuePair.Value.Length; i++)
				{
					if (i < valuePair.Value.Length - 1)
					{
						stAnswer += valuePair.Value[i].ToUpper() + ",";
					}
					else
					{
						stAnswer += valuePair.Value[i].ToUpper();
					}
				}
				writer.WriteLine($"Student answer is : {stAnswer}");
				string correctAnswer = "";
				for (int i = 0; i < valuePair.Key.CorrectAnswerId.Length; i++)
				{
					if (i < valuePair.Value.Length - 1)
					{
						correctAnswer += valuePair.Key.CorrectAnswerId[i] + ",";
					}
					else
					{
						correctAnswer += valuePair.Key.CorrectAnswerId[i];
					}
				}
				writer.WriteLine($"Correct answer is : {correctAnswer}");
				writer.WriteLine();
				writer.WriteLine("-------------------------------------------");
				writer.WriteLine();
			}

		}
		void ClearStudentFile()
		{
			string projectRoot = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..");
			string fullPath = Path.GetFullPath(projectRoot);
			string filePath = Path.Combine(fullPath, "student.txt");
			File.WriteAllText(filePath, "");
		}
		public void DisplayStudentScore()
		{
			ClearStudentFile();
			foreach (KeyValuePair<MyQuestion, string[]> valuePair in QuestionsAnswer)
			{
				if (valuePair.Key.IsAnswerCorrect(valuePair.Value))
				{
					StudentScore++;
				}
				ExportStudentAnswer(valuePair);
			}
			ExportStudentTotalScore((StudentScore / Questions.Count) * 100);
			Console.BackgroundColor = ConsoleColor.White;
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine($"  Student Score is : {(StudentScore / Questions.Count) * 100}%  ");
			Console.BackgroundColor = ConsoleColor.Black;
			Console.ForegroundColor = ConsoleColor.White;
		}

	}
}
