using ProteinApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ProteinApi.Services;

public class ProduceTransactionService
{
    private readonly IMongoCollection<ProduceTransaction> _produceTransactionCollection;

    public ProduceTransactionService(
        IOptions<ProteinIDatabaseSettings> proteinIDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            proteinIDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            proteinIDatabaseSettings.Value.DatabaseName);

        _produceTransactionCollection = mongoDatabase.GetCollection<ProduceTransaction>(
            proteinIDatabaseSettings.Value.ProduceTransactionCollectionName);
    }

    public async Task<List<ProduceTransaction>> GetAsync() =>
        await _produceTransactionCollection.Find(_ => true).ToListAsync();

    public async Task<ProduceTransaction?> GetAsync(string id) =>
        await _produceTransactionCollection.Find(x => x.ProduceTransactionId == id).FirstOrDefaultAsync();

    public async Task CreateAsync(ProduceTransaction newProduceTransaction) =>
        await _produceTransactionCollection.InsertOneAsync(newProduceTransaction);

    public async Task UpdateAsync(string id, ProduceTransaction updatedProduceTransaction) =>
        await _produceTransactionCollection.ReplaceOneAsync(x => x.ProduceTransactionId == id, updatedProduceTransaction);

    public async Task RemoveAsync(string id) =>
        await _produceTransactionCollection.DeleteOneAsync(x => x.ProduceTransactionId == id);
}



