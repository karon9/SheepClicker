using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
//加算する金額
    public int value;
//Walletオブジェクト 目的地兼、加算対象
    public Wallet wallet;
//移動待ち時間
    private float waitTime;
// Start is called before the first frame update
    void Start()
    {
        waitTime = Random.Range(0.1f, 0.3f); //0.1秒～0.3秒のランダム
    }
// Update is called once per frame
    void Update()
    {
        waitTime -= Time.deltaTime; //カウントダウン
        if (waitTime > 0) return; //まだ待ち時間なので動かない
        var v = wallet.transform.position - transform.position;//現在の位置から、Walletオブジェクトまで進むベクトル
        transform.position += v * Time.deltaTime * 20;
        //近づいたら到着したとみなす
        if (v.magnitude < 0.5f)
        {
            wallet.money += value;
            Destroy(gameObject);
            SoundManager.Instance.Play("コイン");
        }
    }
}

