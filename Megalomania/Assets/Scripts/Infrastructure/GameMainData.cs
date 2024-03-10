using UnityEngine;

[CreateAssetMenu(fileName ="GameMainData",menuName = "ScriptableObjects")]
public class GameMainData : ScriptableObject
{
    [Header("Resources adding value")]
    [Tooltip("How much wood will be mined at a time")]
    public int StoneAddingValue;
    [Tooltip("How much stone will be mined at a time")]
    public int WoodAddingValue;

    [Space(20),Header("Resources mining interval")]

    [Tooltip("How often wood will mine (In milliseconds)")]
    public int WoodAddingInterval;
    [Tooltip("How often stone will mine (In milliseconds)")]
    public int StoneAddingInterval;


}
