using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaskedTextBox;
using PagueMenosDesafio.Services;

namespace PagueMenosDesafio
{
  public partial class Form1 : Form
  {
    private readonly ProdutoService _produtoService;

    private Label lblIdProduto;
    private MaskedTextBox txtIdProduto;

    private Label lblNomeProduto;
    private MaskedTextBox txtNomeProduto;

    private Label lblDescricaoProduto;
    private MaskedTextBox txtDescricaoProduto;

    private Label lblPrecoProduto;
    private MaskedTextBox txtPrecoProduto;

    private Label lblQuantidadeEstoque;
    private MaskedTextBox txtQuantidadeEstoque;

    private Button btnSalvar;
    private Button btnEditar;
    private Button btnExcluir;

    public Form1(ProdutoService produtoService)
    {
      _produtoService = produtoService;

      InitializeComponent();

      // Criação dos elementos da interface

      lblIdProduto = new Label();
      lblIdProduto.Text = "ID do Produto:";
      lblIdProduto.Location = new Point(10, 10);

      txtIdProduto = new MaskedTextBox();
      txtIdProduto.Location = new Point(10, 30);
      txtIdProduto.Width = 100;

      lblNomeProduto = new Label();
      lblNomeProduto.Text = "Nome do Produto:";
      lblNomeProduto.Location = new Point(10, 60);

      txtNomeProduto = new MaskedTextBox();
      txtNomeProduto.Location = new Point(10, 80);
      txtNomeProduto.Width = 200;

      lblDescricaoProduto = new Label();
      lblDescricaoProduto.Text = "Descrição do Produto:";
      lblDescricaoProduto.Location = new Point(10, 110);

      txtDescricaoProduto = new MaskedTextBox();
      txtDescricaoProduto.Location = new Point(10, 130);
      txtDescricaoProduto.Width = 200;
      txtDescricaoProduto.Multiline = true;
      txtDescricaoProduto.ScrollBars = ScrollBars.Vertical;

      lblPrecoProduto = new Label();
      lblPrecoProduto.Text = "Preço do Produto:";
      lblPrecoProduto.Location = new Point(10, 180);

      txtPrecoProduto = new MaskedTextBox();
      txtPrecoProduto.Location = new Point(10, 200);
      txtPrecoProduto.Width = 100;
      txtPrecoProduto.Mask = "999,99";

      lblQuantidadeEstoque = new Label();
      lblQuantidadeEstoque.Text = "Quantidade em Estoque:";
      lblQuantidadeEstoque.Location = new Point(10, 230);

      txtQuantidadeEstoque = new MaskedTextBox();
      txtQuantidadeEstoque.Location = new Point(10, 250);
      txtQuantidadeEstoque.Width = 100;
      txtQuantidadeEstoque.Mask = "99999";

      btnSalvar = new Button();
      btnSalvar.Text = "Salvar";
      btnSalvar.Location = new Point(10, 280);
      btnSalvar.Click += BtnSalvar_Click;

      btnEditar = new Button();
      btnEditar.Text = "Editar";
      btnEditar.Location = new Point(110, 280);
      btnEditar.Click += BtnEditar_Click;

      btnExcluir = new Button();
      btnExcluir.Text = "Excluir";
      btnExcluir.Location = new Point(210, 280);
      btnExcluir.Click += BtnExcluir_Click;

      // Posicionamento dos elementos no formulário
      this.Controls.Add(lblIdProduto);
      this.Controls.Add(txtIdProduto);
      this.Controls.Add(lblNomeProduto);
      this.Controls.Add(txtNomeProduto);
      this.Controls.Add(lblDescricaoProduto);
      this.Controls.Add(txtDescricaoProduto);
      this.Controls.Add(lblPrecoProduto);
      this.Controls.Add(txtPrecoProduto);
      this.Controls.Add(lblQuantidadeEstoque);
      this.Controls.Add(txtQuantidadeEstoque);
      this.Controls.Add(btnSalvar);
      this.Controls.Add(btnEditar);
    }
  }
}   
