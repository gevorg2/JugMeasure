using System;
using System.Linq;
using Xunit;

namespace JugMeasure.Core.Test
{
    public class JugMeasureTestTest
    {
        [Fact]
        public void Test1()
        {
            var jugMeasure = new JugMeasureService();
            var res = jugMeasure.ReverseMeasure(new Jug(5, "Jug5"), new Jug(3, "Jug3"), new Capacity(4));
            Assert.Equal(res.Actions.Count(),8);
            Assert.Equal(res.Actions[0].From,null);
            Assert.Equal(res.Actions[0].To.Value.Name, "Jug3");

            Assert.Equal(res.Actions[1].From.Value.Name, "Jug3");
            Assert.Equal(res.Actions[1].To.Value.Name, "Jug5");

            Assert.Equal(res.Actions[2].From, null);
            Assert.Equal(res.Actions[2].To.Value.Name, "Jug3");

            Assert.Equal(res.Actions[3].From.Value.Name, "Jug3");
            Assert.Equal(res.Actions[3].To.Value.Name, "Jug5");

            Assert.Equal(res.Actions[4].From.Value.Name, "Jug5");
            Assert.Equal(res.Actions[4].To, null);

            Assert.Equal(res.Actions[5].From.Value.Name, "Jug3");
            Assert.Equal(res.Actions[5].To.Value.Name, "Jug5");

            Assert.Equal(res.Actions[6].From, null);
            Assert.Equal(res.Actions[6].To.Value.Name, "Jug3");

            Assert.Equal(res.Actions[7].From.Value.Name, "Jug3");
            Assert.Equal(res.Actions[7].To.Value.Name, "Jug5");

        }

        [Fact]
        public void Test2()
        {
            var jugMeasure = new JugMeasureService();
            var res = jugMeasure.Measure(new Jug(5, "Jug5"), new Jug(3, "Jug3"), new Capacity(4));
            Assert.Equal(res.Actions.Count(), 6);
            Assert.Equal(res.Actions[0].From, null);
            Assert.Equal(res.Actions[0].To.Value.Name, "Jug5");

            Assert.Equal(res.Actions[1].From.Value.Name, "Jug5");
            Assert.Equal(res.Actions[1].To.Value.Name, "Jug3");

            Assert.Equal(res.Actions[2].From.Value.Name, "Jug3");
            Assert.Equal(res.Actions[2].To, null);

            Assert.Equal(res.Actions[3].From.Value.Name, "Jug5");
            Assert.Equal(res.Actions[3].To.Value.Name, "Jug3");

            Assert.Equal(res.Actions[4].From, null);
            Assert.Equal(res.Actions[4].To.Value.Name, "Jug5");

            Assert.Equal(res.Actions[5].From.Value.Name, "Jug5");
            Assert.Equal(res.Actions[5].To.Value.Name, "Jug3");
        }

        [Fact]
        public void Test3()
        {
            var jugMeasure = new JugMeasureService();
            var res = jugMeasure.Measure(new Jug(5, "Jug5"), new Jug(5, "Jug3"), new Capacity(5));
            Assert.Equal(res.Actions.Count(), 1);
            Assert.Equal(res.Actions[0].From, null);
            Assert.Equal(res.Actions[0].To.Value.Name, "Jug5");
        }

        [Fact]
        public void Test4()
        {
            var jugMeasure = new JugMeasureService();
            var res = jugMeasure.Measure(new Jug(5, "Jug5"), new Jug(5, "Jug3"), new Capacity(4));
            Assert.Null(res);
        }

        [Fact]
        public void Test5()
        {
            var jugMeasure = new JugMeasureService();
            var res = jugMeasure.Measure(new Jug(6, "Jug5"), new Jug(3, "Jug3"), new Capacity(2));
            Assert.Null(res);
        }

        [Fact]
        public void Test6()
        {
            var jugMeasure = new JugMeasureService();
            var res = jugMeasure.Measure(new Jug(6, "Jug5"), new Jug(2, "Jug3"), new Capacity(3));
            Assert.Null(res);
        }

        [Fact]
        public void Test7()
        {
            var jugMeasure = new JugMeasureService();
            var res = jugMeasure.Measure(new Jug(6, "Jug5"), new Jug(2, "Jug3"), new Capacity(2));
            Assert.NotNull(res);
        }
    }
}
