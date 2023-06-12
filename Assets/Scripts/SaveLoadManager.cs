using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
    // 保存対象①所持金用
    [SerializeField] private Wallet wallet;
    
    //保存対象②羊の頭数用
    [SerializeField] private Shop shop;

    private void OnApplicationQuit()
    {
        Debug.Log("セーブ");
        //所持金を保存
        PlayerPrefs.SetString("MONEY",wallet.money.ToString());
        //全ての羊の頭数を保存しておく
        for (var index = 0; index < shop.sheepButtonList.Count; index++)
        {
            var sheepButton = shop.sheepButtonList[index];
            PlayerPrefs.SetInt($"SHEEP{index}",sheepButton.currentCnt);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("ロード");
        
        
        //所持金をロード
        wallet.money = BigInteger.Parse(PlayerPrefs.GetString("MONEY", "0"));
        //全ての羊の頭数をロードする
        for (var index = 0; index < shop.sheepButtonList.Count; index++)
        {
            var sheepButton = shop.sheepButtonList[index];
            var sheepCnt = PlayerPrefs.GetInt($"SHEEP{index}", 0);
            sheepButton.currentCnt = sheepCnt;
            for (var i = 0; i < sheepCnt; i++)
            {
                sheepButton.sheepGenerator.CreateSheep(sheepButton.sheepData);
            }
        }
    }
}
