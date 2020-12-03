using System.Collections.Generic;
using System.Text;

namespace Caldast.AlgoLife.Strings
{
    class ParseExpression
    {
        // 2 - 6 - 7 * 8 / 2 + 5
        public double ComputeResult(string expression)
        {
            List<Term> termList = Term.ParseTerm(expression);

            Term processing = null;
            double result = 0;
           
            for (int i = 0; i < expression.Length; i++)
            {
                Term current = termList[i];
                Term next = i + 1 >= expression.Length ? null : termList[i + 1];

                processing = Collapse(current, next);

                if (next == null || next.Operator == Operator.Add || next.Operator == Operator.Subtract)
                {
                    result += ApplyOp(processing.Value, next.Operator, next.Value);
                    processing = null;
                }               
                
            }

            return result;
        }

        private Term Collapse(Term current, Term next)
        {
            if (current == null)
                return next;
            if (next == null)
                return current;

           double result = ApplyOp(current.Value, next.Operator, next.Value);
           current.Value = result;

            return current;
        
        }

        private double ApplyOp(double left, Operator op, double right)
        {

            switch (op)
            {
                case Operator.Add:
                    return left + right;
                case Operator.Subtract:
                    return left - right;
                case Operator.Multiply:
                    return left * right;
                case Operator.Divide:
                    return left / right;
                default:
                    return right;
            }

            throw new System.Exception("Invalid operator");
        }

    }
    class Term
    {
        public double Value { get; set; }
        public Operator Operator { get; set; }

        public Term(double value, Operator @operator)
        {
            Value = value;
            Operator = @operator;
        }

        public static List<Term> ParseTerm(string expression)
        {
            var list = new List<Term>();
            int i = 0;
            while(i < expression.Length)
            {                
                Operator op = Operator.Blank;

                if (i > 0)
                {
                   op = ParseOperator(expression[i]);
                    if (op == Operator.Blank)
                    {
                        i++;
                        continue;
                    }
                    i++;
                }
                try
                {
                    double value = ParseNext(expression, i);
                    i += value.ToString().Length;
                    list.Add(new Term(value, op));
                }
                catch (System.Exception)
                {
                    throw;
                }


               

            }
            return list;
        }

        private static double ParseNext(string expression, int offset)
        {
            var sb = new StringBuilder();
            while (offset < expression.Length && char.IsDigit(expression[offset]))
            {
                sb.Append(expression[offset]);
                offset++;
            }
            return double.Parse(sb.ToString());
        }

        private static Operator ParseOperator(char op)
        {
            switch (op)
            {
                case '+':
                    return Operator.Add;                   
                case '-':
                    return Operator.Subtract;                   
                case '*':
                    return Operator.Multiply;                  
                case '\\':
                   return Operator.Divide; 
            }
            return Operator.Blank;
        }
    }

    public enum Operator
    {
        Add,
        Subtract,
        Divide, 
        Multiply,
        Blank
    }
}
