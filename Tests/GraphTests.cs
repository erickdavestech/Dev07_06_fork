using Implementations;

namespace AAD.Tests;

public class GraphTests
{
    [Fact]
    public void Paths_NodeNotFound()
    {
        var g = new Graph<string>();

        Assert.Empty(g.Paths("A", "B"));
    }

    [Fact]
    public void Paths_StartDoesNotExist()
    {
        var g = new Graph<string>();
        g.Add("A", "B");

        Assert.Empty(g.Paths("C", "B"));
    }

    [Fact]
    public void Paths_EndDoesNotExist()
    {
        var g = new Graph<string>();
        g.Add("A", "B");

        Assert.Empty(g.Paths("A", "C"));
    }

    [Fact]
    public void Paths_StartToStart()
    {
        var g = new Graph<string>();
        g.Add("A", "B");

        var path = Assert.Single(g.Paths("A", "A"));

        Assert.Equal(new[] { "A" }, path);
    }

    [Fact]
    public void Paths_OneSingleStepPath()
    {
        var g = new Graph<string>();
        g.Add("A", "B");

        var path = Assert.Single(g.Paths("A", "B"));

        Assert.Equal(new[] { "A", "B" }, path);
    }

    [Fact]
    public void Paths_One2StepPath()
    {
        var g = new Graph<string>();
        g.Add("A", "B");
        g.Add("B", "C");

        var path = Assert.Single(g.Paths("A", "C"));

        Assert.Equal(new[] { "A", "B", "C" }, path);
    }

    [Fact]
    public void Paths_TwoPaths()
    {
        var g = new Graph<string>();
        g.Add("A", "B");
        g.Add("B", "C");
        g.Add("A", "C");

        var paths = g.Paths("A", "C");

        var expected = new[]
        {
            new[] { "A", "B", "C" }, 
            new[] { "A", "C" }
        };
        
        Assert.Equal(expected, paths);
    }
    
    [Fact]
    public void Paths_3StepsPath()
    {
        var g = new Graph<string>();
        g.Add("A", "B");
        g.Add("B", "C");
        g.Add("C", "D");

        var paths = g.Paths("A", "D");

        var expected = new[]
        {
            new[] { "A", "B", "C", "D" }
        };
        
        Assert.Equal(expected, paths);
    }
    
    [Fact]
    public void Paths_Circular()
    {
        var g = new Graph<string>();
        g.Add("A", "B");
        g.Add("B", "C");
        g.Add("C", "A");
        g.Add("C", "D");

        var paths = g.Paths("A", "D");

        var expected = new[]
        {
            new[] { "A", "B", "C", "D" }
        };
        
        Assert.Equal(expected, paths);
    }
    
    [Fact]
    public void Paths_Complex()
    {
        var g = new Graph<string>();
        g.Add("SD", "Villa Altagracia");
        g.Add("Villa Altagracia", "Bonao");
        g.Add("Bonao", "La Vega");
        g.Add("SD", "Yamasa");
        g.Add("Yamasa", "Bonao");
        g.Add("Yamasa", "Cotui");
        g.Add("Cotui", "La Vega");

        var paths = g.Paths("SD", "La Vega");

        var expected = new[]
        {
            new[] { "SD", "Villa Altagracia", "Bonao", "La Vega" },
            new[] { "SD", "Yamasa", "Bonao", "La Vega" },
            new[] { "SD", "Yamasa", "Cotui", "La Vega" },
        };
        
        Assert.Equal(expected, paths);
    }
    
    
     [Fact]
        public void ShortestPath_Exists()
        {
            var g = new Graph<string>();
            g.Add("A", "B");
            g.Add("A", "C");
            g.Add("B", "D");
            g.Add("C", "D");
            g.Add("D", "E");
            g.Add("C", "E");

            var shortestPath = g.ShortestPath("A", "E");

            var expectedPath = new[] { "A", "C", "E" };

            Assert.Equal(expectedPath, shortestPath);
        }

        [Fact]
        public void ShortestPath_NoPath()
        {
            var g = new Graph<string>();
            g.Add("A", "B");
            g.Add("B", "C");
            g.Add("B", "D");

            var shortestPath = g.ShortestPath("A", "E");

            Assert.Empty(shortestPath);
        }

        [Fact]
        public void ShortestPath_StartEqualsEnd()
        {
            var g = new Graph<string>();
            g.Add("A", "B");
            g.Add("B", "C");

            var shortestPath = g.ShortestPath("A", "A");

            var expectedPath = new[] { "A" };

            Assert.Equal(expectedPath, shortestPath);
        }

        [Fact]
        public void ShortestPath_Circular()
        {
            var g = new Graph<string>();
            g.Add("A", "B");
            g.Add("B", "C");
            g.Add("C", "A");
            g.Add("C", "D");

            var shortestPath = g.ShortestPath("A", "D");

            var expectedPath = new[] { "A", "B", "C", "D" };

            Assert.Equal(expectedPath, shortestPath);
        }

        [Fact]
        public void ShortestPath_Complex()
        {
            var g = new Graph<string>();
            g.Add("SD", "Villa Altagracia");
            g.Add("Villa Altagracia", "Bonao");
            g.Add("Bonao", "La Vega");
            g.Add("SD", "Yamasa");
            g.Add("Yamasa", "Bonao");
            g.Add("Yamasa", "Cotui");
            g.Add("Cotui", "La Vega");

            var shortestPath = g.ShortestPath("SD", "La Vega");

            var expectedPath = new[] { "SD", "Villa Altagracia", "Bonao", "La Vega" };

            Assert.Equal(expectedPath, shortestPath);
        }
}