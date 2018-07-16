using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TestMongo.Models;
using TestMongo.Services.GlobalService.Abstracts;

namespace TestMongo.Services.GlobalService
{
    public class GlobalService : IGlobalService
    {
        private readonly GlobalsRepository _repository = null;

        public GlobalService(IOptions<Settings> settings)
        {
            _repository = new GlobalsRepository(settings);
        }

        public async Task AddGlobal(GlobalModel model)
        {
            await _repository.Globals.InsertOneAsync(model);
        }

        public async Task<DeleteResult> DeleteGlobal(string key)
        {
            var filter = Builders<GlobalModel>.Filter.Eq("key", key);
            return await _repository.Globals.DeleteOneAsync(filter);
        }

        public async Task<GlobalModel> GetGlobal(string key)
        {
            var filter = Builders<GlobalModel>.Filter.Eq("key", key);
            return await _repository.Globals.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<GlobalModel>> GetAllGlobals()
        {
            return await _repository.Globals.Find(x => true).ToListAsync();
        }

        public async Task<bool> UpdateGlobal(GlobalModel model)
        {
            //Check if model match with at least one
            var filter = Builders<GlobalModel>.Filter.Eq("key", model.Key);
            var product = _repository.Globals.Find(filter).FirstOrDefaultAsync();
            if (product.Result == null)
                return false;

            //update model properties
            var updateModel = Builders<GlobalModel>.Update
                                                  .Set(x => x.Group, model.Group)
                                                  .Set(x => x.Projects, model.Projects)
                                                  .Set(x => x.Public, model.Public)
                                                  .Set(x => x.Translations, model.Translations);

            await _repository.Globals.UpdateOneAsync(filter, updateModel);

            return true;
        }
    }
}
