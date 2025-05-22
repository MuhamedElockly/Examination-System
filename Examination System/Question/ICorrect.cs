using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Question
{
	internal interface ICorrect
	{
		public bool IsAnswerCorrect(string[] answer);
	}
}
