using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Datas
{
    public int Id;
    private int data;

    public int Data
    {
        get { return data; }
        set
        {
            data = value;
            DataBits = data;
        }
    }

    private int dataBits;

    public int DataBits
    {
        get { return dataBits; }
        private set
        {
            var tempData = data;
            while (tempData > 0)
            {
                tempData >>= 1;
                dataBits++;
            }
        }
    }
    public int dataMask;
    public int shiftBitCount;

}
public class SaveAndLoadSystem : MonoBehaviour
{
    private int counter = 0;
    private int packed;
    private int maskPacked;
    public List<Datas> datas = new List<Datas>();

    private static SaveAndLoadSystem _instance;
    public static SaveAndLoadSystem Instance => _instance ?? (_instance = new SaveAndLoadSystem());

    private SaveAndLoadSystem()
    {
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(Instance.datas.Count);
    }

    public void AddDatas(Datas data)
    {
        var existIdData = Instance.datas.Find(x => x.Id == data.Id);
        if (existIdData.Id > 0)
        {
            Instance.datas.Remove(existIdData);
            Instance.datas.Add(data);
            //For Test
            SaveDatas();
        }
        else
        {
            Instance.datas.Add(data);
            //For Test
            SaveDatas();
        }
    }


    public void SaveDatas()
    {
        for (int i = 0; i < Instance.datas.Count; i++)
        {
            counter += Instance.datas[i].DataBits;

            if (counter <= 32)
            {
                BitPacking(Instance.datas[i], counter);
            }
        }
    }

    private void BitPacking(Datas datas, int bitCounter)
    {
        int counter = 1;
        var power = datas.DataBits;
        packed = packed | (datas.Data << (31 - bitCounter));
        while (power >= 0)
        {
            datas.dataMask |= ((int)Mathf.Pow(2, power));

            counter++;
            power--;
        }
        maskPacked = maskPacked | (datas.dataMask << (31 - bitCounter));
        datas.shiftBitCount = 31 - bitCounter;
        //Debug.Log(Convert.ToString(packed, 2).PadLeft(32, '0'));
        //Debug.Log(Convert.ToString(maskPacked, 2).PadLeft(32, '0'));
        //Debug.Log(Convert.ToString(datas.dataMask, 2).PadLeft(32, '0'));

        BitUnPacking(datas);
    }
    private int BitUnPacking(Datas datas)
    {
        var unPacking = (maskPacked & packed) >> datas.shiftBitCount;

        Debug.Log(Convert.ToString(unPacking, 2).PadLeft(32, '0'));
        return unPacking;
    }

}
