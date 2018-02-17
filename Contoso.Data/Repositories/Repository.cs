using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Contoso.Data.Repositories {
    class Repository<T> : IRepository<T> where T : class {

    }
}
