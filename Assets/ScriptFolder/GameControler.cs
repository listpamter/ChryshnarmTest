using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.ConstrainedExecution;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameControler : MonoBehaviour
{


    string chapter,chart;
  
    bool start = false;

    float musicTime;
    float beat;

    public static int IndexNote = 0;
    int IndexBpm = 0;

    public GameObject Tap;
    public GameObject line;

    public AudioSource Music;
   void Awake()
   {
       Music.Pause();
       line.name = "line0";
       //暂时设定
       chapter = "CPT1";
       chart = "chart";
       //主程序
       string ChartPath = MakeChartPath(chapter, chart);
       string complete = LoadChart.loadChart(ChartPath);       
       if(complete=="finish")
       {
           StartCoroutine("MandGStart");
           start = true;
       }
   }
    void Start()
    {
        Music= GetComponent<AudioSource>(); 
    }
    void Update()
    {
        
        transformer.IndexNoteM = IndexNote;
        if (start)
        {
            Beat();
            CreateNote();
            musicTime=Music.time;
            //Debug.Log(musicTime);
            BpmListCheck();
        }      
    }
    public void Beat()
    {
        beat = (musicTime * LoadChart.bpm[IndexBpm] * 2f) / 60f;
        transformer.globalOffset = LoadChart.bpm[IndexBpm] / 60f + (LoadChart.offset * LoadChart.bpm[IndexBpm]) / 1000f;
        transformer.globalBeat = beat;
        Debug.Log(beat);
    }
    //生成判定线
    public void CreateLine()
    {
        for (int i = 1; i < LoadChart.linenums+1; i++)
        {
            Instantiate(line, new Vector3(0, 0, 0), Quaternion.identity);
            line.name="line"+i.ToString();
        }
    }
    //生成音符
    public void CreateNote()
    {      
        float NOBnoteStart = LoadChart.stba[IndexNote] + LoadChart.stbb[IndexNote] / LoadChart.stbc[IndexNote];
        float NOBnoteEnd = LoadChart.edba[IndexNote] + LoadChart.edbb[IndexNote] / LoadChart.edba[IndexNote];
        
        
        if (LoadChart.notetype[IndexNote] != 3 && beat >= NOBnoteStart)
        {
            
            Instantiate(Tap, new Vector3(0, 0, 0), Quaternion.identity);
            
            IndexNote++;
        }
    }
    //bpm列表检测
    public void BpmListCheck()
    {
        if(LoadChart.BpmListLength > 1) 
        { 
            float bpmStamp = LoadChart.beata[IndexBpm + 1] + LoadChart.beatb[IndexBpm + 1] / LoadChart.beatc[IndexBpm + 1];
            if(beat >= bpmStamp)
            {
                IndexBpm++;
            }
        }
        transformer.IndexBpmM = IndexBpm;
    }
    //组合铺面路径
    public string MakeChartPath(string chapter,string chart)
    {
        string ChartPath = chapter + "/" + chart + ".cecf";
        return ChartPath;
    }
    //铺面播放等待
    IEnumerator MandGStart()
    {
        CreateLine();
        yield return new WaitForSeconds(2);
        Music.Play();
        
    }
    //铺面读取
    
}




/*[System.Serializable]
public class ChartData
{
    public string id;
    public string time;
    public string PosX;
    public string PosY;
    public string speedX;
    public string speedY;
    public string line;
    public string turn;
    public string type;
}
[System.Serializable]
public class ChartDataItems
{
    public ChartData[] note;
}
*/



/*ChartDataItems first = JsonUtility.FromJson<ChartDataItems>(file);

foreach(ChartData chartData in first.note)
{


}
*/

/*  }

  // Update is called once per frame
  void Update()
  {

  }


}
*/