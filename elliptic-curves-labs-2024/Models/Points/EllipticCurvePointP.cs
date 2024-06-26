﻿using System.Drawing;
using System.Numerics;
using System.Text.RegularExpressions;

namespace elliptic_curves_labs_2024.Models.Points
{
    public class EllipticCurvePointP
    {
        public BigInteger X { get; set; }
        public BigInteger Y { get; set; }
        public BigInteger Z { get; set; }
        public BigInteger module { get; set; }

        public EllipticCurvePointP(BigInteger X, BigInteger Y, BigInteger Z, BigInteger module)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
            this.module = module;
        }

        public override string ToString()
        {
            return String.Format($"Point has the following coordinates: \n\t\t(X, Y, Z) = ({this.X}, {this.Y}, {this.Z}) in F_{module}.");
        }

        public static EllipticCurvePointP Parse(string input)
        {
            string modulusPattern = @"F_(\d+)";
            string coordinatePattern = @"\((\d+),\s*(\d+),\s*(\d+)\)";

            var modulusMatch = Regex.Match(input, modulusPattern);
            
            var module = modulusMatch.Success 
                ? BigInteger.Parse(modulusMatch.Groups[1].Value) 
                : throw new Exception("Module was not found.");
            
            var coordinateMatch = Regex.Match(input, coordinatePattern);
            
            if (!coordinateMatch.Success)
                throw new Exception("Coordinates were not found.");
            
            return new EllipticCurvePointP(
                    BigInteger.Parse(coordinateMatch.Groups[1].Value),
                    BigInteger.Parse(coordinateMatch.Groups[2].Value),
                    BigInteger.Parse(coordinateMatch.Groups[3].Value),
                    module);
        }

        public static bool operator !=(EllipticCurvePointP point_1, EllipticCurvePointP point_2)
        {
            if ((object)point_1 == null || (object)point_2 == null)
                throw new ArgumentNullException();

            return point_1.module != point_2.module ||
                    point_1.X != point_2.X ||
                    point_1.Y != point_2.Y ||
                    point_1.Z != point_2.Z;
        }

        public static bool operator ==(EllipticCurvePointP point_1, EllipticCurvePointP point_2)
        {
            if ((object)point_1 == null || (object)point_2 == null)
                throw new ArgumentNullException();

            return point_1.module == point_2.module &&
                    point_1.X == point_2.X &&
                    point_1.Y == point_2.Y &&
                    point_1.Z == point_2.Z;
        }
    }
}
