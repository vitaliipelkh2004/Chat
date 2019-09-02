using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Entities
{
   public class EFContext:DbContext
    {
        public EFContext():base("connchat")
        {


        }
       public DbSet<User> Users { get; set; }
        public DbSet<Messesage> Messesages { get; set; }
        public DbSet<MiniChat> MiniChats { get; set; }
        public DbSet<UserReceiver> userReceivers { get; set; }
    }
}
