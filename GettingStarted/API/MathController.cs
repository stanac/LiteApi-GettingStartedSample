using LiteApi;
using LiteApi.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GettingStarted.API
{
    public class MathController: LiteController
    {
        public int Add(int a, int b) => a + b;

        [ActionRoute("/{a}/minus/{b}")]
        public int Minus(int a, int b) => a - b;

        public int Sum(int[] ints) => ints.Sum();
    }
}
