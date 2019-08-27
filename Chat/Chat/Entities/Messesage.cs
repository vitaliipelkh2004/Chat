using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Entities
{
    [Table("tblMessesage")]
  public class Messesage
    {
        [Key]
        public int ID { get; set; }
        [Required,StringLength(200)]
        public string Text { get; set; }
        [ForeignKey("Userof")]
        public int User_ID { get; set; }
        public virtual User Userof { get; set; }



    }
}
