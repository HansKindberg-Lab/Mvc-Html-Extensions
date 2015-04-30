using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace Company.Web.Mvc.Html
{
	public interface ITagHelper
	{
		#region Methods

		IHtmlString AttributesToHtml(IDictionary<string, object> attributes);
		IHtmlString AttributesToHtml(IDictionary<string, object> attributes, bool leadingSpace, bool trailingSpace);
		IDictionary<string, object> BuildAttributes(HtmlHelper htmlHelper);
		IDictionary<string, object> BuildAttributes(HtmlHelper htmlHelper, object attributes);
		IDictionary<string, object> BuildAttributes(HtmlHelper htmlHelper, IDictionary<string, object> attributes);
		IDictionary<string, object> BuildAttributes(string expression, HtmlHelper htmlHelper);
		IDictionary<string, object> BuildAttributes(string expression, HtmlHelper htmlHelper, object attributes);
		IDictionary<string, object> BuildAttributes(string expression, HtmlHelper htmlHelper, IDictionary<string, object> attributes);
		IDictionary<string, object> BuildAttributes<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression, HtmlHelper<TModel> htmlHelper);
		IDictionary<string, object> BuildAttributes<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression, HtmlHelper<TModel> htmlHelper, object attributes);
		IDictionary<string, object> BuildAttributes<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression, HtmlHelper<TModel> htmlHelper, IDictionary<string, object> attributes);
		IDictionary<string, object> BuildInputAttributes(HtmlHelper htmlHelper);
		IDictionary<string, object> BuildInputAttributes(HtmlHelper htmlHelper, object attributes);
		IDictionary<string, object> BuildInputAttributes(HtmlHelper htmlHelper, IDictionary<string, object> attributes);
		IDictionary<string, object> BuildInputAttributes(string expression, HtmlHelper htmlHelper);
		IDictionary<string, object> BuildInputAttributes(string expression, HtmlHelper htmlHelper, object attributes);
		IDictionary<string, object> BuildInputAttributes(string expression, HtmlHelper htmlHelper, IDictionary<string, object> attributes);
		IDictionary<string, object> BuildInputAttributes<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression, HtmlHelper<TModel> htmlHelper);
		IDictionary<string, object> BuildInputAttributes<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression, HtmlHelper<TModel> htmlHelper, object attributes);
		IDictionary<string, object> BuildInputAttributes<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression, HtmlHelper<TModel> htmlHelper, IDictionary<string, object> attributes);
		IDictionary<string, object> BuildTextAreaAttributes(HtmlHelper htmlHelper);
		IDictionary<string, object> BuildTextAreaAttributes(HtmlHelper htmlHelper, object attributes);
		IDictionary<string, object> BuildTextAreaAttributes(HtmlHelper htmlHelper, IDictionary<string, object> attributes);
		IDictionary<string, object> BuildTextAreaAttributes(string expression, HtmlHelper htmlHelper);
		IDictionary<string, object> BuildTextAreaAttributes(string expression, HtmlHelper htmlHelper, object attributes);
		IDictionary<string, object> BuildTextAreaAttributes(string expression, HtmlHelper htmlHelper, IDictionary<string, object> attributes);
		IDictionary<string, object> BuildTextAreaAttributes<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression, HtmlHelper<TModel> htmlHelper);
		IDictionary<string, object> BuildTextAreaAttributes<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression, HtmlHelper<TModel> htmlHelper, object attributes);
		IDictionary<string, object> BuildTextAreaAttributes<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression, HtmlHelper<TModel> htmlHelper, IDictionary<string, object> attributes);
		IDictionary<string, object> BuildTextInputAttributes(HtmlHelper htmlHelper);
		IDictionary<string, object> BuildTextInputAttributes(HtmlHelper htmlHelper, object attributes);
		IDictionary<string, object> BuildTextInputAttributes(HtmlHelper htmlHelper, IDictionary<string, object> attributes);
		IDictionary<string, object> BuildTextInputAttributes(string expression, HtmlHelper htmlHelper);
		IDictionary<string, object> BuildTextInputAttributes(string expression, HtmlHelper htmlHelper, object attributes);
		IDictionary<string, object> BuildTextInputAttributes(string expression, HtmlHelper htmlHelper, IDictionary<string, object> attributes);
		IDictionary<string, object> BuildTextInputAttributes<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression, HtmlHelper<TModel> htmlHelper);
		IDictionary<string, object> BuildTextInputAttributes<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression, HtmlHelper<TModel> htmlHelper, object attributes);
		IDictionary<string, object> BuildTextInputAttributes<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression, HtmlHelper<TModel> htmlHelper, IDictionary<string, object> attributes);
		void SortAttributes(IDictionary<string, object> attributes);

		#endregion
	}
}