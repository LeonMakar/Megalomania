using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class CitizenController
{
    private Stack<Citizen> _freeCitizens = new Stack<Citizen>();
    private List<Citizen> _workingCitizens = new List<Citizen>();
    private Citizen.Factory _citizenFactory;
    private EventBus _eventBus;
    private CitizenSimulatorFactory _citizenSimulatorFactory;
    private Collider2D _mainBuildingCollider;
    private TextMeshProUGUI _notation;

    public CitizenController(Citizen.Factory factory, EventBus eventBus, CitizenSimulatorFactory citizenSimulationFactory,
        Collider2D castleCollider, TextMeshProUGUI notation)
    {
        _citizenFactory = factory;
        _eventBus = eventBus;
        _citizenSimulatorFactory = citizenSimulationFactory;
        _mainBuildingCollider = castleCollider;
        _notation = notation;
    }

    public void AddNewCitizen()
    {
        var citizen = _citizenFactory.Create();
        _freeCitizens.Push(citizen);
        citizen.AddToCitizenSimulator(_citizenSimulatorFactory.Create());
        citizen.SetNewDestination(Calculation.GetRandomePointInsideCollider(_mainBuildingCollider));
        _eventBus.Invoke(new OnAddedNewCitizenSignal(1));
    }

    public int GetFreeCitizens()
    {
        return _freeCitizens.Count;
    }

    public void SetCitizenToWork(WorkType workType, Collider2D workingArea)
    {
        _freeCitizens.TryPop(out Citizen result);
        if (result != null)
        {
            var citizen = result;
            _workingCitizens.Add(result);
            result.ChangeWorkCondition(workType).Forget();
            result.SetNewDestination(Calculation.GetRandomePointInsideCollider(workingArea));
            _eventBus.Invoke(new OnSetWorkToCitizenSignal(false));
        }
        else
        {
            SetNewTextAsync("Havent Free Citizens").Forget();
        }
    }

    public void ResetCitizenWork(WorkType workType)
    {
        Citizen citizenInCurrentWork;
        switch (workType)
        {
            case WorkType.WoodWork:
                citizenInCurrentWork = _workingCitizens.FirstOrDefault(citizen => citizen.GeneratingResourceType == ResourcesType.Wood);
                FireCitizenFromHisWork(citizenInCurrentWork);
                break;
            case WorkType.StoneWork:
                citizenInCurrentWork = _workingCitizens.FirstOrDefault(citizen => citizen.GeneratingResourceType == ResourcesType.Stone);
                FireCitizenFromHisWork(citizenInCurrentWork);
                break;
        }
        _eventBus.Invoke(new OnResetWorkOfCitizenSignal(false));
    }

    private void FireCitizenFromHisWork(Citizen citizen)
    {
        if (citizen == null)
        {
            SetNewTextAsync("Non Working Citizens").Forget();
            return;
        }

        citizen.StopMining();
        _freeCitizens.Push(citizen);
        _workingCitizens.Remove(citizen);
        citizen.SetNewDestination(Calculation.GetRandomePointInsideCollider(_mainBuildingCollider));
    }
    private async UniTaskVoid SetNewTextAsync(string text)
    {
        _notation.text = text;
        await UniTask.Delay(2000);
        _notation.text = string.Empty;
    }
}
