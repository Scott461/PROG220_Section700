﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class SalaryCalculator
    {
        const int HoursInYear = 2080; // constant number of hours in a year 
        public decimal GetAnnualSalary(decimal hourlyWage) // calculates annual salary 
        {
            if (hourlyWage > 0)
                return hourlyWage * HoursInYear;
            else
                throw new InvalidOperationException("Hourly wage must be greater than zero.");// throw exception if negative wages 
        }


        public decimal GetHourlyWage(int annualSalary)//calculates hourly wage
        {
            if (annualSalary > 0)
                return annualSalary / HoursInYear;
            else
                throw new InvalidOperationException("Yearly salary must be greater than zero."); // throw exception if negative salary 
        }   
        public TaxData TaxWithheld(decimal weeklySalary, int numDependents) // calculate tax data 
        {
            if (weeklySalary > 0) {
                decimal dd = 0;

                decimal ptwh = 0.06m * weeklySalary; // provincial
                decimal ftwh = 0.25m * weeklySalary; // federal 
                if (numDependents >= 0) // dependent deduction
                    dd = 0.02m * numDependents * weeklySalary;
                else
                    throw new InvalidOperationException("Number dependents cannot be negative."); // can't have negative kids
                decimal twh = ptwh + ftwh - dd;// total withheld 
                decimal tth = weeklySalary - twh; //total take home

                return new TaxData((double)ptwh, (double)ftwh, (double)dd, (double)twh, (double)tth);
            } else
                throw new InvalidOperationException("Weekly salary must be greater than zero.");
        }
    }
}
