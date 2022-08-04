using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Interview.Model;

namespace Interview
{
    public interface IValetService
    {
        Task<ValetResponse> GetObervationsByDate(string startDate, string endDate);
    }
}