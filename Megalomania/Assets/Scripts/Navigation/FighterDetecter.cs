using Cysharp.Threading.Tasks;
using System.Linq;
using UnityEngine;

public class FighterDetecter : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    private EnemyController _enemyController;
    private SoldierController _soldierController;
    private int _enemyID;
    private void Start()
    {
        FindEnemyAsync().Forget();
    }

    public void SetID(int id) => _enemyID = id;

    private async UniTaskVoid FindEnemyAsync()
    {
        while (gameObject.activeSelf)
        {
            await UniTask.Delay(1000, false, PlayerLoopTiming.Update, gameObject.GetCancellationTokenOnDestroy());
            var objects = Physics2D.OverlapCircleAll(transform.position, 0.3f, _layerMask.value);
            if (objects.Length > 0)
            {
                objects.First().gameObject.TryGetComponent<SoldierCounter>(out SoldierCounter counter);
                if (counter != null)
                {
                    _enemyController.KillEnemyUnderID(_enemyID);
                    _soldierController.KillSoldierUnderID(counter.ID);
                    Destroy(objects.First().gameObject);
                    Destroy(gameObject);
                }
            }
        }
    }
    internal void Initialize(EnemyController enemyController, SoldierController soldierController)
    {
        _enemyController = enemyController;
        _soldierController = soldierController;
    }
}
