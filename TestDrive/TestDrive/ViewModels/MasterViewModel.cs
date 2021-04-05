using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
    class MasterViewModel: BaseViewModel
    {
        public string Nome
        {
            get { return this.usuario.nome; }
            set { this.usuario.nome = value; }
        }

        public string Email
        {
            get { return this.usuario.email; }
            set { this.usuario.email = value; }
        }

        public string Telefone
        {
            get { return this.usuario.telefone; }
            set { this.usuario.telefone = value; }
        }

        public string DataNasc
        {
            get { return this.usuario.dataNasc; }
            set { this.usuario.dataNasc = value; }
        }

        private bool editando = false;
        public bool Editando
        {
            get { return editando; }
            private set 
            { 
                editando = value;
                OnPropertyChanged(nameof(Editando));
            }
        }


        private readonly Usuario usuario;

        public ICommand EditarPerfilCommand { get; private set; }
        public ICommand EditarCommand { get; private set; }
        public ICommand SalvarCommand { get; private set; }

        public MasterViewModel(Usuario usuario)
        {
            this.usuario = usuario;

            DefinirComandos(usuario);
        }

        private void DefinirComandos(Usuario usuario)
        {
            EditarPerfilCommand = new Command(() =>
            {
                MessagingCenter.Send<Usuario>(usuario, "EditarUsuario");
            });

            EditarCommand = new Command(() =>
            {
                this.Editando = true;
            });

            SalvarCommand = new Command(() =>
            {
                this.Editando = false;
                MessagingCenter.Send<Usuario>(usuario, "SucessoSalvarUsuario");
            });
        }
    }
}
