﻿using Sell_Train_Ticket.Models;
using Sell_Train_Ticket.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sell_Train_Ticket.Controllers
{
    [Authorize(Roles = "Manager")]
    public class StatisticController : Controller
    {
        private ApplicationDbContext _context;

        public StatisticController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Trip()
        {
            var tripStatistics = _context.TripStatistics.Include("Trip").Include("Trip.Route").ToList();
            long revenueSunday = 0;
            long revenueMonday = 0;
            long revenueTuesday = 0;
            long revenueWednesday = 0;
            long revenueThursday = 0;
            long revenueFriday = 0;
            long revenueSaturday = 0;            

            foreach(var item in tripStatistics)
            {
                switch (item.Trip.DepartureDate.DayOfWeek)
                {
                    case DayOfWeek.Sunday:
                        revenueSunday += item.Revenue;
                        continue;
                    case DayOfWeek.Monday:
                        revenueMonday += item.Revenue;
                        continue;
                    case DayOfWeek.Tuesday:
                        revenueTuesday += item.Revenue;
                        continue;
                    case DayOfWeek.Wednesday:
                        revenueWednesday += item.Revenue;
                        continue;
                    case DayOfWeek.Thursday:
                        revenueThursday += item.Revenue;
                        continue;
                    case DayOfWeek.Friday:
                        revenueFriday += item.Revenue;
                        continue;
                    case DayOfWeek.Saturday:
                        revenueSaturday += item.Revenue;
                        continue;
                    default:
                        continue;
                }
            }

            var viewModel = new TripStatisticViewModel
            {
                TripStatistics = tripStatistics,
                RevenueSunday = revenueSunday,
                RevenueMonday = revenueMonday,
                RevenueTuesday = revenueTuesday,
                RevenueWednesday = revenueWednesday,
                RevenueThursday = revenueThursday,
                RevenueFriday = revenueFriday,
                RevenueSaturday = revenueSaturday
            };

            return View(viewModel);
        }
    }
}