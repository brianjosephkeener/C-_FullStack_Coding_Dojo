using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsORM.Models;


namespace SportsORM.Controllers
{
    public class HomeController : Controller
    {

        private static Context _context;

        public HomeController(Context DBContext)
        {
            _context = DBContext;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.BaseballLeagues = _context.Leagues
                .Where(l => l.Sport.Contains("Baseball"))
                .ToList();
            return View();
        }

        [HttpGet("level_1")]
        public IActionResult Level1()
        {
            ViewBag.WomenLeague = _context.Leagues.Where(l => l.Name.Contains("Women")).ToList();
            ViewBag.HockeyLeague = _context.Leagues.Where(l => l.Sport.Contains("Hockey")).ToList();
            ViewBag.NoFootballLeague = _context.Leagues.Where(l => !l.Sport.Contains("Football")).ToList();
            ViewBag.ConferenceLeague = _context.Leagues.Where(l => l.Name.Contains("Conference")).ToList();
            ViewBag.AtlanticLeague = _context.Leagues.Where(l => l.Name.Contains("Atlantic")).ToList();
            ViewBag.DallasTeam = _context.Teams.Where(l => l.Location.Contains("Dallas")).ToList();
            ViewBag.RaptorTeam = _context.Teams.Where(l => l.TeamName.Contains("Raptors")).ToList();
            ViewBag.CityTeam = _context.Teams.Where(l => l.Location.Contains("City")).ToList();
            //ViewBag.TTeam = _context.Teams.Where(l => l.TeamName.Contains("T")).ToList();
            ViewBag.TTeam = _context.Teams.Where(l => l.TeamName.StartsWith("T")).ToList();
            ViewBag.AlphaTeam = _context.Teams.OrderBy(l => l.TeamName).ToList();
            ViewBag.RAlphaTeam = _context.Teams.OrderByDescending(l => l.TeamName).ToList();
            ViewBag.CooperPlayer = _context.Players.Where(l => l.LastName.Contains("Cooper")).ToList();
            ViewBag.JoshuaPlayer = _context.Players.Where(l => l.FirstName.Contains("Joshua")).ToList();
            ViewBag.CJPlayer = _context.Players.Where(l => l.LastName.Contains("Cooper") && !l.FirstName.Contains("Joshua")).ToList();
            ViewBag.AWPlayer = _context.Players.Where(l => l.FirstName.Contains("Alexander") || l.FirstName.Contains("Wyatt")).ToList();
            return View();
        }

        [HttpGet("level_2")]
        public IActionResult Level2()
        {
            ViewBag.ASC = _context.Teams.Where(l => l.CurrLeague.Name.Contains("Atlantic Soccer Conference")).Include(t => t.CurrLeague).ToList();
            //List<Player> currentplayerswithTeam = _context.Players.ToList();
            //ViewBag.CPWT = currentplayerswithTeam;
            ViewBag.BPP = _context.Players.Where(l => l.CurrentTeam.TeamName.Contains("Boston Penguins")).ToList();
            return View();
        }

        [HttpGet("level_3")]
        public IActionResult Level3()
        {
            return View();
        }

    }
}