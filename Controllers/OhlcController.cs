using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OHLCGenerator.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OhlcController : ControllerBase
    {
        public class Tick {
            public DateTime Time { get; set; }
            public double Open { get; set; }
            public double Close { get; set; }
            public double High { get; set; }
            public double Low { get; set; }
        }

        public class StrTick
        {
            public string Time { get; set; }
            public string Open { get; set; }
            public string Close { get; set; }
            public string High { get; set; }
            public string Low { get; set; }
        }
        [HttpGet]


        public Dictionary<string,List<StrTick>> Get(int size = 5, string code = "AGTC,ORWE")
        {
            Dictionary<string, List<StrTick>> watchList = new Dictionary<string, List<StrTick>>();

            string[] tickers = code.Split(",");
            foreach (var ticker in tickers) {
                watchList.Add(ticker, OneTicker(size));
            }
            return watchList; 
        }

        List<StrTick> OneTicker(int size = 5)
        {
            int interval = 1;
            List<Tick> rsults = new List<Tick>();
            Random random = new Random();
            Tick prev = new Tick
            {
                Time = DateTime.Now,
                Open = 15,
                Close = 15,
                High = 15,
                Low = 15
            };
            rsults.Add(prev);

            for (int i = 0; i < size; i++)
            {
                double Dir = random.Next(0, 2) == 1 ? 1 : -1;
                double myRund = (double)random.Next(0, 100) / 200;
                double delta = Dir * myRund;
                if (rsults.Count > 0)
                {
                    rsults.Add(createTick(rsults.Last(), delta, interval));
                }
            }
            return TickToString(rsults);
        }

        Tick createTick(Tick prev, double delta, double interval) {
            double val = prev.Close + delta;
            Tick current = new Tick
            {
                Time = prev.Time.AddSeconds(interval),
                Close = val,
                High = prev.High < val ? val : prev.High,
                Low = prev.Low > val ? val : prev.Low,
                Open = prev.Open
            };
            return current;
        }

        List<StrTick> TickToString(List<Tick> tickList){
            List<StrTick> strTickList = new List<StrTick>();
            foreach(var t in tickList)
            {
                StrTick at = new StrTick() {
                    Time    = t.Time.ToString("HH:mm:ss"),
                    Close   = t.Close.ToString("00.###"),
                    High    = t.High.ToString("00.###"),
                    Low     = t.Low.ToString("00.###"),
                    Open    = t.Open.ToString("00.###"),

                };
                strTickList.Add(at);
            }
        return strTickList;
    }

    }
}
