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

            Console.WriteLine("Seja bem-vindo ao Product Controller");

            do
            {
                Console.WriteLine("Qual operação deseja realizar: ");
                Console.WriteLine("1)Cadastrar produto\n2)Alterar produto\n3)Excluir Produto\n4)Acessar produtos\n5)Pesquisa");
                Console.Write("Digite o número que corresponte ao que deseja fazer: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:

                        ; break;
                    case 2:

                        ; break;
                    case 3:

                        ; break;
                    case 4:

                        ; break;
                    case 5:

                        ; break;
                }

            }while(opcao != 0);
        }
    }
}
