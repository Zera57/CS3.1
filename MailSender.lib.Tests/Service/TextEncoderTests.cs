using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using MailSenderService.lib;

namespace MailSender.lib.Tests.Service
{
	[TestClass]
	public class TextEncoderTests
	{
		[TestMethod]
		public void Encode_ABC_to_BCD_with_key_1()
		{
			//Arrange
			const string str = "ABC";
			const int key = 1;

			const string expected_str = "BCD";

			//Act
			var actual_str = TextEncoder.Encode(str, key);

			//Assert
			Assert.AreEqual(expected_str, actual_str);
		}

		[TestMethod]
		public void Decode_BCD_to_ABC_with_key_1()
		{
			//Arrange
			const string str = "BCD";
			const int key = 1;

			const string expected_str = "ABC";

			//Act
			var actual_str = TextEncoder.Decode(str, key);

			//Assert
			Assert.AreEqual(expected_str, actual_str);
		}
	}
}
