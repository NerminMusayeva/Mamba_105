using System.ComponentModel.DataAnnotations.Schema;

namespace mamba_project.Models
{
    public class OurTeam
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        public string ?ImgUrl { get; set; }
        [NotMapped]
        public IFormFile ImgFile { get; set; }
    }
}
