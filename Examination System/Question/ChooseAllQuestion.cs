using Examination_System.Answer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Question
{
	internal class ChooseAllQuestion : MyQuestion
	{
		public ChooseAllQuestion(int _id, string _body, AnswerList _answerList, string[] _correctAnswerId) : base("Choose All Correct Answers separated by comma!", _id, _body, _answerList,_correctAnswerId)
		{
	
		}
		public override bool IsAnswerCorrect(string[] answer)
		{
			
			if (answer.Length != CorrectAnswerId.Length || answer[0].GetType() != typeof(string))
			{
				//Console.WriteLine($"{answer.Length} , {CorrectAnswerId.Length}");
				return false;
			}
			for (int i = 0; i < answer.Length; i++)
			{
				if (CorrectAnswerId[i].ToLower() != answer[i].ToLower())
				{
					return false;
				}
			}
			return true;
		}




	}
}
