﻿using System;
using System.Linq.Expressions;

namespace MathExtension
{
    public static class GreatestCommonDivisor
    {
        /// <summary>
        /// Euclids Algorithm for params
        /// </summary>
        /// <param name="numbers">int[]</param>
        /// <returns>Greatest common divisor</returns>
        public static int EuclidsAlgorithm(params int[] numbers) => GcdForAlgorithm(new Func<int, int, int>(EuclidsAlgorithm), numbers);

        /// <summary>
        /// Euclids algorithm fr tree params
        /// </summary>
        /// <param name="a">int</param>
        /// <param name="b">int</param>
        /// <param name="c">int</param>
        /// <returns>Greatest common divisor</returns>
        public static int EuclidsAlgorithm(int a, int b, int c) => GcdForAlgorithm(new Func<int, int, int>(EuclidsAlgorithm), a, b, c);

        /// <summary>   Euclids algorithm for int array. </summary>
        /// <param name="a">    An int to process. </param>
        /// <param name="b">    An int to process. </param>
        /// <returns>   Greatest Common Divisor of numbers like a integer value . </returns>
        public static int EuclidsAlgorithm(int a, int b)
        {
            CheckingForParams(ref a, ref b);
            if (a == 0)
            {
                return b;
            }

            if (b == 0)
            {
                return a;
            }

            while (a != b)
            {
                if (a > b)
                {
                    a -= b;
                }
                else
                {
                    b -= a;
                }
            }

            return a;
        }

        /// <summary>
        /// Binary Euclidean Algoritm for params
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns>Greatest common divisor</returns>
        public static int BinaryEuclideanAlgoritm(params int[] numbers) => GcdForAlgorithm(new Func<int, int, int>(BinaryEuclideanAlgoritm), numbers);

        /// <summary>
        /// Binary euclideam algorithm
        /// </summary>
        /// <param name="a">int</param>
        /// <param name="b">int</param>
        /// <param name="c">int</param>
        /// <returns>Greatest Common Divisor of numbers like a integer value</returns>
        public static int BinaryEuclideanAlgoritm(int a, int b, int c) => GcdForAlgorithm(new Func<int, int, int>(BinaryEuclideanAlgoritm), a, b, c);
        
        /// <summary>   Binary Euclidean algoritm for search of Greatest common divisor . </summary>
        /// <param name="a">    An int to process. </param>
        /// <param name="b">    An int to process. </param>
        /// <returns>   Greatest Common Divisor of numbers like a integer value . </returns>
        public static int BinaryEuclideanAlgoritm(int a, int b)
        {
            CheckingForParams(ref a, ref b);

            if (a == 0)
            {
                return b;
            }

            if (b == 0)
            {
                return a;
            }

            int k = 1;

            while (a != 0 && b != 0)
            {
                while (a % 2 == 0 && b % 2 == 0)
                {
                    a /= 2;
                    b /= 2;
                    k *= 2;
                }

                EvenNumberDevBy2(a, b);

                if (a >= b)
                {
                    a -= b;
                }
                else
                {
                    b -= a;
                }
            }

            return b * k;
        }

        /// <summary>
        /// Common approach for finging Greatest common divisor
        /// </summary>
        /// <param name="selectedMethod">select method</param>
        /// <param name="numbers"></param>
        /// <returns>Greatest common divisor</returns>
        private static int GcdForAlgorithm(Func<int, int, int> selectedMethod, params int[] numbers)
        {
            ValidationData(selectedMethod, numbers);
            int greatestCommonDivisor = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                greatestCommonDivisor = selectedMethod(greatestCommonDivisor, numbers[i]);
            }

            return greatestCommonDivisor;
        }

        /// <summary>
        /// Binary Euclidean Algoritm for tree parameters
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns>GCD</returns>
        private static int GcdForAlgorithm(Func<int, int, int> selectedMethod, int a, int b, int c)
        {
            return selectedMethod(selectedMethod(a, b), c);
        }

        /// <summary>   Checking for parameters. </summary>
        /// <param name="a">    [in,out] An int to process. </param>
        /// <param name="b">    [in,out] An int to process. </param>
        private static void CheckingForParams(ref int a, ref int b)
        {
            if (a < 0)
            {
                a = -a;
            }

            if (b < 0)
            {
                b = -b;
            }
        }
        
        /// <summary>   Even number devision by 2. </summary>
        /// <param name="greatestCommonDivisor">    The greatest common number. </param>
        /// <param name="number">                   Number of. </param>
        private static void EvenNumberDevBy2(int greatestCommonDivisor, int number)
        {
            while (greatestCommonDivisor % 2 == 0)
            {
                greatestCommonDivisor /= 2;
            }

            while (number % 2 == 0)
            {
                number /= 2;
            }
        }

        /// <summary>
        /// validation data for algth
        /// </summary>
        /// <param name="selectedMethod">SelectedMethodDelegate</param>
        /// <param name="numbers">param int[]</param>
        private static void ValidationData(Func<int, int, int> selectedMethod, params int[] numbers)
        {
            if (selectedMethod == null)
            {
                throw new ArgumentNullException($"{ (nameof(selectedMethod))} cant be a null");
            }

            if (numbers.Length == 1 && numbers[0] == 0)
            {
                throw new ArgumentNullException($"{ (nameof(numbers))} cant be a zero");
            }
        }
    }
}
