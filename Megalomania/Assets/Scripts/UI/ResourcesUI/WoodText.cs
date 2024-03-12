public class WoodText : UiResoucres
{
    private void Start()
    {
        Storage.WoodInStorage.OnChange += SetNewText;
        ResourcesType = "Wood";
    }
}
