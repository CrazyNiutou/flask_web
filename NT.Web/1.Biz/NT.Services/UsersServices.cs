using NT.Entity;
using NT.Framework.Data;
using System;

namespace NT.Services
{
    public class UsersServices : StRespository<UsersEntity>
    {
        public static UsersServices Instance
        {
            get
            {
                return ReadNested.Instance;
            }
        }
        private UsersServices(string DataBase) : base(DataBase)
        {
        }
        class ReadNested
        {
            static ReadNested()
            {

            }
            internal static readonly UsersServices Instance = new UsersServices(DBKey.WebKey);

        }

        public bool Exist(string userName)
        {
            return base.Exists(x => x.UserName == userName);
        }
    }
}
