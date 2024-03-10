using Cysharp.Threading.Tasks;
using System.Threading;
using Zenject;

public class Citizen
{
    private StoneText _stoneText;
    private WoodText _woodText;
    private GameMainData _gameMainData;
    private CancellationTokenSource _cancellatinToken;
    private bool _canMining = true;


    public Citizen(StoneText stoneText, WoodText woodText, GameMainData gameMainData, GameToken gameToken)
    {
        _stoneText = stoneText;
        _woodText = woodText;
        _gameMainData = gameMainData;
        _cancellatinToken = new CancellationTokenSource();
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
        while (_canMining)
        {
            await UniTask.Delay(resourcesAddingDelay, true, PlayerLoopTiming.Update, _cancellatinToken.Token);
            uiResoucresType.ResourcesCount += resourcesAddingValue;
            uiResoucresType.SetNewText();
        }

    }

    public class Factory : PlaceholderFactory<Citizen> { }
}


