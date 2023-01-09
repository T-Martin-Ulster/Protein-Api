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
public class FieldController : ControllerBase
{
    private readonly FieldService _fieldService;

    public FieldController(FieldService fieldService) =>
        _fieldService = fieldService;

    [HttpGet]
    public async Task<List<Field>> Get() =>
        await _fieldService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Field>> Get(string id)
    {
        var field = await _fieldService.GetAsync(id);

        if (field is null)
        {
            return NotFound();
        }

        return field;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Field newField)
    {

        string json = Newtonsoft.Json.JsonConvert.SerializeObject(newField);

        string filename = Path.Combine(Environment.CurrentDirectory, @"Scripts/message_post");

        string tangelPath = Globals.tanglePath;

        string cParams = tangelPath + " " + "Field" + " " + json;

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
            newField.MessageId = output;

            await _fieldService.CreateAsync(newField);

            return CreatedAtAction(nameof(Get), new { id = newField.FieldId }, newField);

        }

        return StatusCode(500, "Tangle not responding");
        
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Field updatedField)
    {
        var field = await _fieldService.GetAsync(id);

        if (field is null)
        {
            return NotFound();
        }

        updatedField.FieldId = field.FieldId;

        await _fieldService.UpdateAsync(id, updatedField);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var field = await _fieldService.GetAsync(id);

        if (field is null)
        {
            return NotFound();
        }

        await _fieldService.RemoveAsync(id);

        return NoContent();
    }
}