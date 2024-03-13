using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public abstract class Area : MonoBehaviour, IDragTarget
{
    [SerializeField] protected WorkType WorkType;

    protected TextMeshProUGUI Notation;
    protected CitizenController CitizenConroller;
    protected bool _isCitizenSelected = false;
    private bool _isCanResetWork = false;
    protected EventBus EventBus;
    protected Collider2D Collider2d;

    private void Awake()
    {
        Collider2d = GetComponent<Collider2D>();
    }
    [Inject]
    private void Construct(TextMeshProUGUI text, CitizenController citizenController, EventBus eventBus)
    {
        Notation = text;
        CitizenConroller = citizenController;
        EventBus = eventBus;


        EventBus.Subscrube<OnSetWorkToCitizenSignal>(SetAvailabilityToWork);
        EventBus.Subscrube<OnResetWorkOfCitizenSignal>(SetAvailabilityToResetWork);
    }

    private void SetAvailabilityToWork(OnSetWorkToCitizenSignal signal) => _isCitizenSelected = signal.IsCitizenSelected;
    private void SetAvailabilityToResetWork(OnResetWorkOfCitizenSignal signal) => _isCanResetWork = signal.CanResetCitizenWork;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (_isCitizenSelected)
            SetWorkersToArea();

        if (_isCanResetWork)
            ResetWork();

    }



    public virtual void SetWorkersToArea() { }
    public virtual void ResetWork() { }

    protected async UniTaskVoid SetNewTextAsync(string text)
    {
        Notation.text = text;
        await UniTask.Delay(2000);
        Notation.text = string.Empty;
    }

    public void OnDragEnd(Navigation navigation)
    {

    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }
}

public interface IDragTarget
{
    void OnDragEnd(Navigation navigation);
    GameObject GetGameObject();
}

