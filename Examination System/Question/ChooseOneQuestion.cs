using Examination_System.Answer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Question
{
	internal class ChooseOneQuestion : MyQuestion
	{
		public ChooseOneQuestion(int _id, string _body, AnswerList _answerList, string[] _correctAnswerId) : base("Choose One !", _id, _body, _answerList,_correctAnswerId)
		{
			CorrectAnswerId = _correctAnswerId;
		}


		

		public override bool IsAnswerCorrect(string[] answer)
		{
			if (answer.Length != 1)
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
