using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapScript : MonoBehaviour
{
    bool add = true, remove = true;
    
    void Start()
    {       
        GameObject lineN = GameObject.Find("line" + LoadChart.lineidNote[transformer.IndexNoteM] + "(Clone)");
        this.transform.parent = lineN.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float beat = transformer.globalBeat + transformer.globalOffset;
        float beatStamp = LoadChart.stba[transformer.IndexNoteM] + LoadChart.stbb[transformer.IndexNoteM] / LoadChart.stbc[transformer.IndexNoteM];
        if (add && Mathf.Abs(beatStamp - beat) > (0.06f * LoadChart.bpm[transformer.IndexBpmM] * 2f) / 60f)
        {

        }
        else if(remove)
        {

        }

    }
}
