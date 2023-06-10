using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Wool : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rigidbody2D;

    [SerializeField] private SpriteRenderer woolSpriteRenderer;
    
    //�r�т̐F
    public Color woolColor;

    //�r�т̔��p���i
    public int price = 100;

    //�r�т̔��p����
    public void Sell(Wallet wallet)
    {
        wallet.money += price;
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D.AddForce(Quaternion.Euler(0, 0,
        Random.Range(-15.0f, 15.0f)) * Vector2.up * 4,
        ForceMode2D.Impulse);
        transform.localScale = Vector3.one * Random.Range(0.4f, 1.5f);

        woolColor.a = 0.9f; //������Ɣ�������
        woolSpriteRenderer.color = woolColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -5)
        {
            Destroy(gameObject);
        }
    }
}
