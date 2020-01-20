﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ZeroWidthApi.Controllers
{
    /// <summary>
    /// Controller for encoding en decoding strings
    /// </summary>
    [ApiController]
    [Route("[action]")]
    public class EncodeDecodeController : ControllerBase
    {

        private readonly ILogger<EncodeDecodeController> _logger;
        private Coder _coder;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        public EncodeDecodeController(ILogger<EncodeDecodeController> logger)
        {
            _logger = logger;
            _coder = new Coder();
        }

        /// <summary>
        /// Encode a string
        /// </summary>
        /// <param name="stringToEncode">The string to encode</param>
        /// <returns>Result</returns>
        [HttpPost]
        public string Encode([Required]string stringToEncode)
        {
            return _coder.Encode(stringToEncode);
        }
        
        /// <summary>
        /// Decode a string
        /// </summary>
        /// <param name="stringToDecode">The string to decode</param>
        /// <returns>Result</returns>
        [HttpPost]
        public string Decode([Required]string stringToDecode)
        {
            return _coder.Decode(stringToDecode);
        }


    }
}