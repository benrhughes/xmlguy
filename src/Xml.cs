using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;

namespace XmlGuy
{
	public interface IXmlElement
	{
		string Name { get; set; }
		string Value { get; set; }
		bool IsCData { get; set; }
		IList<IXmlElement> Children { get; set; }

		IXmlElement Up();
		IXmlElement Add(string elementName, string value = null);
		IXmlElement Data(string data);
		IXmlElement Attribute(string name, string value);
	}

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

	public class Xml
	{
		public IXmlElement RootElement { get; private set; }

		public IXmlElement Begin(string rootElementName)
		{
			RootElement = new XmlElement(name: rootElementName);

			return RootElement;
		}

		public override string ToString()
		{
			return ToString(false);
		}

		public string ToString(bool pretty = false)
		{
			var sb = new StringBuilder();
			sb.Add(@"<?xml version=""1.0"" encoding=""utf-8""?>", pretty);

			Action<IXmlElement> recurse = null;
			recurse = e =>
				{
					if (e.IsCData)
					{
						sb.Add("<![CDATA[" + e.Value + "]]>");
						return;
					}

					sb.Add("<" + e.Name + ">", pretty && e.Value == null);

					if (e.Value != null)
						sb.Add(e.Value);
					else
						foreach (var child in e.Children)
							recurse(child);

					sb.Add("</" + e.Name + ">", pretty);
				};

			recurse(RootElement);

			return sb.ToString();
		}
	}
}
