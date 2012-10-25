using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XmlGuy
{
	public class XmlElement : IXmlElement
	{
		IXmlElement _parent;

		public XmlElement(IXmlElement parent = null)
		{
			Children = new List<IXmlElement>();
			Attributes = new Dictionary<string, string>();

			_parent = parent;
		}

		public IList<IXmlElement> Children { get; set; }
		public IDictionary<string, string> Attributes { get; set; }
		public string Name { get; set; }
		public string Value { get; set; }
		public bool IsCData { get; set; }

		public IXmlElement Up()
		{
			return _parent;
		}

		public IXmlElement Add(string name, params object[] args)
		{
			string value = null;
			object attribObject = null;
			Dictionary<string, string> attributes = new Dictionary<string,string>();

			if (args != null)
			{
				foreach (var arg in args)
				{
					if (arg is string)
						value = arg as string;
					else
						attribObject = arg;
				}

				if (attribObject != null)
				{
					foreach (var prop in attribObject.GetType().GetProperties())
					{
						attributes.Add(prop.Name, prop.GetValue(attribObject, null) as string);
					}
				}
			}

			return Add(name, value, false, attributes);
		}

		private IXmlElement Add(
			string name = null, 
			string value = null, 
			bool isCData = false, 
			IDictionary<string, string> attributes = null)
		{
			if (Value != null)
				throw new InvalidOperationException("XML Element " + Name + " has a text value: it cannot contain child elements");

			var child = new XmlElement(this) {Name = name, Value = value, IsCData = isCData, Attributes = attributes };
			Children.Add(child);
			return child;
		}

		public IXmlElement CData(string data)
		{
			Add(value: data, isCData: true);
			return this;
		}
	}
}
