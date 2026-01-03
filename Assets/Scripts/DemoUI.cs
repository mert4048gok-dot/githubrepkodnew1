using UnityEngine;

public class DemoUI : MonoBehaviour
{
    public GameManager gameManager;
    public Shop shop;

    void OnGUI()
    {
        if (gameManager == null || shop == null)
        {
            GUILayout.Label("GameManager veya Shop atanmamış.");
            return;
        }

        GUILayout.BeginVertical("box");
        GUILayout.Label("Phase: " + gameManager.phase);

        if (gameManager.phase == GameManager.Phase.Shop)
        {
            GUILayout.Label("Shop Offers:");
            GUILayout.BeginHorizontal();
            foreach (var c in shop.currentOffers)
            {
                if (c == null) continue;
                GUILayout.BeginVertical("box", GUILayout.Width(120));
                GUILayout.Label(c.displayName);
                GUILayout.Label("Cost: " + c.cost);
                if (GUILayout.Button("Buy"))
                {
                    gameManager.playerBoard.Add(c);
                }
                GUILayout.EndVertical();
            }
            GUILayout.EndHorizontal();

            if (GUILayout.Button("Roll")) shop.Roll();
            if (GUILayout.Button("Start Combat")) gameManager.StartCombat();
        }
        else if (gameManager.phase == GameManager.Phase.Combat)
        {
            GUILayout.Label("Combat in progress...");
        }
        else if (gameManager.phase == GameManager.Phase.Reward)
        {
            GUILayout.Label("Result shown in Console.");
            if (GUILayout.Button("Back to Shop")) gameManager.BackToShop();
        }

        GUILayout.EndVertical();
    }
}
