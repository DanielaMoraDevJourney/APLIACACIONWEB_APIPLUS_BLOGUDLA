namespace APLIACACIONWEB_APIPLUS_BLOGUDLA.Models
{
    public class BlogNodo
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Contenido { get; set; }
        public ICollection<CommentNodo> Comments { get; set; }
    }
}
