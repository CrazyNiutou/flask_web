using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Text;

namespace NT.Framework.Data
{
    public partial class StRespository<T> where T : class, new()
    {
        private string _dbKey;
        private string DataBase = "";
        private string ConnectString = "";

        IOrmLiteDialectProvider _type = MySqlDialect.Provider;

        public StRespository(string dbkey, IOrmLiteDialectProvider provider = null)
        {
            this._dbKey = dbkey;
            if (provider != null)
            {
                this._type = provider;
            }
            ConnectString = DBString.ConnectString;
            OrmLiteConfig.DialectProvider = _type;
        }


        public StRespository(string dbkey, string connkey, IOrmLiteDialectProvider type = null)
        {
            this._dbKey = dbkey;
            //LogManager.LogFactory = new ConsoleLogFactory();

            if (type != null)
            {
                _type = type;
            }

            OrmLiteConfig.DialectProvider = _type; 
            ConnectString = DBString.ConnectString;
        }

        protected virtual bool Exists(Expression<Func<T, bool>> filter)
        {
            using (var db = GetDbConnection())
            {
                return db.Exists(filter);
            }
        }

        protected virtual IDbConnection GetDbConnection()
        {
            return ConnectString.OpenDbConnection();
        }
    }
}
