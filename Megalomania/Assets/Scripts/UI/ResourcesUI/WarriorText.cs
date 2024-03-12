public class WarriorText :UiResoucres
{
    private void Start()
    {
        Storage.WarriorInStorage.OnChange += SetNewText;
        ResourcesType = "Warriors ";
    }
}
