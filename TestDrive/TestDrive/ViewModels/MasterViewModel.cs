using System;
using System.Collections.Generic;
using System.Text;
using TestDrive.Models;

namespace TestDrive.ViewModels
{
    class MasterViewModel
    {
        public string Nome
        {
            get { return this.usuario.Nome; }
            set { this.usuario.Nome = value; }
        }

        public string Email
        {
            get { return this.usuario.Email; }
            set { this.usuario.Email = value; }
        }

        private readonly Usuario usuario;

        public MasterViewModel(Usuario usuario)
        {
            this.usuario = usuario;
        }
    }
}
