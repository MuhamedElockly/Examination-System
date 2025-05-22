using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Examination_System.Json
{
	internal class JsonAnswer
	{
		[JsonConstructor]
		public JsonAnswer() { }
		[JsonPropertyName("id")]
		public string Id { get; set; }
		[JsonPropertyName("body")]
		public string Body { get; set; }
	}
}
