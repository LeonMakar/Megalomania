using UnityEngine;

public class IconMooving : MonoBehaviour
{
    private const int LEFT_MOUSE_BUTTONE = 0;


    private void Update()
    {    
        transform.position = Input.mousePosition;
        if (Input.GetMouseButtonDown(LEFT_MOUSE_BUTTONE))
            Destroy(gameObject);
    }
}
