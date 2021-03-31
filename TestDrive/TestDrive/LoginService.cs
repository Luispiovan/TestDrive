using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive
{
    public class LoginService
    {
        public async Task FazerLogin(Login login)
        {
            using (var cliente = new HttpClient())
            {
                var camposFormulario = new FormUrlEncodedContent(new[]
                {
                        new KeyValuePair<string, string>("email", login.email),
                        new KeyValuePair<string, string>("senha", login.senha),
                    });
                cliente.BaseAddress = new Uri("https://alucar.herokuapp.com");
                var resultado = await cliente.PostAsync("/login", camposFormulario);
                if (resultado.IsSuccessStatusCode)
                {
                    MessagingCenter.Send<Usuario>(new Usuario(), "SucessoLogin");
                }
                else
                {
                    MessagingCenter.Send<LoginException>(new LoginException("Usuário ou Senha incorretos!"), "FalhaLogin");
                }
            }
        }
    }
     class LoginException: Exception
    {
        public LoginException(string message): base(message)
        {
        }
    }
}
