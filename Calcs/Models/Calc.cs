using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalcTextBoxes.Models
{
    public class Calc
    {
        public int num1;
        public int num2;
        public string opr;
        public int res;

        public void CalcRes()
        {
            switch (opr)
            {
                case "+":
                    res = num1 + num2;
                    break;
                case "-":
                    res = num1 - num2;
                    break;
                case "*":
                    res = num1 * num2;
                    break;
                case "/":
                    res = num1 / num2;
                    break;
            }
        }
    }
}