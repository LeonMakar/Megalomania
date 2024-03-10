using UnityEngine;
using UnityEngine.EventSystems;

public class Area : MonoBehaviour, IPointerUpHandler, IPointerMoveHandler, IPointerDownHandler
{

    public void OnPointerDown(PointerEventData eventData)
    {
        SetWorkersToArea();
    }


    public void OnPointerMove(PointerEventData eventData)
    {
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
       
    }

    public virtual void SetWorkersToArea() { 
    }
}
