using UnityEngine;

public class MyMath : MonoBehaviour
{
    public static int CalDistance(Vector2Int p, Vector2Int dp)
    {
        //sqrt((x1 - x2) ^ 2 + (y1 - y2) ^ 2)
        return (int)Mathf.Sqrt(Mathf.Pow((p.x - dp.x), 2) + Mathf.Pow((p.y - dp.y), 2)); 
    }
}
