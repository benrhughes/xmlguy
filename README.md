# XMLGuy

XMLGuy is a fluent, lightweight, flexible XML builder for .NET. It is heavily inspired by [xmlbuilder-js](https://github.com/oozcitak/xmlbuilder-js).

## Usage
``` csharp
var doc = new XmlDocument();

var org = doc.Begin("organisation");
org.Add("staff")
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

## Current Status
As far as I know, XMLGuy currently produces valid XML for elements, attributes, text values and CData values.

It does not currently support namespaces.

It has not yet been extensively tested.

## Motivation
I have a project that needs to create XML files with some non-standard element names, which none of the existing .NET XML frameworks seem to handle. 

Rather than rely on the underlying framework XML classes, XMLGuy simply builds up strings; meaning you can create elements with any name you like, no matter how stupid.

## Installation
For now, you'll need to pull the source and build it (there are no dependencies, unless you want to build the test project, which uses nUnit). 

Once it becomes more stable/feature complete I'll add it to nuget and have an assembly on github to download.
