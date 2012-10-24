# XMLGuy

XMLGuy is a lightweight, flexible XML builder for .NET. It is heavily inspired by [xmlbuilder-js](https://github.com/oozcitak/xmlbuilder-js).

## Usage
``` csharp
var xml = new XmlDocument();

var feed = xml.Begin("feed");

feed.Add("title", "A Test").Up()
    .Add("description", "This is a test").Up()
    .Add("parent")
    	.Add("child", "A child of parent").Up()
    	.Up()
    .Add("data").Data("I live in a CDATA tag").Up()
    .Add("One:LastNode");

Console.WriteLine(xml.ToString(true)); // include pretty formatting
```

This will produce
``` xml
<?xml version="1.0" encoding="utf-8"?>
<feed>
  <title>A Test</title>
	<description>This is a test</description>
	<parent>
		<child>A child of parent</child>
	</parent>
	<data>
		<![CDATA[I live in a CDATA tag]]>
	</data>
	<One:LastNode/>
</feed>
```

## Motivation
For another project, I need to create a wordpress export file. This has some non-standard element names (like `wp:wxr_version`) which none of the existing .NET XML frameworks seem to handle. 

Rather than rely on the underlying framework XML classes, XMLGuy simply builds up strings; meaning you can create elements with any name you like, no matter how stupid.

## Current Status
XMLGuy is still under early development. It currently produces valid XML for elements, text values and CData values.

It does not currently support attributes or namespaces, though that will come.
