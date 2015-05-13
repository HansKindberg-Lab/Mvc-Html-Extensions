using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MvcApplication.Business.Enumerations;

namespace MvcApplication.Models.Forms
{
	public class TestForm
	{
		#region Properties

		[Display(Description = "Email - Description", GroupName = "Email - GroupName", Name = "Email - Name", Order = 10, Prompt = "Email - Prompt", ShortName = "Email - ShortName")]
		[EmailAddress]
		public virtual string Email { get; set; }

		[Display(Description = "LocalizedEnumerationValue - Description", GroupName = "LocalizedEnumerationValue - GroupName", Name = "LocalizedEnumerationValue - Name", Order = 10, Prompt = "LocalizedEnumerationValue - Prompt", ShortName = "LocalizedEnumerationValue - ShortName")]
		public virtual LocalizedEnumeration? LocalizedEnumerationValue { get; set; }

		[Display(Description = "Message - Description", GroupName = "Message - GroupName", Name = "Message - Name", Order = 20, Prompt = "Message - Prompt", ShortName = "Message - ShortName")]
		public virtual string Message { get; set; }

		[Display(Description = "Number - Description", GroupName = "Number - GroupName", Name = "Number - Name", Order = 10, Prompt = "Number - Prompt", ShortName = "Number - ShortName")]
		[Range(1, int.MaxValue)]
		public virtual int Number { get; set; }

		[Display(Description = "Pattern - Description", GroupName = "Pattern - GroupName", Name = "Pattern - Name", Order = 10, Prompt = "Pattern - Prompt", ShortName = "Pattern - ShortName")]
		[RegularExpression("Test")]
		public virtual string Pattern { get; set; }

		[Display(Description = "ReadOnlyValue - Description", GroupName = "ReadOnlyValue - GroupName", Name = "ReadOnlyValue - Name", Order = 10, Prompt = "ReadOnlyValue - Prompt", ShortName = "ReadOnlyValue - ShortName")]
		[ReadOnly(true)]
		public virtual string ReadOnlyValue { get; set; }

		[Display(Description = "RequiredValue - Description", GroupName = "RequiredValue - GroupName", Name = "RequiredValue - Name", Order = 10, Prompt = "RequiredValue - Prompt", ShortName = "RequiredValue - ShortName")]
		[Required(ErrorMessage = "RequiredValue - ErrorMessage")]
		public virtual string RequiredValue { get; set; }

		[Display(Description = "Sender - Description", GroupName = "Sender - GroupName", Name = "Sender - Name", Order = 10, Prompt = "Sender - Prompt", ShortName = "Sender - ShortName")]
		public virtual string Sender { get; set; }

		[Display(Description = "UnlocalizedEnumerationValue - Description", GroupName = "UnlocalizedEnumerationValue - GroupName", Name = "UnlocalizedEnumerationValue - Name", Order = 10, Prompt = "UnlocalizedEnumerationValue - Prompt", ShortName = "UnlocalizedEnumerationValue - ShortName")]
		public virtual UnlocalizedEnumeration UnlocalizedEnumerationValue { get; set; }

		[Display(Description = "Url - Description", GroupName = "Url - GroupName", Name = "Url - Name", Order = 10, Prompt = "Url - Prompt", ShortName = "Url - ShortName")]
		public virtual Uri Url { get; set; }

		[DataType("number")]
		[Display(Description = "ValueAsNumberInput - Description", GroupName = "ValueAsNumberInput - GroupName", Name = "ValueAsNumberInput - Name", Order = 10, Prompt = "ValueAsNumberInput - Prompt", ShortName = "ValueAsNumberInput - ShortName")]
		public virtual string ValueAsNumberInput { get; set; }

		#endregion
	}
}