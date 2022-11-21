using AppCustoViagem.Model;
using AppCustoViagem.Model;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppCustoViagem.Helper
{

    public class SQLiteDatabaseHelper
    {

        readonly SQLiteAsyncConnection _connection;

        public SQLiteDatabaseHelper(string path)
        {

            _connection = new SQLiteAsyncConnection(path);

            _connection.CreateTableAsync<Pedagio>().Wait();

            _connection.CreateTableAsync<Viagem>().Wait();
        }

        public Task<int> Insert(Pedagio p)
        {
            return _connection.InsertAsync(p);
        }

        public Task<List<Pedagio>> Update(Pedagio p)
        {
            string sql = "UPDATE Pedagio SET Localizacao=?, Valor=? WHERE id= ? ";
            return _connection.QueryAsync<Pedagio>(sql, p.Localizacao, p.Valor, p.Id);
        }

        public Task<List<Pedagio>> GetAll()
        {
            return _connection.Table<Pedagio>().ToListAsync();
        }

        public Task<int> Delete(int id)
        {
            return _connection.Table<Pedagio>().DeleteAsync(i => i.Id == id);
        }

        public Task<List<Pedagio>> Search(string q)
        {
            string sql = "SELECT * FROM Pedagio WHERE Descricao LIKE '%" + q + "%' ";

            return _connection.QueryAsync<Pedagio>(sql);
        }

        public Task<int> InsertV(Viagem v)
        {
            return _connection.InsertAsync(v);
        }

        public Task<List<Viagem>> UpdateV(Viagem v)
        {
            string sql = "UPDATE Pedagio SET Origem=?, Destino=?, Preco_Combustivel=?, Consumo=?, Distancia=? WHERE id= ? ";
            return _connection.QueryAsync<Viagem>(sql, v.Distancia, v.Consumo, v.Preco_Combustivel, v.Destino, v.Origem, v.Id);
        }

        public Task<List<Viagem>> GetAllV()
        {
            return _connection.Table<Viagem>().ToListAsync();
        }

        public Task<int> DeleteV(int id)
        {
            return _connection.Table<Viagem>().DeleteAsync(i => i.Id == id);
        }

        public Task<List<Viagem>> SearchV(string q)
        {
            string sql = "SELECT * FROM Viagem WHERE Id LIKE '%" + q + "%' ";

            return _connection.QueryAsync<Viagem>(sql);
        }

    }
}