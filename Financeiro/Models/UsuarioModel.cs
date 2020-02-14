using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Financeiro.Models
{
    public class UsuarioModel
    {
        [Required]
        public string nome { get; set; }
        [Required, EmailAddress]
        public string email { get; set; }
        [Required]
        public string senha { get; set; }
        [Compare("senha")]
        public string confSenha { get; set; }
    }
}