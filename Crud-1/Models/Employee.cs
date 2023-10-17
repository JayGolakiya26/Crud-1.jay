using System.ComponentModel.DataAnnotations;

namespace Crud_1.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        public string? fname { get; set; }
            
        public string? color { get; set; }
            
       
    }
}
