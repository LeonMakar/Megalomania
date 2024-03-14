using System.Collections.Generic;
using UnityEngine;

public class SoldierController
{
    private Soldier.Factory _soldierFactory;
    private Collider2D _mainBuildingCollider;
    private int _soldierID;
    public int SoldiersKilled;

    private Dictionary<int, Soldier> _soldiers = new Dictionary<int, Soldier>();

    public SoldierController(Soldier.Factory soldierFactory, Collider2D castleColldier)
    {
        _soldierFactory = soldierFactory;
        _mainBuildingCollider = castleColldier;
    }

    public Dictionary<int, Soldier> GetSoldiers() => _soldiers;

    public void KillSoldierUnderID(int soldierID)
    {
        if (_soldiers.ContainsKey(soldierID))
        {
            _soldiers.Remove(soldierID);
            SoldiersKilled++;
        }
    }

    public void CreateSoldier(int soldiersAmmount)
    {
        for (int i = 0; i < soldiersAmmount; i++)
        {
            var soldiers = _soldierFactory.Create();
            soldiers.SetIDToSoldier(_soldierID);
            _soldierID++;
            _soldiers.Add(soldiers.SoldierID, soldiers);
            soldiers.SetNewPositionForSoldier(Calculation.GetRandomePointInsideCollider(_mainBuildingCollider));
        }
    }
}
