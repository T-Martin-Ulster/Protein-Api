using ProteinApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ProteinApi.Services;

public class TransactionsService
{
    private readonly IMongoCollection<Transaction> _transactionsCollection;

    public TransactionsService(
        IOptions<ProteinIDatabaseSettings> proteinIDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            proteinIDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            proteinIDatabaseSettings.Value.DatabaseName);

        _transactionsCollection = mongoDatabase.GetCollection<Transaction>(
            proteinIDatabaseSettings.Value.TransactionsCollectionName);
    }

    public async Task<List<Transaction>> GetAsync() =>
        await _transactionsCollection.Find(_ => true).ToListAsync();

    public async Task<Transaction?> GetAsync(string id) =>
        await _transactionsCollection.Find(x => x.TransactionId == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Transaction newTransaction) =>
        await _transactionsCollection.InsertOneAsync(newTransaction);

    public async Task UpdateAsync(string id, Transaction updatedTransaction) =>
        await _transactionsCollection.ReplaceOneAsync(x => x.TransactionId == id, updatedTransaction);

    public async Task RemoveAsync(string id) =>
        await _transactionsCollection.DeleteOneAsync(x => x.TransactionId == id);
}



