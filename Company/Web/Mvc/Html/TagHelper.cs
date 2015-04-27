using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Routing;
using Company.Collections.Generic.Extensions;

namespace Company.Web.Mvc.Html
{
	public class TagHelper : ITagHelper
	{
		#region Methods

		public virtual IDictionary<string, object> BuildAttributes(HtmlHelper htmlHelper)
		{
			return this.BuildAttributes(htmlHelper, this.CreateAttributes());
		}

		public virtual IDictionary<string, object> BuildAttributes(HtmlHelper htmlHelper, object attributes)
		{
			return this.BuildAttributes(htmlHelper, HtmlHelper.AnonymousObjectToHtmlAttributes(attributes));
		}

		public virtual IDictionary<string, object> BuildAttributes(HtmlHelper htmlHelper, IDictionary<string, object> attributes)
		{
			if(htmlHelper == null)
				throw new ArgumentNullException("htmlHelper");

			return this.BuildAttributes(this.CreateAttributesToMetadataMapping(htmlHelper.ViewData.ModelMetadata), attributes);
		}

		public virtual IDictionary<string, object> BuildAttributes(ModelMetadata metadata)
		{
			return this.BuildAttributes(metadata, this.CreateAttributes());
		}

		public virtual IDictionary<string, object> BuildAttributes(ModelMetadata metadata, object attributes)
		{
			return this.BuildAttributes(metadata, HtmlHelper.AnonymousObjectToHtmlAttributes(attributes));
		}

		public virtual IDictionary<string, object> BuildAttributes(ModelMetadata metadata, IDictionary<string, object> attributes)
		{
			return this.BuildAttributes(this.CreateAttributesToMetadataMapping(metadata), attributes);
		}

		public virtual IDictionary<string, object> BuildAttributes(string expression, HtmlHelper htmlHelper)
		{
			return this.BuildAttributes(expression, htmlHelper, this.CreateAttributes());
		}

		public virtual IDictionary<string, object> BuildAttributes(string expression, HtmlHelper htmlHelper, object attributes)
		{
			return this.BuildAttributes(expression, htmlHelper, HtmlHelper.AnonymousObjectToHtmlAttributes(attributes));
		}

		public virtual IDictionary<string, object> BuildAttributes(string expression, HtmlHelper htmlHelper, IDictionary<string, object> attributes)
		{
			if(htmlHelper == null)
				throw new ArgumentNullException("htmlHelper");

			return this.BuildAttributes(this.GetMetadata(expression, htmlHelper.ViewData), attributes);
		}

		public virtual IDictionary<string, object> BuildAttributes(string expression, ViewDataDictionary viewData)
		{
			return this.BuildAttributes(expression, viewData, this.CreateAttributes());
		}

		public virtual IDictionary<string, object> BuildAttributes(string expression, ViewDataDictionary viewData, object attributes)
		{
			return this.BuildAttributes(expression, viewData, HtmlHelper.AnonymousObjectToHtmlAttributes(attributes));
		}

		public virtual IDictionary<string, object> BuildAttributes(string expression, ViewDataDictionary viewData, IDictionary<string, object> attributes)
		{
			return this.BuildAttributes(this.GetMetadata(expression, viewData), attributes);
		}

		public virtual IDictionary<string, object> BuildAttributes<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression, HtmlHelper<TModel> htmlHelper)
		{
			return this.BuildAttributes(expression, htmlHelper, this.CreateAttributes());
		}

		public virtual IDictionary<string, object> BuildAttributes<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression, HtmlHelper<TModel> htmlHelper, object attributes)
		{
			return this.BuildAttributes(expression, htmlHelper, HtmlHelper.AnonymousObjectToHtmlAttributes(attributes));
		}

		public virtual IDictionary<string, object> BuildAttributes<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression, HtmlHelper<TModel> htmlHelper, IDictionary<string, object> attributes)
		{
			if(htmlHelper == null)
				throw new ArgumentNullException("htmlHelper");

			return this.BuildAttributes(this.GetMetadata(expression, htmlHelper.ViewData), attributes);
		}

		public virtual IDictionary<string, object> BuildAttributes<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression, ViewDataDictionary<TModel> viewData)
		{
			return this.BuildAttributes(expression, viewData, this.CreateAttributes());
		}

		public virtual IDictionary<string, object> BuildAttributes<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression, ViewDataDictionary<TModel> viewData, object attributes)
		{
			return this.BuildAttributes(expression, viewData, HtmlHelper.AnonymousObjectToHtmlAttributes(attributes));
		}

		public virtual IDictionary<string, object> BuildAttributes<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression, ViewDataDictionary<TModel> viewData, IDictionary<string, object> attributes)
		{
			return this.BuildAttributes(this.GetMetadata(expression, viewData), attributes);
		}

		protected internal virtual IDictionary<string, object> BuildAttributes(IDictionary<string, Func<string>> attributesToMetadataMapping, IDictionary<string, object> attributes)
		{
			if(attributesToMetadataMapping != null && attributesToMetadataMapping.Any())
			{
				var attributeAdded = false;

				var attributesCopy = this.CreateAttributes(attributes);

				foreach(var item in attributesToMetadataMapping)
				{
					if(this.SetAttributeIfNecessary(attributesCopy, item.Key, item.Value.Invoke()))
						attributeAdded = true;
				}

				if(attributeAdded)
					attributes = attributesCopy;
			}

			if(attributes != null)
				this.SortAttributes(attributes);

			return attributes;
		}

		public virtual IDictionary<string, object> BuildTextInputAttributes(HtmlHelper htmlHelper)
		{
			return this.BuildTextInputAttributes(htmlHelper, this.CreateAttributes());
		}

		public virtual IDictionary<string, object> BuildTextInputAttributes(HtmlHelper htmlHelper, object attributes)
		{
			return this.BuildTextInputAttributes(htmlHelper, HtmlHelper.AnonymousObjectToHtmlAttributes(attributes));
		}

		public virtual IDictionary<string, object> BuildTextInputAttributes(HtmlHelper htmlHelper, IDictionary<string, object> attributes)
		{
			if(htmlHelper == null)
				throw new ArgumentNullException("htmlHelper");

			return this.BuildAttributes(this.CreateTextInputAttributesToMetadataMapping(htmlHelper.ViewData.ModelMetadata), attributes);
		}

		public virtual IDictionary<string, object> BuildTextInputAttributes(ModelMetadata metadata)
		{
			return this.BuildTextInputAttributes(metadata, this.CreateAttributes());
		}

		public virtual IDictionary<string, object> BuildTextInputAttributes(ModelMetadata metadata, object attributes)
		{
			return this.BuildTextInputAttributes(metadata, HtmlHelper.AnonymousObjectToHtmlAttributes(attributes));
		}

		public virtual IDictionary<string, object> BuildTextInputAttributes(ModelMetadata metadata, IDictionary<string, object> attributes)
		{
			return this.BuildAttributes(this.CreateTextInputAttributesToMetadataMapping(metadata), attributes);
		}

		public virtual IDictionary<string, object> BuildTextInputAttributes(string expression, HtmlHelper htmlHelper)
		{
			return this.BuildTextInputAttributes(expression, htmlHelper, this.CreateAttributes());
		}

		public virtual IDictionary<string, object> BuildTextInputAttributes(string expression, HtmlHelper htmlHelper, object attributes)
		{
			return this.BuildTextInputAttributes(expression, htmlHelper, HtmlHelper.AnonymousObjectToHtmlAttributes(attributes));
		}

		public virtual IDictionary<string, object> BuildTextInputAttributes(string expression, HtmlHelper htmlHelper, IDictionary<string, object> attributes)
		{
			if(htmlHelper == null)
				throw new ArgumentNullException("htmlHelper");

			return this.BuildTextInputAttributes(this.GetMetadata(expression, htmlHelper.ViewData), attributes);
		}

		public virtual IDictionary<string, object> BuildTextInputAttributes(string expression, ViewDataDictionary viewData)
		{
			return this.BuildTextInputAttributes(expression, viewData, this.CreateAttributes());
		}

		public virtual IDictionary<string, object> BuildTextInputAttributes(string expression, ViewDataDictionary viewData, object attributes)
		{
			return this.BuildTextInputAttributes(expression, viewData, HtmlHelper.AnonymousObjectToHtmlAttributes(attributes));
		}

		public virtual IDictionary<string, object> BuildTextInputAttributes(string expression, ViewDataDictionary viewData, IDictionary<string, object> attributes)
		{
			return this.BuildTextInputAttributes(this.GetMetadata(expression, viewData), attributes);
		}

		public virtual IDictionary<string, object> BuildTextInputAttributes<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression, HtmlHelper<TModel> htmlHelper)
		{
			return this.BuildTextInputAttributes(expression, htmlHelper, this.CreateAttributes());
		}

		public virtual IDictionary<string, object> BuildTextInputAttributes<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression, HtmlHelper<TModel> htmlHelper, object attributes)
		{
			return this.BuildTextInputAttributes(expression, htmlHelper, HtmlHelper.AnonymousObjectToHtmlAttributes(attributes));
		}

		public virtual IDictionary<string, object> BuildTextInputAttributes<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression, HtmlHelper<TModel> htmlHelper, IDictionary<string, object> attributes)
		{
			if(htmlHelper == null)
				throw new ArgumentNullException("htmlHelper");

			return this.BuildTextInputAttributes(this.GetMetadata(expression, htmlHelper.ViewData), attributes);
		}

		public virtual IDictionary<string, object> BuildTextInputAttributes<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression, ViewDataDictionary<TModel> viewData)
		{
			return this.BuildTextInputAttributes(expression, viewData, this.CreateAttributes());
		}

		public virtual IDictionary<string, object> BuildTextInputAttributes<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression, ViewDataDictionary<TModel> viewData, object attributes)
		{
			return this.BuildTextInputAttributes(expression, viewData, HtmlHelper.AnonymousObjectToHtmlAttributes(attributes));
		}

		public virtual IDictionary<string, object> BuildTextInputAttributes<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression, ViewDataDictionary<TModel> viewData, IDictionary<string, object> attributes)
		{
			return this.BuildTextInputAttributes(this.GetMetadata(expression, viewData), attributes);
		}

		protected internal virtual IDictionary<string, object> CreateAttributes()
		{
			return new RouteValueDictionary();
		}

		protected internal virtual IDictionary<string, object> CreateAttributes(IDictionary<string, object> values)
		{
			if(values == null || !values.Any())
				return this.CreateAttributes();

			return new RouteValueDictionary(values);
		}

		protected internal virtual IDictionary<string, Func<string>> CreateAttributesToMetadataMapping(ModelMetadata metadata)
		{
			var attributesToMetadataMapping = new Dictionary<string, Func<string>>();

			if(metadata != null)
				attributesToMetadataMapping.Add("title", () => metadata.Description);

			return attributesToMetadataMapping;
		}

		protected internal virtual IDictionary<string, Func<string>> CreateTextInputAttributesToMetadataMapping(ModelMetadata metadata)
		{
			var attributesToMetadataMapping = new Dictionary<string, Func<string>>();

			if(metadata != null)
			{
				attributesToMetadataMapping.Add("placeholder", () => metadata.Watermark);

				foreach(var item in this.CreateAttributesToMetadataMapping(metadata))
				{
					attributesToMetadataMapping.Add(item.Key, item.Value);
				}
			}

			return attributesToMetadataMapping;
		}

		protected internal virtual ModelMetadata GetMetadata(string expression, ViewDataDictionary viewData)
		{
			return ModelMetadata.FromStringExpression(expression, viewData);
		}

		protected internal virtual ModelMetadata GetMetadata<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression, ViewDataDictionary<TModel> viewData)
		{
			return ModelMetadata.FromLambdaExpression(expression, viewData);
		}

		protected internal virtual bool SetAttributeIfNecessary(IDictionary<string, object> attributes, string name, object value)
		{
			if(attributes == null)
				throw new ArgumentNullException("attributes");

			if(name == null)
				throw new ArgumentNullException("name");

			if(attributes.ContainsKey(name))
				return false;

			// ReSharper disable UseNullPropagation
			if(value == null)
				return false;
			// ReSharper restore UseNullPropagation

			var valueAsString = value as string;

			if(string.IsNullOrEmpty(valueAsString))
				return false;

			attributes[name] = value;

			return true;
		}

		public virtual void SortAttributes(IDictionary<string, object> attributes)
		{
			attributes.Sort(StringComparer.OrdinalIgnoreCase);
		}

		#endregion
	}
}