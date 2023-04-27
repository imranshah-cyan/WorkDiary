using System;
using WorkDiaryRepository.Dbo;

namespace WorkDiaryRepository
{
    public class RepositoryBase : IDisposable
    {
        #region :: VARIABLES / PROPERTIES ::

        internal ServiceDotNetEntities _db;

        #endregion

        #region :: CONSTRUCTORS ::
        public RepositoryBase()
        {
            _db = new ServiceDotNetEntities();


        }
        #endregion

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
