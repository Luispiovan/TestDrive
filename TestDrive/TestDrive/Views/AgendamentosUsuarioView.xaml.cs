using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgendamentosUsuarioView : ContentPage
    {
        public AgendamentosUsuarioView()
        {
            InitializeComponent();

            this.listViewAgendamentos.ItemsSource = new List<AgendamentoVeiculo>
            {
                new AgendamentoVeiculo("Luis Costa", "1234-5678","luis.costa@email.com", "Hilux 4X4", 90000, new DateTime(2021,04,07), new TimeSpan(14,50,0)),
                new AgendamentoVeiculo("Carlos Costa", "1234-5678","carlos.costa@email.com", "Onix 1.6", 35000, new DateTime(2021,04,07), new TimeSpan(14,50,0)),
                new AgendamentoVeiculo("Luiz Augusto", "1234-5678","luiz.augusto@email.com", "Azera V6", 85000, new DateTime(2021,04,07), new TimeSpan(14,50,0)),
                new AgendamentoVeiculo("Cesar Gomes", "1234-5678","cesar.gomes@email.com", "Astra Sedan", 39000, new DateTime(2021,04,07), new TimeSpan(14,50,0)),
                new AgendamentoVeiculo("João Silva", "1234-5678","joao.silva@email.com", "C3 1.0", 22000, new DateTime(2021,04,07), new TimeSpan(14,50,0)),
            };
        }

    }
}