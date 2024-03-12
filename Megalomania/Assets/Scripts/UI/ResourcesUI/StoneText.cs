public class StoneText : UiResoucres
{
    private void Start()
    {
        ResourcesType = "Stone";
        Storage.StoneInStorage.OnChange += SetNewText;
    }
}
