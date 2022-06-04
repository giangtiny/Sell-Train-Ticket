﻿using Sell_Train_Ticket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sell_Train_Ticket.ViewModels
{
    public class TripViewModel
    {
        public Trip Trip { get; set; }
        public IEnumerable<Route> Routes { get; set; }
        public IEnumerable<Train> Trains { get; set; }
    }
}