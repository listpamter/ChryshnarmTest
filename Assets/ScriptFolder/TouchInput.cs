
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    List<float> 点击x = new List<float>();
    List<float> 点击y = new List<float>();
    List<float> 触摸x = new List<float>();
    List<float> 触摸y = new List<float>();
    //滑动部分
    List<float> 滑动x = new List<float>();
    List<float> 滑动y = new List<float>();
    List<float> 滑动lastX = new List<float>();
    List<float> 滑动lastY = new List<float>();
    /*public GameObject 触控点;
    List<GameObject> 点击位置;*/
    void Update()
    {
        Ray M射线 = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit1;
        if (Physics.Raycast(M射线, out hit1))
        {
            //鼠标模拟
            if (Input.GetMouseButtonDown(0))
            {
                触摸x.Add(hit1.point.x);
                触摸y.Add(hit1.point.y);
            }
            if (Input.GetMouseButton(0))
            {
                点击x.Add(hit1.point.x);
                点击y.Add(hit1.point.y);
            }
            if (滑动lastX.Contains(hit1.point.x) && 滑动lastY.Contains(hit1.point.y) && Input.GetMouseButtonDown(0))
            {
                滑动x.Add(hit1.point.x);
                滑动y.Add(hit1.point.x);
            }

            foreach (Touch 手势 in Input.touches)
            {
                foreach (float a in 触摸x)
                {
                    滑动lastX.Add(a);
                }
                foreach (float b in 触摸y)
                {
                    滑动lastY.Add(b);
                }
                //X坐标清理
                滑动x.Clear();
                滑动lastX.Clear();
                点击x.Clear();
                触摸x.Clear();
                //Y坐标清理        
                滑动y.Clear();
                滑动lastY.Clear();
                点击y.Clear();
                触摸y.Clear();
                //手势触控
                Ray 射线 = Camera.main.ScreenPointToRay(手势.position);
                RaycastHit hit;
                if (Physics.Raycast(射线, out hit))
                {
                    触摸x.Add(hit.point.x);
                    触摸y.Add(hit.point.y);
                    if (手势.phase == TouchPhase.Began)
                    {
                        点击x.Add(hit.point.x);
                        点击y.Add(hit.point.y);
                    }
                    if (滑动lastX.Contains(hit.point.x) && 滑动lastY.Contains(hit.point.y) && 手势.phase == TouchPhase.Moved)
                    {
                        滑动x.Add(hit.point.x);
                        滑动y.Add(hit.point.x);
                      
                    }
                    //生成辅助点
                    /*for (int i = 0; i < 触摸x.Count; i++)
                    {
                        if (i == 点击位置.Count)
                        {
                            GameObject gameObject = Instantiate(触控点, new Vector3(0, 0, 0), Quaternion.identity);
                            点击位置.Add(gameObject);
                        }
                        Vector3 位置 = 点击位置[i].transform.position;
                        位置.x = 触摸x[i];
                        位置.y = 触摸y[i];
                        点击位置[i].transform.position = 位置;                       
                    }
                    for (int i = 触摸x.Count; i < 点击位置.Count;)
                    {
                        Destroy(点击位置[i]);
                        点击位置.RemoveAt(i);
                    }*/
                }
            }
        }
    }
}

