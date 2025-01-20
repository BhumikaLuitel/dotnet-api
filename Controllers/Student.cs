using Microsoft.AspNetCore.Mvc;

namespace FirstC_.Controllers;

public class Student : ControllerBase
{
    // GET
    [HttpGet("greet")]
    public IActionResult Greet()
    {
        return Ok("Hello World!");
    }

    [HttpGet("address/{name}/{ward}/{locality}")]
    public IActionResult Address(string name, int ward, string locality)
    {
        return Ok($"Namaste, {name}, You are from Birtamod {ward} and your tole is {locality}.");
    }

    [HttpGet("hi/{name}")]
    public IActionResult Hi(string name)
    {
        try
        {
            throw new Exception("This is a exception");
            return Ok($"Hello {name}");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}