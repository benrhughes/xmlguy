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
	}
}
