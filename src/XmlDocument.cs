using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;

namespace XmlGuy
{
	public class XmlDocument
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

			var currentDepth = -1;

			Action<IXmlElement> recurse = null;
			recurse = e =>
				{
					currentDepth++;

					if (e.IsCData)
					{
						sb.Add("<![CDATA[" + e.Value + "]]>", pretty, currentDepth--);
						return;
					}

					sb.Add("<" + e.Name + ">", pretty && e.Value == null, currentDepth);

					if (e.Value != null)
						sb.Add(e.Value);
					else
						foreach (var child in e.Children)
							recurse(child);

					sb.Add("</" + e.Name + ">", pretty, currentDepth);

					currentDepth--;
				};

			recurse(RootElement);

			return sb.ToString();
		}
	}
}
