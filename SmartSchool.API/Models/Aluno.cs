namespace SmartSchool.API.Models;

public class Aluno
{
    public Aluno() { }

    public Aluno(string nome, string sobrenome, string telefone)
    {
        Nome = nome;
        Sobrenome = sobrenome;
        Telefone = telefone;
    }

    public int Id { get; set; }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public string Telefone { get; set; }
    public IEnumerable<AlunoDisciplina>? AlunoDisciplinas { get; set; }

}