﻿using System.ComponentModel.DataAnnotations;

namespace curso_02_FilmesAPI.Models;

public class Filme
{
    [Key, Required]
    public int Id { get; set; }
    [Required(ErrorMessage = "O título do filme é obrigatório.")]
    public string Titulo { get; set; }
    [Required(ErrorMessage = "O genero do filme é obrigatório."), MaxLength(50, ErrorMessage = "O tamanho do gênero não pode ser maior que 50 caracteres.")]
    public string Genero { get; set; }
    [Required(ErrorMessage = "A duração do filme é obrigatória."), Range(70, 600, ErrorMessage = "A duração deve ter entre 70 e 600 minutos.")]
    public int Duracao { get; set; }
    public virtual List<Sessao> Sessoes { get; set; }
}
