using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JugMeasure.Core.Test
{
    public class JugActionTest
    {
        [Fact]
        public void Test1()
        {
            var j1 = new Jug(5, "j1");
            var j2 = new Jug(8, "j2");
            j1.Fill(new Capacity(5));
            var a = new JugAction(j1, j2);
            var r = a.Perform();
            Assert.NotNull(r.From);
            Assert.NotNull(r.To);
            Assert.Equal(r.From.Value.FilledCapacity, new Capacity(0));
            Assert.Equal(r.From.Value.FreeCapacity, new Capacity(5));

            Assert.Equal(r.To.Value.FilledCapacity, new Capacity(5));
            Assert.Equal(r.To.Value.FreeCapacity, new Capacity(3));
        }

        [Fact]
        public void Test2()
        {
            var j1 = new Jug(7, "j1");
            var j2 = new Jug(5, "j2");
            j1.Fill(new Capacity(7));
            var a = new JugAction(j1, j2);
            var r = a.Perform();
            Assert.NotNull(r.From);
            Assert.NotNull(r.To);
            Assert.Equal(r.From.Value.FilledCapacity, new Capacity(2));
            Assert.Equal(r.From.Value.FreeCapacity, new Capacity(5));

            Assert.Equal(r.To.Value.FilledCapacity, new Capacity(5));
            Assert.Equal(r.To.Value.FreeCapacity, new Capacity(0));
        }

        [Fact]
        public void Test3()
        {
            var j2 = new Jug(5, "j2");
            j2.Fill(new Capacity(5));
            var a = new JugAction(null, j2);
            var r = a.Perform();
            Assert.Null(r.From);
            Assert.NotNull(r.To);

            Assert.Equal(r.To.Value.FilledCapacity, new Capacity(5));
            Assert.Equal(r.To.Value.FreeCapacity, new Capacity(0));
        }

        [Fact]
        public void Test4()
        {
            var j1 = new Jug(7, "j1");
            j1.Fill(new Capacity(7));
            var a = new JugAction(j1, null);
            var r = a.Perform();
            Assert.NotNull(r.From);
            Assert.Null(r.To);
            Assert.Equal(r.From.Value.FilledCapacity, new Capacity(0));
            Assert.Equal(r.From.Value.FreeCapacity, new Capacity(7));
            
        }
    }
}
