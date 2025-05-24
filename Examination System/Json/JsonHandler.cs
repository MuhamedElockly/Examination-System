using Examination_System.Answer;
using Examination_System.Exam;
using Examination_System.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Examination_System.Json
{
	public class JsonHandler
	{
		public static MyExam CreateExam()
		{
			MyExam? myExam = null;
			try
			{
				string baseDir = AppDomain.CurrentDomain.BaseDirectory;
				string filePath = Path.Combine(baseDir, "Json/Exam.json");

				if (!File.Exists(filePath))
				{
					Console.WriteLine($"Error: File not found at {filePath}");
					Console.WriteLine("Current directory: " + Directory.GetCurrentDirectory());
					return null;
				}

				string jsonContent = File.ReadAllText(filePath);
				var root = JsonSerializer.Deserialize<JsonRootModel>(jsonContent);
				if (root?.Exam?.FirstOrDefault() is JsonExam firstExam)
				{
					QuestionSet myQuestions = new QuestionSet();
					foreach (var question in firstExam.Questions)
					{
						AnswerList answerList = new AnswerList();
						foreach (var answer in question.Answers)
						{
							MyAnswer myAnswer = new MyAnswer(_answerId: answer.Id, _answerBody: answer.Body);
							answerList.Add(myAnswer);
						}
						MyQuestion myQuestion;
						if (question.Header == "choose one")
						{
							myQuestion = new ChooseOneQuestion(question.Id, question.Body, answerList, question.CorrectAnswer.ToArray());
							myQuestions.Add(myQuestion);
						}
						else if (question.Header == "choose all")
						{
							myQuestion = new ChooseAllQuestion(question.Id, question.Body, answerList, question.CorrectAnswer.ToArray());
							myQuestions.Add(myQuestion);
						}
						else if (question.Header == "true of false")
						{
							myQuestion = new TrueOrFalseQuestion(question.Id, question.Body, answerList, question.CorrectAnswer.ToArray());
							myQuestions.Add(myQuestion);

						}

					}

					if (firstExam.Type == "final")
					{
						myExam = new FinalExam(myQuestions.Count, firstExam.Time, myQuestions);
					}
					else if (firstExam.Type == "practical")
					{
						myExam = new PracticalExam(myQuestions.Count, firstExam.Time, myQuestions);

					}

				}
				else
				{
					Console.WriteLine("No exam data found");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
			}
			return myExam;
		}

	}
}
