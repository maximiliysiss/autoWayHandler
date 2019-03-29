using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectTransportSystem.Models.Database;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectTransportSystem.Models
{
    public class ContextAttribute : Attribute { }


    /// <summary>
    /// Главный контекст для доступа к БД
    /// </summary>
    public class MainDbContext : DbContext
    {
        public Dictionary<string, IEnumerable> dictionaryOfContext;

        public Dictionary<string, IEnumerable> DictionaryOfContext
        {
            get
            {
                if (dictionaryOfContext == null)
                    dictionaryOfContext = this.GetType().GetProperties()
                       .Where(x => x.GetCustomAttributes(typeof(ContextAttribute), false).Length > 0)
                       .ToDictionary(x => x.Name, x => x.GetValue(this) as IEnumerable);
                return dictionaryOfContext;
            }
        }

        public IEnumerable GetContext(string name)
        {
            try
            {
                if (DictionaryOfContext.TryGetValue(name, out var value))
                    return value;
                throw new Exception("Not found context");
            }
            catch (Exception ex)
            {
                GlobalStaticContext.Logger.Log(LogLevel.Information, ex, ex.InnerException.Message);
            }
            return null;
        }

        [Context]
        public DbSet<AdditionalOperation> AdditionalOperations { get; set; }
        [ContextAttribute]
        public DbSet<TrailerCar> CarTrailers { get; set; }
        [ContextAttribute]
        public DbSet<Cargo> Cargoes { get; set; }
        [ContextAttribute]
        public DbSet<Contract> Contracts { get; set; }
        [ContextAttribute]
        public DbSet<Costing> Costings { get; set; }
        [ContextAttribute]
        public DbSet<DistanceOnRoadGroup> DistanceOnRoadGroups { get; set; }
        [ContextAttribute]
        public DbSet<DownTimeOnLine> DownTimeOnLines { get; set; }
        [ContextAttribute]
        public DbSet<DriverWork> DriverWorks { get; set; }
        [ContextAttribute]
        public DbSet<DriverAccompanying> DriverAccompanyings { get; set; }
        [ContextAttribute]
        public DbSet<Fuel> Fuels { get; set; }
        [ContextAttribute]
        public DbSet<InformationAboutCargo> InformationAboutTheCargoes { get; set; }
        [ContextAttribute]
        public DbSet<LegalEntity> LegalEntities { get; set; }
        [ContextAttribute]
        public DbSet<LoadUnloadOperation> LoadingAndUnloadingOperations { get; set; }
        [ContextAttribute]
        public DbSet<MovingFuel> MovingFuels { get; set; }
        [ContextAttribute]
        public DbSet<Operation> Operations { get; set; }
        [ContextAttribute]
        public DbSet<OperationLoadUnloadEtc> OperationLoadUnloadEtcs { get; set; }
        [ContextAttribute]
        public DbSet<OtherInformation> OtherInformation { get; set; }
        [ContextAttribute]
        public DbSet<Role> Roles { get; set; }
        [ContextAttribute]
        public DbSet<TransportType> TransportTypes { get; set; }
        [ContextAttribute]
        public DbSet<Trip> Trips { get; set; }
        [ContextAttribute]
        public DbSet<WayBill> WayBills { get; set; }
        [ContextAttribute]
        public DbSet<WayList> WayLists { get; set; }
        [ContextAttribute]
        public DbSet<ShippingKind> ShippingKinds { get; set; }
        [ContextAttribute]
        public DbSet<WaysAndShipping> WaysAndShippings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-MU02QL6\SQLEXPRESS;Initial Catalog=TransportSystem;Integrated Security=True");
            //GlobalStaticContext.Logger.LogInformation($"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={AppDomain.CurrentDomain.BaseDirectory}App_Data\\LocalDatabase.mdf;Integrated Security=True");
            //optionsBuilder.UseSqlServer($"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={AppDomain.CurrentDomain.BaseDirectory}App_Data\\LocalDatabase.mdf;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
