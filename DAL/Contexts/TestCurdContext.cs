using DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contexts;


public class TestCurdContext : DbContext
{
    public TestCurdContext(DbContextOptions<TestCurdContext> options)
        : base(options)
    {
    }
    public DbSet<Person> Persons => Set<Person>();

    public DbSet<PersonStatus> PersonStatus => Set<PersonStatus>();

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       
    }
}


