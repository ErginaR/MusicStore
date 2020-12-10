using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Domain.Entities
{
    public class Album
    {
        public int AlbumID { get; set; }
        
        [Required(ErrorMessage = "Enter a title")]
        public string Title { get; set; }

        [Required(ErrorMessage="Enter a genre")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Enter an artist")]
        public string Artist { get; set; }
        [Required]
        [Range(0.01,double.MaxValue,ErrorMessage ="Enter a positive price")]
        public decimal Price { get; set; }
    }
}
