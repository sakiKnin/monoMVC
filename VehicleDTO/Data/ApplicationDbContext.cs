using Microsoft.EntityFrameworkCore;
using VehicleDTO.Models;

namespace VehicleDTO.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
	
	protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleMakeEntity>()
			.HasIndex(a => a.Id)
            		.IsUnique();

	    modelBuilder.Entity<VehicleModelEntity>()
			.HasKey(ca => ca.Id);

	    // one-to-one relationship between VehicleMake and VehicleModel
	    modelBuilder.Entity<VehicleMakeEntity>()
			    .HasOne(a => a.VehicleModelEntity)
			    .WithOne(a => a.VehicleMakeEntity)
            		    .HasForeignKey<VehicleModelEntity>(a => a.MakeId).HasConstraintName("VehicleModelFK");

	}
	
        public DbSet<VehicleMakeEntity> VehicleMakeEntity { get; set; } 
        public DbSet<VehicleModelEntity> VehicleModelEntity { get; set; }
	
    }
}
