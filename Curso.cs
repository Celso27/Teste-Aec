namespace ProjetoBusca.Models
{
    public class Curso
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Professor { get; set; }
        public string? CargaHoraria { get; set; }
        public string? Descricao { get; set; }

        public Curso() { }

        public Curso(int id, string? titulo, string? professor, string? cargaHoraria, string? descricao)
        {
            Id = id;
            Titulo = titulo;
            Professor = professor;
            CargaHoraria = cargaHoraria;
            Descricao = descricao;
        }
    }
}