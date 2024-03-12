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
    private TimeSpan _timer = new TimeSpan(0, 0, 0);

    [Inject]
    private void Construct(GameMainData gameMainData, GameToken gameToken, EnemyController enemyController)
    {
        _gameMainData = gameMainData;
        _token = gameToken;
        _enemyController = enemyController;
    }



    void Start()
    {
        _timer = _timer.Add(new TimeSpan(0, _gameMainData.MinutesForCurrentLvl, 0));
        StartTimerAsync().Forget();
    }

    private async UniTaskVoid StartTimerAsync()
    {
        while (_timer.TotalMilliseconds != 0)
        {
            await UniTask.Delay(1000, false, PlayerLoopTiming.Update, _token.destroyCancellationToken);
            _timer = _timer.Add(new TimeSpan(0, 0, -1));
            _text.text = $"{_timer:mm\\:ss}";
            if (_timer.TotalSeconds == 0)
            {
                Debug.Log("GameOver");
            }
        }
        _enemyController.CreatEnemyes(_gameMainData.EnemysForCurrentLvl);
    }
}
