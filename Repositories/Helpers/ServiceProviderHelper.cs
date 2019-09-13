using System;
using Microsoft.Extensions.DependencyInjection;

namespace Repositories.Helpers
{
	public class ServiceProviderHelper
	{
		public static ServiceProviderHelper Current { get; private set; }

		private IServiceProvider ServiceProvider { get; set; }

		public static void Init(IServiceProvider serviceProvider)
		{
			Current = new ServiceProviderHelper
			{
				ServiceProvider = serviceProvider
			};
		}


		public object GetService(Type serviceType) => ServiceProvider.GetService(serviceType);

		public T GetService<T>() => ServiceProvider.GetService<T>();
	}
}
