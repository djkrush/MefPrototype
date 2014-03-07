using System;
using System.ComponentModel.Composition;

using MefPrototype.Domain.Contracts;

namespace MefPrototype.Domain.Impl
{
	[Export(typeof(IDomainExtension))]
	[Serializable]
	public class SecondDomainExtension : DomainExtension
	{
		public SecondDomainExtension()
		{
			Name = "Second domain extension";
		}

		public override sealed string Name { get; protected set; }
	}
}
