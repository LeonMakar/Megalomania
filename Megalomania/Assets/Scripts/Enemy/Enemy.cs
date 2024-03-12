using UnityEngine;
using Zenject;

public class Enemy : ISimulatorFighter
{
    private Navigation _navigation;


    public Enemy(EnemySimulatorFactory enemySimulatorFactory, GameMainData gameMainData)
    {
        _navigation = enemySimulatorFactory.Create();
        _navigation.transform.position = gameMainData.EnemySpawnPoint;
    }

    public Vector3 GetFighterPosition()
    {
        return _navigation.transform.position;
    }

    public void SetDestinationForEnemy(Vector3 point) => _navigation.SetNewPosition(point);


    public class Factory : PlaceholderFactory<Enemy> { }

}
