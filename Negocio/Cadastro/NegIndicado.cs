using Entidade;
using Entidade.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Cadastro
{
    public class NegIndicado
    {
        private readonly IMongoCollection<Indicado> _settings;

        public NegIndicado(IIndicadoDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _settings = database.GetCollection<Indicado>(settings.BooksCollectionName);
        }
        public Indicado Create(Indicado indicado)
        {
            _settings.InsertOne(indicado);
            return indicado;
        }
    }
}
