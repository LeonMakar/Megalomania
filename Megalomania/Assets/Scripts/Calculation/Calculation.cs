using UnityEngine;

public static class Calculation 
{
    public static Vector3 GetRandomePointInsideCollider(Collider2D collider2D)
    {
        
        var x = Random.Range(collider2D.bounds.min.x, collider2D.bounds.max.x);
        var y = Random.Range(collider2D.bounds.min.y, collider2D.bounds.max.y);
        return new Vector3(x, y, 0);
    }
    public static Vector3 GetRandomePointAroundCollider(Collider2D collider2D)
    {
        float x = 0;
        float y = 0;
        switch (Random.Range(0, 4))
        {
            case 0:
                x = collider2D.bounds.min.x;
                y = Random.Range(collider2D.bounds.min.y, collider2D.bounds.max.y);
                break;
            case 1:
                x = collider2D.bounds.max.x;
                y = Random.Range(collider2D.bounds.min.y, collider2D.bounds.max.y);
                break;
            case 2:
                x = Random.Range(collider2D.bounds.min.x, collider2D.bounds.max.x);
                y = collider2D.bounds.min.y;
                break;
            case 3:
                x = Random.Range(collider2D.bounds.min.x, collider2D.bounds.max.x);
                y = collider2D.bounds.max.y;
                break;
        }
        return new Vector3(x, y, 0);
    }
}
