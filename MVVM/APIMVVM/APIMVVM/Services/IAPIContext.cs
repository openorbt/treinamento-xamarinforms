using APIMVVM.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APIMVVM.Services
{
    public interface IAPIContext
    {
        Task<List<Pessoa>> GetPessoas();
        Task AddPessoa(Pessoa p);
    }
}
