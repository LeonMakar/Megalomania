
using UnityEngine;
using Zenject;

public class CitizenIconFactory : MonoBehaviour
{
    [SerializeField] private GameObject CitizenIcon;
    [SerializeField] private Transform ParentObject;
    private EventBus _eventBus;

    [Inject]
    public void Construct(EventBus eventBus)
    {
        _eventBus = eventBus;
    }


    public void Create()
    {
        _eventBus.Invoke(new OnSetWorkToCitizenSignal(true));
        var icon = Instantiate(CitizenIcon, ParentObject);
        icon.transform.position = Input.mousePosition;
    }




}
