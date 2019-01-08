//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TableData_Datecal.Models
{
    using System;
    using System.Collections.Generic;
     public partial class TableData
    {
        public int Id { get; set; }
        public string First_Date { get; set; }
        public string Second_Date { get; set; }
        public string Result { get; set; }
        public int m, d, y;
        int[] monthDay = new int[12] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

       public int getDifference(TableData dt1, TableData dt2)
        {
            int n1 = dt1.y * 365 + dt1.d;
            for (int i = 0; i < dt1.m - 1; i++)

                n1 = n1 + monthDay[i];
            n1 = n1 + CountLeapYear(dt1);

            int n2 = dt2.y * 365 + dt2.d;
            for (int i = 0; i < dt2.m - 1; i++)
                n2 = n2 + monthDay[i];
            n2 = n2 + CountLeapYear(dt2);
            return n2 - n1;
        }
        int CountLeapYear(TableData d)
        {
            int year = d.y;
            if (d.m <= 2)
                year--;
            return year / 4 - year / 100 + year / 400;
        }


    }
}
