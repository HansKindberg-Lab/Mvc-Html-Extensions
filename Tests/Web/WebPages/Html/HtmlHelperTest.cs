using System.Linq;
using System.Web.Routing;
using System.Web.WebPages.Html;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Web.WebPages.Html
{
	[TestClass]
	public class HtmlHelperTest
	{
		#region Methods

		[TestMethod]
		public void AnonymousObjectToHtmlAttributes_IfTheParameterIsAString_ShouldReturnARouteValueDictionaryWithOneItemWithInformationAboutTheStringLength()
		{
			var dictionary = HtmlHelper.AnonymousObjectToHtmlAttributes("Test");

			Assert.IsNotNull(dictionary);
			Assert.AreEqual(dictionary.GetType(), typeof(RouteValueDictionary));
			Assert.AreEqual(1, dictionary.Count);
			Assert.AreEqual("Length", dictionary.First().Key);
			Assert.AreEqual(4, dictionary.First().Value);
		}

		[TestMethod]
		public void AnonymousObjectToHtmlAttributes_IfTheParameterIsNull_ShouldReturnAnEmptyRouteValueDictionary()
		{
			var dictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(null);

			Assert.IsNotNull(dictionary);
			Assert.AreEqual(dictionary.GetType(), typeof(RouteValueDictionary));
			Assert.IsFalse(dictionary.Any());
		}

		#endregion
	}
}