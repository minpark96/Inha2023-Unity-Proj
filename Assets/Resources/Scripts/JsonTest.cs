using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;

public class PlayerInfo
{
    public int ID;
    public string Name;
    public double Gold;

    public PlayerInfo(int id, string name, double gold)
    {
        ID = id;
        Name = name;
        Gold = gold;

    }
}

public class JsonTest : MonoBehaviour
{
    public List<PlayerInfo> playerinfoList = new List<PlayerInfo>();

    void Start()
    {
        //SavePlayerInfo();
        LoadPlayerInfo();
    }

    public void SavePlayerInfo()
    {
        Debug.Log("SavePlayerInfo()");

        playerinfoList.Add(new PlayerInfo(1, "이름1", 1001));
        playerinfoList.Add(new PlayerInfo(2, "이름2", 1002));
        playerinfoList.Add(new PlayerInfo(3, "이름3", 1003));
        playerinfoList.Add(new PlayerInfo(4, "이름4", 1004));
        playerinfoList.Add(new PlayerInfo(5, "이름5", 1005));

        JsonData infoJson = JsonMapper.ToJson(playerinfoList);
        File.WriteAllText(Application.dataPath + "/Resources/Data/PlayerInfoData.json", infoJson.ToString());
    }

    public void LoadPlayerInfo()
    {
        Debug.Log("LoadPlayerInfo()");
        if (File.Exists(Application.dataPath + "/Resources/Data/PlayerInfoData.json"))
        {
            string jsonString = File.ReadAllText(Application.dataPath + "/Resources/Data/PlayerInfoData.json");
            Debug.Log(jsonString);

            JsonData playerData = JsonMapper.ToObject(jsonString);
            ParsingJsonPlayerInfo(playerData);
        }

    }

    void ParsingJsonPlayerInfo(JsonData data)
    {
        Debug.Log("ParsingJsonPlayerInfo()");

        for (int i = 0; i < data.Count; i++)
        {
            print(data[i]["ID"].ToString() + " , " +
                data[i]["Name"] + " , " +
                data[i]["Gold"]
                );

            int id = (int)data[i]["ID"];
            print(id.ToString());
            double gold = (double)data[i]["Gold"];
            print(gold.ToString());
        }
    }

    void Update()
    {
        
    }
}
