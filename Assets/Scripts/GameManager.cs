using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Shop shop;
    public BattleSimulator simulator;

    public List<ChampionData> playerBoard = new List<ChampionData>();
    public List<ChampionData> enemyBoard = new List<ChampionData>();

    public enum Phase { Shop, Combat, Reward }
    public Phase phase = Phase.Shop;

    void Start()
    {
        if (shop != null) shop.Roll();
    }

    public void StartCombat()
    {
        phase = Phase.Combat;
        if (simulator != null) simulator.Simulate(playerBoard, enemyBoard);
        phase = Phase.Reward;
    }

    public void BackToShop()
    {
        phase = Phase.Shop;
        if (shop != null) shop.Roll();
    }
}
