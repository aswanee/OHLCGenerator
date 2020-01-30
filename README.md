# OHLCGenerator
It's a simple api with dotnet core to generate list of OHLC(Open,High,Low,Close,Time) object to simulate market stock 

use one get method to return Dictionary<string,List<StrTick>>:
  Key: Reuters Code (APPL,GOOG,)
  Size: Length of each list in the dictinary 

public Dictionary<string,List<StrTick>> Get(int size = 5, string code = "AGTC,ORWE")

discription : this method tack default values 5, "AGTC,ORWE" and return something like :
{
  "AGTC": [
    {
      "time": "20:23:19",
      "open": "15",
      "close": "15",
      "high": "15",
      "low": "15"
    },
    {
      "time": "20:23:20",
      "open": "15",
      "close": "14.535",
      "high": "15",
      "low": "14.535"
    },
    {
      "time": "20:23:21",
      "open": "15",
      "close": "14.66",
      "high": "15",
      "low": "14.535"
    },
    {
      "time": "20:23:22",
      "open": "15",
      "close": "14.48",
      "high": "15",
      "low": "14.48"
    },
    {
      "time": "20:23:23",
      "open": "15",
      "close": "14.25",
      "high": "15",
      "low": "14.25"
    },
    {
      "time": "20:23:24",
      "open": "15",
      "close": "14.345",
      "high": "15",
      "low": "14.25"
    }
  ],
  "ORWE": [
    {
      "time": "20:23:19",
      "open": "15",
      "close": "15",
      "high": "15",
      "low": "15"
    },
    {
      "time": "20:23:20",
      "open": "15",
      "close": "15.11",
      "high": "15.11",
      "low": "15"
    },
    {
      "time": "20:23:21",
      "open": "15",
      "close": "15.17",
      "high": "15.17",
      "low": "15"
    },
    {
      "time": "20:23:22",
      "open": "15",
      "close": "15.245",
      "high": "15.245",
      "low": "15"
    },
    {
      "time": "20:23:23",
      "open": "15",
      "close": "15.11",
      "high": "15.245",
      "low": "15"
    },
    {
      "time": "20:23:24",
      "open": "15",
      "close": "15.225",
      "high": "15.245",
      "low": "15"
    }
  ]
}
