using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.ComponentModel.DataAnnotations
{
	[TestClass]
	public class DataTypeAttributeTest
	{
		#region Methods

		[TestMethod]
		public void CustomDataType_Test()
		{
			var customDataTypeAttribute = new DataTypeAttribute(DataType.Custom);

			Assert.AreEqual(DataType.Custom, customDataTypeAttribute.DataType);
			Assert.IsNull(customDataTypeAttribute.CustomDataType);
			Assert.IsNull(customDataTypeAttribute.DisplayFormat);
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void GetDataTypeName_IfPassingDataTypeCustomToTheConstructor_ShouldThrowAnInvalidOperationException()
		{
			new DataTypeAttribute(DataType.Custom).GetDataTypeName();
		}

		[TestMethod]
		public void GetDataTypeName_Test()
		{
			foreach(var dataType in (DataType[]) Enum.GetValues(typeof(DataType)))
			{
				if(dataType != DataType.Custom)
					Assert.AreEqual(dataType.ToString(), new DataTypeAttribute(dataType).GetDataTypeName());
			}
		}

		#endregion
	}
}