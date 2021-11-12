using StoreManagement.Common.Helpers;
using StoreManagement.Dtos;
using StoreManagement.Models;

namespace StoreManagement.Data
{
    public static class LoggedOnUser
    {
        private static AccountModel _account { get; set; }
        public static void Set(AccountModel account)
        {
            _account = account;
        }

        public static AccountModel Get() => _account;
    }
}
