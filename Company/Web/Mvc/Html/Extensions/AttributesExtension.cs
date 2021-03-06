﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using Company.InversionOfControl;

namespace Company.Web.Mvc.Html.Extensions
{
	public static class AttributesExtension
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

		public static IDictionary<string, object> Attributes(this HtmlHelper htmlHelper, string name)
		{
			return TagHelper.BuildAttributes(name, htmlHelper);
		}

		public static IDictionary<string, object> Attributes(this HtmlHelper htmlHelper, string name, object htmlAttributes)
		{
			return TagHelper.BuildAttributes(name, htmlHelper, htmlAttributes);
		}

		public static IDictionary<string, object> Attributes(this HtmlHelper htmlHelper, string name, IDictionary<string, object> htmlAttributes)
		{
			return TagHelper.BuildAttributes(name, htmlHelper, htmlAttributes);
		}

		public static IDictionary<string, object> AttributesFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
		{
			return TagHelper.BuildAttributes(expression, htmlHelper);
		}

		public static IDictionary<string, object> AttributesFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
		{
			return TagHelper.BuildAttributes(expression, htmlHelper, htmlAttributes);
		}

		public static IDictionary<string, object> AttributesFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes)
		{
			return TagHelper.BuildAttributes(expression, htmlHelper, htmlAttributes);
		}

		public static IDictionary<string, object> InputAttributes(this HtmlHelper htmlHelper, string name)
		{
			return TagHelper.BuildInputAttributes(name, htmlHelper);
		}

		public static IDictionary<string, object> InputAttributes(this HtmlHelper htmlHelper, string name, object htmlAttributes)
		{
			return TagHelper.BuildInputAttributes(name, htmlHelper, htmlAttributes);
		}

		public static IDictionary<string, object> InputAttributes(this HtmlHelper htmlHelper, string name, IDictionary<string, object> htmlAttributes)
		{
			return TagHelper.BuildInputAttributes(name, htmlHelper, htmlAttributes);
		}

		public static IDictionary<string, object> InputAttributesFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
		{
			return TagHelper.BuildInputAttributes(expression, htmlHelper);
		}

		public static IDictionary<string, object> InputAttributesFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
		{
			return TagHelper.BuildInputAttributes(expression, htmlHelper, htmlAttributes);
		}

		public static IDictionary<string, object> InputAttributesFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes)
		{
			return TagHelper.BuildInputAttributes(expression, htmlHelper, htmlAttributes);
		}

		public static IDictionary<string, object> TextAreaAttributes(this HtmlHelper htmlHelper, string name)
		{
			return TagHelper.BuildTextAreaAttributes(name, htmlHelper);
		}

		public static IDictionary<string, object> TextAreaAttributes(this HtmlHelper htmlHelper, string name, object htmlAttributes)
		{
			return TagHelper.BuildTextAreaAttributes(name, htmlHelper, htmlAttributes);
		}

		public static IDictionary<string, object> TextAreaAttributes(this HtmlHelper htmlHelper, string name, IDictionary<string, object> htmlAttributes)
		{
			return TagHelper.BuildTextAreaAttributes(name, htmlHelper, htmlAttributes);
		}

		public static IDictionary<string, object> TextAreaAttributesFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
		{
			return TagHelper.BuildTextAreaAttributes(expression, htmlHelper);
		}

		public static IDictionary<string, object> TextAreaAttributesFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
		{
			return TagHelper.BuildTextAreaAttributes(expression, htmlHelper, htmlAttributes);
		}

		public static IDictionary<string, object> TextAreaAttributesFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes)
		{
			return TagHelper.BuildTextAreaAttributes(expression, htmlHelper, htmlAttributes);
		}

		public static IDictionary<string, object> TextInputAttributes(this HtmlHelper htmlHelper, string name)
		{
			return TagHelper.BuildTextInputAttributes(name, htmlHelper);
		}

		public static IDictionary<string, object> TextInputAttributes(this HtmlHelper htmlHelper, string name, object htmlAttributes)
		{
			return TagHelper.BuildTextInputAttributes(name, htmlHelper, htmlAttributes);
		}

		public static IDictionary<string, object> TextInputAttributes(this HtmlHelper htmlHelper, string name, IDictionary<string, object> htmlAttributes)
		{
			return TagHelper.BuildTextInputAttributes(name, htmlHelper, htmlAttributes);
		}

		public static IDictionary<string, object> TextInputAttributesFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
		{
			return TagHelper.BuildTextInputAttributes(expression, htmlHelper);
		}

		public static IDictionary<string, object> TextInputAttributesFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
		{
			return TagHelper.BuildTextInputAttributes(expression, htmlHelper, htmlAttributes);
		}

		public static IDictionary<string, object> TextInputAttributesFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes)
		{
			return TagHelper.BuildTextInputAttributes(expression, htmlHelper, htmlAttributes);
		}

		public static IHtmlString ToHtml(this IDictionary<string, object> attributes)
		{
			return TagHelper.AttributesToHtml(attributes);
		}

		public static IHtmlString ToHtml(this IDictionary<string, object> attributes, bool leadingSpace, bool trailingSpace)
		{
			return TagHelper.AttributesToHtml(attributes, leadingSpace, trailingSpace);
		}

		#endregion
	}
}