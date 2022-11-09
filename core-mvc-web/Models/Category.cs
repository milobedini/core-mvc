using System;
using System.ComponentModel.DataAnnotations;
//Note the above to allow data annotaions, Key.

namespace core_mvc_web.Models
{
    public class Category
    {
        //Want to make Id column an identity column (PK) of the data.
        //Use data annotation to do this. Literally just have to put [Key].

        [Key]
        public int Id { get; set; }

        //Below to ensure that name is required.
        [Required]
        public string Name { get; set; }

        public int DisplayOrder { get; set; }

        //Below to automatically use the current date time.
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}

