using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Entities
{
    [Table("tblMiniChat")]
   public class Minichat
    {
        [Key]
        public int ID { get; set; }
        [Required,StringLength(200)]
        public string Text { get; set; }
        public virtual ICollection<UserReceiver> UserReceiverof { get; set; }
        public virtual ICollection<UserVid> UserVidof { get; set; }
    }
}
