using Interview.Model;

namespace Interview
{
    public interface ICorrelationCalculator
    {
        CalcResult GetCalcResult(ValetResponse rates);
    }
}