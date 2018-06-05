using AppInicial.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace AppInicial.ViewModels
{
    public class PrincipalPageViewModel
    {
        public ObservableCollection<Pessoa> ListaPessoas { get; set; }
        public string NomePessoa { get; set; }
        public string CPFPessoa { get; set; }

        public Command ClickButton { get; set; }
        public Command<Pessoa> ClickListItem { get; set; }

        public PrincipalPageViewModel()
        {
            ListaPessoas = new ObservableCollection<Pessoa>();
            ListaPessoas.Add(new Pessoa { Id = 0, Nome = "João", CPF = "456789" });
            ListaPessoas.Add(new Pessoa { Id = 1, Nome = "Aline", CPF = "789123" });
            ListaPessoas.Add(new Pessoa { Id = 2, Nome = "Henrique", CPF = "147852" });

            ClickButton = new Command(ExecuteClickButton);
            ClickListItem = new Command<Pessoa>(ExecuteClickListItem);
        }

        private void ExecuteClickListItem(Pessoa obj)
        {
            Helpers.GlobalHelper.PessoaSelecionada = obj;
            App.Current.MainPage.Navigation.PushAsync(new Views.DetalhePage());
        }

        private void ExecuteClickButton()
        {
            if (string.IsNullOrEmpty(NomePessoa) ||
               string.IsNullOrEmpty(CPFPessoa))
            {
                App.Current.MainPage.DisplayAlert("Aviso", "Preencha todos os dados", "Ok");
                return;
            }

            var lastItem = ListaPessoas.Last();

            Pessoa p = new Pessoa
            {
                Id = lastItem.Id + 1,
                Nome = NomePessoa,
                CPF = CPFPessoa
            };

            ListaPessoas.Add(p);

            NomePessoa = "";
            CPFPessoa = "";
        }
    }
}
