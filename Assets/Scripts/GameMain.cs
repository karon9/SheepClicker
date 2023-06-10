using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameMain : MonoBehaviour
{


    [SerializeField]
    private Button sellButton;
    [SerializeField]
    private Wallet wallet;

    private void SellAllWool()
    {
        var wools = FindObjectsOfType<Wool>(); //画面上の全てのWoolスクリプトが付いたオブジェクトを検索してWool配列woolsに格納
foreach (var wool in wools)
        {
            wool.Sell(wallet);
        }
    }
        // Start is called before the first frame update
        void Start()
    {
        sellButton.onClick.AddListener(SellAllWool);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
