using Microsoft.EntityFrameworkCore;

namespace CodeFirst_empAPP.Models
{
    public class empDBContext :DbContext
    {

        public empDBContext(DbContextOptions option):base(option)
        {

        }


        public DbSet<EmployeeDetails> empDetails { get; set; }
    }
}
