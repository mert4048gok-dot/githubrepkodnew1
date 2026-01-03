using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class DemoSceneCreator
{
    [MenuItem("TFT/Create Demo Scene")]
    public static void CreateDemoScene()
    {
        var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);

        if (!AssetDatabase.IsValidFolder("Assets/Resources")) AssetDatabase.CreateFolder("Assets", "Resources");
        if (!AssetDatabase.IsValidFolder("Assets/Resources/Champions")) AssetDatabase.CreateFolder("Assets/Resources", "Champions");
        if (!AssetDatabase.IsValidFolder("Assets/Scenes")) AssetDatabase.CreateFolder("Assets", "Scenes");

        List<ChampionData> created = new List<ChampionData>();
        for (int i = 1; i <= 10; i++)
        {
            var cd = ScriptableObject.CreateInstance<ChampionData>();
            cd.id = "champ_" + i.ToString("D3");
            cd.displayName = "Şampiyon " + i;
            cd.cost = (i % 3) + 1;
            cd.health = 100 + i * 20;
            cd.attack = 10 + i * 2;
            cd.traits = new string[] { (i % 2 == 0) ? "Savaşçı" : "Mistik" };
            var ab = new Ability() { id = "ab_" + i, description = "Basit saldırı", damage = 5 + i, isAoE = false };
            cd.abilities = new Ability[] { ab };

            string path = $"Assets/Resources/Champions/{cd.id}.asset";
            AssetDatabase.CreateAsset(cd, path);
            created.Add(cd);
        }

        AssetDatabase.SaveAssets();

        var shopGO = new GameObject("Shop");
        var shop = shopGO.AddComponent<Shop>();
        shop.pool = created;

        var simGO = new GameObject("BattleSimulator");
        var sim = simGO.AddComponent<BattleSimulator>();

        var gmGO = new GameObject("GameManager");
        var gm = gmGO.AddComponent<GameManager>();
        gm.shop = shop;
        gm.simulator = sim;

        var uiGO = new GameObject("DemoUI");
        var ui = uiGO.AddComponent<DemoUI>();
        ui.gameManager = gm;
        ui.shop = shop;

        for (int i = 0; i < 3; i++)
        {
            gm.playerBoard.Add(created[i]);
            gm.enemyBoard.Add(created[i + 3]);
        }

        EditorSceneManager.MarkSceneDirty(scene);
        EditorSceneManager.SaveScene(scene, "Assets/Scenes/TFT_Demo.unity");
        AssetDatabase.Refresh();
        EditorUtility.DisplayDialog("TFT Demo", "Demo sahnesi oluşturuldu: Assets/Scenes/TFT_Demo.unity", "Tamam");
    }
}
