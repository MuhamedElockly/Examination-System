using Examination_System.Answer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Question
{
	public class TrueOrFalseQuestion : MyQuestion
	{
		public TrueOrFalseQuestion(int _id, string _body, AnswerList _answerList, string[] _correctAnswerId) : base("True Or False", _id, _body, _answerList,_correctAnswerId)
		{
	
		}

		public override bool IsAnswerCorrect(string[] answer)
		{
			if (answer.Length == 0 )
			{
				return false;
			}

			if (answer[0].ToLower() == CorrectAnswerId[0].ToLower())
			{
				return true;
			}
			else
			{
				return false;
			}

		}

		
	}
}

