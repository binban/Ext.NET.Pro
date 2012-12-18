/********
 * @version   : 2.1.1 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-12-10
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System.Collections.Generic;
using System.ComponentModel;

namespace Ext.Net
{
    public partial class ResourceManager
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public const string OnReadyTemplate = "Ext.onReady(function(){{{0}}});";

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public const string ScriptBlockTemplate = "    <script type=\"text/javascript\">\n    //<![CDATA[\n        {0}\n    //]]>\n    </script>\n";

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public const string SimpleScriptBlockTemplate = "\n    <script type=\"text/javascript\">{0}</script>";

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public const string ScriptIncludeTemplate = "\n    <script type=\"text/javascript\" src=\"{0}\"></script>";

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public const string StyleBlockTemplate = "\n    <style type=\"text/css\">\n{0}\n    </style>";

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public const string StyleBlockItemTemplate = "\n        {0}";

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public const string StyleIncludeTemplate = "\n    <link type=\"text/css\" rel=\"stylesheet\" href=\"{0}\" />";

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public const string ThemeIncludeTemplate = "\n    <link type=\"text/css\" rel=\"stylesheet\" href=\"{0}\" id=\"ext-theme\" />";

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public const string CommentTemplate = "\n    <!-- {0} -->";

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public const string FunctionTemplate = "function(){{{0}}}";

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public const string FunctionTemplateWithParams = "function({0}){{{1}}}";

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public const string FilterMarker = "ExtNetInitScriptFilter";

        /// <summary>
        /// 
        /// </summary>        
        public const string INSTANCESCRIPT = "Ext.Net.ResourceMgr.InstanceScript";

        public const string GLOBAL_RESOURCES = "Ext.Net.GlobalResources";
        public const string GLOBAL_CLIENT_RESOURCES = "Ext.Net.GlobalClientResources";

        /// <summary>
        /// 
        /// </summary>
        public readonly static string WarningTemplate = "<Ext.Net.InitScript.Warning><script type=\"text/javascript\">Ext.onReady(function(){Ext.Msg.show({title:'Warning',msg:'The <code>web.config</code> file for this project is missing the required DirectRequestModule.<br /><br /><div style=\"margin-left:48px;\"><b>Example</b><br /><br /><code>&lt;system.web><br />&nbsp;&nbsp;&lt;httpModules><br />&nbsp;&nbsp;&nbsp;&nbsp;&lt;add name=\"DirectRequestModule\" type=\"Ext.Net.DirectRequestModule, Ext.Net\" /><br />&nbsp;&nbsp;&lt;/httpModules><br />&lt;/system.web></code><br /><br />More information available at \"<a href=\"http://examples.ext.net/?/Getting_Started/Introduction/Overview/\">Getting Started</a>\".</div><br />',buttons: Ext.Msg.OK,icon: Ext.MessageBox.WARNING});});</script></Ext.Net.InitScript.Warning>" + Transformer.NET.Net.CreateToken(typeof(Transformer.NET.ItemTag), new Dictionary<string, string> { { "selector", "warning" } }, "");

        /// <summary>
        /// 
        /// </summary>
        public readonly static string ViewStateToken = Transformer.NET.Net.CreateToken(typeof(Transformer.NET.ItemTag), new Dictionary<string, string> { { "selector", "viewstate" } }, "");

        /// <summary>
        /// 
        /// </summary>
        public readonly static string PostBackMethodToken = Transformer.NET.Net.CreateToken(typeof(Transformer.NET.ItemTag), new Dictionary<string, string> { { "selector", "postback" } }, "");

        /// <summary>
        /// 
        /// </summary>
        public readonly static string RemoveBlocksToken = Transformer.NET.Net.CreateToken(typeof(Transformer.NET.ItemTag), new Dictionary<string, string> { { "selector", "removeblocks" } }, "");

        /// <summary>
        /// 
        /// </summary>
        public readonly static string RemoveLeadingEmptyLines = Transformer.NET.Net.CreateToken(typeof(Transformer.NET.ItemTag), new Dictionary<string, string> { { "selector", "removeLeadingEmptyLines" } }, "");

        /// <summary>
        /// 
        /// </summary>
        public readonly static string RemoveLeadingEmptyLinesAfterForm = Transformer.NET.Net.CreateToken(typeof(Transformer.NET.ItemTag), new Dictionary<string, string> { { "selector", "removeLeadingEmptyLinesAfterForm" } }, "");

        /// <summary>
        /// 
        /// </summary>
        public readonly static string InputsToken = Transformer.NET.Net.CreateToken(typeof(InputFieldsTag), new Dictionary<string, string> { { "ref", "init_script" }, {"index", "-100"}}, "");

        /// <summary>
        /// 
        /// </summary>
        public readonly static string InputsVSToken = Transformer.NET.Net.CreateToken(typeof(InputFieldsTag), new Dictionary<string, string> { { "viewstate", "true" }, { "ref", "init_script" }, {"index", "-100"}}, "");
    }
}