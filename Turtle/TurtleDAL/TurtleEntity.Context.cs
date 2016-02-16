﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TurtleDAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class TurtleEntities : DbContext
    {
        public TurtleEntities()
            : base("name=TurtleEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Clan> Clan { get; set; }
        public virtual DbSet<Equipment> Equipment { get; set; }
        public virtual DbSet<Ninja> Ninja { get; set; }
        public virtual DbSet<NinjaEquipment> NinjaEquipment { get; set; }
    
        public virtual ObjectResult<Nullable<int>> uspClanCount()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("uspClanCount");
        }
    
        public virtual int uspClanDelete(Nullable<System.Guid> clanGUID)
        {
            var clanGUIDParameter = clanGUID.HasValue ?
                new ObjectParameter("ClanGUID", clanGUID) :
                new ObjectParameter("ClanGUID", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspClanDelete", clanGUIDParameter);
        }
    
        public virtual int uspClanInsert(string name, string symbolPic, Nullable<bool> isEvil, Nullable<long> createdBy)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var symbolPicParameter = symbolPic != null ?
                new ObjectParameter("SymbolPic", symbolPic) :
                new ObjectParameter("SymbolPic", typeof(string));
    
            var isEvilParameter = isEvil.HasValue ?
                new ObjectParameter("IsEvil", isEvil) :
                new ObjectParameter("IsEvil", typeof(bool));
    
            var createdByParameter = createdBy.HasValue ?
                new ObjectParameter("CreatedBy", createdBy) :
                new ObjectParameter("CreatedBy", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspClanInsert", nameParameter, symbolPicParameter, isEvilParameter, createdByParameter);
        }
    
        public virtual ObjectResult<uspClanList_Result> uspClanList()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<uspClanList_Result>("uspClanList");
        }
    
        public virtual ObjectResult<uspClanSelect_Result> uspClanSelect(Nullable<System.Guid> clanGUID)
        {
            var clanGUIDParameter = clanGUID.HasValue ?
                new ObjectParameter("ClanGUID", clanGUID) :
                new ObjectParameter("ClanGUID", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<uspClanSelect_Result>("uspClanSelect", clanGUIDParameter);
        }
    
        public virtual int uspClanUpdate(string name, string symbolPic, Nullable<bool> isEvil, Nullable<long> createdBy, Nullable<System.Guid> clanGUID)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var symbolPicParameter = symbolPic != null ?
                new ObjectParameter("SymbolPic", symbolPic) :
                new ObjectParameter("SymbolPic", typeof(string));
    
            var isEvilParameter = isEvil.HasValue ?
                new ObjectParameter("IsEvil", isEvil) :
                new ObjectParameter("IsEvil", typeof(bool));
    
            var createdByParameter = createdBy.HasValue ?
                new ObjectParameter("CreatedBy", createdBy) :
                new ObjectParameter("CreatedBy", typeof(long));
    
            var clanGUIDParameter = clanGUID.HasValue ?
                new ObjectParameter("ClanGUID", clanGUID) :
                new ObjectParameter("ClanGUID", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspClanUpdate", nameParameter, symbolPicParameter, isEvilParameter, createdByParameter, clanGUIDParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> uspNinjaCount()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("uspNinjaCount");
        }
    
        public virtual int uspNinjaDelete(Nullable<System.Guid> ninjaGUID)
        {
            var ninjaGUIDParameter = ninjaGUID.HasValue ?
                new ObjectParameter("NinjaGUID", ninjaGUID) :
                new ObjectParameter("NinjaGUID", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspNinjaDelete", ninjaGUIDParameter);
        }
    
        public virtual int uspNinjaInsert(Nullable<int> clanID, string name, Nullable<int> age, string picture, Nullable<long> createdBy, Nullable<bool> isExperienced, Nullable<bool> isAlive)
        {
            var clanIDParameter = clanID.HasValue ?
                new ObjectParameter("ClanID", clanID) :
                new ObjectParameter("ClanID", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var ageParameter = age.HasValue ?
                new ObjectParameter("Age", age) :
                new ObjectParameter("Age", typeof(int));
    
            var pictureParameter = picture != null ?
                new ObjectParameter("Picture", picture) :
                new ObjectParameter("Picture", typeof(string));
    
            var createdByParameter = createdBy.HasValue ?
                new ObjectParameter("CreatedBy", createdBy) :
                new ObjectParameter("CreatedBy", typeof(long));
    
            var isExperiencedParameter = isExperienced.HasValue ?
                new ObjectParameter("IsExperienced", isExperienced) :
                new ObjectParameter("IsExperienced", typeof(bool));
    
            var isAliveParameter = isAlive.HasValue ?
                new ObjectParameter("IsAlive", isAlive) :
                new ObjectParameter("IsAlive", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspNinjaInsert", clanIDParameter, nameParameter, ageParameter, pictureParameter, createdByParameter, isExperiencedParameter, isAliveParameter);
        }
    
        public virtual ObjectResult<uspNinjaList_Result> uspNinjaList(Nullable<int> offset, Nullable<int> rows)
        {
            var offsetParameter = offset.HasValue ?
                new ObjectParameter("Offset", offset) :
                new ObjectParameter("Offset", typeof(int));
    
            var rowsParameter = rows.HasValue ?
                new ObjectParameter("Rows", rows) :
                new ObjectParameter("Rows", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<uspNinjaList_Result>("uspNinjaList", offsetParameter, rowsParameter);
        }
    
        public virtual ObjectResult<uspNinjaSelect_Result> uspNinjaSelect(Nullable<System.Guid> ninjaGUID)
        {
            var ninjaGUIDParameter = ninjaGUID.HasValue ?
                new ObjectParameter("NinjaGUID", ninjaGUID) :
                new ObjectParameter("NinjaGUID", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<uspNinjaSelect_Result>("uspNinjaSelect", ninjaGUIDParameter);
        }
    
        public virtual int uspNinjaUpdate(Nullable<int> clanID, string name, Nullable<int> age, string picture, Nullable<long> createdBy, Nullable<bool> isExperienced, Nullable<bool> isAlive, Nullable<bool> isDeleted, Nullable<System.Guid> ninjaGUID)
        {
            var clanIDParameter = clanID.HasValue ?
                new ObjectParameter("ClanID", clanID) :
                new ObjectParameter("ClanID", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var ageParameter = age.HasValue ?
                new ObjectParameter("Age", age) :
                new ObjectParameter("Age", typeof(int));
    
            var pictureParameter = picture != null ?
                new ObjectParameter("Picture", picture) :
                new ObjectParameter("Picture", typeof(string));
    
            var createdByParameter = createdBy.HasValue ?
                new ObjectParameter("CreatedBy", createdBy) :
                new ObjectParameter("CreatedBy", typeof(long));
    
            var isExperiencedParameter = isExperienced.HasValue ?
                new ObjectParameter("IsExperienced", isExperienced) :
                new ObjectParameter("IsExperienced", typeof(bool));
    
            var isAliveParameter = isAlive.HasValue ?
                new ObjectParameter("IsAlive", isAlive) :
                new ObjectParameter("IsAlive", typeof(bool));
    
            var isDeletedParameter = isDeleted.HasValue ?
                new ObjectParameter("IsDeleted", isDeleted) :
                new ObjectParameter("IsDeleted", typeof(bool));
    
            var ninjaGUIDParameter = ninjaGUID.HasValue ?
                new ObjectParameter("NinjaGUID", ninjaGUID) :
                new ObjectParameter("NinjaGUID", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspNinjaUpdate", clanIDParameter, nameParameter, ageParameter, pictureParameter, createdByParameter, isExperiencedParameter, isAliveParameter, isDeletedParameter, ninjaGUIDParameter);
        }
    }
}
