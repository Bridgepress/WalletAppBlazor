using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletApp.Domain.Authorization
{
    public class MyPolicies
    {
        public const string AdminAccessOnly = "AdminAccessOnly";
        public const string UserShowAndAboveAccess = "UserShowAndAboveAccess";
    }
}
