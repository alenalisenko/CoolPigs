using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.UI;

public class ProgrammingObj : MonoBehaviour
{
    public InputField codeText;
    public Vector3 startPos;
    private bool isOneTriger = false;
    private bool isHold1 = false;

    public void isRun()
    {
        StartCoroutine(delay());
        
    }

    public void Start()
    {
        Cursor.visible = true;
    }

    IEnumerator delay()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        transform.position = startPos;
        string code = codeText.text;
        code = code.Replace("\n", "");
        code = code.Replace(" ", "");
        string[] linesCode = code.Split(";");
        foreach (string i in linesCode)
        {
            string[] lineFun = i.Split('{');
            lineFun[1] = lineFun[1].Replace("}", "");
            string[] lineZnachName = lineFun[0].Split("(");
            lineZnachName[1] = lineZnachName[1].Replace(")", "");
            if (lineZnachName[0] == "near")
            {
                string[] znchNear = lineZnachName[1].Split(",");
                string tagEmpty = znchNear[0];
                string emptyDistance = znchNear[1];
                string[] lineFunctiy = lineFun[1].Split(",");
                bool isPrvk = true;
                foreach (var str in lineFunctiy)
                {
                    string dosplit = str.Replace(")", "");
                    string[] line = dosplit.Split("(");
                    if (isPrvk)
                    {
                        yield return new WaitUntil(()=> Physics.CheckSphere(transform.position, Convert.ToInt32(emptyDistance), LayerMask.GetMask(tagEmpty)));
                        isPrvk = false;
                    }
                    if (line[0] == "move")
                    {
                        for (int j = 0; j < Convert.ToInt32(line[1]); j++)
                        {
                            transform.position += transform.forward;
                            yield return new WaitForSeconds(0.25f);
                        }
                    }
                    else if (line[0] == "rotate")
                    {
                        Vector3 rotate = transform.eulerAngles;
                        rotate.y = Convert.ToInt32(line[1]);
                        transform.rotation = Quaternion.Euler(rotate);
                    }
                    else if (line[0] == "hold")
                    {
                        isHold1 = true;
                    }
                }
            }
            else if (lineZnachName[0] == "start")
            {
                string[] znchNear = lineZnachName[1].Split(",");
                string[] lineFunctiy = lineFun[1].Split(",");
                foreach (var str in lineFunctiy)
                {
                    string dosplit = str.Replace(")", "");
                    string[] line = dosplit.Split("(");
                    if (line[0] == "move")
                    {
                        for (int j = 0; j < Convert.ToInt32(line[1]); j++)
                        {
                            transform.position += transform.forward;
                            yield return new WaitForSeconds(0.25f);
                        }
                    }
                    else if (line[0] == "rotate")
                    {
                        Vector3 rotate = transform.eulerAngles;
                        rotate.y = Convert.ToInt32(line[1]);
                        transform.rotation = Quaternion.Euler(rotate);
                    }
                    else if (line[0] == "hold")
                    {
                        isHold1 = true;
                    }
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "key") // не key, а триггер должен называтся
        {
            isOneTriger = true;
            Destroy(other.gameObject);
            isHold1 = false;
        }
        else if (other.CompareTag("Finish") && isOneTriger)
        {
            Debug.Log("win");
        }
    }
}
