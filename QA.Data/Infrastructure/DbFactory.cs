using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        QAEntities dbContext;

        public QAEntities Init()
        {
            return dbContext ?? (dbContext = new QAEntities());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
