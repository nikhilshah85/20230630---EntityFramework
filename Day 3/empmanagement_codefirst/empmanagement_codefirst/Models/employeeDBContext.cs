using Microsoft.EntityFrameworkCore;

namespace empmanagement_codefirst.Models
{
    public class employeeDBContext :DbContext
    {
        public DbSet<deptInfo> Department { get; set; }
        public DbSet<employeeInfo> Employees { get; set; }

        public employeeDBContext() : base()
        {

        }

        

    }
}
