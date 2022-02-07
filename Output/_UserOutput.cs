using Binus.WS.Pattern.Output;
using System.Collections.Generic;

namespace DuitKu.API.Output
{
    public class _UserOutputGet : OutputBase
    {
        public List<UserDetail> Data { get; set; }

        public _UserOutputGet()
        {
            this.Data = new List<UserDetail>();
        }
    }

    public class _UserOutputAddAndPatch : OutputBase
    {
        public _UserOutputAddAndPatch()
        {
            this.Success = 0;
        }

        public int Success { get; set; }
    }

    public class SpecificUserOutput : OutputBase
    {
        public List<SpecificUserDetail> Data { get; set; }

        public SpecificUserOutput()
        {
            this.Data = new List<SpecificUserDetail>();
        }
    }
    public class UserDetail
    {
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public int UserBalance { get; set; }
        public int UserFinalBalance { get; set; }
    }
    public class SpecificUserDetail
    {
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string Password { get; set; }
        public int UserBalance { get; set; }
        public int UserFinalBalance { get; set; }
    }

    public class UserDetailWithId
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string Password { get; set; }
        public int UserBalance { get; set; }
        public int UserFinalBalance { get; set; }
    }
}