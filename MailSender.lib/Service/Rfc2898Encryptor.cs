using System;
using System.Collections.Generic;
using System.Text;
using MailSender.lib.Interfaces;
using System.Security.Cryptography;
using System.IO;

namespace MailSender.lib.Service
{
	public class Rfc2898Encryptor : IEncryptorService
	{
		private static readonly byte[] SALT =
		{
			0x26 , 0xdc, 0xff, 0x00,
			0xad, 0xed, 0x7a, 0xee,
			0xc5, 0xfe, 0x07, 0xaf,
			0x4d, 0x08, 0x22, 0x3c
		};

		public Encoding Encoding { get; set; } = Encoding.UTF8;

		private static ICryptoTransform GetAlgorithm(string password)
		{
			var pdb = new Rfc2898DeriveBytes(password, SALT);
			var algorithm = Rijndael.Create();
			algorithm.Key = pdb.GetBytes(32);
			algorithm.IV = pdb.GetBytes(16);
			return algorithm.CreateEncryptor();
		}

		private static ICryptoTransform GetInverseAlgorithm(string password)
		{
			var pdb = new Rfc2898DeriveBytes(password, SALT);
			var algorithm = Rijndael.Create();
			algorithm.Key = pdb.GetBytes(32);
			algorithm.IV = pdb.GetBytes(16);
			return algorithm.CreateDecryptor();
		}

		public string Encrypt(string str, string Password)
		{
			var encoding = Encoding ?? Encoding.UTF8;
			var bytes = encoding.GetBytes(str);
			var crypted_bytes = Encrypt(bytes, Password);
			return Convert.ToBase64String(crypted_bytes);
		}

		public string Decrypt(string str, string Password)
		{
			var encoding = Encoding ?? Encoding.UTF8;
			var bytes = Convert.FromBase64String(str);
			var crypted_bytes = Decrypt(bytes, Password);
			return encoding.GetString(crypted_bytes);
		}

		public byte[] Encrypt(byte[] data, string Password)
		{
			var algorithm = GetAlgorithm(Password);

			using (var stream = new MemoryStream())
			using (var crypto_stream = new CryptoStream(stream, algorithm, CryptoStreamMode.Write))
			{
				crypto_stream.Write(data, 0, data.Length);
				crypto_stream.FlushFinalBlock();
				return stream.ToArray();
			}
		}

		public byte[] Decrypt(byte[] data, string Password)
		{
			var algorithm = GetInverseAlgorithm(Password);

			using(var stream = new MemoryStream())
			using(var crypto_stream = new CryptoStream(stream, algorithm, CryptoStreamMode.Write))
			{
				crypto_stream.Write(data, 0, data.Length);
				crypto_stream.FlushFinalBlock();
				return stream.ToArray();
			}
		}
	}
}
