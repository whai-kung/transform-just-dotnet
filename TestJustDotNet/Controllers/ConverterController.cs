using System;
using JUST;
using Microsoft.AspNetCore.Mvc;
//using Newtonsoft.Json;
using TestJustDotNet.Models;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace TestJustDotNet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConverterController : Controller
    {
        [HttpPost("ToJust")]
        public IActionResult ToJustDotNet(RequestModel request)
        {
            string transformedString;
            try
            {
                if (string.IsNullOrEmpty(request.Input) || string.IsNullOrEmpty(request.Output))
                {
                    var transform = JsonSerializer.Serialize(request.Transformer);
                    var source = JsonSerializer.Serialize(request.Source);
                    transformedString = JsonTransformer.Transform(transform, source);
                }
                else
                {
                    var input = Regex.Replace(request.Input, "(\"(?:[^\"\\\\]|\\\\.)*\")|\\s+", "$1");
                    var output = Regex.Replace(request.Output, "(\"(?:[^\"\\\\]|\\\\.)*\")|\\s+", "$1");
                    transformedString = JsonTransformer.Transform(output, input);
                }
                return Ok(transformedString);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
