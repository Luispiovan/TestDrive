using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using TestDrive.Data;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
    class AgendamentosUsuarioViewModel: BaseViewModel
    {
        public ObservableCollection<AgendamentoVeiculo> lista = new ObservableCollection<AgendamentoVeiculo>(); 
        public ObservableCollection<AgendamentoVeiculo> Lista 
        {
            get 
            {
                return lista;
                //return new ObservableCollection<AgendamentoVeiculo>
                //{
                //    new AgendamentoVeiculo("Luis Costa", "1234-5678","luis.costa@email.com", "Hilux 4X4", 90000, new DateTime(2021,04,07), new TimeSpan(14,50,0)),
                //    new AgendamentoVeiculo("Carlos Costa", "1234-5678","carlos.costa@email.com", "Onix 1.6", 35000, new DateTime(2021,04,07), new TimeSpan(14,50,0)),
                //    new AgendamentoVeiculo("Luiz Augusto", "1234-5678","luiz.augusto@email.com", "Azera V6", 85000, new DateTime(2021,04,07), new TimeSpan(14,50,0)),
                //    new AgendamentoVeiculo("Cesar Gomes", "1234-5678","cesar.gomes@email.com", "Astra Sedan", 39000, new DateTime(2021,04,07), new TimeSpan(14,50,0)),
                //    new AgendamentoVeiculo("João Silva", "1234-5678","joao.silva@email.com", "C3 1.0", 22000, new DateTime(2021,04,07), new TimeSpan(14,50,0)),
                //};
            }
            private set 
            { 
                lista = value;
                OnPropertyChanged(); 
            }
        }

        private AgendamentoVeiculo agendamentoSelecionado;
        public AgendamentoVeiculo AgendamentoSelecionado 
        {
            get { return agendamentoSelecionado; }
            set 
            {
                if(value != null)
                {
                    agendamentoSelecionado = value;
                    MessagingCenter.Send<AgendamentoVeiculo>(agendamentoSelecionado, "AgendamentoSelecionado");
                } 
            } 
        }

        public AgendamentosUsuarioViewModel()
        {
            AtualizarLista();
        }

        public void AtualizarLista()
        {
            using (var conexao = DependencyService.Get<ISQLite>().PegarConexao())
            {
                AgendamentoDAO dao = new AgendamentoDAO(conexao);
                var listaDB = dao.Lista;

                var query = listaDB.OrderBy(x => x.DataAgendamento).ThenBy(x => x.HoraAgendamento);

                this.Lista.Clear();
                foreach (var itemDB in query)
                {
                    this.Lista.Add(itemDB);
                }
            }
        }
    }
}
