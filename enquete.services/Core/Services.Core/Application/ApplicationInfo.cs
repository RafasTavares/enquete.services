namespace Services.Core
{
    public class ApplicationInfo
    {
        public string Nome { get; private set; }
        public string VersaoUsoSwagger { get; private set; }
        public string Versao { get; private set; }
        public string Descricao { get; private set; }

        public ApplicationInfo(string nome, string versaoUsoSwagger, string versao, string descricao)
        {
            Nome = nome;
            VersaoUsoSwagger = versaoUsoSwagger;
            Versao = versao;
            Descricao = descricao;
        }
    }
}
