using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Entities
{
    [Table("tblUser")]
    public class User
    {
        [Key]
        public int ID { get; set; }
        [Required,StringLength(50)]
        public string FirstName { get; set; }
        [Required, StringLength(50)]
        public string LastName { get; set; }
      
        public virtual ICollection<UserReceiver> UserReceivers { get; set; }
        public virtual ICollection<Messesage> Messesageof { get; set; }
        public virtual ICollection<UserVid> UserVidof { get; set; }
}
}
