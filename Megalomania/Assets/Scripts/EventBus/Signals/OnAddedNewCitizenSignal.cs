public class OnAddedNewCitizenSignal
{
    public int CitizenAmmount;
    public ResourcesType ResourcesType = ResourcesType.Citizen;
    public OnAddedNewCitizenSignal(int citizenAmmount)
    {
        CitizenAmmount = citizenAmmount;
    }
}
