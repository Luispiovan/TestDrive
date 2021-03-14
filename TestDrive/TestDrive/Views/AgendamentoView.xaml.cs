using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System;
using TestDrive.Models;

namespace TestDrive.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgendamentoView : ContentPage
    {
        public AgendamentoVeiculo Agendamento { get; set; }
        public Veiculo Veiculo
        {
            get { return Agendamento.Veiculo; }
            set { Agendamento.Veiculo = value; }
        }
        public string Nome
        {
            get { return Agendamento.Nome; }
            set { Agendamento.Nome = value; }
        }
        public string Fone
        {
            get { return Agendamento.Fone; }
            set { Agendamento.Fone = value; }
        }
        public string Email
        {
            get { return Agendamento.Email; }
            set { Agendamento.Email = value; }
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

        public AgendamentoView(Veiculo veiculo)
        {
            InitializeComponent();
            this.Agendamento = new AgendamentoVeiculo();
            this.Agendamento.Veiculo = Veiculo;
            this.BindingContext = this;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Agendamento",
                string.Format(@"Veiculo: {0}
                  Nome: {1}
                  Fone: {2}
                  Email: {3}
                  Data do Agendamento: {4}
                  Hora do Agendamento: {5}",Veiculo.nome, Nome, Fone, Email, DataAgendamento.ToString("dd/MM/yyyy"), HoraAgendamento), "OK");
        }
    }
}