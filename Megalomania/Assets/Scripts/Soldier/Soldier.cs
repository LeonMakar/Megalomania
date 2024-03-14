using UnityEngine;
using Zenject;

public class Soldier : ISimulatorFighter
{
    public int SoldierID;
    private Navigation _navigation;
    public Soldier(SoldierSimulatorFactory soldierSimulatorFactory)
    {
        _navigation = soldierSimulatorFactory.Create();

    }

    public void SetIDToSoldier(int soldierID)
    {
        _navigation.gameObject.TryGetComponent(out SoldierCounter soldierCounter);
        if (soldierCounter == null)
        {
            throw new System.Exception("SoldierCounter componnent dont exist on Soldier GameObject");
        }
        SoldierID = soldierID;
        soldierCounter.ID = SoldierID;

    }

    public Vector3 GetFighterPosition()
    {
        return _navigation.transform.position;
    }

    public void SetNewPositionForSoldier(Vector3 position) => _navigation.SetNewPosition(position);
    public class Factory : PlaceholderFactory<Soldier> { }
}
