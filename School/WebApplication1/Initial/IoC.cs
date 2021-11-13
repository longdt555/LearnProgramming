using Microsoft.Extensions.DependencyInjection;
using StoreManagement.IServices;
using StoreManagement.Services;

namespace StoreManagement.Initial
{
    public class IoC
    {
        public static void Register(IServiceCollection services)
        {
            services.AddHttpContextAccessor();

            #region [Services]

            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<ILoaiService, LoaiService>();
            services.AddTransient<IKhachHangService, KhachHangService>();
            services.AddTransient<IHangHoaService, HangHoaService>();
            services.AddTransient<IDonHangService, DonHangService>();
            services.AddTransient<IChiTietDHService, ChiTietDHService>();
            services.AddTransient<IAccountService, AccountService>();

            #endregion [Services]
        }
    }
}
