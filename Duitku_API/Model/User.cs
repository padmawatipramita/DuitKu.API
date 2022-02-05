using Binus.WS.Pattern.Model;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Duitku_API.Model
{
    [DatabaseName("DuitKu")]
    [Table("msUser")]
    public class msUser: BaseModel
    {
        [Column("UserID")]
        [Key]
        public int UserID { get; set; }
        [Column("UserName")]
        public string UserName { get; set; }
        [Column("UserEmail")]
        public string UserEmail { get; set; }
        [Column("UserPassword")]
        public string UserPassword { get; set; }
        [Column("UserBalance")]
        public int UserBalance { get; set; }
    }
}
