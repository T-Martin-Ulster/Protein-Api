using ProteinApi.Models;
using ProteinApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ProteinApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionsController : ControllerBase
{
    private readonly TransactionsService _transactionsService;

    public TransactionsController(TransactionsService transactionsService) =>
        _transactionsService = transactionsService;

    [HttpGet]
    public async Task<List<Transaction>> Get() =>
        await _transactionsService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Transaction>> Get(string id)
    {
        var transaction = await _transactionsService.GetAsync(id);

        if (transaction is null)
        {
            return NotFound();
        }

        return transaction;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Transaction newTransaction)
    {
        //Iota message

        newTransaction.MessageId = "test";
        
        await _transactionsService.CreateAsync(newTransaction);

        return CreatedAtAction(nameof(Get), new { id = newTransaction.TransactionId }, newTransaction);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Transaction updatedTransaction)
    {
        var transaction = await _transactionsService.GetAsync(id);

        if (transaction is null)
        {
            return NotFound();
        }

        updatedTransaction.TransactionId = transaction.TransactionId;

        await _transactionsService.UpdateAsync(id, updatedTransaction);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var transaction = await _transactionsService.GetAsync(id);

        if (transaction is null)
        {
            return NotFound();
        }

        await _transactionsService.RemoveAsync(id);

        return NoContent();
    }
}