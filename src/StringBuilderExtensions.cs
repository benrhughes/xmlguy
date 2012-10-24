using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XmlGuy
{
	public static class StringBuilderExtensions
	{
		public static void Add(this StringBuilder sb, string s, bool pretty = false, int tabs = 0)
		{
			for (int i = 0; i < tabs; i++)
				s = "\t" + s;

			if (pretty)
				sb.AppendLine(s);
			else
				sb.Append(s);
		}
	}
}
