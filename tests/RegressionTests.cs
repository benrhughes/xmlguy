using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using XmlGuy;

namespace XmlGuyTests
{
	public class RegressionTests
	{
		[Test]
		public void RT1()
		{
			var doc = new XmlDocument();
			doc.Begin("bookstore")
				.Add("locations")
					.Add("location", new { store_id = "1", address = "21 Jump St", phone = "123456"}).Up()
					.Add("location", new { store_id = "2",  address = "342 Pitt St", phone = "9876543"}).Up()
					.Up()
				.Add("books")
					.Add("book", new {title = "The Enchiridion", price = "9.75"})
						.Add("author", "Epictetus").Up()
						.Add("stores_with_stock")
							.Add("store", new { store_id = "1"}).Up()
							.Up()
						.Up()
					.Add("book", new {title = "Signal to Noise", price = "5.82"})
						.Add("author", "Neil Gaiman").Up()
						.Add("author", "Dave McKean").Up()
						.Add("stores_with_stock")
							.Add("store", new { store_id = "1"}).Up()
							.Add("store", new { store_id = "2"}).Up()
							.Up()
						.Up()
					.Up()
				.Add("staff")
					.Add("member", new { firstname = "Ben", lastname = "Hughes", staff_id = "123"}).Up()
					.Add("member", new { firstname = "Freddie", lastname = "Smith", staff_id = "124"}).Up();
				
            Assert.AreEqual(Resource.BookstoreExpectedNotPretty, doc.ToString());
            Assert.AreEqual(Resource.BookstoreExpectedPretty, doc.ToString(true));

		    var xmlDoc = new System.Xml.XmlDocument();
            Assert.DoesNotThrow(() => xmlDoc.LoadXml(doc.ToString()));
		}
	}
}
