using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Company.InversionOfControl;

namespace Company.Web.Mvc.Html.Extensions
{
	public static class ListBoxExtension
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

		public static IHtmlString ListBox5(this HtmlHelper htmlHelper, string name)
		{
			return htmlHelper.ListBox(name, null, TagHelper.BuildInputAttributes(name, htmlHelper));
		}

		public static IHtmlString ListBox5(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListItem> selectList)
		{
			return htmlHelper.ListBox(name, selectList, TagHelper.BuildInputAttributes(name, htmlHelper));
		}

		public static IHtmlString ListBox5(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListItem> selectList, object htmlAttributes)
		{
			return htmlHelper.ListBox(name, selectList, TagHelper.BuildInputAttributes(name, htmlHelper, htmlAttributes));
		}

		public static IHtmlString ListBox5(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListItem> selectList, IDictionary<string, object> htmlAttributes)
		{
			return htmlHelper.ListBox(name, selectList, TagHelper.BuildInputAttributes(name, htmlHelper, htmlAttributes));
		}

		public static IHtmlString ListBox5For<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList)
		{
			return htmlHelper.ListBoxFor(expression, selectList, TagHelper.BuildInputAttributes(expression, htmlHelper));
		}

		public static IHtmlString ListBox5For<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, object htmlAttributes)
		{
			return htmlHelper.ListBoxFor(expression, selectList, TagHelper.BuildInputAttributes(expression, htmlHelper, htmlAttributes));
		}

		public static IHtmlString ListBox5For<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, IDictionary<string, object> htmlAttributes)
		{
			return htmlHelper.ListBoxFor(expression, selectList, TagHelper.BuildInputAttributes(expression, htmlHelper, htmlAttributes));
		}

		#endregion
	}
}