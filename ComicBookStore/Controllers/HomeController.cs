using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using ComicBookStore.Models;
using static ComicBookStore.Models.Review;
using static ComicBookStore.Models.Comics;

namespace ComicBookStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly Random m_oRandom = new Random();
        private ComicsContextDb db = new ComicsContextDb();

        public ActionResult Home()
        {
            return View("Home");
        }

        public string GetStatisticsOfComics()
        {
            int allComicsNum = db.Comics.Count();
            string content = "letter\tfrequency\n";
            if (allComicsNum == 0)
                return content;
            foreach (GenreEnum genre in Enum.GetValues(typeof(GenreEnum)))
            {
                content += genre.ToString();
                content += "\t";
                content += "0." + db.Comics.Count(p => p.Genre == genre) * 100 / allComicsNum;
                content += "\n";
            }

            return content;
        }

        public string GetStatisticsOfReviews()
        {
            int allReviewsNum = db.Reviews.Count();
            string content = "letter\tfrequency\n";
            if (allReviewsNum == 0)
                return content;
            foreach (Rank rank in Enum.GetValues(typeof(Rank)))
            {
                content += rank.ToString();
                content += "\t";
                content += "0." + db.Reviews.Count(p => p.ComicsRank == rank) * 100 / allReviewsNum;
                content += "\n";
            }

            return content;
        }
    }
}
