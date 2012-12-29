using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace PrimeFactorsKata
{
    class PrimeFactors
    {
        # region Old version
        /* public List<int> Generate(int number)
         {
             var listPrime = new List<int>();

             if (number == 1)
                 return listPrime;

             var value = number;

             var counter = 2;

             while (counter <= number)
             {
                 while (value % counter == 0)
                 {
                     listPrime.Add(counter);
                     value /= counter;
                 }
                 counter++;
             }

             return listPrime;
         }*/
        #endregion

        public List<int> Generate(int number)
        {
            List<int> listPrimes = new List<int>();

            for (int candidate = 2; number > 1; candidate++)
                for (; number % candidate == 0; number /= candidate)
                    listPrimes.Add(candidate);
            return listPrimes;
        }

    }

    public class PrimeFactorsTests
    {
        private PrimeFactors factors = new PrimeFactors();

        [Fact]
        public void when_argument_1_returns_empty_list()
        {
            var list = factors.Generate(1);

            list.Should().BeEmpty();
        }

        [Fact]
        public void when_argument_2_result_should_be_2()
        {
            var list = factors.Generate(2);

            list.Should().Contain(2);
        }

        [Fact]
        public void should_return_3_if_input_3()
        {
            var list = factors.Generate(3);
            list.Should().Contain(3);
        }

        [Fact]
        public void when_argument_4_result_should_be_2_and_2()
        {
            var list = factors.Generate(4);

            list.ShouldBeEquivalentTo(new List<int> { 2, 2 });
        }

        [Fact]
        public void when_argument_is_6_result_should_be_2_and_3()
        {
            var list = factors.Generate(6);

            list.ShouldBeEquivalentTo(new List<int> { 2, 3 });
        }

        [Fact]
        public void should_return_2_2_2_when_input_8()
        {
            var list = factors.Generate(8);
            list.ShouldBeEquivalentTo(new List<int> { 2, 2, 2 });
        }

        [Fact]
        public void should_return_2_3_when_input_9()
        {
            var list = factors.Generate(9);
            list.ShouldBeEquivalentTo(new List<int> { 3, 3 });
        }
    }
}
