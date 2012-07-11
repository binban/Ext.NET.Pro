/********
 * @version   : 2.0.0.rc2 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-07-10
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System;
using System.Collections.Generic;
using System.Text;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// Class for node instance manipulation
    /// </summary>
    public partial class NodeProxy : BaseItem
    {
        private object storeObj;        
        private string nodeScript;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="store"></param>
        /// <param name="nodeScript"></param>
        public NodeProxy(object store, string nodeScript)
        {
            this.storeObj = store;
            
            if(store is TreeStoreBase)
            {
                this.store = (TreeStoreBase)store;
                this.Owner = this.store;
            }
            if (store is TreePanelBase)
            {
                this.storeId = ((TreePanelBase)store).ClientID + ".store";
                this.Owner = (TreePanelBase)store;
            }
            else if(store is string){
                this.storeId = store as string;
            }
            
            
            this.nodeScript = nodeScript;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="store"></param>
        /// <param name="nodeScript"></param>
        /// <param name="isArray"></param>
        public NodeProxy(object store, string nodeScript, bool isArray) : this(store, nodeScript)
        {
            this.IsArray = isArray;
        }

        protected bool IsArray
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual string NodeInstance
        {
            get
            {
                return this.IsArray ? "node" : this.NodeScript;
            }
        }

        protected virtual string NodeScript
        {
            get
            {
                return "{0}.{1}".FormatWith(this.Store != null ? this.Store.ClientID : this.StoreId, this.nodeScript);
            }
        }

        private string storeId;
        private TreeStoreBase store;

        /// <summary>
        /// 
        /// </summary>
        protected virtual string StoreId
        {
            get
            {
                return this.storeId;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual TreeStoreBase Store
        {
            get
            {
                return this.store;
            }
        }

        private bool autoRegister = true;
        
        /// <summary>
        /// 
        /// </summary>
        public virtual bool AutoRegister
        {
            get
            {
                return this.autoRegister;
            }
            set
            {
                this.autoRegister = value;
            }
        }

        private bool safe;
        
        /// <summary>
        /// 
        /// </summary>
        public virtual bool Safe
        {
            get
            {
                return this.safe;
            }
            set
            {
                this.safe = value;
            }
        }

        private StringBuilder sb;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="script"></param>
        /// <param name="args"></param>
        public override void AddScript(string script, params object[] args)
        {
            if (args != null)
            {
                script = script.FormatWith(args);
            }

            if(this.Safe)
            {
                script = "if({0}){{{1}}}".FormatWith(this.NodeInstance, script);
            }

            if (this.IsArray)
            {
                script = "Ext.each({0}, function(node){{{1}}})".FormatWith(this.NodeScript, script);
            }

            if(this.AutoRegister)
            {
                base.AddScript(script, null);
            }
            else
            {
                if(this.sb == null)
                {
                    this.sb = new StringBuilder();
                }
                this.sb.Append(script);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="args"></param>
        public override void Call(string name, params object[] args)
        {
            StringBuilder sb = new StringBuilder();

            if (args != null && args.Length > 0)
            {
                foreach (object arg in args)
                {
                    sb.AppendFormat("{0},", JSON.Serialize(arg, JSON.ScriptConvertersInternal));
                }
            }

            string script = "{0}.{1}({2});".FormatWith(this.NodeInstance, name, sb.ToString().LeftOfRightmostOf(','));
            this.AddScript(script);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual string ToScript()
        {
            return this.ToScript(true);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clearBuffer"></param>
        /// <returns></returns>
        public virtual string ToScript(bool clearBuffer)
        {
            if(this.AutoRegister)
            {
                throw new Exception(ServiceMessages.TURN_OFF_AUTOREGISTER);
            }

            string s = this.sb.ToString();
            if(clearBuffer){
                this.sb.Length = 0;
            }

            return s;
        }

        /// <summary>
        /// Get proxy instance for root node
        /// </summary>
        /// <param name="store">TreeStore reference</param>
        /// <returns>NodeProxy</returns>
        public static NodeProxy GetRootNode(object store)
        {
            return new NodeProxy(store, "getRootNode()");
        }

        /// <summary>
        /// Get proxy instance for node with passed id
        /// </summary>
        /// <param name="store">TreeStore reference</param>
        /// <param name="id">Node id</param>
        /// <returns>NodeProxy</returns>
        public static NodeProxy GetNodeById(object store, object id)
        {
            return new NodeProxy(store, "getNodeById({0})".FormatWith(JSON.Serialize(id)));
        }

        /// <summary>
        /// An array of this nodes children. Array will be empty if this node has no chidren.
        /// </summary>
        /// <returns></returns>
        public virtual NodeProxy ChildNodes()
        {
            return new NodeProxy(this.storeObj, (this.IsArray ? "node" : this.nodeScript) + ".childNodes", true);
        }

        /// <summary>
        /// A reference to this node's first child node. null if this node has no children.
        /// </summary>
        /// <returns></returns>
        public virtual NodeProxy FirstChild()
        {
            return new NodeProxy(this.storeObj, (this.IsArray ? "node" : this.nodeScript) + ".firstChild");
        }

        /// <summary>
        /// A reference to this node's last child node. null if this node has no children.
        /// </summary>
        /// <returns></returns>
        public virtual NodeProxy LastChild()
        {
            return new NodeProxy(this.storeObj, (this.IsArray ? "node" : this.nodeScript) + ".lastChild");
        }

        /// <summary>
        /// A reference to this node's next sibling node. null if this node does not have a next sibling.
        /// </summary>
        /// <returns></returns>
        public virtual NodeProxy NextSibling()
        {
            return new NodeProxy(this.storeObj, (this.IsArray ? "node" : this.nodeScript) + ".nextSibling");
        }

        /// <summary>
        /// A reference to this node's parent node. null if this node is the root node.
        /// </summary>
        /// <returns></returns>
        public virtual NodeProxy ParentNode()
        {
            return new NodeProxy(this.storeObj, (this.IsArray ? "node" : this.nodeScript) + ".parentNode");
        }

        /// <summary>
        /// A reference to this node's previous sibling node. null if this node does not have a previous sibling.
        /// </summary>
        /// <returns></returns>
        public virtual NodeProxy PreviousSibling()
        {
            return new NodeProxy(this.storeObj, (this.IsArray ? "node" : this.nodeScript) + ".previousSibling");
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual string MethodScript
        {
            get
            {
                return this.NodeInstance + ".{0};";                
            }
        }

        /// <summary>
        /// Returns true if this node is an ancestor (at any point) of the passed node.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="trueFn"></param>
        /// <param name="falseFn"></param>
        public virtual void Contains(NodeProxy node, JFunction trueFn, JFunction falseFn)
        {
            this.AddScript("if({0}.contains({1})){{{2}}}else{{{3};}}", this.NodeInstance, node.NodeInstance, trueFn.ToCallScript(this.NodeInstance), falseFn.ToCallScript(this.NodeInstance));
        }

        /// <summary>
        /// Creates a copy (clone) of this Node.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="deep"></param>
        /// <returns></returns>
        public virtual NodeProxy Copy(object id, bool deep)
        {
            return new NodeProxy(this.storeObj, "{0}.copy({1}, {2})".FormatWith(this.IsArray ? "node" : this.nodeScript, JSON.Serialize(id), JSON.Serialize(deep)));
        }

        /// <summary>
        /// Creates a copy (clone) of this Node.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual NodeProxy Copy(object id)
        {
            return new NodeProxy(this.storeObj, "{0}.copy({1})".FormatWith(this.IsArray ? "node" : this.nodeScript, JSON.Serialize(id)));
        }

        /// <summary>
        /// Creates a copy (clone) of this Node.
        /// </summary>
        /// <returns></returns>
        public virtual NodeProxy Copy()
        {
            return new NodeProxy(this.storeObj, "{0}.copy()".FormatWith(this.IsArray ? "node" : this.nodeScript));
        }

        /// <summary>
        /// Ensures that the passed object is an instance of a Record with the NodeInterface applied
        /// </summary>
        /// <param name="nodeConfig"></param>
        /// <returns></returns>
        public virtual NodeProxy CreateNode(object nodeConfig)
        {
            return new NodeProxy(this.storeObj, "{0}.createNode({1})".FormatWith(this.IsArray ? "node" : this.nodeScript, JSON.Serialize(nodeConfig)));
        }

        /// <summary>
        /// Finds the first child that has the attribute with the specified value.
        /// </summary>
        /// <param name="attribute">The attribute name</param>
        /// <param name="value">The value to search for</param>
        /// <param name="deep"> True to search through nodes deeper than the immediate children</param>
        /// <returns></returns>
        public virtual NodeProxy FindChild(string attribute, object value, bool deep)
        {
            return new NodeProxy(this.storeObj, "{0}.findChild({1},{2},{3})".FormatWith(this.IsArray ? "node" : this.nodeScript, JSON.Serialize(attribute), JSON.Serialize(value), JSON.Serialize(deep)));
        }

        /// <summary>
        /// Finds the first child that has the attribute with the specified value.
        /// </summary>
        /// <param name="attribute">The attribute name</param>
        /// <param name="value">The value to search for</param>
        /// <returns></returns>
        public virtual NodeProxy FindChild(string attribute, object value)
        {
            return new NodeProxy(this.storeObj, "{0}.findChild({1},{2})".FormatWith(this.IsArray ? "node" : this.nodeScript, JSON.Serialize(attribute), JSON.Serialize(value)));
        }

        /// <summary>
        /// Finds the first child by a custom function. The child matches if the function passed returns true.
        /// </summary>
        /// <param name="fn">A function which must return true if the passed Node is the required Node.</param>
        /// <param name="scope">The scope (this reference) in which the function is executed. Defaults to the Node being tested.</param>
        /// <param name="deep">True to search through nodes deeper than the immediate children</param>
        /// <returns></returns>
        public virtual NodeProxy FindChildBy(JFunction fn, string scope, bool deep)
        {
            return new NodeProxy(this.storeObj, "{0}.findChildBy({1},{2},{3})".FormatWith(this.IsArray ? "node" : this.nodeScript, fn.ToScript(), scope, JSON.Serialize(deep)));
        }

        /// <summary>
        /// Finds the first child by a custom function. The child matches if the function passed returns true.
        /// </summary>
        /// <param name="fn">A function which must return true if the passed Node is the required Node.</param>
        /// <param name="scope">The scope (this reference) in which the function is executed. Defaults to the Node being tested.</param>
        /// <returns></returns>
        public virtual NodeProxy FindChildBy(JFunction fn, string scope)
        {
            return new NodeProxy(this.storeObj, "{0}.findChildBy({1},{2})".FormatWith(this.IsArray ? "node" : this.nodeScript, fn.ToScript(), scope));
        }

        /// <summary>
        /// Finds the first child by a custom function. The child matches if the function passed returns true.
        /// </summary>
        /// <param name="fn">A function which must return true if the passed Node is the required Node.</param>
        /// <returns></returns>
        public virtual NodeProxy FindChildBy(JFunction fn)
        {
            return new NodeProxy(this.storeObj, "{0}.findChildBy({1})".FormatWith(this.IsArray ? "node" : this.nodeScript, fn.ToScript()));
        }

        /// <summary>
        /// Returns the child node at the specified index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public virtual NodeProxy GetChildAt(int index)
        {
            return new NodeProxy(this.storeObj, "{0}.getChildAt({1})".FormatWith(this.IsArray ? "node" : this.nodeScript, index));
        }

        /// <summary>
        /// Returns true if this node has one or more child nodes, else false.
        /// </summary>
        /// <param name="trueFn"></param>
        /// <param name="falseFn"></param>
        public virtual void HasChildNodes(JFunction trueFn, JFunction falseFn)
        {
            this.AddScript("if({0}.hasChildNodes()){{{1}}}else{{{2};}}", this.NodeInstance, trueFn.ToCallScript(this.NodeInstance), falseFn.ToCallScript(this.NodeInstance));
        }

        /// <summary>
        /// Returns true if the passed node is an ancestor (at any point) of this node.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="trueFn"></param>
        /// <param name="falseFn"></param>
        public virtual void IsAncestor(NodeProxy node, JFunction trueFn, JFunction falseFn)
        {
            this.AddScript("if({0}.isAncestor({1})){{{2}}}else{{{3};}}", this.NodeInstance, node.NodeInstance, trueFn.ToCallScript(this.NodeInstance), falseFn.ToCallScript(this.NodeInstance));
        }

        /// <summary>
        /// Returns true if this node has one or more child nodes, or if the expandable node attribute is explicitly specified as true, otherwise returns false.
        /// </summary>
        /// <param name="trueFn"></param>
        /// <param name="falseFn"></param>
        public virtual void IsExpandable(JFunction trueFn, JFunction falseFn)
        {
            this.AddScript("if({0}.isExpandable()){{{1}}}else{{{2};}}", this.NodeInstance, trueFn.ToCallScript(this.NodeInstance), falseFn.ToCallScript(this.NodeInstance));
        }

        /// <summary>
        /// Returns true if this node is expaned
        /// </summary>
        /// <param name="trueFn"></param>
        /// <param name="falseFn"></param>
        public virtual void IsExpanded(JFunction trueFn, JFunction falseFn)
        {
            this.AddScript("if({0}.isExpanded()){{{1}}}else{{{2};}}", this.NodeInstance, trueFn.ToCallScript(this.NodeInstance), falseFn.ToCallScript(this.NodeInstance));
        }

        /// <summary>
        /// Returns true if this node is the first child of its parent
        /// </summary>
        /// <param name="trueFn"></param>
        /// <param name="falseFn"></param>
        public virtual void IsFirst(JFunction trueFn, JFunction falseFn)
        {
            this.AddScript("if({0}.isFirst()){{{1}}}else{{{2};}}", this.NodeInstance, trueFn.ToCallScript(this.NodeInstance), falseFn.ToCallScript(this.NodeInstance));
        }

        /// <summary>
        /// Returns true if this node is the last child of its parent
        /// </summary>
        /// <param name="trueFn"></param>
        /// <param name="falseFn"></param>
        public virtual void IsLast(JFunction trueFn, JFunction falseFn)
        {
            this.AddScript("if({0}.isLast()){{{1}}}else{{{2};}}", this.NodeInstance, trueFn.ToCallScript(this.NodeInstance), falseFn.ToCallScript(this.NodeInstance));
        }

        /// <summary>
        /// Returns true if this node is the last child of its parent
        /// </summary>
        /// <param name="trueFn"></param>
        /// <param name="falseFn"></param>
        public virtual void IsLeaf(JFunction trueFn, JFunction falseFn)
        {
            this.AddScript("if({0}.isLeaf()){{{1}}}else{{{2};}}", this.NodeInstance, trueFn.ToCallScript(this.NodeInstance), falseFn.ToCallScript(this.NodeInstance));
        }

        /// <summary>
        /// Returns true if this node is loaded
        /// </summary>
        /// <param name="trueFn"></param>
        /// <param name="falseFn"></param>
        public virtual void IsLoaded(JFunction trueFn, JFunction falseFn)
        {
            this.AddScript("if({0}.isLoaded()){{{1}}}else{{{2};}}", this.NodeInstance, trueFn.ToCallScript(this.NodeInstance), falseFn.ToCallScript(this.NodeInstance));
        }

        /// <summary>
        /// Returns true if this node is the root node
        /// </summary>
        /// <param name="trueFn"></param>
        /// <param name="falseFn"></param>
        public virtual void IsRoot(JFunction trueFn, JFunction falseFn)
        {
            this.AddScript("if({0}.isRoot()){{{1}}}else{{{2};}}", this.NodeInstance, trueFn.ToCallScript(this.NodeInstance), falseFn.ToCallScript(this.NodeInstance));
        }

        /// <summary>
        /// Returns true if this node is visible
        /// </summary>
        /// <param name="trueFn"></param>
        /// <param name="falseFn"></param>
        public virtual void IsVisible(JFunction trueFn, JFunction falseFn)
        {
            this.AddScript("if({0}.isVisible()){{{1}}}else{{{2};}}", this.NodeInstance, trueFn.ToCallScript(this.NodeInstance), falseFn.ToCallScript(this.NodeInstance));
        }

        /// <summary>
        /// Insert node(s) as the last child node of the root node.
        ///
        /// If the node was previously a child node of another parent node, it will be removed from that node first.
        /// </summary>
        /// <param name="node">The node or Array of nodes to append</param>
        public virtual void AppendChild(Node node)
        {
            this.Call("appendChild", new JRawValue(node.ToScript(false)));
        }

        /// <summary>
        /// Insert node(s) as the last child node of the node.
        ///
        /// If the node was previously a child node of another parent node, it will be removed from that node first.
        /// </summary>
        /// <param name="node">The node or Array of nodes to append</param>
        public virtual void AppendChild(NodeProxy node)
        {
            this.Call("appendChild", new JRawValue(node.NodeInstance));
        }

        /// <summary>
        /// Insert node(s) as the last child node of the root node.
        ///
        /// If the node was previously a child node of another parent node, it will be removed from that node first.
        /// </summary>
        /// <param name="nodes">The node or Array of nodes to append</param>
        public virtual void AppendChild(IEnumerable<Node> nodes)
        {
            List<JRawValue> listNodes = new List<JRawValue>();

            foreach (Node node in nodes)
            {
                listNodes.Add(new JRawValue(node.ToScript(false)));
            }

            this.Call("appendChild", listNodes);
        }

        /// <summary>
        /// Bubbles up the tree from this node, calling the specified function with each node. The arguments to the function will be the args provided or the current node. If the function returns false at any point, the bubble is stopped.
        /// </summary>
        /// <param name="function">The function to call</param>
        /// <param name="scope">The scope (this reference) in which the function is executed. Defaults to the current Node.</param>
        public virtual void Bubble(JFunction function, string scope)
        {
            if (function.Fn.IsEmpty() && function.Args == null)
            {
                function.Args = new[] { "node" };
            }

            this.Call("bubble", function, new JRawValue(scope));
        }

        /// <summary>
        /// Bubbles up the tree from this node, calling the specified function with each node. The arguments to the function will be the args provided or the current node. If the function returns false at any point, the bubble is stopped.
        /// </summary>
        /// <param name="function">The function to call</param>
        public virtual void Bubble(JFunction function)
        {
            if (function.Fn.IsEmpty() && function.Args == null)
            {
                function.Args = new[] { "node" };
            }

            this.Call("bubble", function);
        }

        /// <summary>
        /// Cascades down the tree from this node, calling the specified function with each node. The arguments to the function will be the args provided or the current node. If the function returns false at any point, the cascade is stopped on that branch.
        /// </summary>
        /// <param name="function">The function to call</param>
        /// <param name="scope">The scope (this reference) in which the function is executed. Defaults to the current Node.</param>
        public virtual void CascadeBy(JFunction function, string scope)
        {
            if (function.Fn.IsEmpty() && function.Args == null)
            {
                function.Args = new[] { "node" };
            }

            this.Call("cascadeBy", function, new JRawValue(scope));
        }

        /// <summary>
        /// Cascades down the tree from this node, calling the specified function with each node. The arguments to the function will be the args provided or the current node. If the function returns false at any point, the cascade is stopped on that branch.
        /// </summary>
        /// <param name="function">The function to call</param>
        public virtual void CascadeBy(JFunction function)
        {
            if (function.Fn.IsEmpty() && function.Args == null)
            {
                function.Args = new[] { "node" };
            }

            this.Call("cascadeBy", function);
        }

        /// <summary>
        /// Collapse this node.
        /// </summary>
        /// <param name="recursive">True to recursively collapse all the children</param>
        /// <param name="callback">The function to execute once the collapse completes</param>
        /// <param name="scope">The scope to run the callback in</param>
        public virtual void Collapse(bool recursive, JFunction callback, string scope)
        {
            this.Call("collapse", recursive, callback, new JRawValue(scope));
        }

        /// <summary>
        /// Collapse this node.
        /// </summary>
        /// <param name="recursive">True to recursively collapse all the children</param>
        /// <param name="callback">The function to execute once the collapse completes</param>
        public virtual void Collapse(bool recursive, JFunction callback)
        {
            this.Call("collapse", recursive, callback);
        }

        /// <summary>
        /// Collapse this node.
        /// </summary>
        /// <param name="recursive">True to recursively collapse all the children</param>
        public virtual void Collapse(bool recursive)
        {
            this.Call("collapse", recursive);
        }

        /// <summary>
        /// Collapse all the children of this node.
        /// </summary>
        /// <param name="recursive">True to recursively collapse all the children</param>
        /// <param name="callback">The function to execute once all the children are collapsed</param>
        /// <param name="scope">The scope to run the callback in</param>
        public virtual void CollapseChildren(bool recursive, JFunction callback, string scope)
        {
            this.Call("collapseChildren", recursive, callback, new JRawValue(scope));
        }

        /// <summary>
        /// Collapse all the children of this node.
        /// </summary>
        /// <param name="recursive">True to recursively collapse all the children</param>
        /// <param name="callback">The function to execute once all the children are collapsed</param>
        public virtual void CollapseChildren(bool recursive, JFunction callback)
        {
            this.Call("collapseChildren", recursive, callback);
        }

        /// <summary>
        /// Collapse all the children of this node.
        /// </summary>
        /// <param name="recursive">True to recursively collapse all the children</param>
        public virtual void CollapseChildren(bool recursive)
        {
            this.Call("collapseChildren", recursive);
        }

        /// <summary>
        /// Destroys the node.
        /// </summary>
        /// <param name="silent"></param>
        public virtual void Destroy(bool silent)
        {
            this.Call("destroy", silent);
        }

        /// <summary>
        /// Destroys the node.
        /// </summary>
        public virtual void Destroy()
        {
            this.Call("destroy");
        }

        /// <summary>
        /// Interates the child nodes of this node, calling the specified function with each node. The arguments to the function will be the args provided or the current node. If the function returns false at any point, the iteration stops.
        /// </summary>
        /// <param name="function">The function to call</param>
        /// <param name="scope">The scope (this reference) in which the function is executed. Defaults to the current Node in the iteration..</param>
        public virtual void EachChild(JFunction function, string scope)
        {
            if (function.Fn.IsEmpty() && function.Args == null)
            {
                function.Args = new[] { "node" };
            }

            this.Call("eachChild", function, new JRawValue(scope));
        }

        /// <summary>
        /// Interates the child nodes of this node, calling the specified function with each node. The arguments to the function will be the args provided or the current node. If the function returns false at any point, the iteration stops.
        /// </summary>
        /// <param name="function">The function to call</param>
        public virtual void EachChild(JFunction function)
        {
            if (function.Fn.IsEmpty() && function.Args == null)
            {
                function.Args = new[] { "node" };
            }

            this.Call("eachChild", function);
        }

        /// <summary>
        /// Expand this node.
        /// </summary>
        /// <param name="recursive">True to recursively expand all the children</param>
        /// <param name="callback">The function to execute once the expand completes</param>
        /// <param name="scope">The scope to run the callback in</param>
        public virtual void Expand(bool recursive, JFunction callback, string scope)
        {
            this.Call("expand", recursive, callback, new JRawValue(scope));
        }

        /// <summary>
        /// Expand this node.
        /// </summary>
        /// <param name="recursive">True to recursively expand all the children</param>
        /// <param name="callback">The function to execute once the expand completes</param>
        public virtual void Expand(bool recursive, JFunction callback)
        {
            this.Call("expand", recursive, callback);
        }

        /// <summary>
        /// Expand this node.
        /// </summary>
        /// <param name="recursive">True to recursively expand all the children</param>
        public virtual void Expand(bool recursive)
        {
            this.Call("expand", recursive);
        }

        /// <summary>
        /// Expand all the children of this node.
        /// </summary>
        /// <param name="recursive">True to recursively expand all the children</param>
        /// <param name="callback">The function to execute once all the children are expanded</param>
        /// <param name="scope">The scope to run the callback in</param>
        public virtual void ExpandChildren(bool recursive, JFunction callback, string scope)
        {
            this.Call("expandChildren", recursive, callback, new JRawValue(scope));
        }

        /// <summary>
        /// Expand all the children of this node.
        /// </summary>
        /// <param name="recursive">True to recursively expand all the children</param>
        /// <param name="callback">The function to execute once all the children are expanded</param>
        public virtual void ExpandChildren(bool recursive, JFunction callback)
        {
            this.Call("expandChildren", recursive, callback);
        }

        /// <summary>
        /// Expand all the children of this node.
        /// </summary>
        /// <param name="recursive">True to recursively expand all the children</param>
        public virtual void ExpandChildren(bool recursive)
        {
            this.Call("expandChildren", recursive);
        }

        /// <summary>
        /// Inserts the first node before the second node in this nodes childNodes collection.
        /// </summary>
        /// <param name="node">The node to insert</param>
        /// <param name="refNode">The node to insert before</param>
        public virtual void InsertBefore(NodeProxy node, NodeProxy refNode)
        {
            this.Call("insertBefore", new JRawValue(node.NodeInstance), new JRawValue(refNode.NodeInstance));
        }

        /// <summary>
        /// Inserts the first node before the second node in this nodes childNodes collection.
        /// </summary>
        /// <param name="node">The node to insert</param>
        /// <param name="refNode">The node to insert before</param>
        public virtual void InsertBefore(Node node, NodeProxy refNode)
        {
            this.Call("insertBefore", new JRawValue(node.ToScript()), new JRawValue(refNode.NodeInstance));
        }

        /// <summary>
        /// Insert a node into this node
        /// </summary>
        /// <param name="index">The zero-based index to insert the node at</param>
        /// <param name="node">The node to insert</param>
        public virtual void InsertChild(int index, Node node)
        {
            this.Call("insertChild", index, new JRawValue(node.ToScript()));
        }

        /// <summary>
        /// Insert a node into this node
        /// </summary>
        /// <param name="index">The zero-based index to insert the node at</param>
        /// <param name="refNode">The node to insert</param>
        public virtual void InsertChild(int index, NodeProxy refNode)
        {
            this.Call("insertChild", index, new JRawValue(refNode.NodeInstance));
        }

        /// <summary>
        /// Removes this node from its parent
        /// </summary>
        /// <param name="destroy">true to destroy the node upon removal. Defaults to false.</param>
        public virtual void Remove(bool destroy)
        {
            this.Call("remove", destroy);
        }

        /// <summary>
        /// Removes this node from its parent
        /// </summary>
        public virtual void Remove()
        {
            this.Call("remove");
        }

        /// <summary>
        /// Removes all child nodes from this node.
        /// </summary>
        /// <param name="destroy">true to destroy the node upon removal. Defaults to false.</param>
        public virtual void RemoveAll(bool destroy)
        {
            this.Call("removeAll", destroy);
        }

        /// <summary>
        /// Removes all child nodes from this node.
        /// </summary>
        public virtual void RemoveAll()
        {
            this.Call("removeAll");
        }

        /// <summary>
        /// Removes a child node from this node.
        /// </summary>
        /// <param name="node">The node to remove</param>
        /// <param name="destroy">true to destroy the node upon removal. Defaults to false.</param>
        public virtual void RemoveChild(NodeProxy node, bool destroy)
        {
            this.Call("removeChild", new JRawValue(node.NodeInstance), destroy);
        }

        /// <summary>
        /// Removes a child node from this node.
        /// </summary>
        /// <param name="node">The node to remove</param>
        public virtual void RemoveChild(NodeProxy node)
        {
            this.Call("removeChild", new JRawValue(node.NodeInstance));
        }

        /// <summary>
        /// Replaces one child node in this node with another.
        /// </summary>
        /// <param name="newChild">The replacement node</param>
        /// <param name="oldChild">The node to replace</param>
        public virtual void ReplaceChild(NodeProxy newChild, NodeProxy oldChild)
        {
            this.Call("replaceChild", new JRawValue(newChild.NodeInstance), new JRawValue(oldChild.NodeInstance));
        }

        /// <summary>
        /// Replaces one child node in this node with another.
        /// </summary>
        /// <param name="newChild">The replacement node</param>
        /// <param name="oldChild">The node to replace</param>
        public virtual void ReplaceChild(Node newChild, NodeProxy oldChild)
        {
            this.Call("replaceChild", new JRawValue(newChild.ToScript()), new JRawValue(oldChild.NodeInstance));
        }

        /// <summary>
        /// Sorts this nodes children using the supplied sort function.
        /// </summary>
        /// <param name="f">A function which, when passed two Nodes, returns -1, 0 or 1 depending upon required sort order.</param>
        /// <param name="recursive">Whether or not to apply this sort recursively</param>
        /// <param name="suppressEvent">Set to true to not fire a sort event.</param>
        public virtual void Sort(JFunction f, bool recursive, bool suppressEvent)
        {
            this.Call("sort", f, recursive, suppressEvent);
        }

        /// <summary>
        /// Sorts this nodes children using the supplied sort function.
        /// </summary>
        /// <param name="f">A function which, when passed two Nodes, returns -1, 0 or 1 depending upon required sort order.</param>
        /// <param name="recursive">Whether or not to apply this sort recursively</param>
        public virtual void Sort(JFunction f, bool recursive)
        {
            this.Call("sort", f, recursive);
        }

        /// <summary>
        /// Sorts this nodes children using the supplied sort function.
        /// </summary>
        /// <param name="f">A function which, when passed two Nodes, returns -1, 0 or 1 depending upon required sort order.</param>
        public virtual void Sort(JFunction f)
        {
            this.Call("sort", f);
        }

        #region Model
        /// <summary>
        /// Appends an event handler to this element (shorthand for addListener)
        /// </summary>
        /// <param name="eventName">The type of event to listen for</param>
        /// <param name="fn">The method the event invokes</param>
        [Meta]
        public virtual void On(string eventName, string fn)
        {
            this.Call("on", eventName, JRawValue.From(fn));
        }

        /// <summary>
        /// Appends an event handler to this element (shorthand for addListener)
        /// </summary>
        /// <param name="eventName">The type of event to listen for</param>
        /// <param name="fn">The method the event invokes</param>
        /// <param name="scope">The scope (this reference) in which the handler function is executed. If omitted, defaults to the object which fired the event.</param>
        [Meta]
        public virtual void On(string eventName, string fn, string scope)
        {
            this.Call("on", eventName, JRawValue.From(fn), JRawValue.From(scope));
        }

        /// <summary>
        /// Appends an event handler to this element (shorthand for addListener)
        /// </summary>
        /// <param name="eventName">The type of event to listen for</param>
        /// <param name="fn">The method the event invokes</param>
        /// <param name="scope">The scope (this reference) in which the handler function is executed. If omitted, defaults to the object which fired the event.</param>
        /// <param name="options">An object containing handler configuration.</param>
        [Meta]
        public virtual void On(string eventName, string fn, string scope, HandlerConfig options)
        {
            this.Call("on", eventName, JRawValue.From(fn), JRawValue.From(scope), JRawValue.From(options.Serialize()));
        }

        /// <summary>
        /// Appends an event handler to this element (shorthand for addListener)
        /// </summary>
        /// <param name="eventName">The type of event to listen for</param>
        /// <param name="fn">The method the event invokes</param>
        [Meta]
        public virtual void On(string eventName, JFunction fn)
        {
            this.Call("on", eventName, JRawValue.From(fn.ToScript()));
        }

        /// <summary>
        /// Appends an event handler to this element (shorthand for addListener)
        /// </summary>
        /// <param name="eventName">The type of event to listen for</param>
        /// <param name="fn">The method the event invokes</param>
        /// <param name="scope">The scope (this reference) in which the handler function is executed. If omitted, defaults to the object which fired the event.</param>
        [Meta]
        public virtual void On(string eventName, JFunction fn, string scope)
        {
            this.Call("on", eventName, JRawValue.From(fn.ToScript()), JRawValue.From(scope));
        }

        /// <summary>
        /// Appends an event handler to this element (shorthand for addListener)
        /// </summary>
        /// <param name="eventName">The type of event to listen for</param>
        /// <param name="fn">The method the event invokes</param>
        /// <param name="scope">The scope (this reference) in which the handler function is executed. If omitted, defaults to the object which fired the event.</param>
        /// <param name="options">An object containing handler configuration.</param>
        [Meta]
        public virtual void On(string eventName, JFunction fn, string scope, HandlerConfig options)
        {
            this.Call("on", eventName, JRawValue.From(fn.ToScript()), JRawValue.From(scope), JRawValue.From(options.Serialize()));
        }

        /// <summary>
        /// Removes an event handler.
        /// </summary>
        /// <param name="eventName">The type of event the handler was associated with.</param>
        /// <param name="fn">The handler to remove. This must be a reference to the function passed into the addListener call.</param>
        [Meta]
        public virtual void Un(string eventName, string fn)
        {
            this.Call("un", eventName.ToLowerInvariant(), new JRawValue(fn));
        }

        /// <summary>
        /// Removes an event handler.
        /// </summary>
        /// <param name="eventName">The type of event the handler was associated with.</param>
        /// <param name="fn">The handler to remove. This must be a reference to the function passed into the addListener call.</param>
        /// <param name="scope">The scope (this reference) in which the handler function is executed. If omitted, defaults to the object which fired the event.</param>
        [Meta]
        public virtual void Un(string eventName, string fn, string scope)
        {
            this.Call("un", eventName.ToLowerInvariant(), new JRawValue(fn), JRawValue.From(scope));
        }

        /// <summary>
        /// Begin an edit. While in edit mode, no events (e.g. the update event) are relayed to the containing store. When an edit has begun, it must be followed by either endEdit or cancelEdit.
        /// </summary>
        public void BeginEdit()
        {
            this.Call("beginEdit");
        }

        /// <summary>
        /// Cancels all changes made in the current edit operation.
        /// </summary>
        public void CancelEdit()
        {
            this.Call("cancelEdit");
        }

        /// <summary>
        /// Usually called by the Ext.data.Store which owns the model instance. Commits all changes made to the instance since either creation or the last commit operation.
        /// Developers should subscribe to the Ext.data.Store.update event to have their code notified of commit operations.
        /// </summary>
        public void Commit()
        {
            this.Call("commit");
        }

        /// <summary>
        /// Usually called by the Ext.data.Store which owns the model instance. Commits all changes made to the instance since either creation or the last commit operation.
        /// Developers should subscribe to the Ext.data.Store.update event to have their code notified of commit operations.
        /// </summary>
        /// <param name="silent">True to skip notification of the owning store of the change</param>
        public void Commit(bool silent)
        {
            this.Call("commit", silent);
        }

        /// <summary>
        /// End an edit. If any data was modified, the containing store is notified (ie, the store's update event will fire).
        /// </summary>
        public void EndEdit()
        {
            this.Call("endEdit");
        }

        /// <summary>
        /// End an edit. If any data was modified, the containing store is notified (ie, the store's update event will fire).
        /// </summary>
        /// <param name="silent">True to not notify the store of the change</param>
        public void EndEdit(bool silent)
        {
            this.Call("endEdit", silent);
        }

        /// <summary>
        /// Usually called by the Ext.data.Store to which this model instance has been joined. Rejects all changes made to the model instance since either creation, or the last commit operation. Modified fields are reverted to their original values.
        /// Developers should subscribe to the Ext.data.Store.update event to have their code notified of reject operations.
        /// </summary>
        public void Reject()
        {
            this.Call("reject");
        }

        /// <summary>
        /// Usually called by the Ext.data.Store to which this model instance has been joined. Rejects all changes made to the model instance since either creation, or the last commit operation. Modified fields are reverted to their original values.
        /// Developers should subscribe to the Ext.data.Store.update event to have their code notified of reject operations.
        /// </summary>
        /// <param name="silent">reject</param>
        public void Reject(bool silent)
        {
            this.Call("reject", silent);
        }

        /// <summary>
        /// Saves the model instance using the configured proxy
        /// </summary>
        public void Save()
        {
            this.Call("save");
        }

        /// <summary>
        /// Saves the model instance using the configured proxy
        /// </summary>
        /// <param name="options">Options to pass to the proxy</param>
        public void Save(object options)
        {
            this.Call("save", options);
        }

        /// <summary>
        /// Sets the given field to the given value, marks the instance as dirty
        /// </summary>
        /// <param name="fieldName">The field to set</param>
        /// <param name="value">The value to set</param>
        public void Set(string fieldName, object value)
        {
            this.Call("set", fieldName, value);
        }

        /// <summary>
        /// Marks this Record as dirty. This method is used interally when adding phantom records to a writer enabled store.
        /// Marking a record dirty causes the phantom to be returned by Ext.data.Store.getModifiedRecords where it will have a create action composed for it during store save operations.
        /// </summary>
        new public void SetDirty()
        {
            this.Call("setDirty");
        }

        /// <summary>
        /// Sets the model instance's id field to the given id
        /// </summary>
        /// <param name="id">The new id</param>
        public void SetId(object id)
        {
            this.Call("setId", id);
        }
        #endregion
    }
}
