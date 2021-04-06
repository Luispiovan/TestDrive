using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using TestDrive.Data;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
    public class AgendamentoViewModel : BaseViewModel
    {
        const string URL_POST_AGENDAMENTO = "http://aluracar.herokuapp.com/salvaragendamento";
        public AgendamentoVeiculo Agendamento { get; set; }

        public string Modelo
        {
            get { return this.Agendamento.Modelo; }
            set { this.Agendamento.Modelo = value; }
        }

        public decimal Preco
        {
            get { return this.Agendamento.Preco; }
            set { this.Agendamento.Preco = value; }
        }

        public string Nome
        {
            get { return Agendamento.Nome; }
            set
            {
                Agendamento.Nome = value;
                OnPropertyChanged();
                ((Command)AgendarCommand).ChangeCanExecute();
            }
        }
        public string Fone
        {
            get { return Agendamento.Fone; }
            set
            {
                Agendamento.Fone = value;
                OnPropertyChanged();
                ((Command)AgendarCommand).ChangeCanExecute();
            }
        }
        public string Email
        {
            get { return Agendamento.Email; }
            set
            {
                Agendamento.Email = value;
                OnPropertyChanged();
                ((Command)AgendarCommand).ChangeCanExecute();
            }
        }
        public DateTime DataAgendamento
        {
            get { return Agendamento.DataAgendamento; }
            set { Agendamento.DataAgendamento = value; }
        }
        public TimeSpan HoraAgendamento
        {
            get { return Agendamento.HoraAgendamento; }
            set { Agendamento.HoraAgendamento = value; }
        }

        public async void SalvarAgendamento()
        {
            HttpClient cliente = new HttpClient();

            var dataHoraAgendamento = new DateTime(
                DataAgendamento.Year, DataAgendamento.Month, DataAgendamento.Day,
                DataAgendamento.Hour, DataAgendamento.Minute, DataAgendamento.Second);
            var json = JsonConvert.SerializeObject(new
            {
                nome = Nome,
                fone = Fone,
                email = Email,
                carro = Modelo,
                preco = Preco,
                dataAgendamento = dataHoraAgendamento,
            });

            var conteudo = new StringContent(json, Encoding.UTF8, "application/json");
            var resposta = await cliente.PostAsync(URL_POST_AGENDAMENTO, conteudo);
            SalvarAgendamentoDB();

            if (resposta.IsSuccessStatusCode)
            {
                MessagingCenter.Send<AgendamentoVeiculo>(this.Agendamento, "SucessoAgendamento");
            }
            else
            {
                MessagingCenter.Send<ArgumentException>(new ArgumentException(), "FalhaAgendamento");
            }
        }

        private void SalvarAgendamentoDB()
        {
            using (var conexao = DependencyService.Get<ISQLite>().PegarConexao())
            {
                AgendamentoDAO dao = new AgendamentoDAO(conexao);
                dao.Salvar(new AgendamentoVeiculo(Nome, Fone, Email, Modelo, Preco));
            }
        }

        public AgendamentoViewModel(Veiculo veiculo, Usuario usuario)
        {
            this.Agendamento = new AgendamentoVeiculo(usuario.nome, usuario.telefone, usuario.email, veiculo.nome, veiculo.preco);
            AgendarCommand = new Command(() =>
            {
                MessagingCenter.Send<AgendamentoVeiculo>(this.Agendamento, "Agendamento");
            }, () =>
            {
                return !string.IsNullOrEmpty(this.Nome)
                    && !string.IsNullOrEmpty(this.Fone)
                    && !string.IsNullOrEmpty(this.Email);
            });
        }

        public ICommand AgendarCommand { get; set; }


    }
}
