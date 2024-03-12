using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;
using Zenject;

public class Citizen
{
    public ResourcesType GeneratingResourceType;

    private GameMainData _gameMainData;
    private CancellationTokenSource _cancellatinToken;
    private ResourcesStorage _resourcesStorage;
    private bool _canMining = true;
    public Navigation _citizenNavigation;


    public Citizen(GameMainData gameMainData, GameToken gameToken, ResourcesStorage storage)
    {
        _gameMainData = gameMainData;
        _cancellatinToken = new CancellationTokenSource();
        _resourcesStorage = storage;
        gameToken.OnGameTokenDestroy += CancelAsyncMethods;
    }
    public void AddToCitizenSimulator(Navigation navigation) => _citizenNavigation = navigation;
    public void SetNewDestination(Vector3 vector3) => _citizenNavigation.SetNewPosition(vector3);
    public void StopMining() => _canMining = false;

    public void SetWorkToCitizen(WorkType workType)
    {
        switch (workType)
        {
            case WorkType.WoodWork:
                GainingResourcesAsync(ResourcesType.Wood, _gameMainData.WoodAddingInterval, _gameMainData.WoodAddingValue).Forget();
                break;
            case WorkType.StoneWork:
                GainingResourcesAsync(ResourcesType.Stone, _gameMainData.StoneAddingInterval, _gameMainData.StoneAddingValue).Forget();
                break;
        }
    }

    public async UniTaskVoid ChangeWorkCondition(WorkType workType)
    {
        _canMining = false;
        await UniTask.Delay(1500);
        _canMining = true;
        SetWorkToCitizen(workType);
    }


    public void CancelAsyncMethods() => _cancellatinToken.Cancel();

    private async UniTask GainingResourcesAsync(ResourcesType resourcesType, int resourcesAddingDelay, uint resourcesAddingValue)
    {
        switch (resourcesType)
        {
            case ResourcesType.Stone:
                GeneratingResourceType = ResourcesType.Stone;
                break;
            case ResourcesType.Wood:
                GeneratingResourceType = ResourcesType.Wood;
                break;
        }
        while (_canMining)
        {
            await UniTask.Delay(resourcesAddingDelay, true, PlayerLoopTiming.Update, _cancellatinToken.Token);
            _resourcesStorage.AddResource(GeneratingResourceType, resourcesAddingValue);
        }
    }

    public class Factory : PlaceholderFactory<Citizen> { }
}


