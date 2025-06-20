using UnityEngine;

namespace Utilities
{
    
public class GameBounds
{
    public static float Left;
    public static float Right;
    public static float Top;
    public static float Bottom;
    public static void UpdateBounds(Camera cam)
    {
        Vector3 lowerLeft = cam.ViewportToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
        Vector3 upperRight = cam.ViewportToWorldPoint(new Vector3(1, 1, cam.nearClipPlane));

        Left = lowerLeft.x;
        Right = upperRight.x;
        Bottom = lowerLeft.y;
        Top = upperRight.y;
    }
}

}