using System.Collections.Generic;

public class EnemyController
{
    private Enemy.Factory _enemFactory;
    private SoldierController _soldierController;
    public List<Enemy> _enemys = new List<Enemy>();
    private Stack<Soldier> _soldiers = new Stack<Soldier>();
    private Stack<Enemy> _freeEnemys = new Stack<Enemy>();
    private bool _isEnemysMoreThenSoldiers;

    public EnemyController(Enemy.Factory factory, SoldierController soldierController)
    {
        _enemFactory = factory;
        _soldierController = soldierController;
    }

    public void CreatEnemyes(int numberOfEnemyes)
    {
        FindFreeSoldiers();

        for (int i = 0; i < numberOfEnemyes; i++)
        {
            var enemy = _enemFactory.Create();
            _enemys.Add(enemy);
            _freeEnemys.Push(enemy);
            if (IfPossibleSetDestinationToSoldier(enemy)) { }
            else
            {
                FindFreeSoldiers();
                IfPossibleSetDestinationToSoldier(enemy);
                _isEnemysMoreThenSoldiers = true;
            }
        }
        if (!_isEnemysMoreThenSoldiers)
        {
            int i = 0;
            foreach (var soldier in _soldiers)
            {
                soldier.SetNewPositionForSoldier(_enemys[i].GetFighterPosition());
                i++;
            }
        }
    }

    private void FindFreeSoldiers()
    {
        foreach (var soldier in _soldierController.GetSoldiers())
        {
            _soldiers.Push(soldier);
        }
    }

    private bool IfPossibleSetDestinationToSoldier(Enemy enemy)
    {
        _soldiers.TryPop(out Soldier soldier);
        if (soldier != null)
        {
            enemy.SetDestinationForEnemy(soldier.GetFighterPosition());
            return true;
        }
        else
            return false;
    }
}
