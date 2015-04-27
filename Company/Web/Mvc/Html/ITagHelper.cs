using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace Company.Web.Mvc.Html
{
	public interface ITagHelper
	{
		#region Methods

		IDictionary<string, object> BuildAttributes(HtmlHelper htmlHelper);
		IDictionary<string, object> BuildAttributes(HtmlHelper htmlHelper, object attributes);
		IDictionary<string, object> BuildAttributes(HtmlHelper htmlHelper, IDictionary<string, object> attributes);
		IDictionary<string, object> BuildAttributes(ModelMetadata metadata);
		IDictionary<string, object> BuildAttributes(ModelMetadata metadata, object attributes);
		IDictionary<string, object> BuildAttributes(ModelMetadata metadata, IDictionary<string, object> attributes);
		IDictionary<string, object> BuildAttributes(string expression, HtmlHelper htmlHelper);
		IDictionary<string, object> BuildAttributes(string expression, HtmlHelper htmlHelper, object attributes);
		IDictionary<string, object> BuildAttributes(string expression, HtmlHelper htmlHelper, IDictionary<string, object> attributes);
		IDictionary<string, object> BuildAttributes(string expression, ViewDataDictionary viewData);
		IDictionary<string, object> BuildAttributes(string expression, ViewDataDictionary viewData, object attributes);
		IDictionary<string, object> BuildAttributes(string expression, ViewDataDictionary viewData, IDictionary<string, object> attributes);
		IDictionary<string, object> BuildAttributes<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression, HtmlHelper<TModel> htmlHelper);
		IDictionary<string, object> BuildAttributes<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression, HtmlHelper<TModel> htmlHelper, object attributes);
		IDictionary<string, object> BuildAttributes<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression, HtmlHelper<TModel> htmlHelper, IDictionary<string, object> attributes);
		IDictionary<string, object> BuildAttributes<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression, ViewDataDictionary<TModel> viewData);
		IDictionary<string, object> BuildAttributes<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression, ViewDataDictionary<TModel> viewData, object attributes);
		IDictionary<string, object> BuildAttributes<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression, ViewDataDictionary<TModel> viewData, IDictionary<string, object> attributes);
		IDictionary<string, object> BuildTextInputAttributes(HtmlHelper htmlHelper);
		IDictionary<string, object> BuildTextInputAttributes(HtmlHelper htmlHelper, object attributes);
		IDictionary<string, object> BuildTextInputAttributes(HtmlHelper htmlHelper, IDictionary<string, object> attributes);
		IDictionary<string, object> BuildTextInputAttributes(ModelMetadata metadata);
		IDictionary<string, object> BuildTextInputAttributes(ModelMetadata metadata, object attributes);
		IDictionary<string, object> BuildTextInputAttributes(ModelMetadata metadata, IDictionary<string, object> attributes);
		IDictionary<string, object> BuildTextInputAttributes(string expression, HtmlHelper htmlHelper);
		IDictionary<string, object> BuildTextInputAttributes(string expression, HtmlHelper htmlHelper, object attributes);
		IDictionary<string, object> BuildTextInputAttributes(string expression, HtmlHelper htmlHelper, IDictionary<string, object> attributes);
		IDictionary<string, object> BuildTextInputAttributes(string expression, ViewDataDictionary viewData);
		IDictionary<string, object> BuildTextInputAttributes(string expression, ViewDataDictionary viewData, object attributes);
		IDictionary<string, object> BuildTextInputAttributes(string expression, ViewDataDictionary viewData, IDictionary<string, object> attributes);
		IDictionary<string, object> BuildTextInputAttributes<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression, HtmlHelper<TModel> htmlHelper);
		IDictionary<string, object> BuildTextInputAttributes<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression, HtmlHelper<TModel> htmlHelper, object attributes);
		IDictionary<string, object> BuildTextInputAttributes<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression, HtmlHelper<TModel> htmlHelper, IDictionary<string, object> attributes);
		IDictionary<string, object> BuildTextInputAttributes<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression, ViewDataDictionary<TModel> viewData);
		IDictionary<string, object> BuildTextInputAttributes<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression, ViewDataDictionary<TModel> viewData, object attributes);
		IDictionary<string, object> BuildTextInputAttributes<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression, ViewDataDictionary<TModel> viewData, IDictionary<string, object> attributes);
		void SortAttributes(IDictionary<string, object> attributes);

		#endregion
	}
}