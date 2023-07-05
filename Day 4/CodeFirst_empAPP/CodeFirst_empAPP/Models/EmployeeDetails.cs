using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst_empAPP.Models
{
    public class EmployeeDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int empNo { get; set; }
        public string empName { get; set; }
        public double empSalary { get; set; }
        public string empCity { get; set; }
        public bool empIsPermenant { get; set; }

    }
}
