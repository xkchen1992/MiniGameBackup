using Mono.Xml;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security;
using System.Xml;
using UnityEngine;

public class LoadRes : MonoBehaviour {

    public XmlNode generalEventNode;
    public XmlNode oneKeyEventNode;
    public XmlNode doubleKeyEventNode;

    void LoadXml()
    {
        // 加载通用事件表
        string generalEventPath = Application.dataPath + "/Xml/general_event.xml";
        XmlDocument generalEventDoc = new XmlDocument();
        generalEventDoc.Load(generalEventPath);
        generalEventNode = generalEventDoc.SelectSingleNode("TGeneralEventTable_Tab");

        // 加载单key事件表
        string oneKeyEventPath = Application.dataPath + "/Xml/one_key_event.xml";
        XmlDocument oneKeyEventDoc = new XmlDocument();
        oneKeyEventDoc.Load(oneKeyEventPath);
        oneKeyEventNode = oneKeyEventDoc.SelectSingleNode("TOneKeyEventTable_Tab");

        // 加载双key事件表
        string doubleKeyEventPath = Application.dataPath + "/Xml/double_key_event.xml";
        XmlDocument doubleKeyEventDoc = new XmlDocument();
        doubleKeyEventDoc.Load(doubleKeyEventPath);
        doubleKeyEventNode = doubleKeyEventDoc.SelectSingleNode("TDoubleKeyEventTable_Tab");
    }

    void PrintGeneralEventTable()
    {
        print("\n --------General Event Table--------\n");

        foreach (XmlElement item in generalEventNode)
        {
            int id = int.Parse(item.ChildNodes[0].InnerText);
            int type = int.Parse(item.ChildNodes[1].InnerText);
            int money = int.Parse(item.ChildNodes[2].InnerText);
            int reputation = int.Parse(item.ChildNodes[3].InnerText);
  
            print("ID: " + id + " Type: " + type + " Money: " + money + " Reputation: " + reputation);
        }
    }

    void PrintOneKeyEventTable()
    {
        print("\n --------OneKey Event Table--------\n");

        foreach (XmlElement item in oneKeyEventNode)
        {
            int id = int.Parse(item.ChildNodes[0].InnerText);
            int type = int.Parse(item.ChildNodes[1].InnerText);
            int key = int.Parse(item.ChildNodes[2].InnerText);
            int withkeyMoney = int.Parse(item.ChildNodes[3].InnerText);
            int withkeyReputation = int.Parse(item.ChildNodes[4].InnerText);
            int withoutkeyMoney = int.Parse(item.ChildNodes[5].InnerText);
            int withoutkeyReputation = int.Parse(item.ChildNodes[6].InnerText);

            print("ID: " + id + " Type: " + type + " Key: " + key + " WithkeyMoney: " + withkeyMoney + " WithkeyReputation: " + withkeyReputation 
                + " WithoutkeyMoney: " + withoutkeyMoney + " WithoutkeyReputation: " + withoutkeyReputation);
        }
    }

    void PrintDoubleKeyEventTable()
    {
        print("\n --------DoubleKey Event Table--------\n");

        foreach (XmlElement item in doubleKeyEventNode)
        {
            int id = int.Parse(item.ChildNodes[0].InnerText);
            int type = int.Parse(item.ChildNodes[1].InnerText);
            int key1 = int.Parse(item.ChildNodes[2].InnerText);
            int key2 = int.Parse(item.ChildNodes[3].InnerText);
            int withkeyMoney = int.Parse(item.ChildNodes[4].InnerText);
            int withkeyReputation = int.Parse(item.ChildNodes[5].InnerText);
            int withoutkeyMoney = int.Parse(item.ChildNodes[6].InnerText);
            int withoutkeyReputation = int.Parse(item.ChildNodes[7].InnerText);

            print("ID: " + id + " Type: " + type + " Key1: " + key1 + " Key2: " + key2 + " WithkeyMoney: " + withkeyMoney + 
                " WithkeyReputation: " + withkeyReputation + " WithoutkeyMoney: " + withoutkeyMoney + " WithoutkeyReputation: " + withoutkeyReputation);
        }
    }

    // Use this for initialization
    void Start () {

        LoadXml();
        PrintGeneralEventTable();
        PrintOneKeyEventTable();
        PrintDoubleKeyEventTable();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

}
