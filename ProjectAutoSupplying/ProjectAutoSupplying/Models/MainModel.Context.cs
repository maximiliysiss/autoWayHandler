﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectAutoSupplying.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DatabaseEntities2 : DbContext
    {
        public DatabaseEntities2()
            : base("name=DatabaseEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Additional_Operation> Additional_Operations { get; set; }
        public virtual DbSet<Additional_operation__load_unload_> Additional_operation__load_unload_ { get; set; }
        public virtual DbSet<Car_Trailer> Car_Trailer { get; set; }
        public virtual DbSet<Car_Tralers_in_WayList> Car_Tralers_in_WayList { get; set; }
        public virtual DbSet<Cargo> Cargoes { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<Costing> Costings { get; set; }
        public virtual DbSet<Distance_of_transportation_by_road_group> Distance_of_transportation_by_road_groups { get; set; }
        public virtual DbSet<DownTime_on_Line> DownTime_on_Lines { get; set; }
        public virtual DbSet<Driver_Work> Driver_Works { get; set; }
        public virtual DbSet<Driver_Accompanying> Driver_Accompanying { get; set; }
        public virtual DbSet<Driver_Accompanying_in_WayList> Driver_Accompanying_in_WayList { get; set; }
        public virtual DbSet<Fuel> Fuels { get; set; }
        public virtual DbSet<Information_about_the_cargo> Information_about_the_cargoes { get; set; }
        public virtual DbSet<Legal_Entity> Legal_Entities { get; set; }
        public virtual DbSet<Loading_and_unloading_operation> Loading_and_unloading_operations { get; set; }
        public virtual DbSet<Moving_Fuel> Moving_Fuels { get; set; }
        public virtual DbSet<Operation> Operations { get; set; }
        public virtual DbSet<Other_Information> Other_Information { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Transport_Type> Transport_Types { get; set; }
        public virtual DbSet<WayBill> WayBills { get; set; }
        public virtual DbSet<WayBills_In_Contract> WayBills_In_Contracts { get; set; }
        public virtual DbSet<WayList> WayLists { get; set; }
        public virtual DbSet<Trip> Trips { get; set; }
    }
}
