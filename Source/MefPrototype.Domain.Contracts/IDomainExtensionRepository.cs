using System.Collections.Generic;

namespace MefPrototype.Domain.Contracts
{
	public interface IDomainExtensionRepository
	{
		IEnumerable<IDomainExtension> Extensions { get; }
	}
}