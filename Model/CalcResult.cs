namespace Interview.Model
{
    public class CalcResult
    {
        public GeneralStats UsdCadStatus { get; set; }
        public GeneralStats CorraStatus { get; set; }
        public double? Coefficient { get; set; }
    }

    public class GeneralStats
    {
        public double High { get; set; }
        public double Low { get; set; }
        public double Mean { get; set; }
    }
}