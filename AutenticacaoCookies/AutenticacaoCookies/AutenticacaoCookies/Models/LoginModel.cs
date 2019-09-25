﻿using System.ComponentModel.DataAnnotations;

namespace AutenticacaoCookies.Models
{
    public class LoginModel
    {
        [Required]
        public string Usuario { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        public string RequestPath { get; set; }
    }
}
