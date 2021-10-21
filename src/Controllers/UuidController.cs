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
            string[] sequenceSplits = Regex.Split(sequence, " ");
            int[] seqNumbers = Array.ConvertAll(sequenceSplits, int.Parse);
            int number1 = 0;
            List<int> longSeq = new List<int>();
            List<int> finalLongSeq = new List<int>();

            for (int i = 0; i < seqNumbers.Length; i++)
            {
                if ((i + 1) == seqNumbers.Length)
                {
                    if (number1 < seqNumbers[i])
                    {
                        number1 = seqNumbers[i];
                        longSeq.Add(number1);
                    }
                }
                else
                {
                    number1 = seqNumbers[i];
                    longSeq.Add(number1);
                }
                if (((i + 1) == seqNumbers.Length) || number1 > seqNumbers[i + 1])
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

    }

}