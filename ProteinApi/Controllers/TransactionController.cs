using ProteinApi.Models;
using ProteinApi.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.IO;
using Newtonsoft.Json;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;

namespace ProteinApi.Controllers;

//Hello

[ApiController]
[Route("api/[controller]")]
public class ProduceTransactionController : ControllerBase
{
    private readonly ProduceTransactionService _produceTransactionService;

    public ProduceTransactionController(ProduceTransactionService produceTransactionService) =>
        _produceTransactionService = produceTransactionService;

    [HttpGet]
    public async Task<List<ProduceTransaction>> Get() =>
        await _produceTransactionService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<ProduceTransaction>> Get(string id)
    {
        var produceTransaction = await _produceTransactionService.GetAsync(id);

        if (produceTransaction is null)
        {
            return NotFound();
        }

        return produceTransaction;
    }

    [HttpPost]
    public async Task<IActionResult> Post(ProduceTransaction newProduceTransaction)
    {

        string json = Newtonsoft.Json.JsonConvert.SerializeObject(newProduceTransaction);

        string filename = Path.Combine(Environment.CurrentDirectory, @"Scripts/message_post");

        string tangelPath = Globals.tanglePath;

        string cParams = tangelPath + " " + "ProduceTransaction" + " " + json;

        //Runs Exe file
        var proc = new Process();

        proc.StartInfo.RedirectStandardOutput = true;

        proc.StartInfo.UseShellExecute = false;

        proc.StartInfo.FileName = filename;

        proc.StartInfo.Arguments = cParams;

        proc.Start();

        var output = proc.StandardOutput.ReadLine();

        if (output != null)
        {
            newProduceTransaction.MessageId = output;

            await _produceTransactionService.CreateAsync(newProduceTransaction);

            return CreatedAtAction(nameof(Get), new { id = newProduceTransaction.ProduceTransactionId }, newProduceTransaction);

        }

        return StatusCode(500, "Tangle not responding");
        
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, ProduceTransaction updatedProduceTransaction)
    {
        var produceTransaction = await _produceTransactionService.GetAsync(id);

        if (produceTransaction is null)
        {
            return NotFound();
        }

        updatedProduceTransaction.ProduceTransactionId = produceTransaction.ProduceTransactionId;

        await _produceTransactionService.UpdateAsync(id, updatedProduceTransaction);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var produceTransaction = await _produceTransactionService.GetAsync(id);

        if (produceTransaction is null)
        {
            return NotFound();
        }

        await _produceTransactionService.RemoveAsync(id);

        return NoContent();
    }
}