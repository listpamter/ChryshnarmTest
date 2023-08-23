using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements.Experimental;


public static class LoadChart
{
   
    public static int LineEventNum;
    public static int linenums, notenums, BpmListLength;
    public static float offset;
    public static int[] lineid, typeid, alpha, notetype, beata, beatb, beatc, stbaLine, stbbLine, stbcLine, edbaLine, edbbLine, edbcLine, lineidNote, stba, stbb, stbc, edba, edbb, edbc, easingid, fake;
    public static float[] bpm, stval, edval, vistime;

    public static string loadChart(string ChartPath)
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

    public static void OverloadArrays()
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
