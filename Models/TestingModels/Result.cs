using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppForTesting.Models.TestingModels
{
    public class Result
    {       
        public int RightAnswers { get; set; }

        public int Replies { get; set; }

        public Result() {  }

        public Result(int _rightAnswers, int _replies)
        {
            RightAnswers = _rightAnswers;
            Replies = _replies;
        }
        public string PrintRusult()
        {
            return ((RightAnswers * 100) / Replies).ToString();
        }
    }
}