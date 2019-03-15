using Microsoft.EntityFrameworkCore;
using ProjectTransportSystem.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTransportSystem.Models
{
    /// <summary>
    /// Главный контекст для доступа к БД
    /// </summary>
    public class MainDbContext : DbContext
    {
        public DbSet<AdditionalOperation> Additional_Operations { get; set; }
        public DbSet<TrailerCar> Car_Trailer { get; set; }
        public DbSet<Cargo> Cargoes { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Costing> Costings { get; set; }
        public DbSet<DistanceOnRoadGroup> Distance_of_transportation_by_road_groups { get; set; }
        public DbSet<DownTimeOnLine> DownTime_on_Lines { get; set; }
        public DbSet<DriverWork> Driver_Works { get; set; }
        public DbSet<DriverAccompanying> Driver_Accompanying { get; set; }
        public DbSet<Fuel> Fuels { get; set; }
        public DbSet<InformationAboutCargo> Information_about_the_cargoes { get; set; }
        public DbSet<LegalEntity> Legal_Entities { get; set; }
        public DbSet<LoadUnloadOperation> Loading_and_unloading_operations { get; set; }
        public DbSet<MovingFuel> Moving_Fuels { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<OperationLoadUnloadEtc> OperationLoadUnloadEtcs { get; set; }
        public DbSet<OtherInformation> Other_Information { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<TransportType> Transport_Types { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<WayBill> WayBills { get; set; }
        public DbSet<WayList> WayLists { get; set; }
        public DbSet<ShippingKind> ShippingKinds { get; set; }
        public DbSet<WaysAndShipping> WaysAndShippings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
