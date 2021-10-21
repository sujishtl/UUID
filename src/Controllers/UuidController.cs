using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public UuidController(IValidator<string> validator)
        {

            _validator = validator;
        }



        [HttpGet("GetSequence/{sequence}")]
        public async Task<IActionResult> GetSequence(string sequence)
        {
            var validationResult = await _validator.ValidateAsync(sequence);
            if (!validationResult.IsValid)
                return BadRequest("Please give the correct input");

            try
            {
                string[] sequenceSplits = Regex.Split(sequence.Trim(), " ");
                int[] seqNumbers = Array.ConvertAll(sequenceSplits, int.Parse);
                int currentNumber = 0;
                List<int> longSeq = new List<int>();
                List<int> finalLongSeq = new List<int>();

                for (int i = 0; i < seqNumbers.Length; i++)
                {
                    if ((i + 1) == seqNumbers.Length)
                    {
                        if (currentNumber < seqNumbers[i])
                        {
                            currentNumber = seqNumbers[i];
                            longSeq.Add(currentNumber);
                        }
                    }
                    else
                    {
                        currentNumber = seqNumbers[i];
                        longSeq.Add(currentNumber);
                    }
                    if (((i + 1) == seqNumbers.Length) || currentNumber > seqNumbers[i + 1])
                    {
                        if (longSeq.Count > finalLongSeq.Count)
                        {
                            finalLongSeq.Clear();
                            finalLongSeq.AddRange(longSeq);

                        }
                        longSeq.Clear();
                    }
                }

                string returnValue = "";
                foreach (var x in finalLongSeq)
                {
                    returnValue = returnValue + " " + x;
                }
                return Ok(returnValue.Trim());
            }
            catch(Exception ex)
            {
                return BadRequest($"Something went wrong. Please try again. {ex.Message}");
            }
        }

    }

}