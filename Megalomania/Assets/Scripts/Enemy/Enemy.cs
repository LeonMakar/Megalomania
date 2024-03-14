using UnityEngine;
using Zenject;

public class Enemy : ISimulatorFighter
{
    private Navigation _navigation;
    public int EnemyID;


    public Enemy(EnemySimulatorFactory enemySimulatorFactory, GameMainData gameMainData, EnemyController enemyController, SoldierController soldierController)
    {
        _navigation = enemySimulatorFactory.Create();
        _navigation.transform.position = gameMainData.EnemySpawnPoint;
        _navigation.gameObject.TryGetComponent(out FighterDetecter detecter);
        if (detecter == null)
        {
            throw new System.Exception("EnemySimulator dont have FighterDetecter script");
        }
        else
        {
            detecter.Initialize(enemyController, soldierController);
        }
    }

    public void SetIDToEnemySimulator(int id)
    {
        _navigation.gameObject.TryGetComponent(out FighterDetecter detecter);
        if (detecter == null)
        {
            throw new System.Exception("EnemySimulator dont have FighterDetecter script");
        }
        else
        {
            detecter.SetID(id);
        }
    }


    public Vector3 GetFighterPosition()
    {
        return _navigation.transform.position;
    }

    public void SetDestinationForEnemy(Vector3 point) => _navigation.SetNewPosition(point);


    public class Factory : PlaceholderFactory<Enemy> { }

}
