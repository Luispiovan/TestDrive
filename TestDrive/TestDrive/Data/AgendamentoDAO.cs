using SQLite;
using System.Collections.Generic;
using TestDrive.Models;

namespace TestDrive.Data
{
    public class AgendamentoDAO
    {
        readonly SQLiteConnection conexao;

        private List<AgendamentoVeiculo> lista;
        public List<AgendamentoVeiculo> Lista
        {
            get 
            {
                return conexao.Table<AgendamentoVeiculo>().ToList();
            }
            private set { lista = value; }
        }

        public AgendamentoDAO(SQLiteConnection conexao)
        {
            this.conexao = conexao;
            this.conexao.CreateTable<AgendamentoVeiculo>();
        }

        public void Salvar(AgendamentoVeiculo agendamento)
        {
            if (conexao.Find<AgendamentoVeiculo>(agendamento.ID) == null)
            {
                conexao.Insert(agendamento);
            }
            else
            {
                conexao.Update(agendamento);
            }
        }
    }
}
