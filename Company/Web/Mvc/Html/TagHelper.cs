using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Company.Collections.Generic.Extensions;

namespace Company.Web.Mvc.Html
{
	public class TagHelper : ITagHelper
	{
		#region Fields

		private static readonly IDictionary<string, string> _dataTypeToHtmlTextInputTypeMappings = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
		{
			{new DataTypeAttribute(DataType.Date).GetDataTypeName(), "date"},
			{new DataTypeAttribute(DataType.DateTime).GetDataTypeName(), "datetime"},
			{new DataTypeAttribute(DataType.EmailAddress).GetDataTypeName(), "email"},
			{new DataTypeAttribute(DataType.ImageUrl).GetDataTypeName(), "url"},
			{new DataTypeAttribute(DataType.Url).GetDataTypeName(), "url"}
		};

		private static readonly IDictionary<Type, string> _typeToHtmlTextInputTypeMappings = new Dictionary<Type, string>
		{
			{typeof(int), "number"},
			{typeof(int?), "number"},
			{typeof(Uri), "url"}
		};

		#endregion

		#region Properties

		protected internal virtual IDictionary<string, string> DataTypeToHtmlTextInputTypeMappings
		{
			get { return _dataTypeToHtmlTextInputTypeMappings; }
		}

		protected internal virtual IDictionary<Type, string> TypeToHtmlTextInputTypeMappings
		{
			get { return _typeToHtmlTextInputTypeMappings; }
		}

		#endregion

		#region Methods

		protected internal virtual void AddAttributesToMetadataMappings(IDictionary<string, Func<string>> attributesToMetadataMappings, ModelMetadata metadata)
		{
			if(attributesToMetadataMappings == null)
				throw new ArgumentNullException("attributesToMetadataMappings");

			if(metadata == null)
				throw new ArgumentNullException("metadata");

			attributesToMetadataMappings.Add("title", () => metadata.Description);
		}

		protected internal virtual void AddBooleanAttributeToMetadataMapping(IDictionary<string, Func<string>> attributesToMetadataMappings, string attributeName, Func<bool> attributeValueFunction)
		{
			if(attributesToMetadataMappings == null)
				throw new ArgumentNullException("attributesToMetadataMappings");

			attributesToMetadataMappings.Add(attributeName, () => attributeValueFunction.Invoke() ? attributeName : null);
		}

		protected internal virtual void AddInputAttributesToMetadataMappings(IDictionary<string, Func<string>> attributesToMetadataMappings, ModelMetadata metadata)
		{
			if(attributesToMetadataMappings == null)
				throw new ArgumentNullException("attributesToMetadataMappings");

			if(metadata == null)
				throw new ArgumentNullException("metadata");

			this.AddAttributesToMetadataMappings(attributesToMetadataMappings, metadata);
			this.AddBooleanAttributeToMetadataMapping(attributesToMetadataMappings, "required", () => metadata.IsRequired);
		}

		protected internal virtual void AddTextAreaAndTextInputAttributesToMetadataMappings(IDictionary<string, Func<string>> attributesToMetadataMappings, ModelMetadata metadata)
		{
			if(attributesToMetadataMappings == null)
				throw new ArgumentNullException("attributesToMetadataMappings");

			if(metadata == null)
				throw new ArgumentNullException("metadata");

			this.AddInputAttributesToMetadataMappings(attributesToMetadataMappings, metadata);
			attributesToMetadataMappings.Add("placeholder", () => metadata.Watermark);
			this.AddBooleanAttributeToMetadataMapping(attributesToMetadataMappings, "readonly", () => metadata.IsReadOnly);
		}

		protected internal virtual void AddTextAreaAttributesToMetadataMappings(IDictionary<string, Func<string>> attributesToMetadataMappings, ModelMetadata metadata, ControllerContext controllerContext)
		{
			if(attributesToMetadataMappings == null)
				throw new ArgumentNullException("attributesToMetadataMappings");

			if(metadata == null)
				throw new ArgumentNullException("metadata");

			this.AddTextAreaAndTextInputAttributesToMetadataMappings(attributesToMetadataMappings, metadata);
			this.AddValidationAttributesToMetadataMapping(attributesToMetadataMappings, this.GetClientValidationRules(metadata, controllerContext).Where(this.IsTextAreaClientValidationRule));
		}

		protected internal virtual void AddTextInputAttributesToMetadataMappings(IDictionary<string, Func<string>> attributesToMetadataMappings, ModelMetadata metadata, ControllerContext controllerContext)
		{
			if(attributesToMetadataMappings == null)
				throw new ArgumentNullException("attributesToMetadataMappings");

			if(metadata == null)
				throw new ArgumentNullException("metadata");

			this.AddTextAreaAndTextInputAttributesToMetadataMappings(attributesToMetadataMappings, metadata);

			var htmlInputType = this.GetHtmlInputType(metadata);
			if(!string.IsNullOrEmpty(htmlInputType))
				attributesToMetadataMappings.Add("type", () => htmlInputType);

			this.AddValidationAttributesToMetadataMapping(attributesToMetadataMappings, this.GetClientValidationRules(metadata, controllerContext).Where(this.IsTextInputClientValidationRule));
		}

		protected internal virtual void AddValidationAttributesToMetadataMapping(IDictionary<string, Func<string>> attributesToMetadataMappings, IEnumerable<ModelClientValidationRule> clientValidationRules)
		{
			if(attributesToMetadataMappings == null)
				throw new ArgumentNullException("attributesToMetadataMappings");

			foreach(var clientValidationRule in (clientValidationRules ?? Enumerable.Empty<ModelClientValidationRule>()))
			{
				foreach(var item in clientValidationRule.ValidationParameters)
				{
					var itemReference = item;

					if(clientValidationRule is ModelClientValidationMaxLengthRule || clientValidationRule is ModelClientValidationStringLengthRule)
					{
						if(!string.Equals(itemReference.Key, "max", StringComparison.OrdinalIgnoreCase))
							continue;
					}

					attributesToMetadataMappings.Add(itemReference.Key, () => itemReference.Value.ToString());
				}
			}
		}

		public virtual IHtmlString AttributesToHtml(IDictionary<string, object> attributes)
		{
			return this.AttributesToHtml(attributes, true, false);
		}

		public virtual IHtmlString AttributesToHtml(IDictionary<string, object> attributes, bool leadingSpace, bool trailingSpace)
		{
			var html = string.Empty;

			if(attributes != null)
			{
				// ReSharper disable LoopCanBeConvertedToQuery
				foreach(var attribute in attributes)
				{
					if(string.IsNullOrEmpty(attribute.Key))
						continue;

					if(attribute.Value == null)
						continue;

					html += string.Format(CultureInfo.InvariantCulture, " {0}=\"{1}\"", attribute.Key, attribute.Value);
				}
				// ReSharper restore LoopCanBeConvertedToQuery
			}

			if(!leadingSpace)
				html = html.TrimStart(" ".ToCharArray());

			if(!string.IsNullOrEmpty(html) && trailingSpace)
				html += " ";

			return new HtmlString(html);
		}

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

			return this.BuildAttributes(htmlHelper.ViewData.ModelMetadata, htmlHelper.ViewContext, attributes);
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

			return this.BuildAttributes(this.GetMetadata(expression, htmlHelper.ViewData), htmlHelper.ViewContext, attributes);
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

			return this.BuildAttributes(this.GetMetadata(expression, htmlHelper.ViewData), htmlHelper.ViewContext, attributes);
		}

		protected internal virtual IDictionary<string, object> BuildAttributes(ModelMetadata metadata, ControllerContext controllerContext, IDictionary<string, object> attributes)
		{
			return this.BuildAttributes(this.CreateAttributesToMetadataMappings(metadata, controllerContext), attributes);
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

		public virtual IDictionary<string, object> BuildInputAttributes(HtmlHelper htmlHelper)
		{
			return this.BuildInputAttributes(htmlHelper, this.CreateAttributes());
		}

		public virtual IDictionary<string, object> BuildInputAttributes(HtmlHelper htmlHelper, object attributes)
		{
			return this.BuildInputAttributes(htmlHelper, HtmlHelper.AnonymousObjectToHtmlAttributes(attributes));
		}

		public virtual IDictionary<string, object> BuildInputAttributes(HtmlHelper htmlHelper, IDictionary<string, object> attributes)
		{
			if(htmlHelper == null)
				throw new ArgumentNullException("htmlHelper");

			return this.BuildInputAttributes(htmlHelper.ViewData.ModelMetadata, htmlHelper.ViewContext, attributes);
		}

		public virtual IDictionary<string, object> BuildInputAttributes(string expression, HtmlHelper htmlHelper)
		{
			return this.BuildInputAttributes(expression, htmlHelper, this.CreateAttributes());
		}

		public virtual IDictionary<string, object> BuildInputAttributes(string expression, HtmlHelper htmlHelper, object attributes)
		{
			return this.BuildInputAttributes(expression, htmlHelper, HtmlHelper.AnonymousObjectToHtmlAttributes(attributes));
		}

		public virtual IDictionary<string, object> BuildInputAttributes(string expression, HtmlHelper htmlHelper, IDictionary<string, object> attributes)
		{
			if(htmlHelper == null)
				throw new ArgumentNullException("htmlHelper");

			return this.BuildInputAttributes(this.GetMetadata(expression, htmlHelper.ViewData), htmlHelper.ViewContext, attributes);
		}

		public virtual IDictionary<string, object> BuildInputAttributes<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression, HtmlHelper<TModel> htmlHelper)
		{
			return this.BuildInputAttributes(expression, htmlHelper, this.CreateAttributes());
		}

		public virtual IDictionary<string, object> BuildInputAttributes<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression, HtmlHelper<TModel> htmlHelper, object attributes)
		{
			return this.BuildInputAttributes(expression, htmlHelper, HtmlHelper.AnonymousObjectToHtmlAttributes(attributes));
		}

		public virtual IDictionary<string, object> BuildInputAttributes<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression, HtmlHelper<TModel> htmlHelper, IDictionary<string, object> attributes)
		{
			if(htmlHelper == null)
				throw new ArgumentNullException("htmlHelper");

			return this.BuildInputAttributes(this.GetMetadata(expression, htmlHelper.ViewData), htmlHelper.ViewContext, attributes);
		}

		protected internal virtual IDictionary<string, object> BuildInputAttributes(ModelMetadata metadata, ControllerContext controllerContext, IDictionary<string, object> attributes)
		{
			return this.BuildAttributes(this.CreateInputAttributesToMetadataMappings(metadata, controllerContext), attributes);
		}

		public virtual IDictionary<string, object> BuildTextAreaAttributes(HtmlHelper htmlHelper)
		{
			return this.BuildTextAreaAttributes(htmlHelper, this.CreateAttributes());
		}

		public virtual IDictionary<string, object> BuildTextAreaAttributes(HtmlHelper htmlHelper, object attributes)
		{
			return this.BuildTextAreaAttributes(htmlHelper, HtmlHelper.AnonymousObjectToHtmlAttributes(attributes));
		}

		public virtual IDictionary<string, object> BuildTextAreaAttributes(HtmlHelper htmlHelper, IDictionary<string, object> attributes)
		{
			if(htmlHelper == null)
				throw new ArgumentNullException("htmlHelper");

			return this.BuildTextAreaAttributes(htmlHelper.ViewData.ModelMetadata, htmlHelper.ViewContext, attributes);
		}

		public virtual IDictionary<string, object> BuildTextAreaAttributes(string expression, HtmlHelper htmlHelper)
		{
			return this.BuildTextAreaAttributes(expression, htmlHelper, this.CreateAttributes());
		}

		public virtual IDictionary<string, object> BuildTextAreaAttributes(string expression, HtmlHelper htmlHelper, object attributes)
		{
			return this.BuildTextAreaAttributes(expression, htmlHelper, HtmlHelper.AnonymousObjectToHtmlAttributes(attributes));
		}

		public virtual IDictionary<string, object> BuildTextAreaAttributes(string expression, HtmlHelper htmlHelper, IDictionary<string, object> attributes)
		{
			if(htmlHelper == null)
				throw new ArgumentNullException("htmlHelper");

			return this.BuildTextAreaAttributes(this.GetMetadata(expression, htmlHelper.ViewData), htmlHelper.ViewContext, attributes);
		}

		public virtual IDictionary<string, object> BuildTextAreaAttributes<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression, HtmlHelper<TModel> htmlHelper)
		{
			return this.BuildTextAreaAttributes(expression, htmlHelper, this.CreateAttributes());
		}

		public virtual IDictionary<string, object> BuildTextAreaAttributes<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression, HtmlHelper<TModel> htmlHelper, object attributes)
		{
			return this.BuildTextAreaAttributes(expression, htmlHelper, HtmlHelper.AnonymousObjectToHtmlAttributes(attributes));
		}

		public virtual IDictionary<string, object> BuildTextAreaAttributes<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression, HtmlHelper<TModel> htmlHelper, IDictionary<string, object> attributes)
		{
			if(htmlHelper == null)
				throw new ArgumentNullException("htmlHelper");

			return this.BuildTextAreaAttributes(this.GetMetadata(expression, htmlHelper.ViewData), htmlHelper.ViewContext, attributes);
		}

		protected internal virtual IDictionary<string, object> BuildTextAreaAttributes(ModelMetadata metadata, ControllerContext controllerContext, IDictionary<string, object> attributes)
		{
			return this.BuildAttributes(this.CreateTextAreaAttributesToMetadataMappings(metadata, controllerContext), attributes);
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

			return this.BuildTextInputAttributes(htmlHelper.ViewData.ModelMetadata, htmlHelper.ViewContext, attributes);
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

			return this.BuildTextInputAttributes(this.GetMetadata(expression, htmlHelper.ViewData), htmlHelper.ViewContext, attributes);
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

			return this.BuildTextInputAttributes(this.GetMetadata(expression, htmlHelper.ViewData), htmlHelper.ViewContext, attributes);
		}

		protected internal virtual IDictionary<string, object> BuildTextInputAttributes(ModelMetadata metadata, ControllerContext controllerContext, IDictionary<string, object> attributes)
		{
			return this.BuildAttributes(this.CreateTextInputAttributesToMetadataMappings(metadata, controllerContext), attributes);
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

		protected internal virtual IDictionary<string, Func<string>> CreateAttributesToMetadataMappings(ModelMetadata metadata, ControllerContext controllerContext)
		{
			var attributesToMetadataMappings = new Dictionary<string, Func<string>>();

			if(metadata != null)
				this.AddAttributesToMetadataMappings(attributesToMetadataMappings, metadata);

			return attributesToMetadataMappings;
		}

		protected internal virtual IDictionary<string, Func<string>> CreateInputAttributesToMetadataMappings(ModelMetadata metadata, ControllerContext controllerContext)
		{
			var attributesToMetadataMappings = new Dictionary<string, Func<string>>();

			if(metadata != null)
				this.AddInputAttributesToMetadataMappings(attributesToMetadataMappings, metadata);

			return attributesToMetadataMappings;
		}

		protected internal virtual IDictionary<string, Func<string>> CreateTextAreaAttributesToMetadataMappings(ModelMetadata metadata, ControllerContext controllerContext)
		{
			var attributesToMetadataMappings = new Dictionary<string, Func<string>>();

			if(metadata != null)
				this.AddTextAreaAttributesToMetadataMappings(attributesToMetadataMappings, metadata, controllerContext);

			return attributesToMetadataMappings;
		}

		protected internal virtual IDictionary<string, Func<string>> CreateTextInputAttributesToMetadataMappings(ModelMetadata metadata, ControllerContext controllerContext)
		{
			var attributesToMetadataMappings = new Dictionary<string, Func<string>>();

			if(metadata != null)
				this.AddTextInputAttributesToMetadataMappings(attributesToMetadataMappings, metadata, controllerContext);

			return attributesToMetadataMappings;
		}

		protected internal virtual IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext controllerContext)
		{
			if(metadata == null)
				throw new ArgumentNullException("metadata");

			if(controllerContext == null)
				throw new ArgumentNullException("controllerContext");

			var clientValidationRules = new List<ModelClientValidationRule>();

			foreach(var modelValidator in metadata.GetValidators(controllerContext))
			{
				clientValidationRules.AddRange(modelValidator.GetClientValidationRules());
			}

			return clientValidationRules.ToArray();
		}

		protected internal virtual string GetHtmlInputType(ModelMetadata metadata)
		{
			if(metadata == null)
				return null;

			string htmlInputType;

			if(metadata.DataTypeName != null && this.DataTypeToHtmlTextInputTypeMappings.TryGetValue(metadata.DataTypeName, out htmlInputType))
				return htmlInputType;

			if(this.TypeToHtmlTextInputTypeMappings.TryGetValue(metadata.ModelType, out htmlInputType))
				return htmlInputType;

			return null;
		}

		protected internal virtual ModelMetadata GetMetadata(string expression, ViewDataDictionary viewData)
		{
			return ModelMetadata.FromStringExpression(expression, viewData);
		}

		protected internal virtual ModelMetadata GetMetadata<TModel, TProperty>(Expression<Func<TModel, TProperty>> expression, ViewDataDictionary<TModel> viewData)
		{
			return ModelMetadata.FromLambdaExpression(expression, viewData);
		}

		protected internal virtual bool IsTextAreaClientValidationRule(ModelClientValidationRule clientValidationRule)
		{
			if(clientValidationRule is ModelClientValidationMaxLengthRule)
				return true;

			if(clientValidationRule is ModelClientValidationRegexRule)
				return true;

			if(clientValidationRule is ModelClientValidationStringLengthRule)
				return true;

			return false;
		}

		protected internal virtual bool IsTextInputClientValidationRule(ModelClientValidationRule clientValidationRule)
		{
			if(clientValidationRule is ModelClientValidationRangeRule)
				return true;

			return this.IsTextAreaClientValidationRule(clientValidationRule);
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