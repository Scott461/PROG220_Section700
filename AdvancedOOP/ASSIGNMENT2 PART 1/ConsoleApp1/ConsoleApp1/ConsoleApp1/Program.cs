﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            ShippingFeesDelegate theDel;
            ShippingDestination theDest;

            string theZone;
            do
            {
                // get the destination zone
                Console.WriteLine("What is the destination zone?");
                theZone = Console.ReadLine();

                // if the user wrote "exit" then terminate the program,
                // otherwise continue 
                if (!theZone.Equals("exit"))
                {
                    // given the zone, retrieve the associated shipping info
                    theDest = ShippingDestination.getDestinationInfo(theZone);

                    // if there's no associated info, then the user entered
                    // an invalid zone, otherwise continue
                    if (theDest != null)
                    {
                        // ask for the price and convert the string to a decimal number
                        decimal itemPrice = 0;
                        // loops until programs receives a valid item price 
                        do {
                            Console.WriteLine("What is the item price?");
                            string thePriceStr = Console.ReadLine();
                            itemPrice = decimal.Parse(thePriceStr);
                        } while (itemPrice < 0);

                        // Each ShippingDestination object has a function called calcFees,
                        // use that as the delegate for calculating the fee
                        theDel = theDest.calcFees;

                        // For high-risk zones, we tack on the delegate that adds more
                        if (theDest.m_isHighRisk)
                        {
                            theDel += delegate (decimal thePrice, ref decimal itemFee) {
                                itemFee += 25.0m;
                            };
                        }
                        // for low risk zones, we tack on a delegate that checks for potential discounts 
                        // and subtracts $10 if appropriate 
                        else 
                        {
                            theDel += delegate (decimal thePrice, ref decimal itemFee) {
                                if (itemFee > 100.0m)
                                    itemFee -= 10.0m;
                            };
                        }


                        // now all that is left to do is call the delegate and output
                        // the shipping fee to the Console
                        decimal theFee = 0.0m;
                        theDel(itemPrice, ref theFee);
                        Console.WriteLine("The shipping fees are: {0}", theFee);
                    }
                    else
                    {
                        Console.WriteLine("Hmm, you seem to have entered an uknown destination. Try again or 'exit'");
                    }
                }
            } while (theZone != "exit");
        }
    }
}
