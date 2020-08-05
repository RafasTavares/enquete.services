using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Core.Exceptions
{
    public class ErroGenericoException : Exception
    {
        public ErroGenericoException(string mensagem) : base(mensagem)
        {
            Mensagens = new List<string>
            {
                mensagem
            };
        }

        public ErroGenericoException(string mensagem, Exception inner) : base(mensagem, inner)
        {
            Mensagens = new List<string>
            {
                mensagem
            };
        }

        public ErroGenericoException(List<string> mensagens) : base("")
        {
            Mensagens = mensagens ?? new List<string>();
        }

        public List<string> Mensagens { get; }

        public ApplicationResponse GetResponseAPI()
        {
            var result = new ApplicationResponse();
            result.AddErro(Mensagens);
            return result;
        }
    }
}