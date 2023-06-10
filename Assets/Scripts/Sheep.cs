using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer sheepRenderer;

    [SerializeField]
    private Sprite cutSheepSprite;

    [SerializeField]
    private Wool woolPrefab;

    //最初の羊の画像
    private Sprite defaultSprite;

    //移動速度
    private float moveSpeed;

    //羊の初期データ
    public SheepData sheepData;

    //羊毛の量
    private int woolCnt;

    //初期化処理
    private void Initialize()
    {
        sheepRenderer.sprite = defaultSprite;
        transform.position = new Vector3(5, Random.Range(0.0f, 4.0f), 0); //初期位置をセット
        moveSpeed = -Random.Range(1.0f, 2.0f); //移動速度をセット

        sheepRenderer.color = sheepData.color; //色のセット
        woolCnt = sheepData.woolCnt; //羊毛の量
    }


    // Start is called before the first frame update
    void Start()
    {
        defaultSprite = sheepRenderer.sprite;
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(moveSpeed, 0) * Time.deltaTime;
        if (transform.position.x < -5)
        {
            Initialize();
        }
    }

    private void Shaving()
    {
        if (woolCnt <= 0) return; //もう刈り取れる羊毛はないので何もしない
        var shavingWool = (int)(sheepData.woolCnt *Random.Range(0.3f, 0.4f)); //3~40%の羊毛を刈り取る
        if (woolCnt < shavingWool) shavingWool = woolCnt; //今羊に残っている羊毛より多い羊毛は取れないので、上限

        woolCnt -= shavingWool; //今回刈り取る分を保持している羊毛から減らし

        if (woolCnt <= 0)
        {
            sheepRenderer.sprite = cutSheepSprite; //画像をカットされたものに差し替え
            sheepRenderer.color = Color.white; //毛はもうないので色を白に戻す
        }

        var wool = Instantiate(woolPrefab,transform.position, transform.rotation);//TODO Woolオブジェクトに今回刈り取った羊毛と色情報を渡す
        wool.price = shavingWool;
        wool.woolColor = sheepData.color;
    }


    private void OnMouseOver()
    {
        if (Input.GetMouseButton(0) == false)
            return;
        Shaving();
    }
}
