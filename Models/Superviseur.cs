namespace gestion_des_visiteurs.Models
{
    public class Superviseur
    {
        public int Id { get; set; }
        public string? nom { get; set; }
        public string? prenom { get; set; }
        public string? email { get; set; }
        public string? telephone { get; set; }
        public string? cin { get; set; }
        public int? idAdministrateur { get; set; }
        public List<Visiteur> visiteurs { get; set; } = new List<Visiteur>();
        public List<Demande> demandes { get; set; } = new List<Demande>();
        public Administrateur administrateur { get; set; } = new Administrateur();
    }
}
