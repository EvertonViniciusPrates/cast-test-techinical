namespace Cast.Model
{
    public class Categoria : EntityBase
    {
        public string Descricao { get; set; }
        
        public Categoria()
        {
        }

        public Categoria(string descricao)
        {
            Descricao = descricao;
        }

    }
}
