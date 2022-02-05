using Binus.WS.Pattern.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Duitku_API.Model
{
    [DatabaseName("DuitKu")]
    [Table("trTransaction")]
    public class trTransaction : BaseModel
    {
        [Column("TransactionID")]
        [Key]
        public int TransactionID { get; set; }
        [Column("Balance")]
        public int Balance { get; set; }
        [Column("Date")]
        public DateTime? Date { get; set; }
        [Column("Notes")]
        public string Notes { get; set; }
        [Column("TransactionType")]
        public string TransactionType { get; set; }
        [Column("UserID")]
        public int UserID { get; set; }
    }
}
