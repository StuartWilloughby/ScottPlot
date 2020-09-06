﻿using ScottPlot.Demo.Customize;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ScottPlot.Demo.PlotTypes
{
    public static class Polygon
    {
        public class Quickstart : PlotDemo, IPlotDemo
        {
            public string name { get; } = "Polygon Quickstart";
            public string description { get; } = "Pairs of X/Y points can be used to display polygons.";

            public void Render(Plot plt)
            {
                plt.PlotPolygon(
                    xs: new double[] { 2, 8, 6, 4 },
                    ys: new double[] { 3, 4, 0.5, 1 },
                    label: "polygon A", lineWidth: 2, fillAlpha: .8,
                    lineColor: System.Drawing.Color.Black);

                plt.PlotPolygon(
                    xs: new double[] { 3, 2.5, 5 },
                    ys: new double[] { 4.5, 1.5, 2.5 },
                    label: "polygon B", lineWidth: 2, fillAlpha: .8,
                    lineColor: System.Drawing.Color.Black);

                plt.Title($"Polygon Demonstration");
                plt.Legend();
            }
        }

        public class FilledLinePlots : PlotDemo, IPlotDemo
        {
            public string name { get; } = "Filled Line Plots";
            public string description { get; } = "Polygons shaped to appear like filled line plots.";

            public void Render(Plot plt)
            {
                double[] xs = { 1, 2, 3, 4 };
                double[] ys1 = { 1, 3, 1, 2 };
                double[] ys2 = { 3, 7, 3, 1 };
                double[] ys3 = { 5, 2, 5, 6 };

                // create polygons for each data point
                double[] filledXs = xs.Take(1).Concat(xs).Concat(new double[] { xs.Last() }).ToArray();
                double[] filledYs1 = new List<double>() { 0 }.Concat(ys1).Concat(new double[] { 0 }).ToArray();
                double[] filledYs2 = new List<double>() { 0 }.Concat(ys2).Concat(new double[] { 0 }).ToArray();
                double[] filledYs3 = new List<double>() { 0 }.Concat(ys3).Concat(new double[] { 0 }).ToArray();

                plt.PlotPolygon(filledXs, filledYs3, lineWidth: 2, lineColor: Color.Black, fillAlpha: .7);
                plt.PlotPolygon(filledXs, filledYs2, lineWidth: 2, lineColor: Color.Black, fillAlpha: .7);
                plt.PlotPolygon(filledXs, filledYs1, lineWidth: 2, lineColor: Color.Black, fillAlpha: .7);

                plt.AxisAuto(0, 0);
                plt.Title("Filled Line Plots");
            }
        }

        public class FilledLinePlotsStacked : PlotDemo, IPlotDemo
        {
            public string name { get; } = "Filled Line Plots Stacked";
            public string description { get; } = "Polygons shaped to appear like stacked filled line plots.";

            public void Render(Plot plt)
            {
                double[] xs = { 1, 2, 3, 4 };
                double[] ys1 = { 1, 3, 1, 2 };
                double[] ys2 = { 3, 7, 3, 1 };
                double[] ys3 = { 5, 2, 5, 6 };

                // manually stack plots
                ys2 = Enumerable.Range(0, ys2.Length).Select(x => ys2[x] + ys1[x]).ToArray();
                ys3 = Enumerable.Range(0, ys2.Length).Select(x => ys3[x] + ys2[x]).ToArray();

                // create polygons for each data point
                double[] filledXs = xs.Take(1).Concat(xs).Concat(new double[] { xs.Last() }).ToArray();
                double[] filledYs1 = new List<double>() { 0 }.Concat(ys1).Concat(new double[] { 0 }).ToArray();
                double[] filledYs2 = new List<double>() { 0 }.Concat(ys2).Concat(new double[] { 0 }).ToArray();
                double[] filledYs3 = new List<double>() { 0 }.Concat(ys3).Concat(new double[] { 0 }).ToArray();

                plt.PlotPolygon(filledXs, filledYs3, lineWidth: 2, lineColor: Color.Black);
                plt.PlotPolygon(filledXs, filledYs2, lineWidth: 2, lineColor: Color.Black);
                plt.PlotPolygon(filledXs, filledYs1, lineWidth: 2, lineColor: Color.Black);

                plt.AxisAuto(0, 0);
                plt.Title("Stacked Filled Line Plots");
            }
        }
    }
}
