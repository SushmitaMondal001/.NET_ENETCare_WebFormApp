using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ENETCareWebFormApp
{
    public class TestDataCalculation
    {
        public double AddTotalCost(double prevCost, double newCost)
        {
            double totalCost = prevCost + newCost;
            return totalCost;
        }


    }
}