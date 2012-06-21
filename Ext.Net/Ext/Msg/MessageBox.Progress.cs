/********
 * @version   : 2.0.0.rc1 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-06-19
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System.ComponentModel;

using Ext.Net.Utilities;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
    public partial class MessageBox
    {
        /// <summary>
        /// Displays a message box with a progress bar. This message box has no buttons and is not closeable by the user. You are responsible for updating the progress bar as needed via Ext.MessageBox.updateProgress and closing the message box when the process is complete.
        /// </summary>
        /// <param name="title">The title bar text</param>
        /// <param name="msg">The message box body text</param>
        [Description("Displays a message box with a progress bar. This message box has no buttons and is not closeable by the user. You are responsible for updating the progress bar as needed via Ext.MessageBox.updateProgress and closing the message box when the process is complete.")]
        public MessageBox Progress(string title, string msg)
        {
            return this.Progress(title, msg, "");
        }

        /// <summary>
        /// Displays a message box with a progress bar. This message box has no buttons and is not closeable by the user. You are responsible for updating the progress bar as needed via Ext.MessageBox.updateProgress and closing the message box when the process is complete.
        /// </summary>
        /// <param name="title">The title bar text</param>
        /// <param name="msg">The message box body text</param>
        /// <param name="progressText">(optional) The text to display inside the progress bar (defaults to '')</param>
        [Description("Displays a message box with a progress bar. This message box has no buttons and is not closeable by the user. You are responsible for updating the progress bar as needed via Ext.MessageBox.updateProgress and closing the message box when the process is complete.")]
        public MessageBox Progress(string title, string msg, string progressText)
        {
            MessageBoxConfig config = new MessageBoxConfig();
            config.Title = title;
            config.Message = msg;
            config.Progress = true;
            config.Closable = true;
            config.ProgressText = progressText;

            return this.Configure(config);
        }
    }
}