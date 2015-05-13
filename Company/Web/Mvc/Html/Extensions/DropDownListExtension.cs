using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Company.InversionOfControl;

namespace Company.Web.Mvc.Html.Extensions
{
	public static class DropDownListExtension
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

		public static IHtmlString DropDownList5(this HtmlHelper htmlHelper, string name)
		{
			return htmlHelper.DropDownList(name, null, TagHelper.BuildInputAttributes(name, htmlHelper));
		}

		public static IHtmlString DropDownList5(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListItem> selectList)
		{
			return htmlHelper.DropDownList(name, selectList, TagHelper.BuildInputAttributes(name, htmlHelper));
		}

		public static IHtmlString DropDownList5(this HtmlHelper htmlHelper, string name, string optionLabel)
		{
			return htmlHelper.DropDownList(name, null, optionLabel, TagHelper.BuildInputAttributes(name, htmlHelper));
		}

		public static IHtmlString DropDownList5(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListItem> selectList, string optionLabel)
		{
			return htmlHelper.DropDownList(name, selectList, optionLabel, TagHelper.BuildInputAttributes(name, htmlHelper));
		}

		public static IHtmlString DropDownList5(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListItem> selectList, object htmlAttributes)
		{
			return htmlHelper.DropDownList(name, selectList, TagHelper.BuildInputAttributes(name, htmlHelper, htmlAttributes));
		}

		public static IHtmlString DropDownList5(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListItem> selectList, IDictionary<string, object> htmlAttributes)
		{
			return htmlHelper.DropDownList(name, selectList, TagHelper.BuildInputAttributes(name, htmlHelper, htmlAttributes));
		}

		public static IHtmlString DropDownList5(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListItem> selectList, string optionLabel, object htmlAttributes)
		{
			return htmlHelper.DropDownList(name, selectList, optionLabel, TagHelper.BuildInputAttributes(name, htmlHelper, htmlAttributes));
		}

		public static IHtmlString DropDownList5(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListItem> selectList, string optionLabel, IDictionary<string, object> htmlAttributes)
		{
			return htmlHelper.DropDownList(name, selectList, optionLabel, TagHelper.BuildInputAttributes(name, htmlHelper, htmlAttributes));
		}

		public static IHtmlString DropDownList5For<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList)
		{
			return htmlHelper.DropDownListFor(expression, selectList, TagHelper.BuildInputAttributes(expression, htmlHelper));
		}

		public static IHtmlString DropDownList5For<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, string optionLabel)
		{
			return htmlHelper.DropDownListFor(expression, selectList, optionLabel, TagHelper.BuildInputAttributes(expression, htmlHelper));
		}

		public static IHtmlString DropDownList5For<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, object htmlAttributes)
		{
			return htmlHelper.DropDownListFor(expression, selectList, TagHelper.BuildInputAttributes(expression, htmlHelper, htmlAttributes));
		}

		public static IHtmlString DropDownList5For<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, IDictionary<string, object> htmlAttributes)
		{
			return htmlHelper.DropDownListFor(expression, selectList, TagHelper.BuildInputAttributes(expression, htmlHelper, htmlAttributes));
		}

		public static IHtmlString DropDownList5For<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, string optionLabel, object htmlAttributes)
		{
			return htmlHelper.DropDownListFor(expression, selectList, optionLabel, TagHelper.BuildInputAttributes(expression, htmlHelper, htmlAttributes));
		}

		public static IHtmlString DropDownList5For<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, string optionLabel, IDictionary<string, object> htmlAttributes)
		{
			return htmlHelper.DropDownListFor(expression, selectList, optionLabel, TagHelper.BuildInputAttributes(expression, htmlHelper, htmlAttributes));
		}

		public static IHtmlString EnumDropDownList5For<TModel, TEnum>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TEnum>> expression)
		{
			return htmlHelper.EnumDropDownListFor(expression, TagHelper.BuildInputAttributes(expression, htmlHelper));
		}

		public static IHtmlString EnumDropDownList5For<TModel, TEnum>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TEnum>> expression, string optionLabel)
		{
			return htmlHelper.EnumDropDownListFor(expression, optionLabel, TagHelper.BuildInputAttributes(expression, htmlHelper));
		}

		public static IHtmlString EnumDropDownList5For<TModel, TEnum>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TEnum>> expression, object htmlAttributes)
		{
			return htmlHelper.EnumDropDownListFor(expression, TagHelper.BuildInputAttributes(expression, htmlHelper, htmlAttributes));
		}

		public static IHtmlString EnumDropDownList5For<TModel, TEnum>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TEnum>> expression, IDictionary<string, object> htmlAttributes)
		{
			return htmlHelper.EnumDropDownListFor(expression, TagHelper.BuildInputAttributes(expression, htmlHelper, htmlAttributes));
		}

		public static IHtmlString EnumDropDownList5For<TModel, TEnum>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TEnum>> expression, string optionLabel, object htmlAttributes)
		{
			return htmlHelper.EnumDropDownListFor(expression, optionLabel, TagHelper.BuildInputAttributes(expression, htmlHelper, htmlAttributes));
		}

		public static IHtmlString EnumDropDownList5For<TModel, TEnum>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TEnum>> expression, string optionLabel, IDictionary<string, object> htmlAttributes)
		{
			return htmlHelper.EnumDropDownListFor(expression, optionLabel, TagHelper.BuildInputAttributes(expression, htmlHelper, htmlAttributes));
		}

		#endregion
	}
}