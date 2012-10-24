using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using XmlGuy;

namespace XmlGuyTests
{
	public class XmlTests
	{
		[Test]
		public void MyTest()
		{
			var doc = new XmlDocument();

			//var feed = doc.Begin("feed");

			//feed.Add("title", "A Test").Up()
			//    .Add("description", "This is a test", new { id = "desc", @class = "ohmy" }).Up()
			//    .Add("parent")
			//        .Add("child", "A child of parent").Up()
			//        .Up()
			//    .Add("data").Data("I live in a CDATA tag").Up()
			//    .Add("One:LastNode");

			var org = doc.Begin("organisation");
			org.Add("staff")
					.Add("member", new { name = "Joe Smith", age = "45" }).Up()
					.Add("member", new { name = "Jane Smith", age = "48" }).Up()
					.Up()
				.Add("offices")
					.Add("office", new { name = "Head Office", location = "Balmain, Sydney" }).Up()
					.Up()
				.Add("revenue", "0").Up()
				.Add("description").Data("This organisation is a world class leader in excellence").Up()
				.Add("investors");


			Console.WriteLine(doc.ToString(true));
		}
	}
}
