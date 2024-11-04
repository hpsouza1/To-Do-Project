﻿namespace WebApplication1.Models
{
    public class Tarefa
    {
        public int Id { get; set; } 
        public string Titulo { get; set; } = string.Empty; 
        public string Descricao { get; set; } = string.Empty;

        public bool Completed { get; set; } = false; // Definido como false por padrão
    }
}
