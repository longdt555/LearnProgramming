using System;
using Microsoft.EntityFrameworkCore;
using StoreManagement.Dtos;
using StoreManagement.Models;

namespace StoreManagement.Context
{
    public class SMDBContext : DbContext
    {
        public SMDBContext(DbContextOptions<SMDBContext> options) : base(options)
        {
        }

        public SMDBContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region [Params]

            var today = DateTime.Now;
            var userId = 1;

            #endregion [Params]

            #region [Loại khách hàng]



            #endregion [Loại khách hàng]
            modelBuilder.Entity<LoaiKhachHangModel>().HasData(
                new LoaiKhachHangModel() { Id = 1, Name = "VIP_1", Type = "V1", DiscountCode = 2, CreatedBy = userId, CreatedDate = today, UpdatedBy = userId, UpdatedDate = today, IsDeleted = false },
                new LoaiKhachHangModel() { Id = 2, Name = "VIP_2", Type = "V2", DiscountCode = 4, CreatedBy = userId, CreatedDate = today, UpdatedBy = userId, UpdatedDate = today, IsDeleted = false },
                new LoaiKhachHangModel() { Id = 3, Name = "VIP_3", Type = "V3", DiscountCode = 6, CreatedBy = userId, CreatedDate = today, UpdatedBy = userId, UpdatedDate = today, IsDeleted = false },
                new LoaiKhachHangModel() { Id = 4, Name = "VIP_4", Type = "V4", DiscountCode = 8, CreatedBy = userId, CreatedDate = today, UpdatedBy = userId, UpdatedDate = today, IsDeleted = false }
                );
        }
        //entities
        public DbSet<ChiTietDHModel> ChiTietDHs { get; set; }
        public DbSet<DonHangModel> DonHangs { get; set; }
        public DbSet<HangHoaModel> HangHoas { get; set; }
        public DbSet<KhachHangModel> KhachHangs { get; set; }
        public DbSet<LoaiModel> Loais { get; set; }
        public DbSet<LoaiKhachHangModel> LoaiKhachHangs { get; set; }
        public DbSet<StoreManagement.Dtos.KhachHangDto> KhachHangDto { get; set; }
    }
}
