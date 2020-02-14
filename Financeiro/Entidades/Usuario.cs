using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Financeiro.Entidades
{
    public class Usuario
    {
        public int id { get; set; }
        [Required]
        public string nome { get; set; }
        [Required,EmailAddress]
        public string email { get; set; }
    }
}