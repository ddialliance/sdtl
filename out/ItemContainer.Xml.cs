using System;
using System.Xml.Linq;

namespace model
{
    /// <summary>
    /// Partial class implementation for XML generation 
    /// <summary>
    public partial class ItemContainer
    { 
        public XDocument MakeXml()
        {
            XNamespace ns = "http://example.org/todo";
            XDocument xDoc = new XDocument(new XElement(ns + "ItemContainer", new XAttribute(XNamespace.Xmlns + "todo", "http://example.org/todo")));
            if (TopLevelReferences != null && TopLevelReferences.Count > 0)
            {
                foreach (var item in TopLevelReferences)
                {
                    xDoc.Root.Add(new XElement(ns + "TopLevelReference", new XElement(ns + "ID", item.ID), new XElement(ns + "TypeOfObject", item.GetType())));
                }
            }
            foreach (var item in Items)
            {
                xDoc.Root.Add(item.ToXml());
            }
            return xDoc;
        }
    }
}