using UnityEngine;
using UnityEngine.EventSystems;

public class IconMooving : MonoBehaviour, IPointerMoveHandler, IPointerClickHandler
{

    public void OnPointerClick(PointerEventData eventData)
    {
        Destroy(gameObject);
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }
}
