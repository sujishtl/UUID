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
                List<int> longSeq = new();
                List<int> finalLongSeq = new();
                
                for (int i = 0; i < seqNumbers.Length; i++)
                {
                    if ((i + 1) == seqNumbers.Length)
                    {
                        if (currentNumber < seqNumbers[i])
                        {
                            currentNumber = GetNextNumber(seqNumbers, longSeq, i);
                        }
                    }
                    else
                    {
                        currentNumber = GetNextNumber(seqNumbers, longSeq, i);
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
                return Ok(string.Join(" ", finalLongSeq)?.Trim());
            }
            catch(Exception ex)
            {
                return BadRequest($"Something went wrong. Please try again. {ex.Message}");
            }
        }

        private static int GetNextNumber(int[] seqNumbers, List<int> longSeq, int i)
        {
            int currentNumber = seqNumbers[i];
            longSeq.Add(currentNumber);
            return currentNumber;
        }
    }

}