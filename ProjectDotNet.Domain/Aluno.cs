﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectDotNet.Domain
{
    public class Aluno
    {
        //CLASS -DATA TRANSFER OBJET
        public int Id { get; set; }
        [Required(ErrorMessage ="Preencha o nome do aluno")]
        public string Nome { get; set; }

        [DisplayName("Mãe")]
        [Required(ErrorMessage = "Preencha o nome da mãe do aluno")]
        public string Mae { get; set; }

        [DisplayName("Data de Nascimento")]
        [Required(ErrorMessage = "Preencha a data de nascimento do alunio")]
        [DisplayFormat(ApplyFormatInEditMode =true,DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set; }
    }
}