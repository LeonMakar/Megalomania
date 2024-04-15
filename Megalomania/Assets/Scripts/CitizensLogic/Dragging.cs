using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dragging : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Navigation _parentNavigation;
    private IDragTarget _lastDragTarget;
    public void OnBeginDrag(PointerEventData eventData)
    {
        _spriteRenderer.enabled = true;
        gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
    }

    private void SetWorkersToArea()
    {
        if (_lastDragTarget != null)
        {
            switch (_lastDragTarget.GetType())
            {
                case Type n when n == typeof(StoneArea):
                    _lastDragTarget.GetGameObject().GetComponent<Area>().SetWorkersToArea();
                    break;
                case Type n when n == typeof(WoodArea):
                    _lastDragTarget.GetGameObject().GetComponent<Area>().SetWorkersToArea();
                    break;
                default:
                    break;
            }
        }
    }
    private void ResetWorkersFromArea()
    {
        if (_lastDragTarget != null)
        {
            switch (_lastDragTarget.GetType())
            {
                case Type n when n == typeof(StoneArea):
                    _lastDragTarget.GetGameObject().GetComponent<Area>().ResetWork();
                    break;
                case Type n when n == typeof(WoodArea):
                    _lastDragTarget.GetGameObject().GetComponent<Area>().ResetWork();
                    break;
                default:
                    break;
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.pointerCurrentRaycast.worldPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        ResetWorkersFromArea();
        _spriteRenderer.enabled = false;
        eventData.pointerEnter.TryGetComponent(out IDragTarget area);
        if (area != null)
        {
            _parentNavigation.SetNewPosition(Calculation.GetRandomePointInsideCollider(area.GetBoxCollider()));
            _lastDragTarget = area;
            SetWorkersToArea();
        }

        transform.position = _parentNavigation.transform.position;
        gameObject.layer = LayerMask.NameToLayer("UI");
    }
}
