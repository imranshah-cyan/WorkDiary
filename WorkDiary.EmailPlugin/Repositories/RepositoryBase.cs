using exampleOfHangfire.Dto;
using System;

namespace EmailPlugin.Repositories
{
    public class RepositoryBase:IDisposable
    {
        #region :: VARIABLES / PROPERTIES ::

        internal ServiceDotNetEntities _db;

        #endregion

        #region :: CONSTRUCTORS ::
        public RepositoryBase()
        {
            _db = new ServiceDotNetEntities();
           _db.Database.CommandTimeout = 5000;
        }
        #endregion

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}