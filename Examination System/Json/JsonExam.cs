using Examination_System.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Examination_System.Json
{
    internal class JsonExam
	{
		[JsonConstructor]
		public JsonExam() { }
		[JsonPropertyName("type")]
		public string Type { get; set; }
		[JsonPropertyName("time")]
		public int Time { get; set; }
		[JsonPropertyName("questions")]
		public List<JsonQuestion> Questions { get; set; }
	}
}
