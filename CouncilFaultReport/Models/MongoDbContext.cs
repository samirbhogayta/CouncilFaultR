using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace CouncilFaultReport.Models
{
    public class MongoDbContext
    {
        MongoClient _client;
        MongoServerAddress _server;
        public IMongoDatabase _database;
        private readonly IMongoDatabase _mongoDb;
        public MongoDbContext()
        {
            //var MongoDatabaseName = ConfigurationManager.AppSettings["MongoDatabaseName"];
            //var MongoUsername = ConfigurationManager.AppSettings["MongoUsername"];
            //var MongoPassword = ConfigurationManager.AppSettings["MongoPassword"];
            //var MongoPort = ConfigurationManager.AppSettings["27017"];
            //var MongoHost = ConfigurationManager.AppSettings["MongoHost"];


            //var credential = MongoCredential.CreateMongoCRCredential(MongoDatabaseName, MongoUsername, MongoPassword);

            //var settings = new MongoClientSettings
            //{
            //    Credentials = new[] { credential },
            //    Server = new MongoServerAddress(MongoHost, Convert.ToInt32(MongoPort))
            //};
            //_client = new MongoClient(settings);
            //_server = _client.GetServer();
            //var client = new MongoClient("mongodb+srv://admin:<password>@councilf-permit-1h8d5.azure.mongodb.net/test?retryWrites=true&w=majority");
            //var client = new MongoClient("mongodb://admin:admin%40redspark@councilf-permit-1h8d5.azure.mongodb.net/councilf_permitDB");
            //var client = new MongoClient("mongodb+srv://admin:admin%40redspark@councilf-permit-1h8d5.azure.mongodb.net/councilf_permitDB?retryWrites=true&w=majority");
            var client = new MongoClient("mongodb://localhost:27017/Councilf_PermitDB");
            _mongoDb = client.GetDatabase("councilf_permitDB");
        }
        public IMongoCollection<Permit> Permit
        {
            get
            {
                return _mongoDb.GetCollection<Permit>("Permit");
            }
        }        
    }
}