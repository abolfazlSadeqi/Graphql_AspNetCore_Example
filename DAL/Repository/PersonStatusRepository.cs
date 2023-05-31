using DAL.Contexts;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository;

public class PersonStatusRepository : GenericRepository<PersonStatus>, IPersonStatusRepository
{
    public PersonStatusRepository(TestCurdContext context) : base(context) { }

}
