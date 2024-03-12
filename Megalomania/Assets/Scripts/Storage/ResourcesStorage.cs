public class ResourcesStorage
{
    public ReactiveProperty<int> WoodInStorage { get; private set; } = new ReactiveProperty<int>();
    public ReactiveProperty<int> StoneInStorage { get; private set; } = new ReactiveProperty<int>();
    public ReactiveProperty<int> CitizenInStorage { get; private set; } = new ReactiveProperty<int>();
    public ReactiveProperty<int> WarriorInStorage { get; private set; } = new ReactiveProperty<int>();

    public ResourcesStorage(EventBus eventBus)
    {
        eventBus.Subscrube<OnAddedNewCitizenSignal>(AddCitizen);
    }

    public void AddResource(ResourcesType resourcesType, uint ammount)
    {
        switch (resourcesType)
        {
            case ResourcesType.Wood:
                WoodInStorage.Value += (int)ammount;
                break;
            case ResourcesType.Stone:
                StoneInStorage.Value += (int)ammount;
                break;
            case ResourcesType.Citizen:
                CitizenInStorage.Value += (int)ammount;
                break;
            case ResourcesType.Warrior:
                WarriorInStorage.Value += (int)ammount;
                break;
            default:
                throw new System.Exception("Incorrect ResorcesType");
        }
    }
    public void AddCitizen(OnAddedNewCitizenSignal signal)
    {
        CitizenInStorage.Value += signal.CitizenAmmount;
    }




}
