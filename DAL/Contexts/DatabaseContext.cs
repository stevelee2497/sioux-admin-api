using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading;
using System.Threading.Tasks;
using Task = DAL.Models.Task;

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

        public DbSet<Position> Positions { get; set; }

        public DbSet<UserSkill> UserSkills { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public DbSet<BoardUser> BoardUsers { get; set; }

        public DbSet<WorkLog> WorkLogs { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<TaskAssignee> TaskAssignees { get; set; }

        public DbSet<TaskAction> TaskActions { get; set; }

        public DbSet<Task> Tasks { get; set; }

        public DbSet<Board> Boards { get; set; }

        public DbSet<Phase> Phases { get; set; }

        public DbSet<Todo> Todos { get; set; }

        public DbSet<Label> Labels { get; set; }

        public DbSet<TaskLabel> TaskLabels { get; set; }

        public DbSet<Attachment> Attachments { get; set; }


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