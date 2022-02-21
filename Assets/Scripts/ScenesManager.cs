using System;
using System.Collections.Generic;
using UnityEngine;

public class ScenesManager : MonoBehaviour
{
    public List<string> sceneNames;
    private string mainGame = "MainGame";
    private string menu = "Menu";

    private void Awake()
    {
        sceneNames.Add(mainGame);
        sceneNames.Add(menu);
    }

    public string GetSceneName(string scene)
    {
        if (sceneNames.Contains(scene)) return scene;
        else throw new Exception("Scene name doesn't exist"); 
    }
}
