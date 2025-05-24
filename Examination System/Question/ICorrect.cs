using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Question
{
	public interface ICorrect
	{
		public bool IsAnswerCorrect(string[] answer);
	}
}
