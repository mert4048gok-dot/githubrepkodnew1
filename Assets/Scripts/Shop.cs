using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [Tooltip("Pool of all available champions for this shop")] public List<ChampionData> pool = new List<ChampionData>();
    public List<ChampionData> currentOffers = new List<ChampionData>();
    public int rollCount = 5;

    public void Roll()
    {
        currentOffers.Clear();
        if (pool == null || pool.Count == 0) return;
        for (int i = 0; i < rollCount; i++)
        {
            var c = pool[Random.Range(0, pool.Count)];
            currentOffers.Add(c);
        }
    }
}
