using Microsoft.EntityFrameworkCore;
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


        //entities
        public DbSet<ChiTietDHModel> ChiTietDHs { get; set; }
        public DbSet<DonHangModel> DonHangs { get; set; }
        public DbSet<HangHoaModel> HangHoas { get; set; }
        public DbSet<KhachHangModel> KhachHangs { get; set; }
        public DbSet<LoaiModel> Loais { get; set; }
        public DbSet<LoaiKhachHangModel> LoaiKhachHangs { get; set; }
        public DbSet<AccountModel> AccountModels { get; set; }
        public DbSet<RoleModel> Roles { get; set; }
    }
}
