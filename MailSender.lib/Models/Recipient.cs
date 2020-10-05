using MailSender.lib.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MailSender.lib.Models
{
	public class Recipient : Person, IDataErrorInfo
	{
		public override string Name
		{
			get => base.Name;
			set
			{

				base.Name = value;
			}
		}

		string IDataErrorInfo.Error { get; } = null;

		string IDataErrorInfo.this[string PropertyName]
		{
			get
			{
				switch (PropertyName)
				{
					case (nameof(Name)):
						var name = Name;
						if (name is null) return "Имя не должно быть пустой строкой";
						if (name.Length < 2) return "Имя не может быть меньше 2 символов";
						if (name.Length > 20) return "Имя не может быть больше 20 символов";

						return null;

					case (nameof(Address)):
						return null;
					default:
						return null;
				}
			}
		}
	}
}
