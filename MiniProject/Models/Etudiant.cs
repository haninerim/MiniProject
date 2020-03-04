using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MiniProject.Models
{
    public class Etudiant
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string NameEtabli { get; set; }

        public Etablissement Etablissement { get; set; }

    }
}