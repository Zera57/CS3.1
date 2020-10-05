using System;
using System.Collections.Generic;
using System.Text;

namespace MailSender.lib.Models.Base
{
	public abstract class Entity
	{
		public int ID { get; set; }
	}

	public abstract class NamedEntitie : Entity
	{
		public virtual string Name { get; set; }
	}

	public abstract class Person : NamedEntitie
	{
		public string Address { get; set; }
	}
}
