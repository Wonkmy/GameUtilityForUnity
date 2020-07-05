using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.GameFoundation;
using UnityEngine.GameFoundation.DefaultLayers;


public enum FundationType {
    inventory,
    money
}
/// <summary>
/// unity自带背包系统和游戏货币管理系统控制器
/// </summary>
public class FundationCtrl : MonoBehaviour
{
    public FundationType fundationType;
    public void Start()
    {
        var datalayer = new MemoryDataLayer();
        //初始化游戏基础系统
        GameFoundation.Initialize(datalayer, OnloadFinish, OnInitFailed);
    }

    void OnloadFinish()
    {
        if (fundationType == FundationType.money)
        {
            InitMoney();
        }
        if (fundationType == FundationType.inventory)
        {
            InitInventory();
        }
    }

    public static void InitMoney()
    {
        Debug.Log("Game Foundation is successfully initialized");

        const string definitionId = "coin";

        var catalog = GameFoundation.catalogs.currencyCatalog;

        var definition = catalog.FindItem(definitionId);

        if (definition is null)
        {
            Debug.Log($"Definition {definitionId} not found");
            return;
        }

        Debug.Log($"Definition {definition.key} ({definition.type}) '{definition.displayName}' found.");

        var balance = WalletManager.GetBalance(definition);
        Debug.Log($"The balance of '{definition.displayName}' is {balance}");

        TestBalance(definition);
    }

    public static void InitInventory()
    {
        Debug.Log("Game Foundation is successfully initialized");
        //声明你在库存编辑器窗口中设置的item key
        const string definitionId = "wonkmy_test";
        //获得库存目录
        var catalog = GameFoundation.catalogs.inventoryCatalog;
        //从库存目录中寻找指定id的item的定义
        var definition = catalog.FindItem(definitionId);

        if (definition is null)
        {
            Debug.Log($"Definition {definitionId} not found");
            return;
        }

        Debug.Log($"Definition {definition.key} '{definition.displayName}' found.");
        //通过库存管理器创建一个寻找到的并已经定义好的item
        var item = InventoryManager.CreateItem(definition);
        
        Debug.Log($"Item {item.id} of definition '{item.definition.key}' created");
    }

    public static void TestBalance(Currency c)
    {
        SetMoney(c, 600);//设置钱

        AddMoney(c, 100);//添加钱

        var newBalance = GetMoney(c);//获得钱
    }
    /// <summary>
    /// 添加钱
    /// </summary>
    /// <param name="c"></param>
    /// <param name="num"></param>
    public static void AddMoney(Currency c,long num)
    {
        WalletManager.AddBalance(c, num);
    }

    /// <summary>
    /// 获得钱
    /// </summary>
    /// <param name="c"></param>
    /// <param name="num"></param>
    /// <returns></returns>
    public static long GetMoney(Currency c)
    {
       return WalletManager.GetBalance(c);
    }
    /// <summary>
    /// 设置钱
    /// </summary>
    /// <param name="c"></param>
    /// <param name="num"></param>
    public static void SetMoney(Currency c, long num) {
        WalletManager.SetBalance(c, num);
    }

    void OnInitFailed(Exception error)
    { 
        
    }
}
