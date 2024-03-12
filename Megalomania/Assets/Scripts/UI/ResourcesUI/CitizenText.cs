using System;

public class CitizenText : UiResoucres
{
    internal void Initialize()
    {
        Storage.CitizenInStorage.OnChange += SetNewText;
        ResourcesType = "Citizens ";
    }
}
