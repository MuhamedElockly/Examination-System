﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Question
{
	internal class QuestionSet : HashSet<MyQuestion>
	{
		public void Add(MyQuestion question)
		{
			base.Add(question);
		}


	}
}
