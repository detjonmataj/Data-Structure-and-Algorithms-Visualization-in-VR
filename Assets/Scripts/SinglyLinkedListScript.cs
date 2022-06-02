using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SinglyLinkedListScript : MonoBehaviour
{

    private readonly int maxLength = 10;
    private readonly int maxNumber = 999;
    private readonly int minNumber = -999;
    private GameObject[] nodes;
    private GameObject[] links;
    public GameObject node;
    public GameObject link;
    public GameObject nullTxt;
    public GameObject Head;
    public GameObject Tail;

    private GameObject HeadLink;
    private GameObject TailLink;
    private GameObject HeadLabel;
    private GameObject TailLabel;

    // Start is called before the first frame update
    void Start()
    {
        // InitializeRandom();
    }

    public void InitializeRandom()
    {
        int length = UnityEngine.Random.Range(1, maxLength);
        // length = 10;
        nodes = new GameObject[maxLength];
        links = new GameObject[maxLength];
        int randomNumber;

        for (int i = 0; i < length; i++)
        {
            randomNumber = Random.Range(minNumber, maxNumber);
            nodes[i] = GameObject.Instantiate(node, new Vector3((i * 1.2f), 1.0f, 0), Quaternion.identity);
            nodes[i].transform.SetParent(this.transform);
            nodes[i].transform.localScale = new Vector3(0.6f, 0.6f, 0.001f);
            nodes[i].GetComponentInChildren<TextMeshPro>().text = randomNumber.ToString();
            nodes[i].GetComponentInChildren<TextMeshPro>().color = Color.black;

            if(i == 0)
            {
                HeadLabel = GameObject.Instantiate(Head, new Vector3((i * 1.2f), 2f, 0), Quaternion.identity);
                HeadLabel.transform.localScale = new Vector3(1.2f, 1.2f, 0.001f);
                HeadLabel.transform.SetParent(this.transform);
                HeadLink = GameObject.Instantiate(link, new Vector3((i * 1.2f), 1.6f, 0), Quaternion.identity);
                HeadLink.transform.Rotate(0.0f, 0.0f, -90.0f);
                HeadLink.transform.localScale = new Vector3(0.2f, 0.2f, 0.001f);
                HeadLink.transform.SetParent(this.transform);
            }

            links[i] = GameObject.Instantiate(link, new Vector3(nodes[i].transform.localPosition.x, 1.0f, 0), Quaternion.identity);
            if (i == length - 1)
            {
                var nullText = GameObject.Instantiate(nullTxt, new Vector3(nodes[i].transform.localPosition.x + 0.8f, 0.95f, 0), Quaternion.identity);
                nullText.transform.localScale = new Vector3(1.5f, 1.5f, 0.001f);
                nullText.transform.SetParent(this.transform);

                TailLabel = GameObject.Instantiate(Tail, new Vector3((i * 1.2f), 2f, 0), Quaternion.identity);
                TailLabel.transform.localScale = new Vector3(1.2f, 1.2f, 0.001f);
                TailLabel.transform.SetParent(this.transform);
                TailLink = GameObject.Instantiate(link, new Vector3((i * 1.2f), 1.6f, 0), Quaternion.identity);
                TailLink.transform.Rotate(0.0f, 0.0f, -90.0f);
                TailLink.transform.localScale = new Vector3(0.2f, 0.2f, 0.001f);
                TailLink.transform.SetParent(this.transform);
            }
            links[i].transform.localScale = new Vector3(0.2f, 0.2f, 0.001f);
            links[i].transform.SetParent(this.transform);
        }

        transform.position = new Vector3(-length / 2, 5 / 2f, 0);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
