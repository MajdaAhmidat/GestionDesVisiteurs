namespace gestion_des_visiteurs.Models
{
    public class Administrateur
    {
        public int Id { get; set; }
        public string? nom { get; set; }
        public string? prenom { get; set; }
        public string? email { get; set; }
        public List<Superviseur> Superviseurs { get; set; } = new List<Superviseur>();
    }
}
