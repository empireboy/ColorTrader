using UnityEngine;

namespace UnityEngine
{
    public class RangeController
    {
        public static bool IsInRange(Vector3 me, Vector3 target, float range)
        {
            if (Vector3.Distance(me, target) <= range) return true;
            return false;
        }
    }
}