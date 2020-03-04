using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MiniProject.Models
{
    public class Etablissement
    {
        [Key]
        public int Id { get; set; }
      
        public string NameEtabli { get; set; }
        [Required]
        public string Adress{ get; set; }
        public int Tel{ get; set; }
      
        private List<Etudiant> _EtudiantList = new List<Etudiant>();

        public List<Etudiant> EtudiantList
        {
            get { return _EtudiantList; }
        }
    }
}