using APIMVVM.Models;
using APIMVVM.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APIMVVM.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigatingAware
    {
        private readonly IAPIContext _apiContext;

        private List<Pessoa> pessoas;
        public List<Pessoa> Pessoas
        {
            get { return pessoas; }
            set { SetProperty(ref pessoas, value); }
        }

        private bool _refreshing;
        public bool Refreshing
        {
            get { return _refreshing; }
            set { SetProperty(ref _refreshing, value); }
        }

        public DelegateCommand RefreshCommand { get; set; }

        public MainPageViewModel(IAPIContext apiContext)
        {
            _apiContext = apiContext;
            RefreshCommand = new DelegateCommand(ExecuteRefreshCommand);
        }

        private async void ExecuteRefreshCommand()
        {
            Refreshing = true;

            Pessoa p = new Pessoa()
            {
                Name = "Fulano",
                Age = 100,
                City = "Natal",
                Number = "000000"
            };

            await _apiContext.AddPessoa(p);
            Pessoas = await _apiContext.GetPessoas();
            Refreshing = false;
        }

        public async void OnNavigatingTo(NavigationParameters parameters)
        {
            Refreshing = true;
            Pessoas = await _apiContext.GetPessoas();
            Refreshing = false;
        }
    }
}
