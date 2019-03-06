using System;
using System.Collections.Generic;

namespace Caldast.AlgoLife.Stack
{
    public class StackProblems
    {
        /// <summary>
        /// Evaluates Reverse Polish Notation string. 
        /// Time Complexity: O(n),
        /// Space Complexity: O(n)
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public int EvaluateRpn(string expression)
        {
            if (string.IsNullOrWhiteSpace(expression))
                throw new ArgumentException("invalid expression");
            var operatorFuncMapping = new Dictionary<string, Func<int, int, int>>()
            {
                { "+", (x,y)=> x+y },
                { "-", (x,y)=> x-y },
                { "*", (x,y)=> x*y },
                { "/", (x,y)=> x/y }
            };

            var stack = new Stack<int>();

            // call func when operator is encoured and save the intermediate results
            foreach (string item in expression.Split(','))
            {
                if (operatorFuncMapping.ContainsKey(item))
                {
                    int first = stack.Pop();
                    int second = stack.Pop();

                    stack.Push(operatorFuncMapping[item].Invoke(second, first));
                }
                else
                {
                    stack.Push(int.Parse(item));
                }
            }
            return stack.Pop();

        }
    }
}
