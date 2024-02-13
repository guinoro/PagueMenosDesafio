namespace PagueMenosDesafio.Models{
    public class Produto{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public decimal Preco { get; set; }

    public int LojaId { get; set; }
    public Loja Loja { get; set; }
    }

}