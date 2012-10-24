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
			var xml = new Xml();

			var feed = xml.Begin("feed");

			feed.Add("title", "A Test").Up()
				.Add("description", "This is a test").Up()
				.Add("parent")
					.Add("child", "A child of parent").Up()
					.Up()
				.Add("data").Data("I live in a CDATA tag").Up()
				.Add("One:LastNode");


			Console.WriteLine(xml.ToString(true));
		}
	}
}
