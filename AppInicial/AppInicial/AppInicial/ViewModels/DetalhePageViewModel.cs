using AppInicial.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppInicial.ViewModels
{
    public class DetalhePageViewModel
    {
        public Pessoa Pessoa { get; set; }

        public DetalhePageViewModel()
        {
            Pessoa = Helpers.GlobalHelper.PessoaSelecionada;
        }
    }
}
