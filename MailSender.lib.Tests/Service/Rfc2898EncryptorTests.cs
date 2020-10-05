using MailSender.lib.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace MailSender.lib.Tests.Service
{
	[TestClass]
	public class Rfc2898EncryptorTests
	{
		private IEncryptorService _Encryptor = new lib.Service.Rfc2898Encryptor();

		[TestMethod]
		public void Encrypt_Hello_World_and_Decrypt_with_Password()
		{
			const string str = "Hello World!";
			const string password = "Password";

			var encrypted_str = _Encryptor.Encrypt(str, password);

			var decrypted_str = _Encryptor.Decrypt(encrypted_str, password);
			//var wrong_pass_decrypted = _Encryptor.Decrypt(str, "qwerty");

			Assert.AreNotEqual(str, encrypted_str);
			Assert.AreEqual(str, decrypted_str);
			//Assert.AreNotEqual(str, wrong_pass_decrypted);
		}
	}
}
