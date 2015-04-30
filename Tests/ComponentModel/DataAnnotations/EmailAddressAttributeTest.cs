using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.ComponentModel.DataAnnotations
{
	[TestClass]
	public class EmailAddressAttributeTest
	{
		#region Methods

		[TestMethod]
		public void GetDataTypeName_Test()
		{
			Assert.AreEqual("EmailAddress", new EmailAddressAttribute().GetDataTypeName());
		}

		#endregion
	}
}