using UnityEngine;

public class Castle : Building, IDragTarget
{
    public BoxCollider2D Collider2D;

    public BoxCollider2D GetBoxCollider()
    {
        return Collider2D;
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public void OnDragEnd(Navigation navigation)
    {
        
    }
}
