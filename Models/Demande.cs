namespace gestion_des_visiteurs.Models
{
    public class Demande
    {
        public int Id { get; set; }
        public string? nom { get; set; }
        public string? description { get; set; }
        public int idVisiteur { get; set; }
        public int idSuperviseur { get; set; }
        public Visiteur Visiteur { get; set; } = new Visiteur();
        public Superviseur Superviseur { get; set; } = new Superviseur();
    }
}
