﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGGW.MR.Cienowanie
{
  static public partial class Hilbert
    {
      public static Curve Discretization(int depth)
        {
            Curve curve = CurvePoints(depth);
            curve.X = Discretize(curve.X);
            curve.Y = Discretize(curve.Y);
            
            return curve;
        }
      private static List<double> Discretize( List<double> coord)
        {
            Dictionary<double,int> set = new Dictionary<double, int>();
            double [] result = new double[coord.Count];// initialize capacity

            for (int i = 0; i < coord.Count; i++)
            {
                if (set.ContainsKey(coord[i]))
                {
                    double index = set[coord[i]];
                    result[i] = index;

                }else
                {
                    int index = set.Count + 1;
                    // track the index of the next first occured distinct element
                    set.Add(coord[i], index);
                    
                    result[i] = index;

                }
            }
            return result.ToList();
        }
    }
}
