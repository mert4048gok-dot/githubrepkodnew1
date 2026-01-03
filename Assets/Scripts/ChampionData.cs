using UnityEngine;

[CreateAssetMenu(fileName = "ChampionData", menuName = "TFT/ChampionData", order = 1)]
public class ChampionData : ScriptableObject
{
    public string id;
    public string displayName;
    public int cost = 1;
    public int health = 100;
    public int attack = 10;
    public int armor = 0;
    public float attackSpeed = 1f;
    public Ability[] abilities;
    public string[] traits;
}
