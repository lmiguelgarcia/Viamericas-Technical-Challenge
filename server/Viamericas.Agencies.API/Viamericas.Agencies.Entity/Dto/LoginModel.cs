﻿using System.ComponentModel.DataAnnotations;

namespace Viamericas.Agencies.Entity.Dto
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}