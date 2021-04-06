using Microsoft.Data.Sqlite;
using TestDrive.Models;

namespace TestDrive.Data
{
    public class AgendamentoDAO
    {
        readonly SqliteConnection conexao;

        public AgendamentoDAO(SqliteConnection conexao)
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
