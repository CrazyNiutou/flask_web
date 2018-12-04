using ServiceStack.DataAnnotations;
using System;

namespace NT.Entity
{
    [Alias("users")]
    public class UsersEntity
    {
        public long UserId { get; set; }
        public string Pwd { get; set; }
        public string UserName { get; set; }
        public int UserInfo { get; set; }
        public string Remark { get; set; }
    }
}
