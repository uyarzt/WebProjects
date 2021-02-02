using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebAppForTesting.Models;
using WebAppForTesting.Models.TestingModels;

namespace WebAppForTesting.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [AllowAnonymous]
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }

        [ChildActionOnly]
        public ActionResult GetTests()
        {

            ViewBag.Title = "Test List";
            return PartialView(db.TestTypes.ToList());
        }

        [HttpGet]
        public ActionResult Start(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestType testType = db.TestTypes.Find(id);
            if (testType == null)
            {                
                return HttpNotFound();
            }
            Session["TestName"] = testType.TestName;
            ViewBag.Title = "Start Testing";
            return View(testType);
        }

        [HttpPost]
        public ActionResult Start(int? testId, bool ready)
        {            
            ViewBag.Title = "Testing";            
            if (ready && testId != null)
            {
                Session["Questions"] = db.Questions.Where(q => q.TestId == (int)testId);
                return RedirectToAction("Testing");
            }
            else
            {
                return HttpNotFound();
            }            
        }

        [HttpGet]
        public ActionResult Testing()
        {
            IEnumerable<Question> questions = (IEnumerable<Question>)Session["Questions"];
            var ques = questions.ToList().ElementAt(0);            
            ViewBag.Title = "Testing";
            ViewBag.Num = 0;
            ViewBag.Name = ques.Quest;
            ViewBag.Message = $"Ques 1 of {questions.Count()}";
                                
            Session["Result"] = new Result(0, questions.Count());

            return View(ques.Answers);           
        }

        [HttpPost]
        public ActionResult Testing(int? quesId, string ans)
        {
            if (String.IsNullOrEmpty(ans) || quesId == null)
            {
                return RedirectToAction("Testing");
            }

            IEnumerable<Question> questions = (IEnumerable<Question>)Session["Questions"];
            int nextQues = (int)quesId + 1;
            if (nextQues >= questions.Count())
            {
                return RedirectToAction("Result");
            }
            Question ques = questions.ToList().ElementAt(nextQues);
            ViewBag.Num = nextQues;
            ViewBag.Title = "Testing";
            ViewBag.Name = ques.Quest;
            ViewBag.Message = $"Ques {nextQues + 1} of {questions.Count()}";

            CalcResult(questions.ToList()
                .ElementAt((int)quesId)
                .Answers,
                ans);
                        
            return View(ques.Answers);
        }

        public ActionResult Result()
        {
            ViewBag.Title = "Test Results";
            Result result = (Session["Result"] as Result);

            return View(result);
        }

        public void CalcResult(ICollection<Answer> answers, string ans)
        {
            Result result = (Session["Result"] as Result);
            foreach (var item in answers)
            {
                if (ans.Equals(item.Ans))
                {
                    if (item.IsCorrect)
                    {
                        result.RightAnswers++;
                    }
                    break;
                }
            }
            Session["Result"] = result;
        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
      
    }
}