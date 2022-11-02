namespace WebTeste
{
    public class Sexo
    {
        public int SexoId { get; set; }
        public string? SexoNome { get; set; }

        public List<Sexo> SexoList()
        {
            return new List<Sexo>()
            {
                new Sexo{ SexoId = 1, SexoNome = "Feminino"},
                new Sexo{ SexoId=2, SexoNome = "Masculino"}
            };
        }
    }
}
