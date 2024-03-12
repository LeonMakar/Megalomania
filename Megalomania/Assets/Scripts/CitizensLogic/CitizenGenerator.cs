using Cysharp.Threading.Tasks;
using UnityEngine;

public class CitizenGenerator
{
    private CitizenGeneratorData _citizenGeneratorData;
    private GameToken _gameToken;
    private CitizenController _citizenController;

    public CitizenGenerator(CitizenGeneratorData citizenGeneratorData, GameToken gameToken, CitizenController citizenController)
    {
        _citizenGeneratorData = citizenGeneratorData;
        _gameToken = gameToken;
        _citizenController = citizenController;

        GenerateNewCitizenAsync(_citizenGeneratorData.TimeToCreatNewCitizen, _citizenGeneratorData.Modificator).Forget();
    }

    public void Initialize()
    {
        _citizenController.AddNewCitizen();
    }


    private async UniTaskVoid GenerateNewCitizenAsync(float generalTime, float modificator)
    {
        while (true)
        {
            var freeCitizens = _citizenController.GetFreeCitizens();
            int deleayTime = Mathf.FloorToInt((generalTime * modificator) - freeCitizens) * 1000;
            await UniTask.Delay(deleayTime, false, PlayerLoopTiming.Update, _gameToken.destroyCancellationToken);
            _citizenController.AddNewCitizen();
        }
    }
}
