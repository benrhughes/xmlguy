# XMLGuy

XMLGuy is a fluent, lightweight, flexible XML builder for .NET. It is heavily inspired by [xmlbuilder-js](https://github.com/oozcitak/xmlbuilder-js).

## Usage
``` csharp
var doc = new XmlDocument();

doc.Begin("organisation")
	.Add("staff")
		.Add("member", new { name = "Joe Smith", age = "45" }).Up()
		.Add("member", new { name = "Jane Smith", age = "48" }).Up()
		.Up()
	.Add("offices")
		.Add("office", new { name = "Head Office", location = "Balmain, Sydney" }).Up()
		.Up()
	.Add("revenue", "0").Up()
	.Add("description").Data("This organisation is a world class leader in excellence").Up()
	.Add("investors");

Console.WriteLine(doc.ToString(true)); // enable pretty formatting
```

This will produce
``` xml
<?xml version="1.0" encoding="utf-8"?>
<organisation >
	<staff >
		<member name="Joe Smith" age="45"  />
		<member name="Jane Smith" age="48"  />
	</staff>
	<offices >
		<office name="Head Office" location="Balmain, Sydney"  />
	</offices>
	<revenue >0</revenue>
	<description >
		<![CDATA[This organisation is a world class leader in excellence]]>
	</description>
	<investors  />
</organisation>
```
## Installation
XMLGuy is available in [NuGet](http://nuget.org/packages/XmlGuy), which you can access via Visual Studio's package manager, or by running
```
Install-Package XmlGuy
```
from the package manager console.

Alternatively, you can download and build the source yourself.

## Current Status
As far as I know, XMLGuy produces valid XML for elements, attributes, text values and CData values.

It does not have an explict way of handling namespaces, but you can add them manually like this:
``` csharp
var doc = new XmlDocument();

var rss = doc.Begin("rss");
rss.Attributes = new Dictionary<string, string>()
{
	{"xmlns:content", "http://purl.org/rss/1.0/modules/content/"},
	{"xmlns:wfw", "http://wellformedweb.org/CommentAPI/"},
	{"xmlns:dc", "http://purl.org/dc/elements/1.1/"},
};
```

XMLGuy has not yet been extensively tested.

## Motivation
There are other libraries that attempt to make XML in .NET nicer to deal with, but they rely on the underlying .NET XML classes, which can make them a little clunky and inflexible. XMLGuy, on the other hand, simply builds up strings, so you're not bound by the limitations of those classes. Of course, this extra flexibility can mean that you can create invalid XML documents. 

I also prefer the fluent paradigm that I borrowed from xmlbuilder-js.
