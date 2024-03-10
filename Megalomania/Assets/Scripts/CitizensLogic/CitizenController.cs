using System.Collections.Generic;
using System.Linq;

public class CitizenController
{
    private List<Citizen> _citizensList = new List<Citizen>();
    private Citizen.Factory _citizenFactory;

    public CitizenController(Citizen.Factory factory)
    {
        _citizenFactory = factory;

        _citizensList.Add(_citizenFactory.Create());
    }

    public void SetCitizenToWork(WorkType workType)
    {
        var citizen = _citizensList.FirstOrDefault();
        citizen.ChangeWorkCondition(workType).Forget();
    }

}
