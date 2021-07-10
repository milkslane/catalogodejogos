using APICatalogoJogos.InputModel;
using APICatalogoJogos.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APICatalogoJogos.Servicos
{
    public interface IJogoServico : IDisposable
    {
        Task<List<JogoViewModel>> Obter(int pagina, int quantidade);
        Task<JogoViewModel> Obter(Guid id);
        Task<JogoViewModel> Inserir(JogoInputModel jogo);
        Task Atualizar(Guid id, JogoInputModel jogo);
        Task Atualizar(Guid id, double preco);
        Task Remover(Guid id);
    }
}
