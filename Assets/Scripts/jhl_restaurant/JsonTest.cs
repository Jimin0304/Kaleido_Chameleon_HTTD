using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; //파일 입출력

public class JsonTest : MonoBehaviour
{
    public PlayerData playerData;       // 사용할 곳에 데이터 선언
    public GameData gameData;
    //[ContextMenu("To Json Data")]
    public void WriteJsonFile(){
        string path1 = Path.Combine(Application.persistentDataPath,"playerData.json");
        string path2 = Path.Combine(Application.persistentDataPath,"GameData.json"); // 경로 생성
        string path3 = Path.Combine(Application.persistentDataPath,"BuildingPos.json"); // 경로 생성
        string path4 = Path.Combine(Application.persistentDataPath,"DragonPos.json");   // 경로 생성
        string path5 = Path.Combine(Application.persistentDataPath,"DragonName.json");   // 경로 생성
        FileInfo fileInfo = new FileInfo(path1);

        if (!fileInfo.Exists){
            var data1 = new PlayerData();
            var data2 = new GameData();
            var data3 = new BuildingPos();
            var data4 = new DragonPos();
            var data5 = new DragonName();
            data1.score = 500;
            data2.score = 0;
            buildingPos();
            data4.x = 1.5698f;
            data4.y = 0.1f;
            data4.z = -9.0f;
            data5.name = "DragonSD_00";
            string overWritejsonData1 = JsonUtility.ToJson(data1);                // json로 형태 변환
            File.WriteAllText(path1, overWritejsonData1);                         // json 파일 생성

            string overWritejsonData2 = JsonUtility.ToJson(data2);                // json로 형태 변환
            File.WriteAllText(path2, overWritejsonData2);                         // json 파일 생성

            string overWritejsonData4 = JsonUtility.ToJson(data4);                // json로 형태 변환
            File.WriteAllText(path4, overWritejsonData4);                         // json 파일 생성

            string overWritejsonData5 = JsonUtility.ToJson(data5);                // json로 형태 변환
            File.WriteAllText(path5, overWritejsonData5);                         // json 파일 생성
        }      
    }
    public int LoadScoreDataFromJson(){
        string path = Path.Combine(Application.persistentDataPath,"playerData.json");
        string jsonData = File.ReadAllText(path);   
        var playerData = JsonUtility.FromJson<PlayerData>(jsonData);
        return playerData.score;
    }
    // //[ContextMenu("From Json Data")]
    public int LoadPlusDataFromJson(int inputscore){
        string path = Path.Combine(Application.persistentDataPath,"playerData.json"); // 경로 생성
        string jsonData = File.ReadAllText(path);                           // 파일 읽기
        var playerData = JsonUtility.FromJson<PlayerData>(jsonData);        // json 불러오기
        var data = new PlayerData();                                        // 새로운 데이터 생성
        var gameScore = inputscore;
        data.score = playerData.score + gameScore;                          // 더하기 플러스
        string overWritejsonData = JsonUtility.ToJson(data);                // json로 형태 변환
        File.WriteAllText(path, overWritejsonData);                         // json 파일 생성
        Debug.Log("LoadPlusDataFromJson : " + data.score);
        return data.score;
    }
    public int LoadMinusDataFromJson(int inputscore){
        string path = Path.Combine(Application.persistentDataPath,"playerData.json"); // 경로 생성
        string jsonData = File.ReadAllText(path);                           // 파일 읽기
        var playerData = JsonUtility.FromJson<PlayerData>(jsonData);        // json 불러오기
        
        var data = new PlayerData();                                        // 새로운 데이터 생성
        var gameScore = inputscore;
        data.score = playerData.score - gameScore;                          // 빼기 마이너스
        
        string overWritejsonData = JsonUtility.ToJson(data);                // json로 형태 변환
        File.WriteAllText(path, overWritejsonData);                         // json 파일 생성
        return data.score;
    }
    public int LoadGamePlusDataFromJson(int inputscore){                    // 게임 마지막에 죽으면
        string path = Path.Combine(Application.persistentDataPath,"GameData.json");   // 경로 생성
        // string jsonData = File.ReadAllText(path);                           // 파일 읽기
        // var gameData = JsonUtility.FromJson<GameData>(jsonData);            // json 불러오기
        // Debug.Log(gameData.score);
        var data = new GameData();                                          // 새로운 데이터 생성
        var gameScore = inputscore;
        data.score = gameScore;                                             // 게임 스코어
        string overWritejsonData = JsonUtility.ToJson(data);                // json로 형태 변환
        File.WriteAllText(path, overWritejsonData);                         
        var result = LoadPlusDataFromJson(data.score); 
        Debug.Log("result : " + result);                                       // 기존 코인에 더하기
        return result;
    }
    public int LoadGameDataFromJson(){                                      // EndGame
        string path = Path.Combine(Application.persistentDataPath,"GameData.json");   // 경로 생성
        string jsonData = File.ReadAllText(path);                           // 파일 읽기, 몇 점 인지 불러오기
        var gameData = JsonUtility.FromJson<GameData>(jsonData);            // json 불러오기
        return gameData.score;
    }
    public void SaveDragonPos(string tag){
        string buildingpath = Path.Combine(Application.persistentDataPath,"BuildingPos.json");   // 경로 생성
        string path = Path.Combine(Application.persistentDataPath,"DragonPos.json");   // 경로 생성
        
        string jsonData = File.ReadAllText(buildingpath);                           // 파일 읽기, 몇 점 인지 불러오기
        var gameData = JsonUtility.FromJson<BuildingPos>(jsonData);
        var data = new DragonPos(); 
        if(tag == "Dogam")
        {
            data.x = gameData.Dogam.x;
            data.y = gameData.Dogam.y;
            data.z = gameData.Dogam.z;
        }
        else if (tag == "Playgame")
        {
            data.x = gameData.Playgame.x;
            data.y = gameData.Playgame.y;
            data.z = gameData.Playgame.z;
            
        }
        else if (tag == "Hospital")
        {
            data.x = gameData.Hospital.x;
            data.y = gameData.Hospital.y;
            data.z = gameData.Hospital.z;
        }
        else if (tag == "Restaurant")
        {
            data.x = gameData.Restaurant.x;
            data.y = gameData.Restaurant.y;
            data.z = gameData.Restaurant.z;
        }
        else if (tag == "Random")
        {
            data.x = gameData.Random.x;
            data.y = gameData.Random.y;
            data.z = gameData.Random.z;
        }
        string overWritejsonData = JsonUtility.ToJson(data);                // json로 형태 변환
        File.WriteAllText(path, overWritejsonData);          
    }
    public Vector3 GetDragonPos(){
        Vector3 pos;
        string path = Path.Combine(Application.persistentDataPath,"DragonPos.json");   // 경로 생성
        string jsonData = File.ReadAllText(path);                           // 파일 읽기, 몇 점 인지 불러오기
        var gameData = JsonUtility.FromJson<DragonPos>(jsonData);            // json 불러오기
        pos.x = gameData.x;
        pos.y = gameData.y;
        pos.z = gameData.z;
        return pos;
    }
    public void buildingPos(){
        string path = Path.Combine(Application.persistentDataPath,"BuildingPos.json");   // 경로 생성
        var data = new BuildingPos();
        data.Dogam = new Vector3(0.6f,0.1f,-4.8f);    
        data.Playgame = new Vector3(6.0f,0.1f,-5.2f);    
        data.Hospital = new Vector3(-2.0f,0.1f,7.0f); 
        data.Restaurant = new Vector3(-5.3f,0.1f,-2.5f);
        data.Random = new Vector3(1.8f,0.1f,1.7f);
        data.defaultPose = new Vector3(1.5698f,0.1f,-9.0f);
        string overWritejsonData = JsonUtility.ToJson(data);                // json로 형태 변환     
        File.WriteAllText(path, overWritejsonData);      
    }
    public string GetDragonName(){
        string path = Path.Combine(Application.persistentDataPath,"DragonName.json");   // 경로 생성
        string jsonData = File.ReadAllText(path);                           // 파일 읽기, 몇 점 인지 불러오기
        var gameData = JsonUtility.FromJson<DragonName>(jsonData);            // json 불러오기
        return gameData.name;
    }
    public void SaveDragonName(string name){
        string path = Path.Combine(Application.persistentDataPath,"DragonName.json");   // 경로 생성
        var data = new DragonName();
        data.name = name;
        string overWritejsonData = JsonUtility.ToJson(data);                // json로 형태 변환     
        File.WriteAllText(path, overWritejsonData);      
    }
}


public class PlayerData{        //데이터 형태 생성
    public int score;
}
public class GameData{        //데이터 형태 생성
    public int score;
}
public class DragonPos{
    public float x;
    public float y;
    public float z;
}
public class BuildingPos{
    public Vector3 Dogam;
    public Vector3 Playgame;
    public Vector3 Hospital;
    public Vector3 Restaurant;
    public Vector3 Random;
    public Vector3 defaultPose;
}
public class DragonName{
    public string name;
}