using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Company.InversionOfControl;

namespace Company.Web.Mvc.Html.Extensions
{
	public static class RadioButtonExtension
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

		public static IHtmlString RadioButton5(this HtmlHelper htmlHelper, string name, object value)
		{
			return htmlHelper.RadioButton(name, value, TagHelper.BuildInputAttributes(name, htmlHelper));
		}

		public static IHtmlString RadioButton5(this HtmlHelper htmlHelper, string name, object value, bool isChecked)
		{
			return htmlHelper.RadioButton(name, value, isChecked, TagHelper.BuildInputAttributes(name, htmlHelper));
		}

		public static IHtmlString RadioButton5(this HtmlHelper htmlHelper, string name, object value, object htmlAttributes)
		{
			return htmlHelper.RadioButton(name, value, TagHelper.BuildInputAttributes(name, htmlHelper, htmlAttributes));
		}

		public static IHtmlString RadioButton5(this HtmlHelper htmlHelper, string name, object value, IDictionary<string, object> htmlAttributes)
		{
			return htmlHelper.RadioButton(name, value, TagHelper.BuildInputAttributes(name, htmlHelper, htmlAttributes));
		}

		public static IHtmlString RadioButton5(this HtmlHelper htmlHelper, string name, object value, bool isChecked, object htmlAttributes)
		{
			return htmlHelper.RadioButton(name, value, isChecked, TagHelper.BuildInputAttributes(name, htmlHelper, htmlAttributes));
		}

		public static IHtmlString RadioButton5(this HtmlHelper htmlHelper, string name, object value, bool isChecked, IDictionary<string, object> htmlAttributes)
		{
			return htmlHelper.RadioButton(name, value, isChecked, TagHelper.BuildInputAttributes(name, htmlHelper, htmlAttributes));
		}

		public static IHtmlString RadioButton5For<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object value)
		{
			return htmlHelper.RadioButtonFor(expression, value, TagHelper.BuildInputAttributes(expression, htmlHelper));
		}

		public static IHtmlString RadioButton5For<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object value, object htmlAttributes)
		{
			return htmlHelper.RadioButtonFor(expression, value, TagHelper.BuildInputAttributes(expression, htmlHelper, htmlAttributes));
		}

		public static IHtmlString RadioButton5For<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object value, IDictionary<string, object> htmlAttributes)
		{
			return htmlHelper.RadioButtonFor(expression, value, TagHelper.BuildInputAttributes(expression, htmlHelper, htmlAttributes));
		}

		#endregion
	}
}