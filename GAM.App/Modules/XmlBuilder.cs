using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Linq;


public class XmlBuilder
{
    public class XNode 
    {
        public XNode(XmlNode node, string name, string text, XmlNodeList nodes)
        {
            Node = node;
            Name = name;
            Text = text;
            Nodes = nodes;
        }
        public XmlNode Node { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }

        public XmlNodeList Nodes;

        public XAttributes Attributes { get; set; }
        public bool HasAttributes
        {
            get
            {
                if (this.Attributes != null)
                    return true;
                else
                    return false;
            }
        }
        public bool HasChildNodes
        {
            get
            {
                if (this.Nodes.Count > 0)
                    return true;
                else
                    return false;
            }
        }


        public List<XmlNode> GetChildNodes(string tagName)
        {
            List<XmlNode> list = new List<XmlNode>();

            if (Nodes != null)
            {
                foreach (XmlNode n in Nodes)
                {
                    if (n.Name == tagName)
                    {
                        list.Add(n);
                    }
                }
            }

            return list;
        }
        public XmlNode GetFirstChildNode(string tagName)
        {
            if (Nodes != null)
            {
                foreach (XmlNode n in Nodes)
                {
                    if (n.Name == tagName)
                    {
                        return n;
                    }
                }
            }

            return null;
        }
        public XmlAttribute GetXAttribute(string attributeName)
        {
            if (this != null)
            {
                foreach (XmlAttribute att in Node.Attributes)
                {
                    if (att.Name == attributeName)
                    {
                        return att; 
                    }
                }
            }

            return null;
        }
        public bool HasXAttribute(string attributeName)
        {
            if (this != null)
            {
                foreach (XmlAttribute att in Node.Attributes)
                {
                    if (att.Name == attributeName)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

    }
    public class XAttribute
    {
        public XAttribute(string name, string text)
        {
            Name = name;
            Text = text;
        }
        public string Name { get; set; }
        public string Text { get; set; }
    }

    public class XAttributes : List<XAttribute>
    {
        public string this[string attributeName]
        {
            get
            {
                if (this != null)
                {
                    foreach (XAttribute att in this)
                    {
                        if (att.Name == attributeName)
                        {
                            return att.Text;
                        }
                    }
                    return string.Empty;
                }
                else { return string.Empty; }
            }
        }
        public XAttribute GetXAttributeText(string attributeName)
        {
            if (this != null)
            {
                foreach (XAttribute att in this)
                {
                    if (att.Name == attributeName)
                    {
                        return att;
                    }
                }
                return null;
            }
            else { return null; }
        }

    }

    public class XmlNodes : XmlNodeList
    {
        public override int Count
        {
            get
            {
                return this.Count;
            }
        }

        public override System.Collections.IEnumerator GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override XmlNode Item(int index)
        {
            return this[index];
        }

        public XmlNode GetNodeByAttributeTag(string attributeTag, string value)
        {
            foreach (XmlNode n in this)
            {
                if (n.Attributes.Count > 0)
                {
                    foreach (XmlAttribute att in n.Attributes)
                    {
                        if (att.Name == attributeTag & att.InnerText == value)
                        {
                            return n;
                        }
                    }
                }
            }

            return null;
        }

        public XmlNode GetNodeByTag(string nodeName)
        {
            foreach (XmlNode n in this)
            {
                if (n.Name == nodeName)
                {
                    return n;
                }
            }

            return null;
        }

        public XmlAttribute GetAttribute(int nodeindex, string attributeName)
        {
            if (this != null)
            {
                foreach (XmlAttribute att in this[nodeindex].Attributes)
                {
                    if (att.Name == attributeName)
                    {
                        return att;
                    }
                }
            }
            return null;
        }

        public bool Remove(XNode xNode)
        {
            foreach (XmlNode n in this)
            {
                if (n.Name == xNode.Name & n.InnerText == xNode.Text)
                {
                    n.RemoveAll();
                    return true;
                }
            }

            return false;
        }

    }

    public class XNodes : List<XNode>
    {
        public XNode GetNodeByAttributeTag(string attributeName, string text)
        {
            foreach (XNode n in this)
            {
                if (n.HasAttributes)
                {
                    foreach (XAttribute att in n.Attributes)
                    {
                        if (att.Name == attributeName & att.Text == text)
                        {
                            return n;
                        }
                    }
                }
            }

            return null;
        }

        public XNode GetNodeByTag(string nodeName)
        {
            foreach (XNode n in this)
            {
                if (n.Name == nodeName)
                {
                    return n;
                }
            }

            return null;
        }

        public XAttribute GetAttribute(int nodeindex, string attributeName)
        {
            if (this != null)
            {
                return this[nodeindex].Attributes.Where(item => item.Name == attributeName).FirstOrDefault();
            }
            else { return null; }
        }

    }


    public static XmlDocument Document = null;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="savePath">save file name</param>
    /// <returns></returns>
    public static bool Save(string savePath)
    {
        try
        {
            if (Document != null)
            {
                Document.Save(savePath);
                return true;
            }
        }
        catch
        {   }
        return false;
    }

    public static string CreateFromXmlDoc(XmlDocument xmlDoc)
    {
        try
        {
            using (var stringWriter = new StringWriter())
            using (var xmlTextWriter = XmlWriter.Create(stringWriter))
            {
                xmlDoc.WriteTo(xmlTextWriter);
                xmlTextWriter.Flush();
                return stringWriter.GetStringBuilder().ToString();
            }
        }
        catch (System.Exception)
        {
            return string.Empty;
        }
    }


    public static void SaveXML(DataGridView dataGridView, string saveFilePath)
    {
        DataTable dt = new DataTable();
        for (int i = 1; i < dataGridView.Columns.Count + 1; i++)
        {
            DataColumn column = new DataColumn(dataGridView.Columns[i - 1].HeaderText);
            dt.Columns.Add(column);
        }
        int ColumnCount = dataGridView.Columns.Count;
        foreach (DataGridViewRow dr in dataGridView.Rows)
        {
            DataRow dataRow = dt.NewRow();
            for (int i = 0; i < ColumnCount; i++)
            {
                dataRow[i] = dr.Cells[i].Value;
            }

            dt.Rows.Add(dataRow);
        }

        DataSet ds = new DataSet();
        ds.Tables.Add(dt);
        XmlTextWriter textWriter = new XmlTextWriter(saveFilePath, Encoding.UTF8);
        textWriter.Formatting = Formatting.Indented;
        ds.WriteXml(textWriter);
        textWriter.Close();
    }
    public static void SaveXML(TreeView treeView, string saveFilePath)
    {
        XmlTextWriter textWriter = new XmlTextWriter(saveFilePath, Encoding.UTF8);
        textWriter.Formatting = Formatting.Indented;
        // writing the xml declaration tag
        textWriter.WriteStartDocument();
        //textWriter.WriteRaw("\r\n");
        // writing the main tag that encloses all node tags
        textWriter.WriteStartElement("TreeView");

        // save the nodes, recursive method
        SaveNodes(treeView.Nodes, textWriter);

        textWriter.WriteEndElement();

        textWriter.Close();
    }

    public static string CreateFromDataGrid(DataGridView dataGridView)
    {
        DataTable dt = new DataTable();
        for (int i = 1; i < dataGridView.Columns.Count + 1; i++)
        {
            DataColumn column = new DataColumn(dataGridView.Columns[i - 1].HeaderText);
            dt.Columns.Add(column);
        }
        int ColumnCount = dataGridView.Columns.Count;
        foreach (DataGridViewRow dr in dataGridView.Rows)
        {
            DataRow dataRow = dt.NewRow();
            for (int i = 0; i < ColumnCount; i++)
            {
                dataRow[i] = dr.Cells[i].Value;
            }

            dt.Rows.Add(dataRow);
        }

        DataSet ds = new DataSet();
        ds.Tables.Add(dt);

        return ds.GetXml();
    }
    public static string CreateFromTreeView(TreeView treeView)
    {
        StringWriter StringWriter = new StringWriter();
        XmlWriterSettings settings = new XmlWriterSettings() { Indent = true };
        XmlWriter textWriter = XmlWriter.Create(StringWriter, settings);
        // writing the xml declaration tag
        textWriter.WriteStartDocument();
        //textWriter.WriteRaw("\r\n");
        // writing the main tag that encloses all node tags
        textWriter.WriteStartElement("TreeView");

        // save the nodes, recursive method
        SaveNodes(treeView.Nodes, textWriter);

        textWriter.WriteEndElement();

        textWriter.Close();

        return StringWriter.ToString();
    }

    public static XmlDocument FillXmlDoc(string xml)
    {
        try
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            return doc;
        }
        catch (System.Exception)
        {
            return null;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dataGridView"></param>
    /// <param name="xml">Accepted xmlFilePath or xmlString input</param>
    public static void FillDataGridView(DataGridView dataGridView, string xml)
    {
        dataGridView.Rows.Clear();
        if (File.Exists(xml))
        {
            try
            {
                XmlReader xmlFile;
                xmlFile = XmlReader.Create(xml, new XmlReaderSettings());
                DataSet ds = new DataSet();
                ds.ReadXml(xmlFile);
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    dataGridView.Rows.Add(r.ItemArray);
                }
            }
            catch
            {
                dataGridView.DataSource = null;
            }

        }
        else if (xml.Length > 0)
        {
            try
            {
                DataSet ds = new DataSet();
                ds.ReadXml(XmlReader.Create(new StringReader(xml)));
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    dataGridView.Rows.Add(r.ItemArray);
                }
            }
            catch
            {
                dataGridView.DataSource = null;
            }

        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="treeView"></param>
    /// <param name="xml">Accepted xmlFilePath or xmlString input</param>
    public static void FillTreeView(TreeView treeView, string xml)
    {
        if (File.Exists(xml))
        {
            XmlTextReader reader = null;
            try
            {
                // disabling re-drawing of treeview till all nodes are added
                treeView.BeginUpdate();
                reader =
                    new XmlTextReader(xml);

                TreeNode parentNode = null;

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.Name == XmlNodeTag)
                        {
                            TreeNode newNode = new TreeNode();
                            bool isEmptyElement = reader.IsEmptyElement;

                            // loading node attributes
                            int attributeCount = reader.AttributeCount;
                            if (attributeCount > 0)
                            {
                                for (int i = 0; i < attributeCount; i++)
                                {
                                    reader.MoveToAttribute(i);

                                    SetAttributeitem(newNode, reader.Name, reader.Value);
                                }
                            }

                            // add new node to Parent Node or TreeView
                            if (parentNode != null)
                                parentNode.Nodes.Add(newNode);
                            else
                                treeView.Nodes.Add(newNode);

                            // making current node 'ParentNode' if its not empty
                            if (!isEmptyElement)
                            {
                                parentNode = newNode;
                            }

                        }
                    }
                    // moving up to in TreeView if end tag is encountered
                    else if (reader.NodeType == XmlNodeType.EndElement)
                    {
                        if (reader.Name == XmlNodeTag)
                        {
                            parentNode = parentNode.Parent;
                        }
                    }
                    else if (reader.NodeType == XmlNodeType.XmlDeclaration)
                    { //Ignore Xml Declaration                    
                    }
                    else if (reader.NodeType == XmlNodeType.None)
                    {
                        return;
                    }
                    else if (reader.NodeType == XmlNodeType.Text)
                    {
                        parentNode.Nodes.Add(reader.Value);
                    }

                }
            }
            finally
            {
                // enabling redrawing of treeview after all nodes are added
                treeView.EndUpdate();
                reader.Close();
            }

        }
        else if (xml.Length > 0)
        {
            XmlReader reader = null;
            try
            {
                // disabling re-drawing of treeview till all nodes are added
                treeView.BeginUpdate();
                reader = XmlReader.Create(new StringReader(xml));

                TreeNode parentNode = null;

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.Name == XmlNodeTag)
                        {
                            TreeNode newNode = new TreeNode();
                            bool isEmptyElement = reader.IsEmptyElement;

                            // loading node attributes
                            int attributeCount = reader.AttributeCount;
                            if (attributeCount > 0)
                            {
                                for (int i = 0; i < attributeCount; i++)
                                {
                                    reader.MoveToAttribute(i);

                                    SetAttributeitem(newNode, reader.Name, reader.Value);
                                }
                            }

                            // add new node to Parent Node or TreeView
                            if (parentNode != null)
                                parentNode.Nodes.Add(newNode);
                            else
                                treeView.Nodes.Add(newNode);

                            // making current node 'ParentNode' if its not empty
                            if (!isEmptyElement)
                            {
                                parentNode = newNode;
                            }

                        }
                    }
                    // moving up to in TreeView if end tag is encountered
                    else if (reader.NodeType == XmlNodeType.EndElement)
                    {
                        if (reader.Name == XmlNodeTag)
                        {
                            parentNode = parentNode.Parent;
                        }
                    }
                    else if (reader.NodeType == XmlNodeType.XmlDeclaration)
                    { //Ignore Xml Declaration                    
                    }
                    else if (reader.NodeType == XmlNodeType.None)
                    {
                        return;
                    }
                    else if (reader.NodeType == XmlNodeType.Text)
                    {
                        parentNode.Nodes.Add(reader.Value);
                    }

                }
            }
            finally
            {
                // enabling redrawing of treeview after all nodes are added
                treeView.EndUpdate();
                reader.Close();
            }
        }
    }

    public static XNodes GetXmlitems(string xpath, string xml)
    {
        XmlDocument doc = new XmlDocument();

        if (xml.Length > 0)
        {
            if (File.Exists(xml))
                doc.Load(xml);
            else
                doc.LoadXml(xml);

            XmlNodeList xnodes = doc.DocumentElement.SelectNodes(xpath);
            XNodes xmlList = new XNodes();
            foreach (XmlNode node in xnodes)
            {
                XNode n = new XNode(node, node.Name, node.InnerText.Trim(), node.ChildNodes);
                XAttributes a = new XAttributes();

                if (node.Attributes.Count > 0)
                {
                    foreach (XmlAttribute att in node.Attributes)
                    {
                        a.Add(new XAttribute(att.Name, att.Value ));
                    }
                }
                if (a.Count > 0)
                    n.Attributes = a;

                xmlList.Add(n);
            }

            Document = doc;
            return xmlList;
        }
        else
        {
           return null;
        }
    }


    // Xml tag for node, e.g. 'node' in case of <node></node>
    private const string XmlNodeTag = "node";

    // Xml attributes for node e.g. <node text="Asia" tag="" imageindex="1"></node>
    private const string XmlNodeTextAtt = "text";
    private const string XmlNodeChecked = "checked";
    private const string XmlNodeName = "name";
    private const string XmlNodeTagAtt = "tag";
    private const string XmlNodeImageIndexAtt = "imageindex";

    //System.IO.StringWriter s;


    private static void SaveNodes(TreeNodeCollection nodesCollection, XmlWriter xmlWriter)
    {
        for (int i = 0; i < nodesCollection.Count; i++)
        {
            TreeNode node = nodesCollection[i];
            xmlWriter.WriteStartElement(XmlNodeTag);
            xmlWriter.WriteAttributeString(XmlNodeName, node.Name);
            xmlWriter.WriteAttributeString(XmlNodeTextAtt, node.Text);
            if (node.ImageIndex >= 0 )
                xmlWriter.WriteAttributeString(XmlNodeImageIndexAtt, node.ImageIndex.ToString());
            xmlWriter.WriteAttributeString(XmlNodeChecked, node.Checked.ToString());

            if (node.Tag != null)
                xmlWriter.WriteAttributeString(XmlNodeTagAtt, node.Tag.ToString());

            // add other node properties to serialize here

            if (node.Nodes.Count > 0)
            {

                SaveNodes(node.Nodes, xmlWriter);

            }
            xmlWriter.WriteEndElement();
        }
    }

    private static void SaveNodes(TreeNodeCollection nodesCollection, XmlTextWriter textWriter)
    {
        for (int i = 0; i < nodesCollection.Count; i++)
        {
            TreeNode node = nodesCollection[i];
            textWriter.WriteStartElement(XmlNodeTag);
            textWriter.WriteAttributeString(XmlNodeName, node.Name);
            textWriter.WriteAttributeString(XmlNodeTextAtt, node.Text);
            if (node.ImageIndex >= 0)
                textWriter.WriteAttributeString(XmlNodeImageIndexAtt, node.ImageIndex.ToString());
            textWriter.WriteAttributeString(XmlNodeChecked, node.Checked.ToString());

            if (node.Tag != null)
                textWriter.WriteAttributeString(XmlNodeTagAtt, node.Tag.ToString());

            // add other node properties to serialize here

            if (node.Nodes.Count > 0)
            {

                SaveNodes(node.Nodes, textWriter);

            }
            textWriter.WriteEndElement();
        }
    }


    /// <summary>
    /// Used by Deserialize method for setting properties of TreeNode from xml node attributes
    /// </summary>
    /// <param name="node"></param>
    /// <param name="propertyName"></param>
    /// <param name="item"></param>
    private static void SetAttributeitem(TreeNode node, string propertyName, string item)
    {
        if (propertyName == XmlNodeName)
        {
            node.Name = item;
        }
        if (propertyName == XmlNodeTextAtt)
        {
            node.Text = item;
        }
        if (propertyName == XmlNodeChecked)
        {
            node.Checked = bool.Parse(item);
        }
        if (propertyName == XmlNodeImageIndexAtt)
        {
            node.ImageIndex = int.Parse(item);
        }
        if (propertyName == XmlNodeTagAtt)
        {
            node.Tag = item;
        }
    }


   static List<TreeNode> nodeList = new List<TreeNode>();
    private static void PrintRecursive(TreeNode treeNode)
    {
        // Print each node recursively.
        foreach (TreeNode tn in treeNode.Nodes)
        {
            nodeList.Add(tn);
            if (tn.Nodes.Count > 0)
            {
                PrintRecursive(tn);
            }
        }
    }

    // Call the procedure using the TreeView.
    public static List<TreeNode> TreeViewNodes(TreeView treeView)
    {
        nodeList.Clear();
        // Print each node recursively.
        TreeNodeCollection nodes = treeView.Nodes;
        foreach (TreeNode n in nodes)
        {
            nodeList.Add(n);
            if (n.Nodes.Count > 0)
            {
                PrintRecursive(n);
            }
        }

        return nodeList;
    }

    static List<TreeNode> findtreeviewNode = new List<TreeNode>();
    public static List<TreeNode> FindTreeViewNode(TreeView treeView, string tag, string name, string text)
    {
        findtreeviewNode.Clear();

        foreach (TreeNode n in TreeViewNodes(treeView))
        {
            if (n.Tag != null & tag.Length > 0)
            {
                if (n.Tag.ToString() == tag)
                {
                    findtreeviewNode.Add(n);
                }
            }

            if (name.Length > 0)
            {
                if (n.Name == name)
                {
                    findtreeviewNode.Add(n);
                }
            }

            if (text.Length > 0)
            {
                if (n.Text == text)
                {
                    findtreeviewNode.Add(n);
                }
            }
        }

        return findtreeviewNode;
    }

    private static void PrintRecursive(ToolStripMenuItem menuStrip)
    {
        // Print each node recursively.
        foreach (ToolStripMenuItem ms in menuStrip.DropDownItems)
        {
            ToolStripMenuItems.Add(ms);
            if (ms.HasDropDownItems)
            {
                PrintRecursive(ms);
            }
        }
    }
    public static List<ToolStripMenuItem> ToolStripMenuItems = new List<ToolStripMenuItem>();

    private static void PrintRecursive(ToolStripItemCollection menuStrip)
    {
        // Print each node recursively.
        foreach (ToolStripMenuItem ms in menuStrip)
        {
            ToolStripMenuItems.Add(ms);
            if (ms.HasDropDownItems)
            {
                PrintRecursive(ms);
            }
        }
    }

    // Call the procedure using the TreeView.
    public static void FillMenuStripItems(MenuStrip menuStrip)
    {
        ToolStripMenuItems.Clear();
        // Print each node recursively.
        ToolStripItemCollection items = menuStrip.Items;
        foreach (var i in items)
        {
            if (i is ToolStripMenuItem)
            {
                ToolStripMenuItem mnu = i as ToolStripMenuItem;
                ToolStripMenuItems.Add(mnu);
                if (mnu.HasDropDownItems)
                {
                    PrintRecursive(mnu.DropDownItems);
                }
            }
        }
    }

}