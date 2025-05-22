using Examination_System.Exam;
using Examination_System.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Examination_System.Json
{
    internal class JsonRootModel
	{
		[JsonConstructor]
		public JsonRootModel() { }
		[JsonPropertyName("exam")]
		public List<JsonExam> Exam { get; set; }
	}
}
