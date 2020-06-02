using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGameData : MonoBehaviour
{
    /// <summary>
    /// 解析json配置文件
    /// </summary>
    /// <param name="fileName">要解析的文件名称，无须后缀名.json</param>
    public void ParseJsonFile(string fileName)
    {
        //文本为在Unity里面是 TextAsset类型
        //items = new Dictionary<int, ItemsInfoData>();
        TextAsset itemText = Resources.Load<TextAsset>(fileName);
        string itemsJson = itemText.text;//物品信息的Json格式
        JSONObject j = new JSONObject(itemsJson);
        foreach (JSONObject temp in j.list)
        {
            int itemid = (int)(temp["itemid"].n);//id
            int cost = (int)(temp["cost"].n);//花费
            string itemName = (temp["itemName"].str);//物品名字
            int holdAmount = (int)temp["holdAmount"].n;//可持有数
            string itemStyle = temp["itemStyle"].str;//物品类型
            //items.Add(itemid, new ItemsInfoData(itemid, cost, itemName, itemStyle, holdAmount));
        }
    }
}
