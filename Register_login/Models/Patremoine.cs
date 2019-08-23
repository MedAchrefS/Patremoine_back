    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Register_login.Models
{
    public class Patremoine
    {

        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string designation { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string adresse { get; set; }


        public string superficie { get; set; }

        public string couvert { get; set; }


        public string num1 { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string observation { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string nature { get; set; }


        public string pv_affectaion { get; set; }



        public string cf { get; set; }


        public string cv { get; set; }


        public string cl { get; set; }


        public string location { get; set; }


        public string nompropritaire { get; set; }


        public string montant { get; set; }


        public int id_direction { get; set; }

        public int id_region { get; set; }


        public int id_delegation { get; set; }

        public int id_arrandissement { get; set; }


        public int id_typePatremoine { get; set; }


        public DateTime datecreation { get; set; }
    }
}
