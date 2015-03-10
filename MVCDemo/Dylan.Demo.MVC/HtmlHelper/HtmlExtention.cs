using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Routing;
using System.Web.Mvc;
using System.Linq.Expressions;
using Dylan.Demo.MVC.Model;
using Dylan.Demo.MVC.BLL;

namespace Dylan.Demo.MVC.HtmlHelper
{
    public static class HtmlExtention
    {
        public static MvcHtmlString CheckBoxListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, 
            Expression<Func<TModel, TProperty>> expression, string dictionaryType)
        {
            List<DictionaryVM> dictionarys = DictionaryBLL.GetDictionaryByType(dictionaryType);
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression<TModel, TProperty>(expression, htmlHelper.ViewData);
            IEnumerable<string> currentValues = metadata.Model as IEnumerable<string>;
            string name = ExpressionHelper.GetExpressionText(expression);
            string fullHtmlFieldName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            TagBuilder div = new TagBuilder("div");
            if (dictionarys != null && dictionarys.Count > 0)
            {
                foreach (var item in dictionarys)
                {
                    TagBuilder label = new TagBuilder("label");
                    label.MergeAttribute("style", "width:70px");

                    TagBuilder input = new TagBuilder("input");
                    input.AddCssClass("ace");
                    input.MergeAttribute("name", fullHtmlFieldName);
                    input.MergeAttribute("type", "checkbox");
                    input.MergeAttribute("value", item.Value);
                    if (currentValues != null && currentValues.Contains(item.Value))
                    {
                        input.MergeAttribute("checked", "checked");
                    }

                    TagBuilder span = new TagBuilder("span");
                    span.AddCssClass("lbl");
                    span.InnerHtml = item.Name;

                    input.InnerHtml = span.ToString();
                    label.InnerHtml = input.ToString();
                    div.InnerHtml += label.ToString();
                }
            }
            return new MvcHtmlString(div.ToString());
        }
    }
}   