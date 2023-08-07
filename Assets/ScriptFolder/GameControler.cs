using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameControler : MonoBehaviour
{
    string chapter,chart;
    int LineEventNum;
    int linenums,notenums,BpmListLength;
    float offset;
    int[] lineid,typeid,alpha,notetype, beata, beatb, beatc, stbaLine, stbbLine, stbcLine, edbaLine, edbbLine, edbcLine, lineidNote, stba, stbb, stbc, edba, edbb, edbc, easingid, fake;
    float[] bpm,stval,edval,vistime;
    private float timerValue = 0;
    private float timerInterval;
    int IndexNote = 0;
    public GameObject Tap;
    public AudioSource Music;

    
    void Awake()
    {
        Music.Pause();
        
        //暂时设定
        chapter = "CPT1";
        chart = "chart";
        //主程序
        string ChartPath = MakeChartPath(chapter, chart);

        timerInterval = 1 / Convert.ToSingle(TimeSet(ChartPath));

        string complete = LoadChart(ChartPath);
        
        if(complete=="finish")
        {
            StartCoroutine("MandGStart");
            
        }
        
        

    }
    void Start()
    {
        
    }
    void Update()
    {
        StartCoroutine(IncrementTimer());
        float NOBnoteStart = stba[IndexNote] +stbb[IndexNote] / stbc[IndexNote];
        float NOBnoteEnd = edba[IndexNote] + edbb[IndexNote] / edba[IndexNote];

        if (notetype[IndexNote]!=3 &&timerValue>=NOBnoteStart)
        {
            Instantiate(Tap, new Vector3(0,0,0), Quaternion.identity);           
            IndexNote++;
        }


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
        yield return new WaitForSeconds(2);
        Music.Play();
    }
    //计时器
    private IEnumerator IncrementTimer()
    {
        while (true)
        {
            timerValue += timerInterval;
            Debug.Log(timerValue);
            yield return new WaitForSeconds(timerInterval); 
        }
    }

    //计时器设定
    public object TimeSet(string ChartPath)
    {
        string file = File.ReadAllText("/unity/spt/ChryshnarmOntology/Assets/ChartPackage/" + ChartPath);
        string[] first = file.Split('\n');
        string[] firstpart = first[0].Split(' ');
        float math = Convert.ToSingle(firstpart[4]) / 60;
        return math;
    }
    //铺面读取
    public string LoadChart(string ChartPath)
    {
        string file = File.ReadAllText("/unity/spt/ChryshnarmOntology/Assets/ChartPackage/" + ChartPath);
        string[] first = file.Split('\n');
        string[] firstpart = first[0].Split(' ');

        BpmListLength = Convert.ToInt32(firstpart[1]);
        linenums = Convert.ToInt32(firstpart[2]);
        notenums = Convert.ToInt32(firstpart[3]);
        offset = Convert.ToSingle(firstpart[4]);
        LineEventNum = first.Length - notenums - BpmListLength - 1;       

        OverloadArrays();

        int x = 0;
        int n = 0;
        int m = 0;

        for (int i = 1; i < first.Length; i++)
        {
            string[] parts = first[i].Split(' ');
            if (parts[0] == "1")
            {
                beata[x] = Convert.ToInt32(parts[1]);
                beatb[x] = Convert.ToInt32(parts[2]);
                beatc[x] = Convert.ToInt32(parts[3]);
                bpm[x] = Convert.ToSingle(parts[4]);
                x++;
            }
            else if (parts[0] == "2")
            {
                lineid[n] = Convert.ToInt32(parts[1]);
                typeid[n] = Convert.ToInt32(parts[2]);
                stbaLine[n] = Convert.ToInt32(parts[3]);
                stbbLine[n] = Convert.ToInt32(parts[4]);
                stbcLine[n] = Convert.ToInt32(parts[5]);
                edbaLine[n] = Convert.ToInt32(parts[6]);
                edbbLine[n] = Convert.ToInt32(parts[7]);
                edbcLine[n] = Convert.ToInt32(parts[8]);
                stval[n] = Convert.ToSingle(parts[9]);
                edval[n] = Convert.ToSingle(parts[10]);
                easingid[n] = Convert.ToInt32(parts[11]);
                n++;
            }
            else if (parts[0] == "3")
            {
                lineidNote[m] = Convert.ToInt32(parts[1]);
                stba[m] = Convert.ToInt32(parts[2]);
                stbb[m] = Convert.ToInt32(parts[3]);
                stbc[m] = Convert.ToInt32(parts[4]);
                edba[m] = Convert.ToInt32(parts[5]);
                edbb[m] = Convert.ToInt32(parts[6]);
                edbc[m] = Convert.ToInt32(parts[7]);
                notetype[m] = Convert.ToInt32(parts[8]);
                alpha[m] = Convert.ToInt32(parts[9]);
                vistime[m] = Convert.ToInt32(parts[10]);
                fake[m] = Convert.ToInt32(parts[11]);
                m++;
            }
        }
        return "finish";
    }

    public void OverloadArrays()
    {
        beata = new int[BpmListLength];
        beatb = new int[BpmListLength];
        beatc = new int[BpmListLength];
        bpm = new float[BpmListLength];

        stbaLine = new int[LineEventNum];
        stbbLine = new int[LineEventNum];
        stbcLine = new int[LineEventNum];
        edbaLine = new int[LineEventNum];
        edbbLine = new int[LineEventNum];
        edbcLine = new int[LineEventNum];
        stval = new float[LineEventNum];
        edval = new float[LineEventNum];
        easingid = new int[LineEventNum];
        lineid = new int[LineEventNum];
        typeid = new int[LineEventNum];

        lineidNote = new int[notenums];
        stba = new int[notenums];
        stbb = new int[notenums];
        stbc = new int[notenums];
        edba = new int[notenums];
        edbb = new int[notenums];
        edbc = new int[notenums];
        notetype = new int[notenums];
        alpha = new int[notenums];
        vistime = new float[notenums];
        fake = new int[notenums];
        
    }

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