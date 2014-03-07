using System;
using System.ComponentModel.Composition;

using MefPrototype.Domain.Contracts;

namespace MefPrototype.Domain.Impl
{
	[Export(typeof(IDomainExtension))]
	[Serializable]
	public class FourthDomainExtension : DomainExtension
	{
		public FourthDomainExtension()
		{
			Name = "Fourth domain extension";
		}

		public override sealed string Name { get; protected set; }
	}
}
