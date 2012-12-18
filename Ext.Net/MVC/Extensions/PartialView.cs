/********
 * @version   : 2.1.1 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-12-10
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System;
using System.Web.Mvc;
using System.Web;
using Ext.Net.Utilities;

namespace Ext.Net.MVC
{
    /// <summary>
    /// 
    /// </summary>
    public static class PartialViewExtensions
    {
        /// <summary>
        /// Renders the partial view with the parent's view data
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="partialViewName"></param>
        /// <returns></returns>
        public static IHtmlString ExtPartial(this HtmlHelper htmlHelper, string partialViewName)
        {
            return htmlHelper.ExtPartial(partialViewName, viewData: htmlHelper.ViewData);
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="htmlHelper"></param>
        ///// <param name="partialViewName"></param>
        ///// <param name="viewData"></param>
        ///// <param name="model"></param>
        ///// <param name="tempData"></param>
        ///// <param name="idMode"></param>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public static string RenderExtPartial(this HtmlHelper htmlHelper, string partialViewName, ViewDataDictionary viewData, object model, TempDataDictionary tempData, IDMode idMode, string id)
        //{
        //    if (String.IsNullOrEmpty(partialViewName))
        //    {
        //        throw new ArgumentException("Value cannot be null or empty.", "partialViewName");
        //    }

        //    return new PartialViewRenderer().Render(htmlHelper.ViewContext, partialViewName, viewData, model, tempData, idMode, id);
        //}
        
        /// <summary>
        /// Renders the partial view with the parent's view data
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="partialViewName"></param>
        /// <param name="viewData"></param>
        /// <param name="model"></param>
        /// <param name="tempData"></param>
        /// <param name="idMode"></param>
        /// <param name="controlId"></param>
        /// <param name="containerId"></param>
        /// <param name="index"></param>
        /// <param name="ns"></param>
        /// <param name="mode"></param>
        /// <param name="wrapByScriptTag"></param>
        /// <param name="singleControl"></param>
        /// <param name="items"></param>
        /// <param name="controlToRender"></param>
        /// <param name="containerConfig"></param>
        /// <returns></returns>
        public static IHtmlString ExtPartial(this HtmlHelper htmlHelper, 
            string partialViewName, 
            ViewDataDictionary viewData = null, 
            object model = null, 
            TempDataDictionary tempData = null, 
            IDMode idMode = IDMode.Static, 
            string controlId = null, 
            string containerId = null, 
            int index = 0, 
            string ns = null, 
            RenderMode mode = RenderMode.RenderTo, 
            bool wrapByScriptTag = true,
            bool singleControl = false,
            bool items = false,
            string controlToRender = null,
            Container.Config containerConfig = null)
        {
            if (String.IsNullOrEmpty(partialViewName))
            {
                throw new ArgumentException("Value cannot be null or empty.", "partialViewName");
            }

            string divId = null;
            if (containerId.IsEmpty() && mode == RenderMode.RenderTo)
            {
                containerId = BaseControl.GenerateID();
                divId = containerId;
            }

            PartialViewResult result = new PartialViewResult();
            result.WriteToString = true;

            result.ViewName = partialViewName;

            result.ViewData = viewData ?? htmlHelper.ViewData;

            if (model != null)
            {
                result.ViewData.Model = model;
            }

            if (tempData != null)
            {
                result.TempData = tempData;
            }

            result.IDMode = idMode;
            result.ControlId = controlId;
            result.ContainerId = containerId;
            result.Index = index;
            result.Namespace = ns;
            result.RenderMode = mode;
            result.WrapByScriptTag = wrapByScriptTag;
            result.SingleControl = singleControl;
            result.Items = items;
            result.ControlToRender = controlToRender;
            result.ContainerConfig = containerConfig;

            result.ExecuteResult(htmlHelper.ViewContext);

            if (divId != null)
            {
                return new HtmlString(string.Format("<div id=\"{0}\"></div>{1}", divId, result.Output));
            }

            return new HtmlString(result.Output);
        }
    }
}