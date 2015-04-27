using System.ComponentModel.DataAnnotations;
using MvcApplication.Models.Forms;

namespace MvcApplication.Models.ViewModels
{
	public class HomeViewModel
	{
		#region Fields

		private TestForm _subForm;

		#endregion

		#region Properties

		[Display(Description = "FirstName - Description", GroupName = "FirstName - GroupName", Name = "FirstName - Name", Order = 10, Prompt = "FirstName - Prompt", ShortName = "FirstName - ShortName")]
		public virtual string FirstName { get; set; }

		[Display(Description = "LastName - Description", GroupName = "LastName - GroupName", Name = "LastName - Name", Order = 20, Prompt = "LastName - Prompt", ShortName = "LastName - ShortName")]
		public virtual string LastName { get; set; }

		public virtual TestForm SubForm
		{
			get { return this._subForm ?? (this._subForm = new TestForm()); }
			set { this._subForm = value; }
		}

		#endregion
	}
}