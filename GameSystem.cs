using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// 游戏系统  仅开发时或其他方面所用到的脚本
/// 即：并非游戏逻辑，是项目中使用较多的工具类
/// </summary>
public class GameSystem : MonoBehaviour
{
#if UNITY_EDITOR
    [MenuItem("WonkmyGame/删除存档")]
    public static void DeletePlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        ShowUnityWindow();
    }

    public static void ShowUnityWindow()
    {
        EditorUtility.DisplayDialog("系统通知", "删除存档完成！！！", "ok");
    }
#endif

    /// <summary>
    /// 安卓原生提示框
    /// </summary>
    /// <param name="info">要显示的内容</param>
    public void OnShowToast(string info)
    {
        AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");

        AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");

        AndroidJavaClass Toast = new AndroidJavaClass("android.widget.Toast");

        jo.Call("runOnUiThread", new AndroidJavaRunnable(() => {
            Toast.CallStatic<AndroidJavaObject>("makeText", jo, info, Toast.GetStatic<int>("LENGTH_LONG")).Call("show");
        }));
    }
}
