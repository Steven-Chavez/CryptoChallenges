using System;
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
        /// Default constructor
        /// </summary>
        public ScoredMessage()
        {
            Key = ' ';
            Score = 0.0;
            Message = "";
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="key">char</param>
        /// <param name="score">double</param>
        /// <param name="message">message</param>
        public ScoredMessage(char key, double score, string message)
        {
            Key = key;
            Score = score;
            Message = message;
        }

        /// <summary>
        /// Property for key field
        /// </summary>
        public char Key
        {
            get
            {
                return key;
            }

            set
            {
                key = value;
            }
        }

        /// <summary>
        /// Property for score field
        /// </summary>
        public double Score
        {
            get
            {
                return score;
            }

            set
            {
                score = value;
            }
        }

        /// <summary>
        /// Property for message field.
        /// </summary>
        public string Message
        {
            get
            {
                return message;
            }

            set
            {
                message = value;
            }
        }

    }
}
