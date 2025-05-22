using Examination_System.Answer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Question
{
	internal abstract class MyQuestion : ICorrect
	{
		protected MyQuestion(string _header, int _id, string _body, AnswerList _answerList, string[] _correctAnswer)
		{
			Id = _id;
			Body = _body;
			MyAnswerList = _answerList;
			Header = _header;
			CorrectAnswerId = _correctAnswer;

		}
		public string Header { get; set; }
		public override string ToString()
		{
			string questionHeader = $"{Id}- {Header}";
			string answerList = "\t";
			foreach (MyAnswer answer in MyAnswerList)
			{
				answerList += answer + "\n\t";
			}
			string question = $"{questionHeader}: {Body}\n {answerList}";
			return question;
		}
		public abstract bool IsAnswerCorrect(string[] answer);
		public int Id { get; set; }
		public string[] CorrectAnswerId { get; set; }
		public string Body { get; set; }
		public AnswerList MyAnswerList { get; set; }
		public override int GetHashCode()
		{
			string question = Body;
			foreach (var answer in MyAnswerList)
			{
				question += answer.ToString();
			}
			return question.GetHashCode();
		}
		public override bool Equals(object? obj)
		{
			if (obj == null || obj is not MyQuestion)
			{
				return false;
			}
			MyQuestion myQuestion = (MyQuestion)obj;

			if (myQuestion.Body == Body && MyAnswerList.Equals(myQuestion.MyAnswerList))
			{
				return true;
			}
			return false;
		}

	}
}
