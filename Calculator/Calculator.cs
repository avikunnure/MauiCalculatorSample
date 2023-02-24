using System;

namespace Calculator;

public static class Calculator
{

    public static double Calculate(String input)
    {
        String expr = "(" + input + ")";
        Stack<String> ops = new Stack<String>();
        Stack<Double> vals = new Stack<Double>();
        for (int i = 0; i < expr.Length; i++)
        {

            String s = expr.Substring(i, 1);
            if (s.Equals("(")) { }
            else if (s.Equals("+")) { ops.Push(s); }
            else if (s.Equals("-")) { ops.Push(s); }
            else if (s.Equals("x")) { ops.Push(s); }
            else if (s.Equals("/")) { ops.Push(s); }
            else if (s.Equals("^")) { ops.Push(s); }
            else if (s.Equals("%")) { ops.Push(s); }
            else if (s.Equals(")"))
            {
                int count = ops.Count;
                while (count > 0)
                {
                    String op = ops.Pop();
                    double v = vals.Pop();
                    if (op.Equals("+")) v = vals.Pop() + v;
                    else if (op.Equals("-")) v = vals.Pop() - v;
                    else if (op.Equals("x")) v = vals.Pop() * v;
                    else if (op.Equals("/")) v = vals.Pop() / v;
                    else if (op.Equals("^")) v = Math.Sqrt(v);
                    else if (op.Equals("%")) v = vals.Pop() % v;
                    vals.Push(v);

                    count--;
                }
            }
            else if (Char.IsNumber(s, 0))
            {
                vals.Push(Double.Parse(expr.GetNextNumber(ref i)));
            }
        }
        if (vals.Count == 0) return 0;
        return vals.Pop();
    }
}

public static class DoubleExtensions
{
    public static string ToTrimmedString(this double target, string decimalFormat)
    {
        string strValue = target.ToString(decimalFormat); //Get the stock string

        //If there is a decimal point present
        if (strValue.Contains("."))
        {
            //Remove all trailing zeros
            strValue = strValue.TrimEnd('0');

            //If all we are left with is a decimal point
            if (strValue.EndsWith(".")) //then remove it
                strValue = strValue.TrimEnd('.');
        }

        return strValue;
    }

    public static string GetNextNumber(this string input,ref int startPosition)
    {
        string ret = "";
        int count = startPosition;
        while (char.IsDigit(input[count]))
        {
            ret += input[count];
            count++;
        }
        if (ret.Length > 0)
        {
            startPosition = count-1;
        }
        return ret;
    }
}
