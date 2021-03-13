using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System;

namespace TestDrive.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgendamentoView : ContentPage
    {
        public Veiculo Veiculo { get; set; }
        public string Nome { get; set; }
        public string Fone { get; set; }
        public string Email { get; set; }

        private DateTime dataAgendamento = DateTime.Today;

        public DateTime DataAgendamento {
            get {
                return dataAgendamento;
            }
            set {
                dataAgendamento = value;
            } 
        }
        public TimeSpan HoraAgendamento { get; set; }

        public AgendamentoView(Veiculo veiculo)
        {
            InitializeComponent();
            this.Veiculo = veiculo;
            this.BindingContext = this;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Agendamento", 
                string.Format(@"Nome: {0}
                  Fone: {1}
                  Email: {2}
                  Data do Agendamento: {3}
                  Hora do Agendamento: {4}", Nome, Fone, Email, DataAgendamento.ToString("dd/MM/yyyy"), HoraAgendamento), "OK");
        }
    }
}