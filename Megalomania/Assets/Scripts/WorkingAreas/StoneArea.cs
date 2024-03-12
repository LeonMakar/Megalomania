using UnityEngine;

public class StoneArea : Area
{
    public override void SetWorkersToArea()
    {
        SetNewTextAsync("Set Worker To Stone Area").Forget();
        CitizenConroller.SetCitizenToWork(WorkType,Collider2d);
    }
    public override void ResetWork()
    {
        SetNewTextAsync("Reset Worker To Stone Area").Forget();
        CitizenConroller.ResetCitizenWork(WorkType.StoneWork);
    }
}
