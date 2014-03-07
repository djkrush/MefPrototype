using System;
using System.ComponentModel.Composition;

using MefPrototype.Domain.Contracts;

namespace MefPrototype.Domain.Extensions.Impl
{
	[Export(typeof(IDomainExtension))]
	[Serializable]
	public class FirstMefExtension : DomainExtension
	{
		public FirstMefExtension()
		{
			Name = "First mef extension";
		}

		public override sealed string Name { get; protected set; }
	}
}
