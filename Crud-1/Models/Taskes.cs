using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crud_1.Models
{
    public class Taskes
    {
        [Key]
        public int Id { get; set; }

        public string Task { get; set; }    

    }
}
