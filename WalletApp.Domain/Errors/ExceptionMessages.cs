using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletApp.Domain.Errors
{
    public static class ExceptionMessages
    {
        public static string EntityIsNull(string itemName)
        {
            return $"Entity is null {nameof(itemName)}";
        }

        public static string UserNotFound()
        {
            return $"User not found";
        }

        public static string NotFound(string itemName)
        {
            return $"{nameof(itemName)} not found";
        }

        public static string PasswordNoExist()
        {
            return $"Passwords do not match";
        }

        public static string UserIsExist()
        {
            return $"UserName is taken";
        }

        public static string ItemCantAddReason(string reasonError)
        {
            return $"Item cant add reason {reasonError}";
        }

        public static string ItemCantAdd()
        {
            return "Item cant add";
        }

        public static string ItemCantSaveReason(string reasonError)
        {
            return $"Item cant save reason {reasonError}";
        }

        public static string ItemCantSave()
        {
            return $"Item cant save";
        }
    }
}
