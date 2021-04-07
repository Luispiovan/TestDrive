using SQLite;
using TestDrive.Models;

namespace TestDrive.Data
{
    public class AgendamentoDAO
    {
        readonly SQLiteConnection conexao;

        public AgendamentoDAO(SQLiteConnection conexao)
        {
            this.conexao = conexao;
            this.conexao.CreateTable<AgendamentoVeiculo>();
        }

        public void Salvar(AgendamentoVeiculo agendamento)
        {
            conexao.Insert(agendamento);
        }
    }
}
