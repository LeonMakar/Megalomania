public class BuildingView
{


    private Building _building;

    public BuildingView(Building building)
    {
        _building = building;


        _building.WoodUpgradeCount.text = _building.WoodToUpgrade.ToString();
        _building.StoneUpgradeCount.text = _building.StoneToUpgrade.ToString();
        _building.CitizenUpgradeCount.text = _building.CitizenToUpgrade.ToString();
    }


    public bool ChangeBuildingStage()
    {

        if (_building.ConstructionStages.Count > _building.StageIndex)
        {
            if (_building.CheckAllParametersForBuilding())
            {
                _building.CitizenController.UpgradeBuilding(_building.ConstructionStages[_building.StageIndex].CitizensForBuilding);
                _building.StageIndex++;
                _building.BuildingImage.sprite = _building.ConstructionStages[_building.StageIndex].ConstructionFinalSprite;
                _building.WoodToUpgrade = _building.ConstructionStages[_building.StageIndex].WoodsForBuilding;
                _building.StoneToUpgrade = _building.ConstructionStages[_building.StageIndex].StonesForBuilding;
                _building.CitizenToUpgrade = _building.ConstructionStages[_building.StageIndex].CitizensForBuilding;
                _building.SoldierToAdd = _building.ConstructionStages[_building.StageIndex].SoldierToGet;
                _building.WoodUpgradeCount.text = _building.WoodToUpgrade.ToString();
                _building.StoneUpgradeCount.text = _building.StoneToUpgrade.ToString();
                _building.CitizenUpgradeCount.text = _building.CitizenToUpgrade.ToString();

                _building.RestartAllParameters();
                return true;
            }

        }
        if (_building.ConstructionStages.Count <= _building.StageIndex)
        {
            _building.WoodUpgradeCount.text = string.Empty;
            _building.StoneUpgradeCount.text = string.Empty;
            _building.CitizenUpgradeCount.text = string.Empty;
            return false;
        }
        return false;
    }


    public void SetActiveUpgradeUIPart(bool boolian)
    {
        _building.UpgradeButtone.gameObject.SetActive(boolian);
        _building.WoodUpgradeCount.gameObject.SetActive(boolian);
        _building.StoneUpgradeCount.gameObject.SetActive(boolian);
        _building.CitizenUpgradeCount.gameObject.SetActive(boolian);
    }
}
