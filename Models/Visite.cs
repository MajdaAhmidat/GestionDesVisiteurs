namespace gestion_des_visiteurs.Models
{
    public class Visite
    {
        public int Id { get; set; }
        public DateTime? dateVisite { get; set; }
        public TimeOnly? heureDebut { get; set; }
        public TimeOnly? heureFin { get; set; }
        public TimeOnly? duree { get; set; }
        public int? idVisiteur { get; set; }
        public Visiteur Visiteur { get; set; } = new Visiteur();
    }
}
