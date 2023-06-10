using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
//購入ボタンプレファブ
    [SerializeField]
    private SheepButton sheepButtonPrefab;
//生成元になる羊データ配列
    public SheepData[] sheepDatas;
//作成したSheepButtonをListで保持
    public List<SheepButton> sheepButtonList;
//SheepButtonにセットする羊生成オブジェクト
    [SerializeField] private SheepGenerator sheepGenerator;
//SheepButtonセットする所持金オブジェクト
    [SerializeField] private Wallet wallet;
// Start is called before the first frame update
    void Awake()
    {
//受け取ったSheepData入れ宇tの数だけSheepButtonを生成
        foreach(var sheepData in sheepDatas)
        {
            var sheepButton = Instantiate(sheepButtonPrefab, transform);
//transformを指定することで、子要素に生成
            sheepButton.sheepData = sheepData;
            sheepButtonList.Add(sheepButton);
            sheepButton.sheepGenerator = sheepGenerator;
            sheepButton.wallet = wallet;
        }
    }
// Update is called once per frame
    void Update()
    {
    }
}

