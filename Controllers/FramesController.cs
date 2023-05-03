using SeeSharpGlasses.Models;
using SeeSharpGlasses.Services;
using Microsoft.AspNetCore.Mvc;

namespace SeeSharpGlasses.Controllers;

[ApiController]
[Route("[controller]")]
public class FramesController : ControllerBase
{
    public FramesController()
    {

    }

    //GET all action
    [HttpGet]
    public ActionResult<List<Frames>> GetAll() =>
    FramesService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Frames> Get(int id)
    {
        var frames = FramesService.Get(id);
        if(frames == null)
            return NotFound();

        return frames;
    }

    //POST action
    [HttpPost]
    public IActionResult Create(Frames frames)
    {
        FramesService.Add(frames);
        return CreatedAtAction(nameof(Get), new { id = frames.Id }, frames);
    }

    //PUT action
    [HttpPut("{id}")]

    public IActionResult Update(int id, Frames frames)
    {
        if(id != frames.Id)
            return BadRequest();

        var exisitingFrames = FramesService.Get(id);
        if (exisitingFrames is null)
            return NotFound();

        FramesService.Update(frames);

        return NoContent();
    }

    //DELETE action
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var frames = FramesService.Get(id);

        if(frames is null)
            return NotFound();
        
        FramesService.Delete(id);

        return NoContent();
    }
}