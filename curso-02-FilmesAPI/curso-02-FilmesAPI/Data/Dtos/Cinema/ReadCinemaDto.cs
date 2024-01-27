﻿using System.ComponentModel.DataAnnotations;

namespace curso_02_FilmesAPI.Data.Dtos.Cinema
{
    public class ReadCinemaDto
    {
        [Key, Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Nome Obrigatório.")]
        public string Nome { get; set; }
    }
}
