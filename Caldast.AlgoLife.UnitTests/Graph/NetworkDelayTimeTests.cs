using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace Caldast.AlgoLife.Graph.Tests
{
    [TestClass()]
    public class NetworkDelayTimeTests
    {
        [TestMethod()]
        public void GetMaxTimeShouldGiveMaxTime()
        {
            int[][] times = new int[7][];
            var networkDelayTime = new NetworkDelayTime();

            times[0] = new int[] { 1, 3, 4 };
            times[1] = new int[] { 2, 1, 3 };
            times[2] = new int[] { 2, 3, 2 };
            times[3] = new int[] { 3, 4, 1 };
            times[4] = new int[] { 3, 5, 2 };
            times[5] = new int[] { 5, 6, 2 };
            times[6] = new int[] { 6, 4, 3 };


            networkDelayTime.GetMaxTime(times, 6, 2).Should().Be(6);

            times = new int[3][];
            times[0] = new int[] { 2, 1, 1 };
            times[1] = new int[] { 2, 3, 1 };
            times[2] = new int[] { 3, 4, 1 };
            networkDelayTime.GetMaxTime(times, 4, 2).Should().Be(2);

            times = new int[7][];
            times[0] = new int[] { 1, 2, 4 };
            times[1] = new int[] { 1, 3, 5 };
            times[2] = new int[] { 1, 4, 2 };
            times[3] = new int[] { 2, 3, 1 };
            times[4] = new int[] { 3, 5, 3 };
            times[5] = new int[] { 3, 6, 2 };
            times[6] = new int[] { 4, 5, 1 };
            networkDelayTime.GetMaxTime(times, 6, 1).Should().Be(7);

        }
    }
}