using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestMongo.Models;

namespace TestMongo.Services.GlobalService.Abstracts
{
    public interface IGlobalService
    {
        Task<IEnumerable<GlobalModel>> GetAllGlobals();
        Task<GlobalModel> GetGlobal(string key);
        Task AddGlobal(GlobalModel global);
        Task<bool> UpdateGlobal(GlobalModel global);
        Task<DeleteResult> DeleteGlobal(string key);
    }
}
