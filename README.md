# XMLGuy

XMLGuy is a lightweight, flexible XML builder for .NET. It is heavily inspired by [xmlbuilder-js](https://github.com/oozcitak/xmlbuilder-js).

## Usage
``` csharp
var xml = new Xml();

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

## Motivation
For another project, I need to create a wordpress export file. This has some non-standard element names (like `wp:wxr\_version`) which none of the existing .NET XML frameworks seem to handle. 

## Current Status
XMLGuy is still under early development. It currently produces valid XML for elements, text values and CData values.

It does not currently support attributes or namespaces, though that will come.
