using ProteinApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ProteinApi.Services;

public class TransactionRequestService
{
    private readonly IMongoCollection<TransactionRequest> _transactionRequestCollection;

    public TransactionRequestService(
        IOptions<ProteinIDatabaseSettings> proteinIDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            proteinIDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            proteinIDatabaseSettings.Value.DatabaseName);

        _transactionRequestCollection = mongoDatabase.GetCollection<TransactionRequest>(
            proteinIDatabaseSettings.Value.TransactionRequestCollectionName);
    }

    public async Task<List<TransactionRequest>> GetAsync() =>
        await _transactionRequestCollection.Find(_ => true).ToListAsync();

    public async Task<TransactionRequest?> GetAsync(string id) =>
        await _transactionRequestCollection.Find(x => x.TransactionRequestId == id).FirstOrDefaultAsync();

    public async Task CreateAsync(TransactionRequest newTransactionRequest) =>
        await _transactionRequestCollection.InsertOneAsync(newTransactionRequest);

    public async Task UpdateAsync(string id, TransactionRequest updatedTransactionRequest) =>
        await _transactionRequestCollection.ReplaceOneAsync(x => x.TransactionRequestId == id, updatedTransactionRequest);

    public async Task RemoveAsync(string id) =>
        await _transactionRequestCollection.DeleteOneAsync(x => x.TransactionRequestId == id);
}



