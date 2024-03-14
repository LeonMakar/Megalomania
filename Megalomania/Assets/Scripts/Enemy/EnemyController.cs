using Cysharp.Threading.Tasks;
using System.Collections.Generic;

public class EnemyController
{
    private Enemy.Factory _enemFactory;
    private SoldierController _soldierController;
    public Dictionary<int, Enemy> _enemys = new Dictionary<int, Enemy>();
    private Stack<Soldier> _soldiers = new Stack<Soldier>();
    private Stack<Enemy> _freeEnemys = new Stack<Enemy>();
    //private bool _isEnemysMoreThenSoldiers;
    private int _enemyID;

    public int AllEnemyCount;
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
            AllEnemyCount++;
            enemy.EnemyID = _enemyID;
            enemy.SetIDToEnemySimulator(_enemyID);
            _enemyID++;
            _enemys.Add(enemy.EnemyID, enemy);
            _freeEnemys.Push(enemy);
            if (IfPossibleSetDestinationToSoldier(enemy)) { }
            else
            {
                FindFreeSoldiers();
                IfPossibleSetDestinationToSoldier(enemy);
                //_isEnemysMoreThenSoldiers = true;
            }
        }

        _soldiers.Clear();
    }

    public void KillEnemyUnderID(int id)
    {
        if (_enemys.ContainsKey(id))
        {
            _enemys.Remove(id);
            AllEnemyCount--;
        }
    }

    private void FindFreeSoldiers()
    {
        foreach (var soldier in _soldierController.GetSoldiers())
        {
            _soldiers.Push(soldier.Value);
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
