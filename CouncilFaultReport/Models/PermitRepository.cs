using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CouncilFaultReport.Models
{
    public class PermitRepository : IPermitRepository
    {
        //ObjectId id = new ObjectId();
        //MongoClient client = null;
        //MongoServerAddress server = null;
        //MongoDatabaseBase database = null;
        //MongoCollection UserDetailscollection = null;

        MongoDbContext db = new MongoDbContext();
        public async Task Add(Permit permit)
        {
            try
            {
                await db.Permit.InsertOneAsync(permit);
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task Delete(string id)
        {
            try
            {
                FilterDefinition<Permit> data = Builders<Permit>.Filter.Eq("Id", id);
                await db.Permit.DeleteOneAsync(data);
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task<Permit> GetPermit(string id)
        {
            try
            {
                FilterDefinition<Permit> filter = Builders<Permit>.Filter.Eq("Id", id);
                return await db.Permit.Find(filter).FirstOrDefaultAsync();
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task<IEnumerable<Permit>> GetPermits()
        {
            try
            {
                //var permits = db.Permit.FindAsync
                //return View(carDetails);
                return await db.Permit.Find(new BsonDocument()).ToListAsync();
                //return await db.Permit.Find(_ => true).ToListAsync();
                //var result = await _usersCollection.Find(new BsonDocument())
                //                       .Skip(startingFrom)
                //                       .Limit(count)
                //                       .ToListAsync();
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task Update(Permit permit)
        {
            try
            {
                await db.Permit.ReplaceOneAsync(filter: g => g.id == permit.id, replacement: permit);
            }
            catch
            {
                throw new NotImplementedException();
            }
        }
    }
}