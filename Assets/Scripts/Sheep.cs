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

    //�ŏ��̗r�̉摜
    private Sprite defaultSprite;

    //�ړ����x
    private float moveSpeed;

    //�r�̏����f�[�^
    public SheepData sheepData;

    //�r�т̗�
    private int woolCnt;

    //����������
    private void Initialize()
    {
        sheepRenderer.sprite = defaultSprite;
        transform.position = new Vector3(5, Random.Range(0.0f, 4.0f), 0); //�����ʒu���Z�b�g
        moveSpeed = -Random.Range(1.0f, 2.0f); //�ړ����x���Z�b�g

        sheepRenderer.color = sheepData.color; //�F�̃Z�b�g
        woolCnt = sheepData.woolCnt; //�r�т̗�
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
        if (woolCnt <= 0) return; //�����������r�т͂Ȃ��̂ŉ������Ȃ�
        var shavingWool = (int)(sheepData.woolCnt *Random.Range(0.3f, 0.4f)); //3~40%�̗r�т�������
        if (woolCnt < shavingWool) shavingWool = woolCnt; //���r�Ɏc���Ă���r�т�葽���r�т͎��Ȃ��̂ŁA���

        woolCnt -= shavingWool; //���񊠂��镪��ێ����Ă���r�т��猸�炵

        if (woolCnt <= 0)
        {
            sheepRenderer.sprite = cutSheepSprite; //�摜���J�b�g���ꂽ���̂ɍ����ւ�
            sheepRenderer.color = Color.white; //�т͂����Ȃ��̂ŐF�𔒂ɖ߂�
        }

        var wool = Instantiate(woolPrefab,transform.position, transform.rotation);//TODO Wool�I�u�W�F�N�g�ɍ��񊠂������r�тƐF����n��
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
