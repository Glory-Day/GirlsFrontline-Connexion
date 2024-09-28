using System.Collections.Generic;
using GloryDay.Log;

namespace Object.Character
{
    public class CharacterPositionComparer : IComparer<IHorizontalComparable>
    {
        private IHorizontalComparable _pivot;
        
        /// <summary>
        /// Set the horizontal position that becomes the pivot for comparision of the character's horizontal position.
        /// </summary>
        /// <param name="pivot"> The horizontal position that becomes the pivot. </param>
        public void SetPivot(IHorizontalComparable pivot)
        {
            LogManager.LogProgress();
            
            _pivot = pivot;
        }
        
        public int Compare(IHorizontalComparable a, IHorizontalComparable b)
        {
            if (a is null || b is null)
            {
                return -1;
            }

            if (_pivot.HorizontalPosition < a.HorizontalPosition || _pivot.HorizontalPosition < b.HorizontalPosition)
            {
                return -1;
            }
            
            var x01 = a.HorizontalPosition;
            var x02 = b.HorizontalPosition;

            var value = 0;
            if (x01 < x02)
            {
                value = 1;
            }
            else if (x01 > x02)
            {
                value = 0;
            }

            return value;
        }
    }
}