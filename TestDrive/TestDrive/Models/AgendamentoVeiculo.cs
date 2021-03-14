using System;
using System.Collections.Generic;
using System.Text;

namespace TestDrive.Models
{
    public class AgendamentoVeiculo
    {
        public Veiculo Veiculo { get; set; }
        public string Nome { get; set; }
        public string Fone { get; set; }
        public string Email { get; set; }

        public DateTime DataAgendamento = DateTime.Today;

        public TimeSpan HoraAgendamento;
    }

}

