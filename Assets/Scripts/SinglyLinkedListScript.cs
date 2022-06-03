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
    public GameObject newNodeText;
    public GameObject nullTxt;
    public GameObject Head;
    public GameObject Tail;

    private GameObject HeadLink;
    private GameObject TailLink;
    private GameObject HeadLabel;
    private GameObject TailLabel;
    private GameObject NullText;

    private GameObject newNode;
    private GameObject newNodeLabel;
    private GameObject newNodeLinker;
    private int length;

    private bool hasObject = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void InitializeRandom()
    {
        if(hasObject)
        {
            CleanObjects();
        }

        hasObject = true;
        length = Random.Range(2, maxLength);
        //length = 10;
        nodes = new GameObject[100];
        links = new GameObject[100];
        
        int randomNumber;

        for (int i = 0; i < length; i++)
        {
            randomNumber = Random.Range(minNumber, maxNumber);
            nodes[i] = GameObject.Instantiate(node, new Vector3((i * 1.2f)+0.6f, 1.0f, 0), Quaternion.identity);
            nodes[i].transform.SetParent(this.transform);
            nodes[i].transform.localScale = new Vector3(0.6f, 0.6f, 0.001f);
            nodes[i].GetComponentInChildren<TextMeshPro>().text = randomNumber.ToString();
            nodes[i].GetComponentInChildren<TextMeshPro>().color = Color.black;
            nodes[i].transform.localPosition = new Vector3((i * 1.2f) + 0.6f, 1.0f, 0);

            if (i == 0)
            {
                HeadLabel = GameObject.Instantiate(Head, new Vector3((i * 1.2f), 2f, 0), Quaternion.identity);
                HeadLabel.transform.localScale = new Vector3(1.2f, 1.2f, 0.001f);
                HeadLabel.transform.SetParent(this.transform);
                HeadLink = GameObject.Instantiate(link, new Vector3((i * 1.2f), 1.6f, 0), Quaternion.identity);
                HeadLink.transform.Rotate(0.0f, 0.0f, -90.0f);
                HeadLink.transform.localScale = new Vector3(0.2f, 0.2f, 0.001f);
                HeadLink.transform.SetParent(this.transform);

                HeadLabel.transform.localPosition = new Vector3((i * 1.2f) + 0.6f, 2f, 0);
                HeadLink.transform.localPosition = new Vector3((i * 1.2f) + 0.6f, 1.6f, 0);
            }

            links[i] = GameObject.Instantiate(link, new Vector3(nodes[i].transform.localPosition.x, 1.0f, 0), Quaternion.identity);
            if (i == length - 1)
            {
                NullText = GameObject.Instantiate(nullTxt, new Vector3(nodes[i].transform.localPosition.x + 0.8f, 0.95f, 0), Quaternion.identity);
                NullText.transform.localScale = new Vector3(1.5f, 1.5f, 0.001f);
                NullText.transform.SetParent(this.transform);
                NullText.transform.localPosition = new Vector3(nodes[i].transform.localPosition.x + 1.4f, 0.95f, 0);

                TailLabel = GameObject.Instantiate(Tail, new Vector3((i * 1.2f), 2f, 0), Quaternion.identity);
                TailLabel.transform.localScale = new Vector3(1.2f, 1.2f, 0.001f);
                TailLabel.transform.SetParent(this.transform);
                TailLabel.transform.localPosition = new Vector3((i * 1.2f)+0.6f, 2f, 0);

                TailLink = GameObject.Instantiate(link, new Vector3(i * 1.2f, 1.6f, 0), Quaternion.identity);
                TailLink.transform.Rotate(0.0f, 0.0f, -90.0f);
                TailLink.transform.localScale = new Vector3(0.2f, 0.2f, 0.001f);
                TailLink.transform.SetParent(this.transform);
                TailLink.transform.localPosition = new Vector3((i * 1.2f) + 0.6f, 1.6f, 0);
            }
            links[i].transform.localScale = new Vector3(0.2f, 0.2f, 0.001f);
            links[i].transform.SetParent(this.transform);
            links[i].transform.localPosition = new Vector3((i * 1.2f) + 1.2f, 1.0f, 0);
        }

        transform.position = new Vector3(-length / 2, 5 / 2f, 0);
    }

    public IEnumerator Append()
    {
        yield return new WaitForSeconds(1);

    }

    public void Prepend(int number)
    {
        StartCoroutine(PrependUtil(number));
    }
    private IEnumerator PrependUtil(int number)
    {

        newNode = Instantiate(node, new Vector3(nodes[0].transform.localPosition.x, -0.14f, 0), Quaternion.identity);
        newNode.transform.SetParent(this.transform);
        newNode.transform.localScale = new Vector3(0.6f, 0.6f, 0.001f);
        newNode.GetComponentInChildren<TextMeshPro>().text = number.ToString();
        newNode.GetComponentInChildren<TextMeshPro>().color = Color.black;
        newNode.transform.localPosition = new Vector3(nodes[0].transform.localPosition.x, -0.14f, 0);

        newNodeLabel = Instantiate(newNodeText, new Vector3(nodes[0].transform.localPosition.x - 0.3f, -0.14f, 0), Quaternion.identity);
        newNodeLabel.transform.localScale = new Vector3(.9f, .9f, 0.001f);
        newNodeLabel.transform.SetParent(this.transform);
        newNodeLabel.transform.localPosition = new Vector3(nodes[0].transform.localPosition.x, newNode.transform.localPosition.y - 0.5f, 0);

        newNodeLinker = Instantiate(link, new Vector3(newNode.transform.localPosition.x, nodes[0].transform.localPosition.y - 0.55f, 0), Quaternion.identity);
        newNodeLinker.transform.Rotate(0.0f, 0.0f, 90.0f);
        newNodeLinker.transform.localScale = new Vector3(0.2f, 0.2f, 0.001f);
        newNodeLinker.transform.SetParent(this.transform);
        newNodeLinker.transform.localPosition = new Vector3(newNode.transform.localPosition.x, nodes[0].transform.localPosition.y - .55f, 0);

        yield return new WaitForSeconds(1.5f);
        LeanTween.moveLocalX(newNode, nodes[0].transform.localPosition.x-1.2f, 1.5f);
        LeanTween.moveLocalY(newNode, 1f, 1.5f);
        LeanTween.rotateZ(newNodeLinker, 0, 1.5f);
        LeanTween.moveLocalY(newNodeLinker, 1f, 1.5f);
        LeanTween.moveLocalX(newNodeLinker, nodes[0].transform.localPosition.x - 0.6f, 1.5f);
        LeanTween.moveLocalX(newNodeLabel, nodes[0].transform.localPosition.x - 1.2f, 1.5f);
        LeanTween.moveLocalY(newNodeLabel, 0.5f, 1.5f);

        yield return new WaitForSeconds(1.8f);
        LeanTween.moveLocalX(HeadLabel, nodes[0].transform.localPosition.x - 1.2f, 1.5f);
        LeanTween.moveLocalX(HeadLink, nodes[0].transform.localPosition.x - 1.2f, 1.5f);
        yield return new WaitForSeconds(1.8f);

        newNodeLabel.transform.parent = null;
        Destroy(newNodeLabel);


        for (int i = length - 1; i > 0; i--)
        {
            nodes[i] = nodes[i - 1];
            links[i] = links[i - 1];
        }
        nodes[0] = newNode;


    }

    public void CleanObjects()
    {
        if (hasObject)
        {
            hasObject = false;
            foreach (GameObject nd in nodes)
            {
                if (nd != null)
                {
                    nd.transform.parent = null;
                    Destroy(nd);
                }
            }

            foreach (GameObject lnk in links)
            {
                if (lnk != null)
                {
                    lnk.transform.parent = null;
                    Destroy(lnk);
                }
            }

            HeadLink.transform.parent = null;
            Destroy(HeadLink);
            TailLink.transform.parent = null;
            Destroy(TailLink);
            HeadLabel.transform.parent = null;
            Destroy(HeadLabel);
            TailLabel.transform.parent = null;
            Destroy(TailLabel);
            NullText.transform.parent = null;
            Destroy(NullText);

            while (this.transform.childCount > 0)
            {
                foreach (Transform child in this.transform)
                {
                    child.SetParent(null);
                    Destroy(child.gameObject);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
