using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletApp.Domain.Interfaces
{
    public interface ICurrentUserService
    {
        public string UserName { get; }
    }
}
