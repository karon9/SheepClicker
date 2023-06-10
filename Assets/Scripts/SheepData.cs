using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SheepData : ScriptableObject
{
    /// <summary>
    /// �r�̐F
    /// </summary>
    public Color color;
    /// <summary>
    /// �����l�i
    /// </summary>
    public int basePrice;
    /// <summary>
    /// �l�i�㏸�z
    /// </summary>
    public int extendPrice;
    /// <summary>
    /// �w�������
    /// </summary>
    public int maxCount;
    /// <summary>
    /// �r�т̗�
    /// </summary>
    public int woolCnt;
}
