using UnityEngine;

public class Castle : Building, IDragTarget
{
    public Collider2D Collider2D;

    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public void OnDragEnd(Navigation navigation)
    {
        
    }
}
