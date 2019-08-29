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
   public class MiniChat
    {
        [Key]
        public int ID { get; set; }
        [Required,StringLength(200)]
        public string Text { get; set; }
        [ForeignKey("Userof_1")]
        public int User_ID_1 { get; set; }
        [ForeignKey("Userof_2")]
        public int User_ID_2 { get; set; }

        public virtual User Userof_1 { get; set; }
        public virtual User Userof_2 { get; set; }
    }
}
