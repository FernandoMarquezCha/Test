﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestInterview
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class CarlosMárquezEntities1 : DbContext
    {
        public CarlosMárquezEntities1()
            : base("name=CarlosMárquezEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AvaliableTypes> AvaliableTypes { get; set; }
        public virtual DbSet<Buildings> Buildings { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<PartNumbers> PartNumbers { get; set; }
    
        public virtual int Add_Building(string building, Nullable<bool> avaliable)
        {
            var buildingParameter = building != null ?
                new ObjectParameter("Building", building) :
                new ObjectParameter("Building", typeof(string));
    
            var avaliableParameter = avaliable.HasValue ?
                new ObjectParameter("Avaliable", avaliable) :
                new ObjectParameter("Avaliable", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Add_Building", buildingParameter, avaliableParameter);
        }
    
        public virtual int Add_Customer(string customer, string pREFIX, Nullable<int> fKBuilding, Nullable<bool> avaliable)
        {
            var customerParameter = customer != null ?
                new ObjectParameter("Customer", customer) :
                new ObjectParameter("Customer", typeof(string));
    
            var pREFIXParameter = pREFIX != null ?
                new ObjectParameter("PREFIX", pREFIX) :
                new ObjectParameter("PREFIX", typeof(string));
    
            var fKBuildingParameter = fKBuilding.HasValue ?
                new ObjectParameter("FKBuilding", fKBuilding) :
                new ObjectParameter("FKBuilding", typeof(int));
    
            var avaliableParameter = avaliable.HasValue ?
                new ObjectParameter("Avaliable", avaliable) :
                new ObjectParameter("Avaliable", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Add_Customer", customerParameter, pREFIXParameter, fKBuildingParameter, avaliableParameter);
        }
    
        public virtual int Add_PartNumbers(string partNumber, Nullable<int> fKCustomer, Nullable<bool> avaliable)
        {
            var partNumberParameter = partNumber != null ?
                new ObjectParameter("PartNumber", partNumber) :
                new ObjectParameter("PartNumber", typeof(string));
    
            var fKCustomerParameter = fKCustomer.HasValue ?
                new ObjectParameter("FKCustomer", fKCustomer) :
                new ObjectParameter("FKCustomer", typeof(int));
    
            var avaliableParameter = avaliable.HasValue ?
                new ObjectParameter("Avaliable", avaliable) :
                new ObjectParameter("Avaliable", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Add_PartNumbers", partNumberParameter, fKCustomerParameter, avaliableParameter);
        }
    }
}
