using System;
using System.Collections.Generic;
using System.Text;

namespace MailSender.lib.Models.Base
{
	public class Entitie
	{
		public int ID { get; set; }
	}

	public class NamedEntitie : Entitie
	{
		public string Name { get; set; }
	}

	public class Person : NamedEntitie
	{
		public string Address { get; set; }
	}
}
