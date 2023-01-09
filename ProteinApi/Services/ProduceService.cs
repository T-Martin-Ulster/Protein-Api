using ProteinApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ProteinApi.Services;

public class ProduceService
{
    private readonly IMongoCollection<Produce> _produceCollection;

    public ProduceService(
        IOptions<ProteinIDatabaseSettings> proteinIDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            proteinIDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            proteinIDatabaseSettings.Value.DatabaseName);

        _produceCollection = mongoDatabase.GetCollection<Produce>(
            proteinIDatabaseSettings.Value.ProduceCollectionName);
    }

    public async Task<List<Produce>> GetAsync() =>
        await _produceCollection.Find(_ => true).ToListAsync();

    public async Task<Produce?> GetAsync(string id) =>
        await _produceCollection.Find(x => x.ProduceId == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Produce newProduce) =>
        await _produceCollection.InsertOneAsync(newProduce);

    public async Task UpdateAsync(string id, Produce updatedProduce) =>
        await _produceCollection.ReplaceOneAsync(x => x.ProduceId == id, updatedProduce);

    public async Task RemoveAsync(string id) =>
        await _produceCollection.DeleteOneAsync(x => x.ProduceId == id);
}



