using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeProdutos.DbApplication
{
    internal class ProdutosDb
    {
        public string Mensagem { get; set; }
        public bool Status { get; set; }
        public string Tabela { get; set; }
        public SQLServerClass db { get; set; }


        public ProdutosDb(string tabela)
        {
            Status = true;
            try
            {
                db = new SQLServerClass();
                Tabela = tabela;
                Mensagem = "Conexão com a tabela criada com sucesso";
            }
            catch (Exception ex)
            {
                Status = false;
                Mensagem = "Conexão com a tabela com erro: " + ex.Message;

            }
        }

        public void Cadastrar(int id, string nome, double valorUnit, int estoque, string fabricante)
        {
            Status = true;

            try
            {
                var sql = $"INSERT INTO {Tabela} VALUES ({id}, '{nome}',{valorUnit}, {estoque}, '{fabricante}'); ";
                db.SQLCommand(sql);
                Status = true;
                Mensagem = "Cadastro concluido com sucesso. Id: " + id;
            }
            catch(Exception ex)
            {
                Status = false;
                Mensagem = "Erro ao cadastrar o produto: " + ex.Message;
            }
        }

        public void Excluir(int id)
        {
            Status = true;
            try
            {
                var sql = $"DELETE FROM {Tabela} WHERE Id = {id};";
                db.SQLCommand(sql);
                Status = true;
                Mensagem = "Deletação concluida com sucesso. Id: " + id;
            }
            catch(Exception ex)
            {
                Status=false;
                Mensagem = "Houve um problema ao excluir o produto: " + ex.Message;
            }
        }
        public void AlterarValor(int id, double novoValor)
        {
            Status = true;

            try
            {
                var sql = $"UPDATE {Tabela} SET PRECO = {novoValor} WHERE Id = {id};"
                db.SQLCommand(sql);
                Status = true;
                Mensagem = "Alteração concluida com sucesso. Id: " + id;
            }
            catch (Exception ex)
            {
                Status = false;
                Mensagem = "Houve um problema ao excluir o produto: " + ex.Message;
            }
        }
    }
}
