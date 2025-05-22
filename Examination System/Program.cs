using Examination_System.Answer;
using Examination_System.Exam;
using Examination_System.Json;
using Examination_System.Question;
using System.Text.Json;

namespace Examination_System
{
    internal static class Program
	{
		static void Main(string[] args)
		{			
			JsonHandler handler = new JsonHandler();
			MyExam myExam= handler.CreateExam();
			myExam.DisplayExam();
		}

	}
}
