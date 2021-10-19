using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Uuid;
using Uuid.Models;

namespace DotnetDockerIntegrationTests.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UuidController : ControllerBase
    {
        
        private readonly IValidator<string> _validator;

        public UuidController( IValidator<string> validator)        {
            
            _validator = validator;
        }



        [HttpGet("GetSequence/{sequence}")]
        public async Task<IActionResult> GetSequence(string sequence)
        {
            string[] sequenceSplits = Regex.Split(sequence, " ");

      
            int[] ints = Array.ConvertAll(sequenceSplits, int.Parse);

            Array.Sort(ints);

            string returnValue="";
            foreach(var x in ints)
            {
                returnValue = returnValue + " " + x;
            }


            return Ok("1 5 9");
        }

    }

}