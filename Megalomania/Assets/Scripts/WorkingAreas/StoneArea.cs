using UnityEngine;

public class StoneArea : Area
{
    public override void SetWorkersToArea()
    {
        SetNewTextAsync("Set Worker To Stone Area").Forget();
        CitizenConroller.SetCitizenToWork(WorkType);
    }
}
