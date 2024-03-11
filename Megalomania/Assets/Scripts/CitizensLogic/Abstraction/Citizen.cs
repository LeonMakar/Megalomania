using Cysharp.Threading.Tasks;
using System.Threading;
using Zenject;

public class Citizen
{
    private StoneText _stoneText;
    private WoodText _woodText;
    private GameMainData _gameMainData;
    private CancellationTokenSource _cancellatinToken;
    private ResourcesStorage _resourcesStorage;
    private bool _canMining = true;
    private ResourcesType _generatingType;


    public Citizen(StoneText stoneText, WoodText woodText, GameMainData gameMainData, GameToken gameToken, ResourcesStorage storage)
    {
        _stoneText = stoneText;
        _woodText = woodText;
        _gameMainData = gameMainData;
        _cancellatinToken = new CancellationTokenSource();
        _resourcesStorage = storage;
        gameToken.OnGameTokenDestroy += CancelAsyncMethods;

    }

    public void SetWorkToCitizen(WorkType workType)
    {
        switch (workType)
        {
            case WorkType.WoodWork:
                GainingResourcesAsync(_woodText, _gameMainData.WoodAddingInterval, _gameMainData.WoodAddingValue).Forget();

                break;
            case WorkType.StoneWork:
                GainingResourcesAsync(_stoneText, _gameMainData.StoneAddingInterval, _gameMainData.StoneAddingValue).Forget();
                break;
            case WorkType.SolderWork:
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

    private async UniTask GainingResourcesAsync(UiResoucres uiResoucresType, int resourcesAddingDelay, float resourcesAddingValue)
    {
        switch (uiResoucresType.GetType().Name)
        {
            case nameof(StoneText):
                _generatingType = ResourcesType.Stone;
                break;
            case nameof(WoodText):
                _generatingType = ResourcesType.Wood;
                break;
        }
        while (_canMining)
        {
            await UniTask.Delay(resourcesAddingDelay, true, PlayerLoopTiming.Update, _cancellatinToken.Token);
            uiResoucresType.ResourcesCount += resourcesAddingValue;
            _resourcesStorage.AddResource(_generatingType, resourcesAddingValue);
            uiResoucresType.SetNewText();
        }

    }

    public class Factory : PlaceholderFactory<Citizen> { }
}


