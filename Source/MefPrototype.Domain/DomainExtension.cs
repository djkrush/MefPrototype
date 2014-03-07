using System;

using MefPrototype.Domain.Contracts;

namespace MefPrototype.Domain
{
	public abstract class DomainExtension : MarshalByRefObject, IDomainExtension
	{
		public abstract string Name { get; protected set; }

		public virtual bool IsValid(IDomainExtension extension)
		{
			var result = extension != null && extension.GetType() == GetType();

			return result;
		}
	}
}
