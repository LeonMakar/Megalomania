using TMPro;
using UnityEngine;

public class UiResoucres : MonoBehaviour
{
    public TextMeshProUGUI Text;
    public float ResourcesCount;
    protected string ResourcesType;

    public void SetNewText()
    {
        Text.text = $"{ResourcesType} {ResourcesCount}";
    }

}
