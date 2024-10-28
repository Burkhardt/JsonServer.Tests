using Newtonsoft.Json.Linq;
using Xunit;
//using JsonServer.Services;
using System.Diagnostics;

namespace JsonServer.Tests
{
	/// <summary>
	/// Here are some tests from swagger – as curl commands
	/// 	URL: http://localhost:5054/swagger/index.html
	///		time curl -X 'GET' \
	///		'http://localhost:5054/api/Dynamic/query?filter=item.Name%20%21%3D%20%22Otto%22&sort=Age%3Aasc%2CModified%3Adesc&select=Name%2C%20Spouse%2C%20Modified%2C%20Children' \
	///		-H 'accept: application/json'
	///		curl -X 'GET' \
	///		'http://localhost:5054/api/Dynamic/query?filter=%28%28%28string%29item.Name%29.StartsWith%28%27N%27%29%20%7C%7C%20%28%28string%29item.Name%29.EndsWith%28%27t%27%29%29%20&sort=Age%3Aasc%2CModified%3Adesc&select=Name%2C%20Spouse%2C%20Modified%2C%20Children%2C%20Kids&topN=1' \
	///		-H 'accept: application/json'
	///			curl -X 'GET' \
	///		'http://localhost:5054/api/Dynamic/Nina?select=Name%2CAge%2CKids&topN=1' \
	///		-H 'accept: */*'
	///		curl -X 'POST' \
	///		'http://localhost:5054/api/Dynamic' \
	///		-H 'accept: */*' \
	///		-H 'Content-Type: application/json' \
	///		-d '{ "Name": "Kilian", "Age": 30 }'
	///		curl -X 'GET' \
	///		'http://localhost:5054/api/Dynamic/Kilian?select=Name%2CAge%2CModified%2CDeleted&topN=1' \
	///		-H 'accept: */*'
	///		curl -X 'GET' \
	///		'http://localhost:5054/api/Dynamic/query?filter=item.Name.ToString%28%29.StartsWith%28%22Nina%22%29%20%7C%7C%20%20%20%20%20%20%20%20%20%20%20%20%20%20%20%20%20item.Name%20%3D%3D%20%22Hannah%22%20%7C%7C%20%20%20%20%20%20%20%20%20%20%20%20%20%20%20%20%20item.Name%20%3D%3D%20%22Vuyisile%22%20%7C%7C%20%20%20%20%20%20%20%20%20%20%20%20%20%20%20%20%20item.Name%20%3D%3D%20%22Kilian%22%20%7C%7C%20%20%20%20%20%20%20%20%20%20%20%20%20%20%20%20%20item.Name%20%3D%3D%20%22Laura%22%20%7C%7C%20%20%20%20%20%20%20%20%20%20%20%20%20%20%20%20%20item.Name%20%3D%3D%20%22Mbali%22%20%7C%7C%20%20%20%20%20%20%20%20%20%20%20%20%20%20%20%20%20item.Name%20%3D%3D%20%22Logan%22&select=Name%2CKids' \
	///		-H 'accept: application/json'
	/// </summary>
	/// <remarks>TODO: add those tests as system calls using RaiSystem... works on any UNIX</remarks>
	public class PitExpressionsTests
	{
		private readonly JObject sampleObject = JObject.Parse(@"{
			'Name': 'Hannah',
			'Age': 35,
			'Spouse': 'Thomas',
			'Children': [
				{ 'Name': 'Anna', 'Age': 5 },
				{ 'Name': 'Ben', 'Age': 8 }
			]
		}");

		private readonly JObject anotherSampleObject = JObject.Parse(@"{
			'Name': 'Tom',
			'Age': 40,
			'Spouse': 'Mina',
			'Children': [
				{ 'Name': 'Nina', 'Age': 3 }
			]
		}");

		private IEnumerable<JObject> GetSampleObjects()
		{
			var sampleObject1 = new JObject {
				{ "Name", "Nomsa" },
				{ "Age", 52 },
				{ "Kids", new JArray { "Vuyisile", "Mbali", "Logan" } }
			};
			var sampleObject2 = new JObject {
				{ "Name", "Rainer" },
				{ "Age", 61 },
				{ "Spouse", "Nomsa" }
			};
			var sampleObject3 = new JObject {
				{ "Name", "Nina" },
				{ "Age", 35 },
				{ "Spouse", "Tom" }
			};
			var sampleObject4 = new JObject {
				{ "Name", "Hannah" },
				{ "Age", 33 }
			};
			return new List<JObject> { sampleObject1, sampleObject2, sampleObject3, sampleObject4 };
		}
	}
}
