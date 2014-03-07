using System;
using System.ComponentModel.Composition;

using MefPrototype.Domain.Contracts;

namespace MefPrototype.Domain.Impl
{
	[Export(typeof(IDomainExtension))]
	[Serializable]
	public class ThirdDomainExtension : DomainExtension
	{
		public ThirdDomainExtension()
		{
			Name = "Third domain extension";
		}

		public override sealed string Name { get; protected set; }
	}
}
