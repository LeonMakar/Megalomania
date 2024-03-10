using UnityEngine;

public class WoodArea : Area
{
    public override void SetWorkersToArea()
    {

        SetNewTextAsync("Set Worker To Wood Area").Forget();
        CitizenConroller.SetCitizenToWork(WorkType);
    }
}
