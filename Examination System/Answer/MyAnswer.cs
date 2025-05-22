using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Answer
{
	internal class MyAnswer
	{
		public MyAnswer(string _answerId, string _answerBody)
		{
			AnswerId = _answerId;
			AnswerBody = _answerBody;
		}
		public string AnswerId { get; set; }
		public string AnswerBody { get; set; }
		public override string ToString()
		{
			return $"{AnswerId}- {AnswerBody}";
		}
	}
}
