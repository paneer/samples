﻿' <Snippet1>
Option Explicit
Option Strict

Imports System.IO
Imports System.Xml

Public Class Sample
    Private Shared filename As String = "sampledata.xml"
    Public Shared Sub Main()
        Dim writer As XmlTextWriter = Nothing
        
        writer = New XmlTextWriter(filename, Nothing)
        'Use indenting for readability.
        writer.Formatting = Formatting.Indented
        
        'Write the XML delcaration. 
        writer.WriteStartDocument()
        
        'Write the ProcessingInstruction node.
        Dim PItext As String = "type='text/xsl' href='book.xsl'"
        writer.WriteProcessingInstruction("xml-stylesheet", PItext)
        
        'Write the DocumentType node.
        writer.WriteDocType("book", Nothing, Nothing, "<!ENTITY h 'hardcover'>")
        
        'Write a Comment node.
        writer.WriteComment("sample XML")
        
        'Write a root element.
        writer.WriteStartElement("book")
        
        'Write the genre attribute.
        writer.WriteAttributeString("genre", "novel")
        
        'Write the ISBN attribute.
        writer.WriteAttributeString("ISBN", "1-8630-014")
        
        'Write the title.
        writer.WriteElementString("title", "The Handmaid's Tale")
        
        'Write the style element.
        writer.WriteStartElement("style")
        writer.WriteEntityRef("h")
        writer.WriteEndElement()
        
        'Write the price.
        writer.WriteElementString("price", "19.95")
        
        'Write CDATA.
        writer.WriteCData("Prices 15% off!!")
        
        'Write the close tag for the root element.
        writer.WriteEndElement()
        
        writer.WriteEndDocument()
        
        'Write the XML to file and close the writer.
        writer.Flush()
        writer.Close()
        
        'Load the file into an XmlDocument to ensure well formed XML.
        Dim doc As New XmlDocument()
        'Preserve white space for readability.
        doc.PreserveWhitespace = True
        'Load the file.
        doc.Load(filename)
        
        'Display the XML content to the console.
        Console.Write(doc.InnerXml)
    End Sub
End Class 'Sample
' </Snippet1>