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
        public AgendamentoView(Veiculo veiculo, Usuario usuario)
        {
            InitializeComponent();
            this.ViewModel = new AgendamentoViewModel(veiculo, usuario);
            this.BindingContext = this.ViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<AgendamentoVeiculo>(this, "Agendamento",
                async (msg) =>
                {
                    var confirma = await DisplayAlert("Salvar Agendamento",
                        "Deseja confirmar o agendamento?",
                        "SIM", "NÃO");

                    if (confirma)
                    {
                        this.ViewModel.SalvarAgendamento();
                        //DisplayAlert("Agendamento",
                        //string.Format(@"Veiculo: {0}
                        //nome: {1}
                        //Fone: {2}
                        //Email: {3}
                        //Data do Agendamento: {4}
                        //Hora do Agendamento: {5}", ViewModel.Agendamento.Veiculo.nome,
                        //ViewModel.Agendamento.Nome, ViewModel.Agendamento.Fone,
                        //ViewModel.Agendamento.Email, ViewModel.Agendamento.DataAgendamento.ToString("dd/MM/yyyy"),
                        //ViewModel.Agendamento.HoraAgendamento), "OK");
                    }
                });
            MessagingCenter.Subscribe<AgendamentoVeiculo>(this, "SucessoAgendamento",
                (msg) => 
                {
                    DisplayAlert("Agendamento", "Agendamento salvo com sucesso!","ok");
                });
            MessagingCenter.Subscribe<ArgumentException>(this, "FalhaAgendamento",
                (msg) =>
                {
                    DisplayAlert("Agendamento", "Falha ao agendar o Test Drive! Verifique os dados e tente novamente mais tarde!", "ok");
                });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<AgendamentoVeiculo>(this, "Agendamento");
            MessagingCenter.Unsubscribe<AgendamentoVeiculo>(this, "SucessoAgendamento");
            MessagingCenter.Unsubscribe<ArgumentException>(this, "FalhaAgendamento");
        }
    }
}