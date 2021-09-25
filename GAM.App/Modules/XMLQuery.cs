using System.Collections.Generic;
using System.IO;
using System.Xml.XPath;
using System.Linq;
using System.Xml.Linq;
using System.Collections.ObjectModel;
using System.Xml;

public class Elements : ObservableCollection<XElement>
{
    public XElement this[string elementName]
    {
        get
        {
            if (this != null)
            {
                foreach (XElement e in this.Elements())
                {
                    if (e.Name == elementName)
                    {
                        return e;
                    }
                }
            }
            return null;
        }
    }
    public XElement GetParent()
    {
        if (this != null)
        {
            XElement xnode = this.Elements().FirstOrDefault().Parent;
            return xnode;
        }
        else
        {
            return null;
        }
    }

    public XAttribute GetAttribute(int nodeIndex, string attributeName)
    {
        if (this != null)
        {
            foreach (XAttribute att in this[nodeIndex].Attributes())
            {
                if (att.Name == attributeName)
                {
                    return att;
                }
            }
        }
        return null;
    }
    public bool HasAttribute(int nodeIndex, string attributeName)
    {
        if (this != null)
        {
            if (this[nodeIndex].HasAttributes)
            {
                foreach (XAttribute att in this[nodeIndex].Attributes())
                {
                    if (att.Name == attributeName)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    public bool HasChild(int nodeIndex, string elementName)
    {
        if (this != null)
        {
            if (this[nodeIndex].HasElements)
            {
                foreach (XElement e in this[nodeIndex].Elements())
                {
                    if (e.Name == elementName)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }
    public void CreateChildIfNotFound(string elementName, string value)
    {
        if (this != null)
        {
            if (this[0].HasElements)
            {
                foreach (XElement e in this[0].Elements())
                {
                    if (e.Name == elementName)
                    {
                        e.Value = value;
                        return;
                    }
                }
            }

            this[0].Add(new XElement(elementName, value));
        }
    }

    public void CreateAttIfNotFound(string attributeName, string value)
    {
        if (this != null)
        {
            var y = this[0];
            if (this[0].HasAttributes)
            {
                foreach (XAttribute e in this[0].Attributes())
                {
                    if (e.Name == attributeName)
                    {
                        e.Value = value;
                        return;
                    }
                }
            }

            this[0].Add(new XAttribute(attributeName, value));
        }
    }
    public XElement GetChild(int nodeIndex, string childName)
    {
        if (this != null)
        {
            foreach (XElement ele in this[nodeIndex].Elements())
            {
                if (ele.Name == childName)
                {
                    return ele;
                }
            }
        }
        return null;
    }

}

class XMLQuery
{
    public XDocument xDocument = new XDocument();
    private string filePath = "";

    /// <summary>
    /// 
    /// </summary>
    /// <param name="xml">Xmlfile or xml string</param>
    public XMLQuery(string xmlFile)
    {
        Load(xmlFile);
    }
    private void Load(string xml)
    {
        if (File.Exists(xml))
        {
            filePath = xml;
            xDocument = XDocument.Load(xml);
        }
    }
    public Elements XQuery(string xpath)
    {
        if (xDocument != null)
        {
            Elements list = new Elements();
            var xnodes = xDocument.Root.XPathSelectElements(xpath).ToArray();
            foreach (XElement ele in xnodes)
            {
                list.Add(ele);
            }
            return list;
        }
        else
        {
            return null;
        }
    }

    public bool Save()
    {
        try
        {
            if (xDocument != null)
            {
                xDocument.Save(filePath);
                return true;
            }
        }
        catch
        { }
        return false;
    }

}

