using System.ComponentModel.DataAnnotations;

namespace MvcApplication.Models.Forms
{
	public class TestForm
	{
		#region Properties

		[Display(Description = "Message - Description", GroupName = "Message - GroupName", Name = "Message - Name", Order = 20, Prompt = "Message - Prompt", ShortName = "Message - ShortName")]
		public virtual string Message { get; set; }

		[Display(Description = "Sender - Description", GroupName = "Sender - GroupName", Name = "Sender - Name", Order = 10, Prompt = "Sender - Prompt", ShortName = "Sender - ShortName")]
		public virtual string Sender { get; set; }

		#endregion
	}
}