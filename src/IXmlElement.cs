using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XmlGuy
{
	public interface IXmlElement
	{
		string Name { get; set; }
		string Value { get; set; }
		bool IsCData { get; set; }
		IList<IXmlElement> Children { get; set; }

		IXmlElement Up();
		IXmlElement Add(string name, params object[] args);
		IXmlElement CData(string data);
		IDictionary<string, string> Attributes { get; set; }
	}
}
