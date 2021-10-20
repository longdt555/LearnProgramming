using Microsoft.EntityFrameworkCore;
using StoreManagement.Models;

namespace StoreManagement.Context
{
    public class SMDBContext: DbContext
    {
        public SMDBContext(DbContextOptions<SMDBContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        //entities
        public DbSet<ChiTietDHModel> ChiTietDHs { get; set; }
        public DbSet<DonHangModel> DonHangs { get; set; }
        public DbSet<HangHoaModel> HangHoas { get; set; }
        public DbSet<KhachHangModel> KhachHangs { get; set; }
        public DbSet<LoaiModel> Loais { get; set; }

    }
}
