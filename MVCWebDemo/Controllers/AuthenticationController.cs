using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCWebDemo.Converters;
using MVCWebDemo.Core.BLL;
using MVCWebDemo.Core.DAL.Contexts;
using MVCWebDemo.Core.DAL.Model;

namespace MVCWebDemo.Controllers
{
    public class AuthenticationController : Controller
    {
        HighScoreViewModelConverter cvt;
        HighScoreRepository repo;
        IHighScoreContext context;

        public AuthenticationController(IHighScoreContext _context)
        {
            context = _context;
            repo = new HighScoreRepository(context);
            cvt = new HighScoreViewModelConverter();
        }

        [Authorize(Roles = "Member")]
        public IActionResult MemberOnly()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AdminOnly()
        {
            return View();
        }

        [Authorize]
        public IActionResult AuthenticatedOnly()
        {
            return View();
        }
        [Authorize]
        public IActionResult PlayGame()
        {
            HighScore high = new HighScore
            {
                Scores = repo.GetScores()
            };
            return View(high);
        }
    }
}