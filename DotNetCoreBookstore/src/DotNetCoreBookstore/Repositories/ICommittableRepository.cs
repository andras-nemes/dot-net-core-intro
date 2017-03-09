using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreBookstore.Repositories
{
    public interface ICommittableRepository
    {
		void CommitChanges();
    }
}
