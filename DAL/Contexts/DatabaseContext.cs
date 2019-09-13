using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Contexts
{
	public class DatabaseContext : DbContext, IDataContext
	{
		private readonly IConfigurationRoot _configRoot;

		public DatabaseContext(IConfigurationRoot configRoot)
		{
			_configRoot = configRoot;
		}

		#region DbSet

		public DbSet<User> Users { get; set; }

		public DbSet<Role> Roles { get; set; }

		public DbSet<UserRole> UserRoles { get; set; }

		#endregion

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(_configRoot.GetConnectionString("DefaultConnection"));
		}
	}

	public interface IDataContext : IDisposable
	{
		int SaveChanges();
		Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
		DbSet<TEntity> Set<TEntity>() where TEntity : class;
		EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
	}
}