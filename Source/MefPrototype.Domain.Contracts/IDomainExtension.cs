namespace MefPrototype.Domain.Contracts
{
	public interface IDomainExtension
	{
		string Name { get; }

		bool IsValid(IDomainExtension extension);
	}
}
