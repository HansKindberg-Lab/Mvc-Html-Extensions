using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Company.InversionOfControl;

namespace Company.Web.Mvc.Html.Extensions
{
	public static class TextBoxExtension
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

		public static IHtmlString TextBox5(this HtmlHelper htmlHelper, string name)
		{
			return htmlHelper.TextBox(name, TagHelper.BuildTextInputAttributes(name, htmlHelper));
		}

		public static IHtmlString TextBox5(this HtmlHelper htmlHelper, string name, object value)
		{
			return htmlHelper.TextBox(name, value, TagHelper.BuildTextInputAttributes(name, htmlHelper));
		}

		public static IHtmlString TextBox5(this HtmlHelper htmlHelper, string name, object value, object htmlAttributes)
		{
			return htmlHelper.TextBox(name, value, TagHelper.BuildTextInputAttributes(name, htmlHelper, htmlAttributes));
		}

		public static IHtmlString TextBox5(this HtmlHelper htmlHelper, string name, object value, IDictionary<string, object> htmlAttributes)
		{
			return htmlHelper.TextBox(name, value, TagHelper.BuildTextInputAttributes(name, htmlHelper, htmlAttributes));
		}

		public static IHtmlString TextBox5(this HtmlHelper htmlHelper, string name, object value, string format)
		{
			return htmlHelper.TextBox(name, value, format, TagHelper.BuildTextInputAttributes(name, htmlHelper));
		}

		public static IHtmlString TextBox5(this HtmlHelper htmlHelper, string name, object value, string format, object htmlAttributes)
		{
			return htmlHelper.TextBox(name, value, format, TagHelper.BuildTextInputAttributes(name, htmlHelper, htmlAttributes));
		}

		public static IHtmlString TextBox5(this HtmlHelper htmlHelper, string name, object value, string format, IDictionary<string, object> htmlAttributes)
		{
			return htmlHelper.TextBox(name, value, format, TagHelper.BuildTextInputAttributes(name, htmlHelper, htmlAttributes));
		}

		public static IHtmlString TextBox5For<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
		{
			return htmlHelper.TextBoxFor(expression, TagHelper.BuildTextInputAttributes(expression, htmlHelper));
		}

		public static IHtmlString TextBox5For<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
		{
			return htmlHelper.TextBoxFor(expression, TagHelper.BuildTextInputAttributes(expression, htmlHelper, htmlAttributes));
		}

		public static IHtmlString TextBox5For<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes)
		{
			return htmlHelper.TextBoxFor(expression, TagHelper.BuildTextInputAttributes(expression, htmlHelper, htmlAttributes));
		}

		public static IHtmlString TextBox5For<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string format)
		{
			return htmlHelper.TextBoxFor(expression, format, TagHelper.BuildTextInputAttributes(expression, htmlHelper));
		}

		public static IHtmlString TextBox5For<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string format, object htmlAttributes)
		{
			return htmlHelper.TextBoxFor(expression, format, TagHelper.BuildTextInputAttributes(expression, htmlHelper, htmlAttributes));
		}

		public static IHtmlString TextBox5For<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string format, IDictionary<string, object> htmlAttributes)
		{
			return htmlHelper.TextBoxFor(expression, format, TagHelper.BuildTextInputAttributes(expression, htmlHelper, htmlAttributes));
		}

		#endregion
	}
}