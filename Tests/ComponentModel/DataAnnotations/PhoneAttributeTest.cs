using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.ComponentModel.DataAnnotations
{
	[TestClass]
	public class PhoneAttributeTest
	{
		#region Methods

		[TestMethod]
		public void GetDataTypeName_Test()
		{
			Assert.AreEqual("PhoneNumber", new PhoneAttribute().GetDataTypeName());
		}

		#endregion
	}
}