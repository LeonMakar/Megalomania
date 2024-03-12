using UnityEngine;
public class BuildingView
{
    private int _stageIndex = -1;
    private int _woodToUpgrade;
    private int _stoneToUpgrade;
    private int _citizenToUpgrade;

    private Building _building;

    public BuildingView(Building building)
    {
        _building = building;


        _building.WoodUpgradeCount.text = _woodToUpgrade.ToString();
        _building.StoneUpgradeCount.text = _stoneToUpgrade.ToString();
        _building.CitizenUpgradeCount.text = _citizenToUpgrade.ToString();
    }


    public void ChangeBuildingStage()
    {

        if (_building.ConstructionStages.Count > _stageIndex)
        {
            _stageIndex++;
            _building.BuildingImage.sprite = _building.ConstructionStages[_stageIndex].ConstructionFinalSprite;
            _woodToUpgrade = _building.ConstructionStages[_stageIndex].WoodsForBuilding;
            _stoneToUpgrade = _building.ConstructionStages[_stageIndex].StonesForBuilding;
            _citizenToUpgrade = _building.ConstructionStages[_stageIndex].CitizensForBuilding;
            _building.WoodUpgradeCount.text = _woodToUpgrade.ToString();
            _building.StoneUpgradeCount.text = _stoneToUpgrade.ToString();
            _building.CitizenUpgradeCount.text = _citizenToUpgrade.ToString();
        }
        if (_building.ConstructionStages.Count <= _stageIndex)
        {
            _building.WoodUpgradeCount.text = string.Empty;
            _building.StoneUpgradeCount.text = string.Empty;
            _building.CitizenUpgradeCount.text = string.Empty;
        }
    }


    public void SetActiveUpgradeUIPart(bool boolian)
    {
        _building.UpgradeButtone.gameObject.SetActive(boolian);
        _building.WoodUpgradeCount.gameObject.SetActive(boolian);
        _building.StoneUpgradeCount.gameObject.SetActive(boolian);
        _building.CitizenUpgradeCount.gameObject.SetActive(boolian);
    }
}
