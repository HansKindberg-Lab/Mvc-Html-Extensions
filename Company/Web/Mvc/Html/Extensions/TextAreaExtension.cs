using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Company.InversionOfControl;

namespace Company.Web.Mvc.Html.Extensions
{
	public static class TextAreaExtension
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

		public static IHtmlString TextArea5(this HtmlHelper htmlHelper, string name)
		{
			return htmlHelper.TextArea(name, TagHelper.BuildTextAreaAttributes(name, htmlHelper));
		}

		public static IHtmlString TextArea5(this HtmlHelper htmlHelper, string name, object htmlAttributes)
		{
			return htmlHelper.TextArea(name, TagHelper.BuildTextAreaAttributes(name, htmlHelper, htmlAttributes));
		}

		public static IHtmlString TextArea5(this HtmlHelper htmlHelper, string name, IDictionary<string, object> htmlAttributes)
		{
			return htmlHelper.TextArea(name, TagHelper.BuildTextAreaAttributes(name, htmlHelper, htmlAttributes));
		}

		public static IHtmlString TextArea5(this HtmlHelper htmlHelper, string name, string value)
		{
			return htmlHelper.TextArea(name, value, TagHelper.BuildTextAreaAttributes(name, htmlHelper));
		}

		public static IHtmlString TextArea5(this HtmlHelper htmlHelper, string name, string value, object htmlAttributes)
		{
			return htmlHelper.TextArea(name, value, TagHelper.BuildTextAreaAttributes(name, htmlHelper, htmlAttributes));
		}

		public static IHtmlString TextArea5(this HtmlHelper htmlHelper, string name, string value, IDictionary<string, object> htmlAttributes)
		{
			return htmlHelper.TextArea(name, value, TagHelper.BuildTextAreaAttributes(name, htmlHelper, htmlAttributes));
		}

		public static IHtmlString TextArea5(this HtmlHelper htmlHelper, string name, string value, int rows, int columns, object htmlAttributes)
		{
			return htmlHelper.TextArea(name, value, rows, columns, TagHelper.BuildTextAreaAttributes(name, htmlHelper, htmlAttributes));
		}

		public static IHtmlString TextArea5(this HtmlHelper htmlHelper, string name, string value, int rows, int columns, IDictionary<string, object> htmlAttributes)
		{
			return htmlHelper.TextArea(name, value, rows, columns, TagHelper.BuildTextAreaAttributes(name, htmlHelper, htmlAttributes));
		}

		public static IHtmlString TextArea5For<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
		{
			return htmlHelper.TextAreaFor(expression, TagHelper.BuildTextAreaAttributes(expression, htmlHelper));
		}

		public static IHtmlString TextArea5For<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
		{
			return htmlHelper.TextAreaFor(expression, TagHelper.BuildTextAreaAttributes(expression, htmlHelper, htmlAttributes));
		}

		public static IHtmlString TextArea5For<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes)
		{
			return htmlHelper.TextAreaFor(expression, TagHelper.BuildTextAreaAttributes(expression, htmlHelper, htmlAttributes));
		}

		public static IHtmlString TextArea5For<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, int rows, int columns, object htmlAttributes)
		{
			return htmlHelper.TextAreaFor(expression, rows, columns, TagHelper.BuildTextAreaAttributes(expression, htmlHelper, htmlAttributes));
		}

		public static IHtmlString TextArea5For<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, int rows, int columns, IDictionary<string, object> htmlAttributes)
		{
			return htmlHelper.TextAreaFor(expression, rows, columns, TagHelper.BuildTextAreaAttributes(expression, htmlHelper, htmlAttributes));
		}

		#endregion
	}
}