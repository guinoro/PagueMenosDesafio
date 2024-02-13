using System;
using System.Windows.Forms;

namespace PagueMenosDesafio
{
  internal static class Program
  {
    [STAThread]
    private static void Main()
    {
      Application.SetHighDpiMode(HighDpiMode.SystemAware);
      Application.EnableVisualStyles();
      Application.Run(new Form1(new ProdutoService()));
    }
  }
}
