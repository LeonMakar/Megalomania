using System.Collections.Generic;
using UnityEngine;

public class SoldierController
{
    private Soldier.Factory _soldierFactory;
    private Collider2D _mainBuildingCollider;

    private List<Soldier> _soldiers = new List<Soldier>();

    public SoldierController(Soldier.Factory soldierFactory, Collider2D castleColldier)
    {
        _soldierFactory = soldierFactory;
        _mainBuildingCollider = castleColldier;
    }

    public List<Soldier> GetSoldiers() => _soldiers;


    public void CreateSoldier(int soldiersAmmount)
    {
        for (int i = 0; i < soldiersAmmount; i++)
        {
            var soldiers = _soldierFactory.Create();
            _soldiers.Add(soldiers);
            soldiers.SetNewPositionForSoldier(Calculation.GetRandomePointInsideCollider(_mainBuildingCollider));
        }
    }
}
