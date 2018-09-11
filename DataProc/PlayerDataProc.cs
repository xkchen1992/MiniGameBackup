using Mono.Xml;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security;
using System.Xml;
using UnityEngine;

public class PlayerDataProc : MonoBehaviour {

    void CreatePlayerDB()
    {
        string path = Application.dataPath + "/Xml/palyerDB.xml";
        if (!File.Exists(path))
        {
            //创建最上一层的节点。
            XmlDocument xml = new XmlDocument();
            XmlElement root = xml.CreateElement("Players");
            //创建子节点
            XmlElement element = xml.CreateElement("Player");
       
            XmlElement elementName = xml.CreateElement("Name");
            elementName.InnerText = "neilxkchen";

            XmlElement elementPasword = xml.CreateElement("Pasword");
            elementPasword.InnerText = "hello world";
            //把节点一层一层的添加至xml中，注意他们之间的先后顺序，这是生成XML文件的顺序
            element.AppendChild(elementName);
            element.AppendChild(elementPasword);
            root.AppendChild(element);
            xml.AppendChild(root);
            //最后保存文件
            xml.Save(path);
        }
    }

    void addPlayerData(string name, string password)
    {
        string path = Application.dataPath + "/Xml/palyerDB.xml";
        if (File.Exists(path))
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(path);
            XmlNode root = xml.SelectSingleNode("Players");
            
            XmlElement element = xml.CreateElement("Player");
           
            XmlElement elementName = xml.CreateElement("Name");
            elementName.InnerText = name;

            XmlElement elementPasword = xml.CreateElement("Pasword");
            elementPasword.InnerText = password;
            //把节点一层一层的添加至xml中，注意他们之间的先后顺序，这是生成XML文件的顺序
            element.AppendChild(elementName);
            element.AppendChild(elementPasword);

            root.AppendChild(element);

            xml.AppendChild(root);
            //最后保存文件
            xml.Save(path);
        }
    }

    //修改
    void updatePlayerData(string name, string password)
    {
        string path = Application.dataPath + "/Xml/palyerDB.xml";
        if (File.Exists(path))
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(path);
            XmlNodeList xmlNodeList = xml.SelectSingleNode("Players").ChildNodes;
            foreach (XmlElement xl1 in xmlNodeList)
            {
                if (0 == name.CompareTo(xl1.ChildNodes[0].InnerText))
                {
                    xl1.ChildNodes[1].InnerText = password;
                }
            }
            xml.Save(path);
        }
    }

    // Use this for initialization
    void Start () {
        CreatePlayerDB();
        addPlayerData("xkchen", "1234");
        updatePlayerData("xkchen", "4321");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
