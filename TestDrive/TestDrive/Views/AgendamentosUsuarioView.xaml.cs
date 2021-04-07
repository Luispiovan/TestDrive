using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Models;
using TestDrive.Services;
using TestDrive.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgendamentosUsuarioView : ContentPage
    {
        readonly AgendamentosUsuarioViewModel _viewModel;

        public AgendamentosUsuarioView()
        {
            InitializeComponent();
            this._viewModel = new AgendamentosUsuarioViewModel();
            this.BindingContext = this._viewModel;

            //this.listViewAgendamentos.ItemsSource = new List<AgendamentoVeiculo>
            //{
            //    new AgendamentoVeiculo("Luis Costa", "1234-5678","luis.costa@email.com", "Hilux 4X4", 90000, new DateTime(2021,04,07), new TimeSpan(14,50,0)),
            //    new AgendamentoVeiculo("Carlos Costa", "1234-5678","carlos.costa@email.com", "Onix 1.6", 35000, new DateTime(2021,04,07), new TimeSpan(14,50,0)),
            //    new AgendamentoVeiculo("Luiz Augusto", "1234-5678","luiz.augusto@email.com", "Azera V6", 85000, new DateTime(2021,04,07), new TimeSpan(14,50,0)),
            //    new AgendamentoVeiculo("Cesar Gomes", "1234-5678","cesar.gomes@email.com", "Astra Sedan", 39000, new DateTime(2021,04,07), new TimeSpan(14,50,0)),
            //    new AgendamentoVeiculo("João Silva", "1234-5678","joao.silva@email.com", "C3 1.0", 22000, new DateTime(2021,04,07), new TimeSpan(14,50,0)),
            //};
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<AgendamentoVeiculo>(this, "AgendamentoSelecionado",
                async (agendamento) =>
                {
                    if (!agendamento.Confirmado)
                    {
                        var reenviar = await DisplayAlert("Reenviar", "Deseja reenviar o agendamento?", "sim", "não");
                        if (reenviar)
                        {
                            AgendamentoService agendamentoService = new AgendamentoService();
                            await agendamentoService.EnviarAgendamento(agendamento);
                            this._viewModel.AtualizarLista();
                        }
                    }
                });
            MessagingCenter.Subscribe<AgendamentoVeiculo>(this, "SucessoAgendamento",
                async (agendamento) =>
                {
                    await DisplayAlert("Reenviar", "Reenvio com sucesso!", "OK");
                });

            MessagingCenter.Subscribe<AgendamentoVeiculo>(this, "FalhaAgendamento",
                async (agendamento) =>
                {
                    await DisplayAlert("Reenviar", "Falha ao reenviar agendamento!", "OK");
                });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<AgendamentoVeiculo>(this, "AgendamentoSelecionado");
            MessagingCenter.Unsubscribe<AgendamentoVeiculo>(this, "SucessoAgendamento");
            MessagingCenter.Unsubscribe<AgendamentoVeiculo>(this, "FalhaAgendamento");
        }

    }
}