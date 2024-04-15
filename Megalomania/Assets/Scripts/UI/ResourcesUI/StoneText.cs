public class StoneText : UiResoucres
{
    private void Start()
    {
        Storage.StoneInStorage.OnChange += SetNewText;
        ResourcesType = "Stone";
        SetNewText(0);
    }
}
