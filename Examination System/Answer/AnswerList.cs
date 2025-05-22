using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Answer
{
	internal class AnswerList : List<MyAnswer>
	{
		public void Add(MyAnswer answer)
		{
			base.Add(answer);
		}
		public override bool Equals(object? obj)
		{
			if (obj == null || obj.GetType() != typeof(AnswerList))
			{
				return false;
			}
			AnswerList answerList = (AnswerList)obj;
			if (answerList.Count != this.Count)
			{
				return false;
			}
			foreach (MyAnswer answer in answerList)
			{
				if (!this.Contains(answer))
				{
					return false;
				}
			}
			return true;
		}
	}
}
