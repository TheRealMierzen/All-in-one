using UnityEngine;

public class Util
{
    /// <summary>
    /// Checks if the line from origin is obstructed.
    /// </summary>
    /// <param name="origin">Origin of the line to be checked.</param>
    /// <param name="direction">Direction wherein the line goes.</param>
    /// <param name="length">The length of the line.</param>
    /// <returns></returns>
    public static bool isObstructed(Vector3 origin, Vector3 direction, float length)
    {
        RaycastHit[] hits;
        hits = Physics.RaycastAll(origin, direction, length);

        if (hits.Length != 1)
            return false;
        else
            return true;
    }
}
