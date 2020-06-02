//===============
//此脚本是初始化unityads的，需要自行开启unityads哦
//===============

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class InitADS : MonoBehaviour
{
    public string gameId = "3526482";

    private void Start()
    {
        Advertisement.Initialize(gameId);
        DontDestroyOnLoad(this);
        Invoke("GotoChooseLevelScene", 1);
    }

    public void GotoChooseLevelScene()
    {
        GameStateManager.instance.gameState = GameState.choose;
        SceneManager.LoadScene("Loading");
    }
}
