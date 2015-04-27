using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Company.InversionOfControl;

namespace Company.Web.Mvc.Html.Extensions
{
	public static class LabelExtension
	{
		#region Fields

		private static readonly object _lockObject = new object();
		private static volatile ITagHelper _tagHelper;

		#endregion

		#region Properties

		public static ITagHelper TagHelper
		{
			get
			{
				if(_tagHelper == null)
				{
					lock(_lockObject)
					{
						if(_tagHelper == null)
							_tagHelper = ServiceLocator.Instance.GetService<ITagHelper>();
					}
				}

				return _tagHelper;
			}
			set
			{
				if(Equals(_tagHelper, value))
					return;

				lock(_lockObject)
				{
					_tagHelper = value;
				}
			}
		}

		#endregion

		#region Methods

		public static IHtmlString Label5(this HtmlHelper html, string expression)
		{
			return html.Label(expression, TagHelper.BuildAttributes(expression, html));
		}

		public static IHtmlString Label5(this HtmlHelper html, string expression, string labelText)
		{
			return html.Label(expression, labelText, TagHelper.BuildAttributes(expression, html));
		}

		public static IHtmlString Label5(this HtmlHelper html, string expression, object htmlAttributes)
		{
			return html.Label(expression, TagHelper.BuildAttributes(expression, html, htmlAttributes));
		}

		public static IHtmlString Label5(this HtmlHelper html, string expression, IDictionary<string, object> htmlAttributes)
		{
			return html.Label(expression, TagHelper.BuildAttributes(expression, html, htmlAttributes));
		}

		public static IHtmlString Label5(this HtmlHelper html, string expression, string labelText, object htmlAttributes)
		{
			return html.Label(expression, labelText, TagHelper.BuildAttributes(expression, html, htmlAttributes));
		}

		public static IHtmlString Label5(this HtmlHelper html, string expression, string labelText, IDictionary<string, object> htmlAttributes)
		{
			return html.Label(expression, labelText, TagHelper.BuildAttributes(expression, html, htmlAttributes));
		}

		public static IHtmlString Label5For<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
		{
			return html.LabelFor(expression, TagHelper.BuildAttributes(expression, html));
		}

		public static IHtmlString Label5For<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string labelText)
		{
			return html.LabelFor(expression, labelText, TagHelper.BuildAttributes(expression, html));
		}

		public static IHtmlString Label5For<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, object htmlAttributes)
		{
			return html.LabelFor(expression, TagHelper.BuildAttributes(expression, html, htmlAttributes));
		}

		public static IHtmlString Label5For<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, IDictionary<string, object> htmlAttributes)
		{
			return html.LabelFor(expression, TagHelper.BuildAttributes(expression, html, htmlAttributes));
		}

		public static IHtmlString Label5For<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string labelText, object htmlAttributes)
		{
			return html.LabelFor(expression, labelText, TagHelper.BuildAttributes(expression, html, htmlAttributes));
		}

		public static IHtmlString Label5For<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string labelText, IDictionary<string, object> htmlAttributes)
		{
			return html.LabelFor(expression, labelText, TagHelper.BuildAttributes(expression, html, htmlAttributes));
		}

		public static IHtmlString Label5ForModel(this HtmlHelper html)
		{
			return html.LabelForModel(TagHelper.BuildAttributes(html));
		}

		public static IHtmlString Label5ForModel(this HtmlHelper html, string labelText)
		{
			return html.LabelForModel(labelText, TagHelper.BuildAttributes(html));
		}

		public static IHtmlString Label5ForModel(this HtmlHelper html, object htmlAttributes)
		{
			return html.LabelForModel(TagHelper.BuildAttributes(html, htmlAttributes));
		}

		public static IHtmlString Label5ForModel(this HtmlHelper html, IDictionary<string, object> htmlAttributes)
		{
			return html.LabelForModel(TagHelper.BuildAttributes(html, htmlAttributes));
		}

		public static IHtmlString Label5ForModel(this HtmlHelper html, string labelText, object htmlAttributes)
		{
			return html.LabelForModel(labelText, TagHelper.BuildAttributes(html, htmlAttributes));
		}

		public static IHtmlString Label5ForModel(this HtmlHelper html, string labelText, IDictionary<string, object> htmlAttributes)
		{
			return html.LabelForModel(labelText, TagHelper.BuildAttributes(html, htmlAttributes));
		}

		#endregion
	}
}