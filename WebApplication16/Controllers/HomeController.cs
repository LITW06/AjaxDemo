using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication16.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetFakePerson(int minAge, int maxAge)
        {
            var person = GenerateFakePerson(minAge, maxAge);
            return Json(person, JsonRequestBehavior.AllowGet);
        }
        //[HttpPost]
        //public ActionResult GetFakePerson(int minAge, int maxAge)
        //{
        //    var person = GenerateFakePerson(minAge, maxAge);
        //    return Json(person);
        //}

        public ActionResult ShowReverse()
        {
            return View();
        }

        public ActionResult Reverse(Foo foo)
        {
            string reversed = new string(foo.Text.Reverse().ToArray());
            return Json(new { Word = reversed }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetPeople(int size)
        {
            var ppl = Enumerable.Range(1, size)
                .Select(_ => GenerateFakePerson(10, 90));
            return Json(ppl);

        }

        private Person GenerateFakePerson(int minAge, int maxAge)
        {
            return new Person
            {
                FirstName = Faker.Name.First(),
                LastName = Faker.Name.Last(),
                Age = Faker.RandomNumber.Next(minAge, maxAge)
            };
        }
    }

    public class Foo
    {
        public string Text { get; set; }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}

//Create an application that has two textboxes and a button. The user will then
//be able to type into the first textbox, and click the button. When the button is
//clicked, your application should make an ajax request (get or post, you can do
//whatever you want) that sends along the text from the first textbox. The 
//server should then respond with an object that has the string on it but in 
//reverse. Back in your JS, the second textbox should get populated with the reversed
//text.