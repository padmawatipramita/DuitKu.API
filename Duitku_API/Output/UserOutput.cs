using Binus.WS.Pattern.Output;

namespace Duitku_API.Output
{
    public class UserOutput : OutputBase
    {
        public List<UserDetail> Data { get; set; }

        public UserOutput()
        {
            this.Data = new List<UserDetail>();
            this.Success = 0;
        }

        public int Success { get; set; }

    }
    public class UserDetail
    {
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public int UserBalance { get; set; }
        public int UserFinalBalance { get; set; }
    }
}
