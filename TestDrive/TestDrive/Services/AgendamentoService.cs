using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Data;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive.Services
{
    public class AgendamentoService
    {
        const string URL_POST_AGENDAMENTO = "http://aluracar.herokuapp.com/salvaragendamento";

        public async Task EnviarAgendamento(AgendamentoVeiculo agendamento)
        {
            HttpClient cliente = new HttpClient();

            var dataHoraAgendamento = new DateTime(
                agendamento.DataAgendamento.Year, agendamento.DataAgendamento.Month, agendamento.DataAgendamento.Day,
                agendamento.DataAgendamento.Hour, agendamento.DataAgendamento.Minute, agendamento.DataAgendamento.Second);
            var json = JsonConvert.SerializeObject(new
            {
                nome = agendamento.Nome,
                fone = agendamento.Fone,
                email = agendamento.Email,
                carro = agendamento.Modelo,
                preco = agendamento.Preco,
                dataAgendamento = dataHoraAgendamento,
            });

            var conteudo = new StringContent(json, Encoding.UTF8, "application/json");
            var resposta = await cliente.PostAsync(URL_POST_AGENDAMENTO, conteudo);
            agendamento.Confirmado = resposta.IsSuccessStatusCode;
            SalvarAgendamentoDB(agendamento);

            if (agendamento.Confirmado)
            {
                MessagingCenter.Send<AgendamentoVeiculo>(agendamento, "SucessoAgendamento");
            }
            else
            {
                MessagingCenter.Send<ArgumentException>(new ArgumentException(), "FalhaAgendamento");
            }
        }

        private void SalvarAgendamentoDB(AgendamentoVeiculo agendamento)
        {
            using (var conexao = DependencyService.Get<ISQLite>().PegarConexao())
            {
                AgendamentoDAO dao = new AgendamentoDAO(conexao);
                dao.Salvar(agendamento);
            }
        }
    }
}
