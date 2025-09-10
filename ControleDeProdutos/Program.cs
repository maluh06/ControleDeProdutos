using ControleDeProdutos.DbApplication;
using ControleDeProdutos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeProdutos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcao;
            ComandosSQL comandosSQL = new ComandosSQL("`Produtos");


            Console.WriteLine("Seja bem-vindo ao Product Controller");

            do
            {
                Console.WriteLine("Qual operação deseja realizar: ");
                Console.WriteLine("1)Cadastrar produto\n2)Alterar produto\n3)Excluir Produto\n4)Acessar produtos\n5)Pesquisa");
                Console.WriteLine();
                Console.Write("Digite o número que corresponte ao que deseja fazer: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Cadastro de produto: ");
                        Console.Write("Insira o Id do produto: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Insira o nome: ");
                        string nome = (Console.ReadLine());
                        Console.Write("Insira seu valor unitário: ");
                        double valorUnitario = double.Parse(Console.ReadLine());
                        Console.Write("Insira a sua quantidade estocada: ");
                        int estoque = int.Parse(Console.ReadLine());
                        Console.Write("Insira o nome do fabricante: ");
                        string fabricante = (Console.ReadLine());
                        Console.WriteLine("");
                        Console.WriteLine("Produto cadastrado");

                        Produto produto = new Produto(id, nome, valorUnitario, estoque, fabricante);
                        comandosSQL.Cadastrar(produto);
                        ; break;
                    case 2:
                        Console.WriteLine("Alteração de produto: ");
                        Console.Write("Insira o Id do produto: ");
                        id = int.Parse(Console.ReadLine());
                        Console.Write("Insira o novo valor: ");
                        valorUnitario = double.Parse(Console.ReadLine());
                        Console.WriteLine("");
                        Console.WriteLine("Produto alterado");

                        comandosSQL.AlterarValor(id, valorUnitario);

                        ; break;
                    case 3:
                        Console.WriteLine("Alteração de produto: ");
                        Console.Write("Insira o Id do produto: ");
                        id = int.Parse(Console.ReadLine());
                        Console.WriteLine("");
                        Console.WriteLine("Produto excluido");

                        comandosSQL.Excluir(id);
                        ; break;
                    case 4:
                        var produtos = comandosSQL.AcessarProdutos();
                        foreach (var p in produtos)
                        {
                            Console.WriteLine($"{p.Id} | {p.Name} | {p.ValorUnitario:C} | {p.Estoque} | {p.Fabricante}");
                        }

                        ; break;
                    default:
                        Console.WriteLine("Valor inválido");
                        ;break;
                }

            }while(opcao != 0);
        }
    }
}
