using UnityEngine;
using Zenject;

public class Soldier : ISimulatorFighter
{
    private Navigation _navigation;
    public Soldier(SoldierSimulatorFactory soldierSimulatorFactory)
    {
        _navigation = soldierSimulatorFactory.Create();
    }

    public Vector3 GetFighterPosition()
    {
        return _navigation.transform.position;
    }

    public void SetNewPositionForSoldier(Vector3 position) => _navigation.SetNewPosition(position);
    public class Factory : PlaceholderFactory<Soldier> { }
}
