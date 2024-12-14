using RecyclableCalculator.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecyclableCalculator.Infrastructure.DatabaseContext
{
	public class ApplicationDbContext : DbContext
	{
		public DbSet<RecyclableType> RecyclableTypes { get; set; }
		public DbSet<RecyclableItem> RecyclableItems { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}
}
