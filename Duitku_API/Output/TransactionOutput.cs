using Binus.WS.Pattern.Output;

namespace Duitku_API.Output
{
    public class TransactionOutput : OutputBase
    {
        public TransactionOutput()
        {
            this.Success = 0;
        }
        public int Success { get; set; }
    }
}
