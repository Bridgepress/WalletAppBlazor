using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletApp.Data.Entities
{
    public abstract class BaseEntity
    {        
        public AppUser? AppUser { get; set; }
        public Guid? AppUserId { get; set; }
    }
}
