using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DVConsistPlanner.Models.DerailValley;

namespace DVConsistPlanner.Models
{
    public class TestModel
    {
        public Consist GetTestConsist()
        {
            /*
            Consist test = new Consist();
            Job logiHaul = new Job
            {
                Departing = DerailValley.GetStations().FirstOrDefault(s => s.Abbreviation == "FF"),
                Arriving = DerailValley.GetStations().FirstOrDefault(s => s.Abbreviation == "HB"),
                JobType = JobType.Logistic,
                JobNumber = 48,
                Payout = 11331,
                TrainMass = 93.00M,
                TrainLength = 96.49M
            };
            Job freHaul = new Job
            {
                Departing = DerailValley.GetStations().FirstOrDefault(s => s.Abbreviation == "FF"),
                Arriving = DerailValley.GetStations().FirstOrDefault(s => s.Abbreviation == "HB"),
                JobType = JobType.Freight,
                JobNumber = 44,
                Payout = 9585,
                TrainMass = 180.00M,
                TrainLength = 72.18M
            };

            test.Jobs.Add(logiHaul);
            test.Jobs.Add(freHaul);
            test.Locomotives.Add(new Locomotive
            {
                Length = 18.77M,
                Weight = 115000
            });
            */
            Consist test = new Consist();
            Station currentStation = DerailValley.GetStations().FirstOrDefault(s => s.Abbreviation == "FM");
            Station foodFactoryStation = DerailValley.GetStations().FirstOrDefault(s => s.Abbreviation == "FF");
            Station goodsFactoryStation = DerailValley.GetStations().FirstOrDefault(s => s.Abbreviation == "GF");

            Job fh09 = new Job()
            {
                Departing = currentStation,
                Arriving = foodFactoryStation,
                JobType = JobType.Freight,
                JobNumber = 09,
                Payout = 5536,
                TrainMass = 97.00M,
                TrainLength = 42.36M
            };
            Job fh77 = new Job()
            {
                Departing = currentStation,
                Arriving = foodFactoryStation,
                JobType = JobType.Freight,
                JobNumber = 77,
                Payout = 6916,
                TrainMass = 132.00M,
                TrainLength = 56.48M
            };
            Job fh20 = new Job()
            {
                Departing = currentStation,
                Arriving = foodFactoryStation,
                JobType = JobType.Freight,
                JobNumber = 20,
                Payout = 7630,
                TrainMass = 176.00M,
                TrainLength = 60.58M
            };
            Job lh95 = new Job()
            {
                Departing = currentStation,
                Arriving = goodsFactoryStation,
                JobType = JobType.Logistic,
                JobNumber = 95,
                Payout = 5333,
                TrainMass = 44.00M,
                TrainLength = 72.18M
            };
            Job lh15 = new Job()
            {
                Departing = currentStation,
                Arriving = goodsFactoryStation,
                JobType = JobType.Logistic,
                JobNumber = 15,
                Payout = 5333,
                TrainMass = 44.00M,
                TrainLength = 72.18M
            };


            test.Jobs.Add(fh09);
            test.Jobs.Add(fh77);
            test.Jobs.Add(fh20);
            test.Jobs.Add(lh95);
            test.Jobs.Add(lh15);

            return test;
        }
    }
}