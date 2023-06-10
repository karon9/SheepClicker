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
        var wools = FindObjectsOfType<Wool>(); //��ʏ�̑S�Ă�Wool�X�N���v�g���t�����I�u�W�F�N�g����������Wool�z��wools�Ɋi�[
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
