using System.Collections.Generic;
using UnityEngine;

public class BattleSimulator : MonoBehaviour
{
    // Basit simülasyon: toplam saldırı gücünü hesaplayıp kazananı belirler.
    public void Simulate(List<ChampionData> leftBoard, List<ChampionData> rightBoard)
    {
        int leftPower = 0;
        int rightPower = 0;

        foreach (var c in leftBoard)
        {
            if (c == null) continue;
            leftPower += c.attack + c.health / 10;
        }

        foreach (var c in rightBoard)
        {
            if (c == null) continue;
            rightPower += c.attack + c.health / 10;
        }

        if (leftPower == rightPower)
        {
            Debug.Log("Battle result: Draw");
        }
        else if (leftPower > rightPower)
        {
            Debug.Log("Battle result: Left wins");
        }
        else
        {
            Debug.Log("Battle result: Right wins");
        }
    }
}
