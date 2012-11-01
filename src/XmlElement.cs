using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XmlGuy
{
	public class XmlElement : AbstractXmlElement
	{
		public XmlElement(XmlElement parent = null) : base(parent)
		{
			Children = new List<IXmlElement>();
			Attributes = new Dictionary<string, string>();
		}

		public IList<IXmlElement> Children { get; set; }
		public IDictionary<string, string> Attributes { get; set; }

		public XmlElement Up()
		{
			return Parent;
		}

		public XmlElement Add(string name, params object[] args)
		{
			string value = null;
			Dictionary<string, string> attributes = new Dictionary<string, string>();

			if (args != null)
			{
				foreach (var arg in args)
				{
					if (arg is string)
						value = arg as string;
					else
						foreach (var prop in arg.GetType().GetProperties())
							attributes.Add(prop.Name, prop.GetValue(arg, null) as string);
				}
			}

			return Add(name, value, attributes);
		}

		private XmlElement Add(string name, string value, IDictionary<string, string> attributes)
		{
			if (Value != null)
				throw new InvalidOperationException("XML Element " + Name + " has a text value: it cannot contain child elements");

			var child = new XmlElement(this) { Name = name, Value = value, Attributes = attributes };
			Children.Add(child);
			return child;
		}

		public XmlElement CData(string data)
		{
			Children.Add(new CDataElement(this) { Value = data });
			return this;
		}
	}

	public class CDataElement : AbstractXmlElement
	{
		public CDataElement(XmlElement parent = null) : base(parent)
		{

		}
	}
}
