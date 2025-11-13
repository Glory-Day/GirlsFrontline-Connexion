using UnityEngine;

namespace GloryDay.Math
{
    public static class BezierCurve
    {
        /// <param name="time"> Rate of change in time from 0 to 1. </param>
        /// <returns>
        /// Linear interpolation value of the bézier curve formula calculated from the rate of change in time.
        /// </returns>
        public static Vector3 GetPosition(float time, Vector3[] points)
        {
            var deltaTimeCube = (1 - time) * (1 - time) * (1 - time);
            var timeCube = time * time * time;
            var u = 3 * time * (1 - time) * (1 - time);
            var v = 3 * time * time * (1 - time);
            
            return deltaTimeCube * points[0] + u * points[1] + v * points[2] + timeCube * points[3];
        }
    }
}