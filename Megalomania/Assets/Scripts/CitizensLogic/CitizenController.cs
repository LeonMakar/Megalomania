using System.Collections.Generic;
using System.Linq;

public class CitizenController
{
    private List<Citizen> _citizensList = new List<Citizen>();
    private Citizen.Factory _citizenFactory;
    private EventBus _eventBus;

    public CitizenController(Citizen.Factory factory, EventBus eventBus)
    {
        _citizenFactory = factory;
        _eventBus = eventBus;

        _citizensList.Add(_citizenFactory.Create());
    }

    public void SetCitizenToWork(WorkType workType)
    {
        var citizen = _citizensList.FirstOrDefault();
        citizen.ChangeWorkCondition(workType).Forget();
        _eventBus.Invoke(new OnSetWorkToCitizenSignal(false));
    }

}
