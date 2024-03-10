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

    [Inject]
    private void Construct(TextMeshProUGUI text, CitizenController citizenController)
    {
        Notation = text;
        CitizenConroller = citizenController;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SetWorkersToArea();

    }


    public virtual void SetWorkersToArea()
    {
    }

    protected async UniTaskVoid SetNewTextAsync(string text)
    {
        Notation.text = text;
        await UniTask.Delay(2000);
        Notation.text = "";
    }
}
