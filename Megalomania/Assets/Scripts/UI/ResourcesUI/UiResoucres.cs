using TMPro;
using UnityEngine;
using Zenject;

public class UiResoucres : MonoBehaviour
{
    public TextMeshProUGUI Text;
    protected string ResourcesType;
    protected ResourcesStorage Storage;

    [Inject]
    private void Construct(ResourcesStorage storage)
    {
        Storage = storage;
    }
    public void SetNewText(int resourcesValue)
    {
        Text.text = $"{ResourcesType} {resourcesValue}";
    }

}
