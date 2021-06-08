using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class sample : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI Text = null;

    public enum eTest
    {
        No0,
        No1,
        No2,
    }

    [System.Serializable]
    public class TestData
    {
        public int      ID;
        public string   Message;
        public bool     Flag;
        public eTest    Test;
        public int[]    Stage;
    }

    void Awake()
    {
        // clear
        updateLoadData(new TestData());
    }

    void updateLoadData(TestData data)
    {
        Text.SetText(
            $"ID = {data.ID}{Environment.NewLine}" +
            $"Message = '{data.Message}'{Environment.NewLine}" +
            $"Flag = {data.Flag}{Environment.NewLine}" +
            $"Test = {data.Test}{Environment.NewLine}"
        );
    }

    public void ClickButtonSave()
    {
        TestData savedata = new TestData()
        {
            ID = 10,
            Message = "TestData",
            Flag = true,
            Test = eTest.No1,
            Stage = new int[] { 1,2,3,4,5 },
        };

        jsonSaveLoad.Save("savedata", savedata);
    }

    public void ClickButtonLoad()
    {
        TestData loaddata = jsonSaveLoad.Load<TestData>("savedata");

        // display load data
        updateLoadData(loaddata);
    }
}
