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
            modelBuilder.Entity<VehicleMake>()
			.HasIndex(a => a.Id)
            		.IsUnique();

	    modelBuilder.Entity<VehicleModel>()
			.HasKey(ca => ca.Id);

	    // one-to-one relationship between VehicleMake and VehicleModel
	    modelBuilder.Entity<VehicleMake>()
			    .HasOne(a => a.VehicleModel)
			    .WithOne(a => a.VehicleMake)
            		    .HasForeignKey<VehicleModel>(a => a.MakeId).HasConstraintName("VehicleModelFK");

	}
	
        public DbSet<VehicleMake> VehicleMake { get; set; } 
        public DbSet<VehicleModel> VehicleModel { get; set; }
	
    }
}
