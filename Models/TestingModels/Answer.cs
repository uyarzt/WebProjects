using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppForTesting.Models.TestingModels
{
    public class Answer
    {
        public int Id { get; set; }
        public string Ans { get; set; }
        public bool IsCorrect { get; set; }
        public Nullable<int> QuestionId { get; set; }

        public virtual Question Question { get; set; }
    }
}