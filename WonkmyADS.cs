using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class WonkmyADS : MonoBehaviour
{

    public static WonkmyADS instance;

    public GameObject quitGameUI;
    public GameObject menuUI;
    public GameObject listLevelUI;

    private void Awake()
    {
        instance = this;
    }

    
    private void Start()
    {
        StartCoroutine(ShowBannerWhenReady());
    }

    IEnumerator ShowBannerWhenReady()
    {
        while (!Advertisement.IsReady("myban"))
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Show("myban");
    }
    /// <summary>
    /// 播放视频，可跳过，无任何奖励
    /// </summary>
    public void ShowADs()
    {
        if (Advertisement.IsReady("video"))
        {
            Advertisement.Show("video");
        }
    }

    /// <summary>
    /// 播放有回报的视频，不可跳过
    /// </summary>
    public void ShowRewardedAd()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("rewardedVideo", options);
        }
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                //视频播放成功
                GameManager.instance.ShowHint();
                break;
            case ShowResult.Skipped:
                //视频跳过播放
                break;
            case ShowResult.Failed:
                #if !UNITY_EDITOR
                GameStateManager.instance.OnShowToast("暂时无法播放视频,请稍后再试哦~");
#endif
                //视频播放错误
                break;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!menuUI.activeSelf) {//如果菜单界面没有显示
                if (listLevelUI.activeSelf)
                {
                    listLevelUI.SetActive(false);
                    menuUI.SetActive(true);
                }
                else
                {
                    listLevelUI.SetActive(true);
                    menuUI.SetActive(false);
                }
            }
            else
            {
                if (!quitGameUI.activeSelf)
                {
                    quitGameUI.SetActive(true);
                }
                else
                {
                    quitGameUI.SetActive(false);
                }
            }
        }
    }

}
