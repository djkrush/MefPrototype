using System;
using System.Configuration;

using MefPrototype.Domain.Contracts;

namespace MefPrototype.ConsoleApp
{
	class Program
	{
		static void Main(string[] args)
		{
			var exit = false;

			do
			{
				if (DoesUserWantToDisplayExtensions())
				{
					DisplayExtensions();
				}
				else
				{
					exit = true;
				}
			}
			while (exit == false);
		}

		private static bool DoesUserWantToDisplayExtensions()
		{
			var result = false;

			Console.WriteLine(String.Empty);
			Console.WriteLine("Welcome to the MEF demo. Choose an option:");
			Console.WriteLine("[D]isplay extensions");
			Console.WriteLine("[E]xit");

			var selection = Console.ReadKey();

			Console.WriteLine(String.Empty);

			if (selection.KeyChar.ToString().ToUpperInvariant() == "D")
			{
				Console.WriteLine("Displaying extensions...");
				result = true;
			}
			else
			{
				Console.WriteLine(String.Empty);
				Console.WriteLine("Goodbye...");
			}

			return result;
		}

		private static void DisplayExtensions()
		{
			var domainAssemblyDirectory = ConfigurationManager.AppSettings["ExtensionsDirectory"];

			var setup = new AppDomainSetup
			{
				ShadowCopyFiles = "true",
				ShadowCopyDirectories = domainAssemblyDirectory,
				PrivateBinPath = domainAssemblyDirectory,
				ApplicationBase = domainAssemblyDirectory
			};

			var appDomain = AppDomain.CreateDomain("Child Domain", null, setup);

			var extensionRepository = appDomain.CreateInstanceAndUnwrap("MefPrototype.Domain", "MefPrototype.Domain.DomainExtensionRepository") as IDomainExtensionRepository;

			if (extensionRepository == null)
			{
				Console.WriteLine("Cannot load DomainExtensionRepository from separate AppDomain");
			}
			else
			{
				foreach (var extension in extensionRepository.Extensions)
				{
					Console.WriteLine(extension.Name);
					Console.WriteLine("IsValid: " + extension.IsValid(null));
				}
			}

			// Any reference to the extensions after this point will cause the application to crash
			AppDomain.Unload(appDomain);
		}
	}
}
