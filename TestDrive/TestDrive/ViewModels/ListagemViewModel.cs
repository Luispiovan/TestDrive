using System;
using System.Collections.Generic;
using System.Text;
using TestDrive.Models;

namespace TestDrive.ViewModel
{
    class ListagemViewModel
    {
        public List<Veiculo> Veiculos { get; set; }
        public ListagemViewModel()
        {
            this.Veiculos = new ListagemVeiculos().Veiculos;
        }

    }
}
