using ControleDeProdutos.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeProdutos.DbApplication
{
    internal class ComandosSQL
    {
        public string Mensagem { get; set; }
        public bool Status { get; set; }
        public string Tabela { get; set; }
        public SQLServerClass db { get; set; }


        public ComandosSQL(string tabela)
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

        public void Cadastrar(Produto p)
        {
            Status = true;

            try
            {
                var sql = $"INSERT INTO {Tabela} VALUES ({p.Id}, '{p.Name}',{p.ValorUnitario}, {p.Estoque}, '{p.Fabricante}'); ";
                db.SQLCommand(sql);
                Status = true;
                Mensagem = "Cadastro concluido com sucesso. Id: " + p.Id;
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
                var sql = $"UPDATE {Tabela} SET PRECO = {novoValor} WHERE Id = {id};";
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
        public List<Produto> AcessarProdutos()
        {
            var lista = new List<Produto>();

            try
            {
                var sql = $"SELECT * FROM {Tabela};";
                DataTable dt = db.SQLQuery(sql);
                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(new Produto
                    {
                        Id = Convert.ToInt32(row["Id"]),
                        Name = row["Name"].ToString(),
                        ValorUnitario = Convert.ToDouble(row["ValorUnitario"]),
                        Estoque = Convert.ToInt32(row["Estoque"]),
                        Fabricante = row["Fabricante"].ToString()
                    });
                }
                Status = true;
                Mensagem = "Acesso com sucesso" ;
            }
            catch (Exception ex)
            {
                Status = false;
                Mensagem = "Houve um problema ao excluir o produto: " + ex.Message;
            }
            return lista;
        }
    }
}
