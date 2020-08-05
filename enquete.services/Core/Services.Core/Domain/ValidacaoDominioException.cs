using System;
using System.Collections.Generic;

namespace Services.Core.Domain
{
    public class ValidacaoDominioException : Exception
    {
        public ValidacaoDominioException(string mensagem) : base(mensagem)
        {
            Mensagens = new List<string>
            {
                mensagem
            };
        }

        public ValidacaoDominioException(string mensagem, Exception inner) : base(mensagem, inner)
        {
            Mensagens = new List<string>();

            Mensagens.Add(mensagem);
        }

        public ValidacaoDominioException(List<string> mensagens) : base("")
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
