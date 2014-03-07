using System;
using System.ComponentModel.Composition;

using MefPrototype.Domain.Contracts;

namespace MefPrototype.Domain.Impl
{
	[Export(typeof(IDomainExtension))]
	[Serializable]
	public class FirstDomainExtension : DomainExtension
	{
		public FirstDomainExtension()
		{
			Name = "First domain extension";
		}

		public override sealed string Name { get; protected set; }
	}
}
