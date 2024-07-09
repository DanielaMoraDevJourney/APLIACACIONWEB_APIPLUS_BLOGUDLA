namespace APLIACACIONWEB_APIPLUS_BLOGUDLA.Models
{
    public class BlogFica {

        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Contenido { get; set; }
        public ICollection<CommentFica> Comments { get; set; }
    }

}

