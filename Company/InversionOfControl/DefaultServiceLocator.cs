using System;
using System.Collections.Generic;
using System.Linq;
using Company.Web.Mvc.Html;

namespace Company.InversionOfControl
{
	public class DefaultServiceLocator : IServiceLocator
	{
		#region Fields

		private readonly IDictionary<Type, object> _registrations = new Dictionary<Type, object>
		{
			{typeof(ITagHelper), new TagHelper()}
		};

		#endregion

		#region Properties

		protected internal virtual IDictionary<Type, object> Registrations
		{
			get { return this._registrations; }
		}

		#endregion

		#region Methods

		public virtual object GetService(Type serviceType)
		{
			if(serviceType == null)
				throw new ArgumentNullException("serviceType");

			if(this.Registrations.ContainsKey(serviceType))
				return this.Registrations[serviceType];

			return Activator.CreateInstance(serviceType);
		}

		public virtual T GetService<T>()
		{
			return (T) this.GetService(typeof(T));
		}

		public virtual T GetService<T>(string key)
		{
			return (T) this.GetService(typeof(T), key);
		}

		public virtual object GetService(Type serviceType, string key)
		{
			if(key == null)
				return this.GetService(serviceType);

			throw new NotImplementedException();
		}

		public virtual IEnumerable<T> GetServices<T>()
		{
			return this.GetServices(typeof(T)).OfType<T>();
		}

		public virtual IEnumerable<object> GetServices(Type serviceType)
		{
			return new[] {this.GetService(serviceType)};
		}

		#endregion
	}
}