﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace set1Challenge3_XORCipher
{
    /// <summary>
    /// Author: Steven Chavez
    /// Date: 6/9/17
    /// File: ScoredMessages.cs
    /// Version: 1.0
    /// 
    /// Container for scored messages
    /// </summary>
    class ScoredMessage
    {
        /// <summary>
        /// Contains key used to decode message.
        /// </summary>
        private char key;

        /// <summary>
        /// Contains score of decoded message.
        /// </summary>
        private double score;

        /// <summary>
        /// Contains decoded message.
        /// </summary>
        private string message;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="key">char</param>
        /// <param name="score">double</param>
        /// <param name="message">message</param>
        public ScoredMessage(char key, double score, string message)
        {
            this.key = key;
            this.score = score;
            this.message = message;
        }
    }
}
