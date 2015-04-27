using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Company.InversionOfControl;

namespace Company.Web.Mvc.Html.Extensions
{
	public static class CheckBoxExtension
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

		public static IHtmlString CheckBox5(this HtmlHelper htmlHelper, string name)
		{
			return htmlHelper.CheckBox(name, TagHelper.BuildAttributes(name, htmlHelper));
		}

		public static IHtmlString CheckBox5(this HtmlHelper htmlHelper, string name, bool isChecked)
		{
			return htmlHelper.CheckBox(name, isChecked, TagHelper.BuildAttributes(name, htmlHelper));
		}

		public static IHtmlString CheckBox5(this HtmlHelper htmlHelper, string name, object htmlAttributes)
		{
			return htmlHelper.CheckBox(name, TagHelper.BuildAttributes(name, htmlHelper, htmlAttributes));
		}

		public static IHtmlString CheckBox5(this HtmlHelper htmlHelper, string name, IDictionary<string, object> htmlAttributes)
		{
			return htmlHelper.CheckBox(name, TagHelper.BuildAttributes(name, htmlHelper, htmlAttributes));
		}

		public static IHtmlString CheckBox5(this HtmlHelper htmlHelper, string name, bool isChecked, object htmlAttributes)
		{
			return htmlHelper.CheckBox(name, isChecked, TagHelper.BuildAttributes(name, htmlHelper, htmlAttributes));
		}

		public static IHtmlString CheckBox5(this HtmlHelper htmlHelper, string name, bool isChecked, IDictionary<string, object> htmlAttributes)
		{
			return htmlHelper.CheckBox(name, isChecked, TagHelper.BuildAttributes(name, htmlHelper, htmlAttributes));
		}

		public static IHtmlString CheckBox5For<TModel>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, bool>> expression)
		{
			return htmlHelper.CheckBoxFor(expression, TagHelper.BuildAttributes(expression, htmlHelper));
		}

		public static IHtmlString CheckBox5For<TModel>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, bool>> expression, object htmlAttributes)
		{
			return htmlHelper.CheckBoxFor(expression, TagHelper.BuildAttributes(expression, htmlHelper, htmlAttributes));
		}

		public static IHtmlString CheckBox5For<TModel>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, bool>> expression, IDictionary<string, object> htmlAttributes)
		{
			return htmlHelper.CheckBoxFor(expression, TagHelper.BuildAttributes(expression, htmlHelper, htmlAttributes));
		}

		#endregion
	}
}