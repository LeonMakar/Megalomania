
using Cysharp.Threading.Tasks;
using UnityEngine;

public static class Calculation 
{
    public static Vector3 GetRandomePointInsideCollider(Collider2D collider2D)
    {

        var x = Random.Range(collider2D.bounds.min.x, collider2D.bounds.max.x);
        var y = Random.Range(collider2D.bounds.min.y, collider2D.bounds.max.y);
        return new Vector3(x, y, 0);
    }
}
