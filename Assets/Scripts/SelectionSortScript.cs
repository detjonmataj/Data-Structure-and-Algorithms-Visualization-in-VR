using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.UI;
using TMPro;
using System;

public class SelectionSortScript : MonoBehaviour
{

    private readonly int maxLength = 10;
    private readonly int maxNumber = 999;
    private readonly int minNumber = -999;
    private GameObject[] objects;
    public GameObject Cube;

    // Start is called before the first frame update
    public void Start()
    {
        initializeRandom();
        StartCoroutine(selectionSortASC(objects));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void initializeRandom()
    {
        int length = UnityEngine.Random.Range(1, maxLength);
        // length = 10;
        objects = new GameObject[length];
        int randomNumber;

        for (int i = 0; i < length; i++)
        {
            randomNumber = UnityEngine.Random.Range(minNumber, maxNumber);
            // GameObject cube = GameObject.CreatePrimitive(PrimitiveType.NodePrefab);
            // cube.transform.localScale = new Vector3(1.5f, 1.5f, 0.001f);
            // cube.transform.position = new Vector3((i * 1.75f), 0.4f, 0);
            // cube.transform.SetParent(this.transform);
            // objects[i] = cube;
            objects[i] = GameObject.Instantiate(Cube, new Vector3((i * 1.75f), 1.0f, 0), Quaternion.identity);
            objects[i].transform.SetParent(this.transform);
            objects[i].transform.localScale = new Vector3(1.5f, 1.5f, 0.001f);
            objects[i].GetComponentInChildren<TextMeshPro>().text = randomNumber.ToString();
            objects[i].GetComponentInChildren<TextMeshPro>().color = Color.black;
        }

        transform.position = new Vector3(-length / 2, 5 / 2f, 0);

    }

    IEnumerator selectionSortASC(GameObject[] unsortedList)
    {
        int minIndex;
        GameObject temp;
        // Vector3 tempPosition;

        for(int i = 0; i < unsortedList.Length; i++)
        {
            LeanTween.color(unsortedList[i], Color.blue, 1f);
            // yield return new WaitForSeconds(1);
            minIndex = i;
            // LeanTween.color(unsortedList[i], Color.red, 1f);
            yield return new WaitForSeconds(1);
            for(int j = i + 1; j < unsortedList.Length; j++)
            {

                yield return new WaitForSeconds(1);
                LeanTween.color(unsortedList[j], Color.yellow, 1f);
                yield return new WaitForSeconds(1);
                if (Int32.Parse(unsortedList[j].GetComponentInChildren<TextMeshPro>().text) < Int32.Parse(unsortedList[minIndex].GetComponentInChildren<TextMeshPro>().text))
                {
                   
                    if (minIndex == i)
                    {
                        LeanTween.color(unsortedList[i], Color.blue, 1f);
                    } else
                    {
                        LeanTween.color(unsortedList[minIndex], Color.white, 1f);
                    }
                    yield return new WaitForSeconds(1);
                    minIndex = j;
                    LeanTween.color(unsortedList[j], Color.red, 1f);
                } else
                {
                    LeanTween.color(unsortedList[j], Color.white, 1f);
                    yield return new WaitForSeconds(1);
                }
            }
            if (minIndex != i)
            {
                yield return new WaitForSeconds(1);
                temp = unsortedList[i];
                unsortedList[i] = unsortedList[minIndex];
                unsortedList[minIndex] = temp;

                LeanTween.moveLocalY(unsortedList[i], unsortedList[i].transform.localPosition.y - 1.6f, .75f);
                LeanTween.moveLocalY(unsortedList[minIndex], unsortedList[i].transform.localPosition.y + 1.6f, .75f);
                yield return new WaitForSeconds(1f);

                LeanTween.moveLocalX(unsortedList[i], unsortedList[minIndex].transform.localPosition.x, 1);
                LeanTween.moveLocalX(unsortedList[minIndex], unsortedList[i].transform.localPosition.x, 1);
                yield return new WaitForSeconds(1);
                LeanTween.moveLocalY(unsortedList[i], unsortedList[i].transform.localPosition.y + 1.6f, .75f);
                LeanTween.moveLocalY(unsortedList[minIndex], unsortedList[minIndex].transform.localPosition.y - 1.6f, .75f);
                yield return new WaitForSeconds(1);
                LeanTween.color(unsortedList[minIndex], Color.white, 1f);

                // LeanTween.moveLocalZ(unsortedList[i], -3, .5f).setLoopPingPong(1);

                // LeanTween.moveLocalZ(unsortedList[minIndex], 3, .5f).setLoopPingPong(1);

                // unsortedList[i].transform.localPosition = new Vector3(unsortedList[minIndex].transform.localPosition.x, tempPosition.y, tempPosition.z);
                // unsortedList[minIndex].transform.localPosition = new Vector3(tempPosition.x, unsortedList[minIndex].transform.localPosition.y, unsortedList[minIndex].transform.localPosition.z);
            }
            yield return new WaitForSeconds(.75f);
            LeanTween.color(unsortedList[i], Color.green, 1f);
        }
    }

}
