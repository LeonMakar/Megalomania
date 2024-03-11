using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class Area : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] protected WorkType WorkType;

    protected TextMeshProUGUI Notation;
    protected CitizenController CitizenConroller;
    protected bool _isCitizenSelected = false;

    protected EventBus EventBus;

    [Inject]
    private void Construct(TextMeshProUGUI text, CitizenController citizenController, EventBus eventBus)
    {
        Notation = text;
        CitizenConroller = citizenController;
        EventBus = eventBus;


        EventBus.Subscrube<OnSetWorkToCitizenSignal>(SetAvailabilityToWork);
    }


    private void SetAvailabilityToWork(OnSetWorkToCitizenSignal signal) => _isCitizenSelected = signal.IsCitizenSelected;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (_isCitizenSelected)
            SetWorkersToArea();
    }


    public virtual void SetWorkersToArea() { }

    protected async UniTaskVoid SetNewTextAsync(string text)
    {
        Notation.text = text;
        await UniTask.Delay(2000);
        Notation.text = "";
    }
}
