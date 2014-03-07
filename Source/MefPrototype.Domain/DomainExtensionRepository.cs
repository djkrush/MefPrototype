using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;

using MefPrototype.Domain.Contracts;

namespace MefPrototype.Domain
{
	public class DomainExtensionRepository : MarshalByRefObject, IDomainExtensionRepository
	{
		private static CompositionContainer CreateContainer()
		{
			var catalog = new AggregateCatalog();

			var extensionsPath = Path.GetFullPath(@"..\..\..\MefPrototype.Domain.Extensions\bin\Debug");
			catalog.Catalogs.Add(new DirectoryCatalog(extensionsPath));
			//catalog.Catalogs.Add(new AssemblyCatalog(typeof(DomainExtensionRepository).Assembly));

			var result = new CompositionContainer(catalog, CompositionOptions.DisableSilentRejection | CompositionOptions.IsThreadSafe);

			return result;
		}


		public DomainExtensionRepository()
		{
			var container = CreateContainer();

			try
			{
				//var conventions = new RegistrationBuilder();

				//conventions
				//	.ForTypesDerivedFrom<DomainExtension>()
				//	.Export<IDomainExtension>();

				//conventions
				//	.ForType<DomainExtensionRepository>()
				//	.ImportProperty(x => x.Extensions);

				//container.SatisfyImportsOnce(this, conventions);

				container.SatisfyImportsOnce(this);
			}
			catch (CompositionException ex)
			{
				Extensions = Enumerable.Empty<IDomainExtension>();
			}

			//Extensions = new List<IDomainExtension>
			//{
			//	new FirstDomainExtension(),
			//	new SecondDomainExtension(),
			//	new ThirdDomainExtension(),
			//	new FourthDomainExtension()
			//};
		}

		[ImportMany]
		public IEnumerable<IDomainExtension> Extensions { get; set; }
	}
}
