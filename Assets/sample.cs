using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class sample : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI dataPath = null;
    [SerializeField]
    TextMeshProUGUI classdata = null;
    [SerializeField]
    TextMeshProUGUI click = null;

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

    const string filename = "savedata";

    void Awake()
    {
        dataPath.SetText(Path.Combine(Application.persistentDataPath, filename));

        // clear
        classdata.SetText("");
    }

    public void ClickButtonSave()
    {
        click.SetText("* SAVE *");
        classdata.SetText("");

        TestData savedata = new TestData()
        {
            ID = 10,
            Message = "TestData",
            Flag = true,
            Test = eTest.No1,
            Stage = new int[] { 1,2,3,4,5 },
        };

        jsonSaveLoad.Save(filename, savedata);
    }

    public void ClickButtonLoad()
    {
        classdata.SetText("");

        TestData loaddata = jsonSaveLoad.Load<TestData>(filename);

        // display load data
        if (loaddata == null)
        {
            click.SetText("* LOAD ERROR *");
        }
        else
        {
            click.SetText("* LOAD *");
            classdata.SetText(
                $"ID = {loaddata.ID}{Environment.NewLine}" +
                $"Message = '{loaddata.Message}'{Environment.NewLine}" +
                $"Flag = {loaddata.Flag}{Environment.NewLine}" +
                $"Test = {loaddata.Test}{Environment.NewLine}"
            );
        }
    }

    public void ClickButtonDelete()
    {
        click.SetText("* DELETE *");
        classdata.SetText("");

        jsonSaveLoad.Delete(filename);
    }
}
