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
public class ProduceController : ControllerBase
{
    private readonly ProduceService _produceService;

    public ProduceController(ProduceService produceService) =>
        _produceService = produceService;

    [HttpGet]
    public async Task<List<Produce>> Get() =>
        await _produceService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Produce>> Get(string id)
    {
        var produce = await _produceService.GetAsync(id);

        if (produce is null)
        {
            return NotFound();
        }

        return produce;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Produce newProduce)
    {

        string json = Newtonsoft.Json.JsonConvert.SerializeObject(newProduce);

        string filename = Path.Combine(Environment.CurrentDirectory, @"Scripts/message_post");

        string tangelPath = Globals.tanglePath;

        string cParams = tangelPath + " " + "Produce" + " " + json;

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
            newProduce.MessageId = output;

            await _produceService.CreateAsync(newProduce);

            return CreatedAtAction(nameof(Get), new { id = newProduce.ProduceId }, newProduce);

        }

        return StatusCode(500, "Tangle not responding");
        
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Produce updatedProduce)
    {
        var produce = await _produceService.GetAsync(id);

        if (produce is null)
        {
            return NotFound();
        }

        updatedProduce.ProduceId = produce.ProduceId;

        await _produceService.UpdateAsync(id, updatedProduce);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var produce = await _produceService.GetAsync(id);

        if (produce is null)
        {
            return NotFound();
        }

        await _produceService.RemoveAsync(id);

        return NoContent();
    }
}