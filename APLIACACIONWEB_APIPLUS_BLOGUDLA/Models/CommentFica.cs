namespace APLIACACIONWEB_APIPLUS_BLOGUDLA.Models
{
    public class CommentFica
    {
        public Guid Id { get; set; }
        public string Contenido { get; set; }
        public DateTime Fecha { get; set; }
        public Guid BlogFicaId { get; set; }
    }
}
