using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMRF.Domain.Login;

namespace BMRF.Domain.DonateModels
{
    public class Donation
    {
        public decimal Amount { get; set; }
        public DonationType Purpose { get; set; }
        public ForumUser User { get; set; }
    }

    public enum DonationType
    {
        DayZ
    }
}
