using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XmlGuy
{
	public class XmlElement : IXmlElement
	{
		IXmlElement _parent;

		public XmlElement(IXmlElement parent = null, string name = null, string value = null)
		{
			Children = new List<IXmlElement>();

			_parent = parent;
			Name = name;
			Value = value;
		}

		public IList<IXmlElement> Children { get; set; }
		public string Name { get; set; }
		public string Value { get; set; }
		public bool IsCData { get; set; }

		public IXmlElement Up()
		{
			return _parent;
		}

		public IXmlElement Add(string name = null, string value = null)
		{
			return Add(name, value, false);
		}

		private IXmlElement Add(string name = null, string value = null, bool isCData = false)
		{
			if (Value != null)
				throw new InvalidOperationException("XML Element " + Name + " has a text value: it cannot contain child elements");

			var child = new XmlElement(this, name, value) { IsCData = isCData };
			Children.Add(child);
			return child;
		}

		public IXmlElement Data(string data)
		{
			Add(value: data, isCData: true);
			return this;
		}

		public IXmlElement Attribute(string name, string value)
		{
			throw new NotImplementedException();
		}
	}
}
