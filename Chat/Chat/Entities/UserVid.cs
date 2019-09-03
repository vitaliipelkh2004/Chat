using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Entities
{
    [Table("tblUserVid")]
    public class UserVid
    {
        [Key, Column(Order = 0)]
        public int ID { get; set; }
        [Key, Column(Order = 1), ForeignKey("Userof")]
        public int UserV_ID { get; set; }
        [Key, Column(Order = 2), ForeignKey("MiniChatof")]
        public int MiniChat_ID { get; set; }

        public virtual User Userof { get; set; }

        public virtual MiniChat MiniChatof { get; set; }
    }
}
