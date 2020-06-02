//======================
//专门用来制作有加载界面的游戏项目  将此脚本挂载在加载界面，并进行相应的修改即可
//======================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// 加载中...
/// </summary>
public class LodingScene : MonoBehaviour {

    AsyncOperation async;
    public Slider m_pProgress;
    private int progress = 0;
    public Text lodingNum;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(LoadScenes());
    }
    IEnumerator LoadScenes()
    {
        int nDisPlayProgress = 0;
        if(GameStateManager.instance.gameState==GameState.choose)
        {
            async = SceneManager.LoadSceneAsync("ChooseLevel");
        }
        if(GameStateManager.instance.gameState == GameState.main)
        {
            async = SceneManager.LoadSceneAsync("MainScene");
        }
        
        async.allowSceneActivation = false;
        while (async.progress < 0.9f)
        {
            progress = (int)async.progress * 100;
            while (nDisPlayProgress < progress)
            {
                ++nDisPlayProgress;
                m_pProgress.value = (float)nDisPlayProgress / 100;
                lodingNum.text = (m_pProgress.value*100).ToString() + "%";
                yield return new WaitForEndOfFrame();
            }
            yield return null;
        }
        progress = 100;
        while (nDisPlayProgress < progress)
        {
            ++nDisPlayProgress;
            m_pProgress.value = (float)nDisPlayProgress / 100;
            lodingNum.text = (m_pProgress.value * 100).ToString() + "%";
            yield return new WaitForEndOfFrame();
        }
        async.allowSceneActivation = true;

    }
}
