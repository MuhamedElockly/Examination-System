using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Examination_System.Json
{
	internal class JsonQuestion
	{
		[JsonConstructor]
		public JsonQuestion() { }
		[JsonPropertyName("header")]
		public string Header { get; set; }
		[JsonPropertyName("id")]
		public int Id { get; set; }
		[JsonPropertyName("body")]
		public string Body { get; set; }
		[JsonPropertyName("answers")]
		public List<JsonAnswer> Answers { get; set; }
		[JsonPropertyName("correct answer")]
		public List<string> CorrectAnswer { get; set; }
	}
}
