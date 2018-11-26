using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace NT.Framework.Data
{
    public partial class StRespository<T> where T : class, new()
    {
        private string dbKey;
        private string DataBase = "";
        private string ConnectString = "";

        IOrmLiteDialectProvider t
    }
}
