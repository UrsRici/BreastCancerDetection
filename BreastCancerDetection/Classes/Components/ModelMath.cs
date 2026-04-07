using System;
using System.Collections.Generic;
using NCalc;

namespace BreastCancerDetection.Classes
{
    public class ModelMath
    {
        public string F1Expr { get; set; }
        public string F2Expr { get; set; }

        private double TStart = 0;
        public double TEnd { get; set; }

        public double X0 { get; set; }
        public double Y0 { get; set; }

        private double Min = 100;
        private double Max = 100;

        public double Step { get; set; } = 0.5;

        private Expression expr1;
        private Expression expr2;

        public void Initialize()
        {
            // 🔥 înlocuire automată dacă mai ai x1/x2
            F1Expr = F1Expr.Replace("x1", "x").Replace("x2", "y");
            F2Expr = F2Expr.Replace("x1", "x").Replace("x2", "y");

            expr1 = new Expression(F1Expr);
            expr2 = new Expression(F2Expr);
        }

        private (double dx, double dy) F(double t, double x, double y)
        {
            expr1.Parameters["t"] = t;
            expr1.Parameters["x"] = x;
            expr1.Parameters["y"] = y;

            expr2.Parameters["t"] = t;
            expr2.Parameters["x"] = x;
            expr2.Parameters["y"] = y;

            return (
                Convert.ToDouble(expr1.Evaluate()),
                Convert.ToDouble(expr2.Evaluate())
            );
        }

        public List<(double t, double x, double y)> SolveMain()
        {
            var result = new List<(double, double, double)>();

            double t = TStart;
            double x = X0;
            double y = Y0;

            while (t <= TEnd)
            {
                result.Add((t, x, y));

                var k1 = F(t, x, y);
                var k2 = F(t + Step / 2, x + Step * k1.dx / 2, y + Step * k1.dy / 2);
                var k3 = F(t + Step / 2, x + Step * k2.dx / 2, y + Step * k2.dy / 2);
                var k4 = F(t + Step, x + Step * k3.dx, y + Step * k3.dy);

                x += Step * (k1.dx + 2 * k2.dx + 2 * k3.dx + k4.dx) / 6;
                y += Step * (k1.dy + 2 * k2.dy + 2 * k3.dy + k4.dy) / 6;

                t += Step;
            }

            return result;
        }

        public List<List<(double x, double y)>> SolvePhase()
        {
            var all = new List<List<(double, double)>>();

            for (double i = 0; i <= Max; i += 10)
            {
                for (double j = 0; j <= Min; j += 10)
                {
                    double t = TStart;
                    double x = i;
                    double y = j;

                    var traj = new List<(double, double)>();

                    while (t <= TEnd)
                    {
                        traj.Add((x, y));

                        var k1 = F(t, x, y);
                        var k2 = F(t + Step / 2, x + Step * k1.dx / 2, y + Step * k1.dy / 2);
                        var k3 = F(t + Step / 2, x + Step * k2.dx / 2, y + Step * k2.dy / 2);
                        var k4 = F(t + Step, x + Step * k3.dx, y + Step * k3.dy);

                        x += Step * (k1.dx + 2 * k2.dx + 2 * k3.dx + k4.dx) / 6;
                        y += Step * (k1.dy + 2 * k2.dy + 2 * k3.dy + k4.dy) / 6;

                        t += Step;
                    }

                    all.Add(traj);
                }
            }

            return all;
        }
    }
}