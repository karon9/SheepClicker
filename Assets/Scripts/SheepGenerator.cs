using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepGenerator : MonoBehaviour
{
    [SerializeField]
    private Sheep sheepPrefab; //��������r��Prefab

    //�r�쐬
    public void CreateSheep()
    {
        var sheep = Instantiate(sheepPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            CreateSheep();
        }
        
    }
}
