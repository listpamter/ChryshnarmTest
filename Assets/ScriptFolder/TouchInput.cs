
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    List<float> ���x = new List<float>();
    List<float> ���y = new List<float>();
    List<float> ����x = new List<float>();
    List<float> ����y = new List<float>();
    //��������
    List<float> ����x = new List<float>();
    List<float> ����y = new List<float>();
    List<float> ����lastX = new List<float>();
    List<float> ����lastY = new List<float>();
    /*public GameObject ���ص�;
    List<GameObject> ���λ��;*/
    void Update()
    {
        Ray M���� = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit1;
        if (Physics.Raycast(M����, out hit1))
        {
            //���ģ��
            if (Input.GetMouseButtonDown(0))
            {
                ����x.Add(hit1.point.x);
                ����y.Add(hit1.point.y);
            }
            if (Input.GetMouseButton(0))
            {
                ���x.Add(hit1.point.x);
                ���y.Add(hit1.point.y);
            }
            if (����lastX.Contains(hit1.point.x) && ����lastY.Contains(hit1.point.y) && Input.GetMouseButtonDown(0))
            {
                ����x.Add(hit1.point.x);
                ����y.Add(hit1.point.x);
            }

            foreach (Touch ���� in Input.touches)
            {
                foreach (float a in ����x)
                {
                    ����lastX.Add(a);
                }
                foreach (float b in ����y)
                {
                    ����lastY.Add(b);
                }
                //X��������
                ����x.Clear();
                ����lastX.Clear();
                ���x.Clear();
                ����x.Clear();
                //Y��������        
                ����y.Clear();
                ����lastY.Clear();
                ���y.Clear();
                ����y.Clear();
                //���ƴ���
                Ray ���� = Camera.main.ScreenPointToRay(����.position);
                RaycastHit hit;
                if (Physics.Raycast(����, out hit))
                {
                    ����x.Add(hit.point.x);
                    ����y.Add(hit.point.y);
                    if (����.phase == TouchPhase.Began)
                    {
                        ���x.Add(hit.point.x);
                        ���y.Add(hit.point.y);
                    }
                    if (����lastX.Contains(hit.point.x) && ����lastY.Contains(hit.point.y) && ����.phase == TouchPhase.Moved)
                    {
                        ����x.Add(hit.point.x);
                        ����y.Add(hit.point.x);
                      
                    }
                    //���ɸ�����
                    /*for (int i = 0; i < ����x.Count; i++)
                    {
                        if (i == ���λ��.Count)
                        {
                            GameObject gameObject = Instantiate(���ص�, new Vector3(0, 0, 0), Quaternion.identity);
                            ���λ��.Add(gameObject);
                        }
                        Vector3 λ�� = ���λ��[i].transform.position;
                        λ��.x = ����x[i];
                        λ��.y = ����y[i];
                        ���λ��[i].transform.position = λ��;                       
                    }
                    for (int i = ����x.Count; i < ���λ��.Count;)
                    {
                        Destroy(���λ��[i]);
                        ���λ��.RemoveAt(i);
                    }*/
                }
            }
        }
    }
}

