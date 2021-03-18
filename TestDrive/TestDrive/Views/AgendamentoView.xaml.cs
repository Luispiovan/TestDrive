using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System;
using TestDrive.Models;
using TestDrive.ViewModels;

namespace TestDrive.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgendamentoView : ContentPage
    {
        public AgendamentoViewModel ViewModel { get; set; }
        public AgendamentoView(Veiculo veiculo)
        {
            InitializeComponent();
            this.ViewModel = new AgendamentoViewModel(veiculo);
            this.BindingContext = this.ViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<AgendamentoVeiculo>(this, "Agendamento",
                (msg) =>
                {
                    DisplayAlert("Agendamento",
                    string.Format(@"Veiculo: {0}
                    nome: {1}
                    Fone: {2}
                    Email: {3}
                    Data do Agendamento: {4}
                    Hora do Agendamento: {5}", ViewModel.Agendamento.Veiculo.nome,
                    ViewModel.Agendamento.Nome, ViewModel.Agendamento.Fone,
                    ViewModel.Agendamento.Email, ViewModel.Agendamento.DataAgendamento.ToString("dd/MM/yyyy"),
                    ViewModel.Agendamento.HoraAgendamento), "OK");
                });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<AgendamentoVeiculo>(this, "Agendamento");
        }
    }
}