using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidade.Models
{
    public class Indicado
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [ReadOnly(true)]
        [DefaultValue(null)]
        public string Id { get; set; }

        [Required]
        [DefaultValue(null)]
        public string nome { get; set; }

        [Required]
        [DefaultValue(null)]
        public long numeroTelefone { get; set; }

        [Required]
        [DefaultValue(null)]
        public string observacoes { get; set; }

        [Required]
        [DefaultValue(null)]
        public string nomeIndicador { get; set;}

        [Required]
        [DefaultValue(null)]
        public long telefoneIndicador { get; set;}
    }
}
