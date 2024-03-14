using Cysharp.Threading.Tasks;
using System;
using TMPro;
using UnityEngine;
using Zenject;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private GameMainData _gameMainData;
    private GameToken _token;
    private EnemyController _enemyController;
    private GameStateMachine _gameStateMachine;
    private SoldierController _soldierController;
    private TimeSpan _timer = new TimeSpan(0, 0, 0);
    private TimeSpan _halfTimer;

    [Inject]
    private void Construct(GameMainData gameMainData, GameToken gameToken, EnemyController enemyController, GameStateMachine gameStateMachine, SoldierController soldierController)
    {
        _gameMainData = gameMainData;
        _token = gameToken;
        _enemyController = enemyController;
        _gameStateMachine = gameStateMachine;
        _soldierController = soldierController;
    }



    void Start()
    {
        _timer = _timer.Add(new TimeSpan(0, _gameMainData.MinutesForCurrentLvl, 0));
        _halfTimer = new TimeSpan(0, 0, Mathf.FloorToInt((float)_timer.TotalSeconds / 2));
        StartTimerAsync().Forget();
    }

    private async UniTaskVoid StartTimerAsync()
    {
        while (_timer.TotalMilliseconds != 0)
        {
            await UniTask.Delay(1000, false, PlayerLoopTiming.Update, _token.destroyCancellationToken);
            _timer = _timer.Add(new TimeSpan(0, 0, -1));
            _text.text = $"{_timer:mm\\:ss}";
            if (_halfTimer.TotalSeconds == _timer.TotalSeconds)
            {
                _enemyController.CreatEnemyes(Mathf.FloorToInt(_gameMainData.EnemysForCurrentLvl / 2));
                WaitResultAsync(false).Forget();
            }

            if (_timer.TotalSeconds == 0)
            {
                WaitResultAsync(true).Forget();
            }
        }
        _enemyController.CreatEnemyes(_gameMainData.EnemysForCurrentLvl);
    }

    private async UniTaskVoid WaitResultAsync(bool isLastWave)
    {
        await UniTask.Delay(6000, false, PlayerLoopTiming.Update, _token.destroyCancellationToken);
        if (_enemyController.AllEnemyCount > 0)
            _gameStateMachine.SetGameOver();
        else
        {
            _soldierController.CreateSoldier(_soldierController.SoldiersKilled);
        }

        if (isLastWave)
        {
            if (_enemyController.AllEnemyCount > 0)
                _gameStateMachine.SetGameOver();
            else
                _gameStateMachine.SetGameIsWin();
        }


    }
}
