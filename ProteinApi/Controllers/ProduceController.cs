using ProteinApi.Models;
using ProteinApi.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.IO;
using Newtonsoft.Json;
using System.Diagnostics;

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
        string json = Newtonsoft.Json.JsonConvert.SerializeObject(newTransaction);

        string filename = Path.Combine(Environment.CurrentDirectory, @"Scripts/message_post");

        //todo Move path tp appsettings
        string cParams = "http://localhost:14266" + " " + "Transactions" + " " + json;

        var proc = new Process();

        proc.StartInfo.RedirectStandardOutput = true;

        proc.StartInfo.UseShellExecute = false;

        proc.StartInfo.FileName = filename;

        proc.StartInfo.Arguments = cParams;

        proc.Start();

        var output = proc.StandardOutput.ReadLine();

        if (output != null)
        {
            newTransaction.MessageId = output;

            await _transactionsService.CreateAsync(newTransaction);

            return CreatedAtAction(nameof(Get), new { id = newTransaction.TransactionId }, newTransaction);

        }

        return StatusCode(500, "Tangle not responding");
        
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