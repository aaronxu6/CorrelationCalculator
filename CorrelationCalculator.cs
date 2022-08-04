using System;
using System.Linq;
using System.Collections.Generic;
using Interview.Model;

namespace Interview
{
    public class CorrelationCalculator : ICorrelationCalculator
    {
        public CalcResult GetCalcResult(ValetResponse rates)
        {
            CalcResult result = new CalcResult();
            try
            {
                var usdCadRates = rates.Observations.Select(o => o.UsdCadRate.Value).ToList<double>();
                var corraRates = rates.Observations.Select(o => o.CorraRate.Value).ToList<double>();
                if (usdCadRates.Any())
                {
                    result.UsdCadStatus = new GeneralStats
                    {
                        High = usdCadRates.Max(),
                        Low = usdCadRates.Min(),
                        Mean = usdCadRates.Average()
                    };
                    result.CorraStatus = new GeneralStats
                    {
                        High = corraRates.Max(),
                        Low = corraRates.Min(),
                        Mean = corraRates.Average()
                    };
                    if (usdCadRates.Count > 1)
                    {
                        var sdUsdCad = GetStandardDeviation(usdCadRates, result.UsdCadStatus.Mean);
                        var sdCorra = GetStandardDeviation(corraRates, result.CorraStatus.Mean);
                        var covariance = GetCovariance(usdCadRates, result.UsdCadStatus.Mean, corraRates, result.CorraStatus.Mean);
                        if (sdUsdCad != 0.0 && sdCorra != 0.0)
                        {
                            result.Coefficient = covariance / (sdUsdCad * sdCorra);
                        }
                    }
                }
                return result;
            }
            catch (System.Exception)
            {   
                throw;
            }
        }

        private double GetStandardDeviation(List<double> rates, double average)
        {
            double sum = rates.Sum(r => Math.Pow(r - average, 2));
            return Math.Sqrt(sum / (rates.Count() - 1));
        }

        private double GetCovariance(List<double> ratesA, double averageA, List<double> ratesB, double averageB)
        {
            double sum = 0.0;
            for (int i = 0; i < ratesA.Count(); i ++)
            {
                sum += ((ratesA[i] - averageA) * (ratesB[i] - averageB));
            }
            return sum / (ratesA.Count() - 1);
        }
    }
}