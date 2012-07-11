/********
 * @version   : 2.0.0.rc2 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-07-10
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System.ComponentModel;

namespace Ext.Net
{
    /// <summary><![CDATA[
    /// JsonPProxy is useful when you need to load data from a domain other than the one your application is running on. If your application is running on http://domainA.com it cannot use Ajax to load its data from http://domainB.com because cross-domain ajax requests are prohibited by the browser.
    /// 
    /// We can get around this using a JsonPProxy. JsonPProxy injects a <script> tag into the DOM whenever an AJAX request would usually be made. Let's say we want to load data from http://domainB.com/users - the script tag that would be injected might look like this:
    /// 
    /// <script src="http://domainB.com/users?callback=someCallback"></script>
    /// When we inject the tag above, the browser makes a request to that url and includes the response as if it was any other type of JavaScript include. By passing a callback in the url above, we're telling domainB's server that we want to be notified when the result comes in and that it should call our callback function with the data it sends back. So long as the server formats the response to look like this, everything will work:
    /// 
    /// someCallback({
    ///     users: [
    ///         {
    ///             id: 1,
    ///             name: "Ed Spencer",
    ///             email: "ed@sencha.com"
    ///         }
    ///     ]
    /// });
    /// As soon as the script finishes loading, the 'someCallback' function that we passed in the url is called with the JSON object that the server returned.
    /// 
    /// JsonPProxy takes care of all of this automatically. It formats the url you pass, adding the callback parameter automatically. It even creates a temporary callback function, waits for it to be called and then puts the data into the Proxy making it look just like you loaded it through a normal AjaxProxy. Here's how we might set that up:
    /// 
    /// Ext.regModel('User', {
    ///     fields: ['id', 'name', 'email']
    /// });
    /// 
    /// var store = new Ext.data.Store({
    ///     model: 'User',
    ///     proxy: {
    ///         type: 'jsonp',
    ///         url : 'http://domainB.com/users'
    ///     }
    /// });
    /// 
    /// store.load();
    /// That's all we need to do - JsonPProxy takes care of the rest. In this case the Proxy will have injected a script tag like this:
    /// 
    /// <script src="http://domainB.com/users?callback=stcCallback001" id="stcScript001"></script>
    /// Customization
    ///
    /// Most parts of this script tag can be customized using the callbackParam, callbackPrefix and scriptIdPrefix configurations. For example:
    /// 
    /// var store = new Ext.data.Store({
    ///     model: 'User',
    ///     proxy: {
    ///         type: 'jsonp',
    ///         url : 'http://domainB.com/users',
    ///         callbackParam: 'theCallbackFunction',
    ///         callbackPrefix: 'ABC',
    ///         scriptIdPrefix: 'injectedScript'
    ///     }
    /// });
    /// 
    /// store.load();
    /// Would inject a script tag like this:
    /// 
    /// <script src="http://domainB.com/users?theCallbackFunction=ABC001" id="injectedScript001"></script>
    /// Implementing on the server side
    /// 
    /// The remote server side needs to be configured to return data in this format. Here are suggestions for how you might achieve this using ASP.net:
    /// 
    /// ASP.net:
    /// 
    /// String jsonString = "{success: true}";
    /// String cb = Request.Params.Get("callback");
    /// String responseString = "";
    /// if (!String.IsNullOrEmpty(cb)) {
    ///     responseString = cb + "(" + jsonString + ")";
    /// } else {
    ///     responseString = jsonString;
    /// }
    /// Response.Write(responseString);
    /// 
    /// 
    /// More information is available here: http://en.wikipedia.org/wiki/JSONP
    /// ]]></summary>
    [Meta]
    public partial class JsonPProxy : ServerProxy
    {
        /// <summary>
        /// 
        /// </summary>
        public JsonPProxy()
        {
        }
        
        /// <summary>
        /// Alias
        /// </summary>
        [ConfigOption]
        [DefaultValue(null)]
        protected override string Type
        {
            get
            {
                return "jsonp";
            }
        }

        /// <summary>
        /// True to automatically append the request's params to the generated url. Defaults to true
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("True to automatically append the request's params to the generated url. Defaults to true")]
        public virtual bool AutoAppendParams
        {
            get
            {
                return this.State.Get<bool>("AutoAppendParams", true);
            }
            set
            {
                this.State.Set("AutoAppendParams", value);
            }
        }

        /// <summary>
        /// Specifies the GET parameter that will be sent to the server containing the function name to be executed when the request completes. Defaults to callback. Thus, a common request will be in the form of url?callback=Ext.data.JsonP.callback1
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("Specifies the GET parameter that will be sent to the server containing the function name to be executed when the request completes. Defaults to callback. Thus, a common request will be in the form of url?callback=Ext.data.JsonP.callback1")]
        public virtual string CallbackKey
        {
            get
            {
                return this.State.Get<string>("CallbackKey", "");
            }
            set
            {
                this.State.Set("CallbackKey", value);
            }
        }

        /// <summary>
        /// The param name to use when passing records to the server (e.g. 'records=someEncodedRecordString'). Defaults to 'records'
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The param name to use when passing records to the server (e.g. 'records=someEncodedRecordString'). Defaults to 'records'")]
        public virtual string RecordParam
        {
            get
            {
                return this.State.Get<string>("RecordParam", "");
            }
            set
            {
                this.State.Set("RecordParam", value);
            }
        }
    }
}
