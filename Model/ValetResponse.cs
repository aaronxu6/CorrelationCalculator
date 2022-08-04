using Newtonsoft.Json;
using System.Collections.Generic;

namespace Interview.Model 
{
    // Only parsing the properties that we need for this question

    public class ValetResponse
    { 
        [JsonProperty("observations")]
        public List<Observation> Observations { get; init; }
    }

    public class Observation
    {
        [JsonProperty("d")]
        public string Date { get; init; }
        
        [JsonProperty("AVG.INTWO")]
        public RateValue CorraRate { get; init; }

        [JsonProperty("FXUSDCAD")]
        public RateValue UsdCadRate { get; init; }
    }

    public class RateValue
    {
        [JsonProperty("v")]
        public double Value { get; init; }
    }
}