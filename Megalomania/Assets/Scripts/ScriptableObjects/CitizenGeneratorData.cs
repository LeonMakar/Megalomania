using UnityEngine;

[CreateAssetMenu(fileName = "CitizenGeneratorData" ,menuName = "ScriptableObjects/CitizenGenerator")]
public class CitizenGeneratorData : ScriptableObject
{
    public float Modificator;
    public float TimeToCreatNewCitizen;
    public int BaseGainingValue { get; private set; } = 8;

}
