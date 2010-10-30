using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Selenium;
using XPathItUp;
using System.Diagnostics;
using System.Threading;

/*
Copyright (C) 2010  Torgeir Helgevold

This program is free software; you can redistribute it and/or
modify it under the terms of the GNU General Public License
as published by the Free Software Foundation; either version 2
of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program; if not, write to the Free Software
Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
*/
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
