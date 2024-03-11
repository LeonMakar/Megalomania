public class ResourcesStorage
{

    public float WoodInStorage { get; private set; }
    public float StoneInStorage { get; private set; }


    public void AddResource(ResourcesType resourcesType, float ammount)
    {
        switch (resourcesType)
        {
            case ResourcesType.Wood:
                WoodInStorage += ammount;
                break;
            case ResourcesType.Stone:
                StoneInStorage += ammount;
                break;
            default:
                throw new System.Exception("Incorrect ResorcesType");
        }
    }




}
