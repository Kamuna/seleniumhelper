/*
Copyright 2011 Torgeir Helgevold 

Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the License at 
http://www.apache.org/licenses/LICENSE-2.0 
Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" 
BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.  

*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Selenium;
using XPathItUp;
using System.Diagnostics;
using System.Threading;


namespace SeleniumHelper
{
    public static class SeleniumExtensions
    {
        public static ITagElement IsElement(this ISelenium sel,string tag)
        {
            Finder finder = new Finder();
            return finder.Tag(tag);
        }

        public static bool IsPresentNow(this ISelenium sel,IBase iBase)
        {
            return sel.IsElementPresent(iBase.ToXPathExpression());
        }

        public static bool IsNotPresentNow(this ISelenium sel, IBase iBase)
        {
            return !sel.IsElementPresent(iBase.ToXPathExpression());
        }

        public static bool IsPresentInLessThan(this ISelenium sel, int seconds, IBase iBase)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            while (stopwatch.Elapsed.Seconds < seconds)
            {
                bool present = sel.IsElementPresent(iBase.ToXPathExpression());
                if (present == true)
                {
                    return true;
                }
                //sleep for 200 ms between checks
                Thread.Sleep(200);
            }

            return false;
        }
    }
}
