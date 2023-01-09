using ProteinApi.Models;
using ProteinApi.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.IO;
using Newtonsoft.Json;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;

namespace ProteinApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionRequestController : ControllerBase
{
    private readonly TransactionRequestService _transactionRequestService;

    public TransactionRequestController(TransactionRequestService transactionRequestService) =>
        _transactionRequestService = transactionRequestService;

    [HttpGet]
    public async Task<List<TransactionRequest>> Get() =>
        await _transactionRequestService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<TransactionRequest>> Get(string id)
    {
        var transactionRequest = await _transactionRequestService.GetAsync(id);

        if (transactionRequest is null)
        {
            return NotFound();
        }

        return transactionRequest;
    }

    [HttpPost]
    public async Task<IActionResult> Post(TransactionRequest newTransactionRequest)
    {

           await _transactionRequestService.CreateAsync(newTransactionRequest);

           return CreatedAtAction(nameof(Get), new { id = newTransactionRequest.TransactionRequestId }, newTransactionRequest);

    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, TransactionRequest updatedTransactionRequest)
    {
        var transactionRequest = await _transactionRequestService.GetAsync(id);

        if (transactionRequest is null)
        {
            return NotFound();
        }

        updatedTransactionRequest.TransactionRequestId = transactionRequest.TransactionRequestId;

        await _transactionRequestService.UpdateAsync(id, updatedTransactionRequest);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var transactionRequest = await _transactionRequestService.GetAsync(id);

        if (transactionRequest is null)
        {
            return NotFound();
        }

        await _transactionRequestService.RemoveAsync(id);

        return NoContent();
    }
}