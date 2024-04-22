using UnityEngine;
using static UnityEngine.Random;

namespace RH_Modules.Utilities.Extensions
{
    public static class Vector3Extensions
    {
        public static Vector3 AddRandomInBox(this Vector3 origin, Vector3 size) =>
            origin + new Vector3(
                Range(-size.x, size.x),
                Range(-size.y, size.y),
                Range(-size.z, size.z));

        public static Vector2 ToXY(this Vector3 origin) =>
            new Vector2(origin.x, origin.z);
    }
}