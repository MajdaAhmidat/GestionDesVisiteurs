using System.ComponentModel;

namespace gestion_des_visiteurs.Models
{
    public class Visiteur
    {
        public int Id { get; set; }
        public string? nom { get; set; }
        public string? prenom { get; set; }
        public string? email { get; set; }
        public string? telephone { get; set; }
        public string? cin { get; set; }
        public int? idSuperviseur { get; set; }
        public List<Visite> visites { get; set; } = new List<Visite>();
        public List<Demande> demandes { get; set; } = new List<Demande>();
        public Superviseur Superviseur { get; set; } = new Superviseur();
    }
}
