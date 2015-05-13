using System.ComponentModel.DataAnnotations;
using MvcApplication.Business.Enumerations.Resources;

namespace MvcApplication.Business.Enumerations
{
	public enum LocalizedEnumeration
	{
		[Display(Name = "First", ResourceType = typeof(LocalizedEnumerationResource))] First,
		[Display(Name = "Second", ResourceType = typeof(LocalizedEnumerationResource))] Second,
		[Display(Name = "Third", ResourceType = typeof(LocalizedEnumerationResource))] Third
	}
}