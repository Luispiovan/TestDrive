using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive
{
    public class LoginService
    {
        public async Task<HttpResponseMessage> FazerLogin(Login login)
        {

            using (var cliente = new HttpClient())
            {
                var camposFormulario = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("email", login.email),
                    new KeyValuePair<string, string>("senha", login.senha),
                });

                cliente.BaseAddress = new Uri("https://alucar.herokuapp.com");
                HttpResponseMessage resultado = null;

                try
                {
                    resultado = await cliente.PostAsync("/login", camposFormulario);
                    if (resultado.IsSuccessStatusCode)
                    {
                        var conteudoresultado = await resultado.Content.ReadAsStringAsync();
                        var resultadoLogin = JsonConvert.DeserializeObject<ResultadoLogin>(conteudoresultado);

                        MessagingCenter.Send<Usuario>(resultadoLogin.usuario, "SucessoLogin");
                    }
                    else
                    {
                        MessagingCenter.Send<LoginException>(new LoginException("Usuário ou Senha incorretos!"), "FalhaLogin");
                    }
                }
                catch
                {
                    MessagingCenter.Send<LoginException>(new LoginException(@"Ocorreu um erro de comunicação com o servidor." +
                        "Por favor verifique a sua conexão e tente novamente mais tarde!"), "FalhaLogin");
                }
            }
        }
    }

    public class LoginException : Exception
    {
        public LoginException(string message) : base(message)
        {
        }
    }
}
