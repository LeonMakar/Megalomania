using UnityEngine;

public class WoodArea : Area
{
 
    public override void SetWorkersToArea()
    {

        SetNewTextAsync("Set Worker To Wood Area").Forget();
        CitizenConroller.SetCitizenToWork(WorkType,Collider2d);
    }

    public override void ResetWork()
    {
        SetNewTextAsync("Reset Worker To Wood Area").Forget();
        CitizenConroller.ResetCitizenWork(WorkType.WoodWork);
    }
}
