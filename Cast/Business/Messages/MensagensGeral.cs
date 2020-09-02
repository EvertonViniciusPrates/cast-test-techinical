namespace Cast.Business.Messages
{
    public class MensagensGeral
    {
        public const string CADASTRA_SUCESSO = "CURSO CADASTRADO COM SUCESSO!";
        public const string REMOVE_SUCESSO = "CURSO REMOVIDO COM SUCESSO!";
        public const string ALTERA_SUCESSO = "CURSO ALTERADO COM SUCESSO!";
        
        public const string CADASTRA_ERRO = "ESTE CURSO NÃO PODE SER CADASTRADO!";
        public const string REMOVE_ERRO = "CURSO NÃO EXISTENTE!";
        public const string ALTERA_ERRO = "CURSO NÃO EXISTENTE!";

        public const string EXCECAO = "OCORREU UM PROBLEMA NO NOSSO LADO, EX:";

        public const string CONSULTA_ZERO_RESULTADOS = "SUA PESQUISA TROUXE NENHUM RESULTADO!";
        public const string PERIODO_ALERTA_INFERIOR = "NÃO PODE SER INSERIDO UM CURSO COM A DATA INICIO INFERIOR A DATA ATUAL!";
        public const string PERIODO_ALERTA_MESMO_PERIODO = "EXISTE(M) CURSO(S) PLANEJADOS(S) DENTRO DO PERÍODO INFORMADO.";
        public const string PERIODO_ALERTA_TERMINO_INFERIOR = "NÃO PODE SER INSERIDO UM CURSO COM A DATA TERMINO INFERIOR A DATA INICIO!";
        public const string CAMPO_OBRIGATORIO_NAO_PREENCHIDO = "EXISTEM CAMPOS OBRIGATORIOS QUE NÃO FORAM PREENCHIDOS!";
    }
}
