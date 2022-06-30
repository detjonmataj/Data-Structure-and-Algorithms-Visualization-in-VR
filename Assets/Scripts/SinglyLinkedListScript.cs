using System.Collections;
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
    public GameObject CurrentText;
    public GameObject PreviousLBL;
    public TMP_InputField NumberInputField;
    public TMP_InputField IndexInputField;

    private GameObject HeadLink;
    private GameObject TailLink;
    private GameObject HeadLabel;
    private GameObject TailLabel;
    private GameObject NullText;
    private int length = 0;

    private bool hasObject = false;

    // Start is called before the first frame update
    void Start()
    {
        InitializeRandom();
        // Implicit Boxing avoid if possible
        // NumberInputField.text = 990.ToString(); // Some C# Magic
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

            // For Testing Purposes
            // if (i == 3){ randomNumber = 1; }
            // if (i == length - 1){ randomNumber = 0; }

            nodes[i] = Instantiate(node, new Vector3((i * 1.2f)+0.6f, 1.0f, 0), Quaternion.identity);
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

            links[i] = Instantiate(link, new Vector3(nodes[i].transform.localPosition.x, 1.0f, 0), Quaternion.identity);
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


    public void DeleteFirst()
    {
        StartCoroutine(DeleteFirstUtil());
    }

    private IEnumerator DeleteFirstUtil()
    {
            if (length == 0)
            {

            }
            else
            {
                LeanTween.moveLocalX(HeadLabel, nodes[1].transform.localPosition.x, 1.5f);
                LeanTween.moveLocalX(HeadLink, nodes[1].transform.localPosition.x, 1.5f);
                yield return new WaitForSeconds(1f);
                LeanTween.color(nodes[0], Color.red, 1f);
                yield return new WaitForSeconds(2f);
                nodes[0].transform.SetParent(null);
                links[0].transform.SetParent(null);
                Destroy(links[0]);
                Destroy(nodes[0]);

                for (int i = 1; i < length; i++)
                {
                    nodes[i - 1] = nodes[i];
                    links[i - 1] = links[i];
                }

                length--;
            }
    }

    public void DeleteLast()
    {
        StartCoroutine(DeleteLastUtil());
    }

    private IEnumerator DeleteLastUtil()
    {
        if (length == 0)
        {

        }
        else
        {
            GameObject tempNull;
            GameObject CurrentLabel;
            GameObject CurrentLink;

            CurrentLabel = GameObject.Instantiate(CurrentText, new Vector3(nodes[0].transform.localPosition.x, nodes[0].transform.localPosition.y - .9f, 0), Quaternion.identity);
            CurrentLabel.transform.localScale = new Vector3(1.2f, 1.2f, 0.001f);
            CurrentLabel.transform.SetParent(this.transform);
            CurrentLink = GameObject.Instantiate(link, new Vector3(nodes[0].transform.localPosition.x, nodes[0].transform.localPosition.y - 0.55f, 0), Quaternion.identity);
            CurrentLink.transform.Rotate(0.0f, 0.0f, 90.0f);
            CurrentLink.transform.localScale = new Vector3(0.2f, 0.2f, 0.001f);
            CurrentLink.transform.SetParent(this.transform);
            CurrentLabel.transform.localPosition = new Vector3(nodes[0].transform.localPosition.x, nodes[0].transform.localPosition.y - .9f, 0);
            CurrentLink.transform.localPosition = new Vector3(nodes[0].transform.localPosition.x, nodes[0].transform.localPosition.y - 0.55f, 0);


            for (int i = 0; i < length - 1; i++)
            {
                LeanTween.moveLocalX(CurrentLabel, nodes[i].transform.localPosition.x, .7f);
                LeanTween.moveLocalX(CurrentLink, nodes[i].transform.localPosition.x, .7f);
                LeanTween.color(nodes[i], Color.blue, 1f).setLoopPingPong(1);
                if (i != length - 2)
                {
                    LeanTween.moveLocalX(links[i], links[i].transform.localPosition.x + 0.09f, 1f).setLoopPingPong(1);
                }
                yield return new WaitForSeconds(1.5f);
            }

            LeanTween.moveLocalX(TailLabel, nodes[length - 2].transform.localPosition.x, 1.5f);
            LeanTween.moveLocalX(TailLink, nodes[length - 2].transform.localPosition.x, 1.5f);
            yield return new WaitForSeconds(1.5f);

            tempNull = Instantiate(NullText, new Vector3(TailLink.transform.localPosition.x + .8f, TailLink.transform.localPosition.y - .2f, 0), Quaternion.identity);
            tempNull.transform.localScale = new Vector3(1.5f, 1.5f, 0.001f);
            tempNull.transform.SetParent(this.transform);
            tempNull.transform.localPosition = new Vector3(TailLink.transform.localPosition.x + .8f, TailLink.transform.localPosition.y - .2f, 0);

            LeanTween.rotateZ(links[length - 2], 50, 1.5f).setLoopPingPong(1);
            LeanTween.moveLocalY(links[length - 2], links[length - 2].transform.localPosition.y + .3f, 1.5f).setLoopPingPong(1);
            yield return new WaitForSeconds(1f);
            LeanTween.color(nodes[length - 1], Color.red, 1f);
            yield return new WaitForSeconds(.6f);
            NullText.transform.SetParent(null);
            Destroy(NullText);
            nodes[length - 1].transform.SetParent(null);
            links[length - 1].transform.SetParent(null);
            Destroy(links[length - 1]);
            Destroy(nodes[length - 1]);

            CurrentLabel.transform.SetParent(null);
            CurrentLink.transform.SetParent(null);
            Destroy(CurrentLabel);
            Destroy(CurrentLink);

            LeanTween.moveLocalX(tempNull, nodes[length - 2].transform.localPosition.x + 1.4f, 1.5f);
            LeanTween.moveLocalY(tempNull, .95f, 1.5f);

            // yield return new WaitForSeconds(2f);

            NullText = tempNull;
            length--;
        }
    }


    public void Append()
    {
        int number = int.Parse(NumberInputField.text);
        StartCoroutine(AppendUtil(number));
    }

    public void Prepend()
    {
        int number = int.Parse(NumberInputField.text);
        StartCoroutine(PrependUtil(number));
    }

    private IEnumerator AppendUtil(int number)
    {
        if (length == 0)
        {
            nodes = new GameObject[100];
            links = new GameObject[100];
            length = 1;
            nodes[0] = Instantiate(node, new Vector3(0.6f, 1.0f, 0), Quaternion.identity);
            nodes[0].transform.SetParent(this.transform);
            nodes[0].transform.localScale = new Vector3(0.6f, 0.6f, 0.001f);
            nodes[0].GetComponentInChildren<TextMeshPro>().text = NumberInputField.text;
            nodes[0].GetComponentInChildren<TextMeshPro>().color = Color.black;
            nodes[0].transform.localPosition = new Vector3(0.6f, 1.0f, 0);


            HeadLabel = Instantiate(Head, new Vector3(0 , 2f, 0), Quaternion.identity);
            HeadLabel.transform.localScale = new Vector3(1.2f, 1.2f, 0.001f);
            HeadLabel.transform.SetParent(this.transform);
            HeadLink = Instantiate(link, new Vector3(0, 1.6f, 0), Quaternion.identity);
            HeadLink.transform.Rotate(0.0f, 0.0f, -90.0f);
            HeadLink.transform.localScale = new Vector3(0.2f, 0.2f, 0.001f);
            HeadLink.transform.SetParent(this.transform);
            HeadLabel.transform.localPosition = new Vector3(0.6f, 2f, 0);
            HeadLink.transform.localPosition = new Vector3(0.6f, 1.6f, 0);

            links[0] = Instantiate(link, new Vector3(nodes[0].transform.localPosition.x, 1.0f, 0), Quaternion.identity);

            NullText = Instantiate(nullTxt, new Vector3(nodes[0].transform.localPosition.x + 0.8f, 0.95f, 0), Quaternion.identity);
            NullText.transform.localScale = new Vector3(1.5f, 1.5f, 0.001f);
            NullText.transform.SetParent(this.transform);
            NullText.transform.localPosition = new Vector3(nodes[0].transform.localPosition.x + 1.4f, 0.95f, 0);

            TailLabel = Instantiate(Tail, new Vector3(0, 2f, 0), Quaternion.identity);
            TailLabel.transform.localScale = new Vector3(1.2f, 1.2f, 0.001f);
            TailLabel.transform.SetParent(this.transform);
            TailLabel.transform.localPosition = new Vector3(0.6f, 2f, 0);

            TailLink = Instantiate(link, new Vector3(0, 1.6f, 0), Quaternion.identity);
            TailLink.transform.Rotate(0.0f, 0.0f, -90.0f);
            TailLink.transform.localScale = new Vector3(0.2f, 0.2f, 0.001f);
            TailLink.transform.SetParent(this.transform);
            TailLink.transform.localPosition = new Vector3(0.6f, 1.6f, 0);
            
            links[0].transform.localScale = new Vector3(0.2f, 0.2f, 0.001f);
            links[0].transform.SetParent(this.transform);
            links[0].transform.localPosition = new Vector3(1.2f, 1.0f, 0);

            transform.position = new Vector3(-length / 2, 5 / 2f, 0);

        }
        else
        {
            GameObject newNode;
            GameObject newNodeLabel;
            GameObject newNodeLinker;
            GameObject TempNull;

            newNode = Instantiate(node, new Vector3(nodes[length - 1].transform.localPosition.x, -0.14f, 0), Quaternion.identity);
            newNode.transform.SetParent(this.transform);
            newNode.transform.localScale = new Vector3(0.6f, 0.6f, 0.001f);
            newNode.GetComponentInChildren<TextMeshPro>().text = number.ToString();
            newNode.GetComponentInChildren<TextMeshPro>().color = Color.black;
            newNode.transform.localPosition = new Vector3(nodes[length - 1].transform.localPosition.x, -0.14f, 0);

            newNodeLabel = Instantiate(newNodeText, new Vector3(nodes[length - 1].transform.localPosition.x - 0.3f, -0.14f, 0), Quaternion.identity);
            newNodeLabel.transform.localScale = new Vector3(.9f, .9f, 0.001f);
            newNodeLabel.transform.SetParent(this.transform);
            newNodeLabel.transform.localPosition = new Vector3(nodes[length - 1].transform.localPosition.x, newNode.transform.localPosition.y - 0.5f, 0);

            newNodeLinker = Instantiate(link, new Vector3(newNode.transform.localPosition.x, 1.0f, 0), Quaternion.identity);
            newNodeLinker.transform.localScale = new Vector3(0.2f, 0.2f, 0.001f);
            newNodeLinker.transform.SetParent(this.transform);
            newNodeLinker.transform.localPosition = new Vector3(newNode.transform.localPosition.x + 0.6f, newNode.transform.localPosition.y, 0);

            TempNull = Instantiate(NullText, new Vector3(newNode.transform.localPosition.x + 1.4f, newNode.transform.localPosition.y, 0), Quaternion.identity);
            TempNull.transform.localScale = new Vector3(1.5f, 1.5f, 0.001f);
            TempNull.transform.SetParent(this.transform);
            TempNull.transform.localPosition = new Vector3(newNode.transform.localPosition.x + 1.4f, newNode.transform.localPosition.y, 0);


            yield return new WaitForSeconds(1f);

            NullText.transform.SetParent(null);
            Destroy(NullText);
            NullText = TempNull;


            LeanTween.moveLocalX(links[length - 1], newNode.transform.localPosition.x, 1.5f).setLoopPingPong(1);
            LeanTween.moveLocalY(links[length - 1], nodes[length - 1].transform.localPosition.y - .55f, 1.5f).setLoopPingPong(1);
            LeanTween.rotateZ(links[length - 1], -90, 1.5f).setLoopPingPong(1);


            yield return new WaitForSeconds(1.5f);

            LeanTween.moveLocalX(newNode, nodes[length - 1].transform.localPosition.x + 1.2f, 1.5f);
            LeanTween.moveLocalY(newNode, 1f, 1.5f);
            LeanTween.rotateZ(newNodeLinker, 0, 1.5f);

            LeanTween.moveLocalY(newNodeLinker, 1f, 1.5f);
            LeanTween.moveLocalX(newNodeLinker, newNode.transform.localPosition.x + 1.8f, 1.5f);

            LeanTween.moveLocalY(TempNull, .95f, 1.5f);
            LeanTween.moveLocalX(TempNull, newNode.transform.localPosition.x + 2.5f, 1.5f);

            LeanTween.moveLocalX(newNodeLabel, newNode.transform.localPosition.x + 1.2f, 1.5f);
            LeanTween.moveLocalY(newNodeLabel, 0.5f, 1.5f);

            yield return new WaitForSeconds(1.8f);
            LeanTween.moveLocalX(TailLabel, nodes[length - 1].transform.localPosition.x + 1.2f, 1.5f);
            LeanTween.moveLocalX(TailLink, nodes[length - 1].transform.localPosition.x + 1.2f, 1.5f);
            yield return new WaitForSeconds(1.8f);

            newNodeLabel.transform.parent = null;
            Destroy(newNodeLabel);

            links[length] = newNodeLinker;
            nodes[length] = newNode;

            length++;
        }
    }

    private IEnumerator PrependUtil(int number)
    {

        if (length == 0)
        {
            Append();

        }
        else
        {
            GameObject newNode;
            GameObject newNodeLabel;
            GameObject newNodeLinker;
            GameObject TempNull;

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

            // newNodeLinker = Instantiate(link, new Vector3(newNode.transform.localPosition.x, nodes[0].transform.localPosition.y - 0.55f, 0), Quaternion.identity);
            // newNodeLinker.transform.Rotate(0.0f, 0.0f, 90.0f);
            // newNodeLinker.transform.localScale = new Vector3(0.2f, 0.2f, 0.001f);
            // newNodeLinker.transform.SetParent(this.transform);
            // newNodeLinker.transform.localPosition = new Vector3(newNode.transform.localPosition.x, nodes[0].transform.localPosition.y - .55f, 0);

            newNodeLinker = Instantiate(link, new Vector3(newNode.transform.localPosition.x, 1.0f, 0), Quaternion.identity);
            newNodeLinker.transform.localScale = new Vector3(0.2f, 0.2f, 0.001f);
            newNodeLinker.transform.SetParent(this.transform);
            newNodeLinker.transform.localPosition = new Vector3(newNode.transform.localPosition.x + 0.6f, newNode.transform.localPosition.y, 0);

            TempNull = Instantiate(NullText, new Vector3(newNode.transform.localPosition.x + 1.4f, newNode.transform.localPosition.y, 0), Quaternion.identity);
            TempNull.transform.localScale = new Vector3(1.5f, 1.5f, 0.001f);
            TempNull.transform.SetParent(this.transform);
            TempNull.transform.localPosition = new Vector3(newNode.transform.localPosition.x + 1.4f, newNode.transform.localPosition.y, 0);

            yield return new WaitForSeconds(1f);

            LeanTween.moveLocalX(newNodeLinker, nodes[0].transform.localPosition.x, 1.5f);
            LeanTween.moveLocalY(newNodeLinker, nodes[0].transform.localPosition.y - 0.55f, 1.5f);
            LeanTween.rotateZ(newNodeLinker, 90, 1.5f);

            TempNull.transform.parent = null;
            Destroy(TempNull);

            yield return new WaitForSeconds(1.5f);
            LeanTween.moveLocalX(newNode, nodes[0].transform.localPosition.x - 1.2f, 1.5f);
            LeanTween.moveLocalY(newNode, 1f, 1.5f);
            LeanTween.rotateZ(newNodeLinker, 0, 1.5f);
            LeanTween.moveLocalY(newNodeLinker, 1f, 1.5f);
            LeanTween.moveLocalX(newNodeLinker, nodes[0].transform.localPosition.x - 0.6f, 1.5f);
            LeanTween.moveLocalX(newNodeLabel, nodes[0].transform.localPosition.x - 1.2f, 1.5f);
            LeanTween.moveLocalY(newNodeLabel, 0.5f, 1.5f);


            // yield return new WaitForSeconds(1.8f);
            LeanTween.moveLocalX(HeadLabel, nodes[0].transform.localPosition.x - 1.2f, 1.5f);
            LeanTween.moveLocalX(HeadLink, nodes[0].transform.localPosition.x - 1.2f, 1.5f);
            yield return new WaitForSeconds(1.8f);

            newNodeLabel.transform.parent = null;
            Destroy(newNodeLabel);


            for (int i = length; i > 0; i--)
            {
                nodes[i] = nodes[i - 1];
                links[i] = links[i - 1];
            }
            nodes[0] = newNode;
            links[0] = newNodeLinker;
            length++;
        }
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

    public void Search()
    {
        int number = int.Parse(NumberInputField.text);
        StartCoroutine(SearchUtil(number));
    }

    private IEnumerator SearchUtil(int number)
    {
        if (length == 0)
        {

        }
        else
        {
            GameObject CurrentLabel;
            GameObject CurrentLink;

            CurrentLabel = GameObject.Instantiate(CurrentText, new Vector3(nodes[0].transform.localPosition.x, nodes[0].transform.localPosition.y - .9f, 0), Quaternion.identity);
            CurrentLabel.transform.localScale = new Vector3(1.2f, 1.2f, 0.001f);
            CurrentLabel.transform.SetParent(this.transform);
            CurrentLink = GameObject.Instantiate(link, new Vector3(nodes[0].transform.localPosition.x, nodes[0].transform.localPosition.y - 0.55f, 0), Quaternion.identity);
            CurrentLink.transform.Rotate(0.0f, 0.0f, 90.0f);
            CurrentLink.transform.localScale = new Vector3(0.2f, 0.2f, 0.001f);
            CurrentLink.transform.SetParent(this.transform);
            CurrentLabel.transform.localPosition = new Vector3(nodes[0].transform.localPosition.x, nodes[0].transform.localPosition.y - .9f, 0);
            CurrentLink.transform.localPosition = new Vector3(nodes[0].transform.localPosition.x, nodes[0].transform.localPosition.y - 0.55f, 0);

            yield return new WaitForSeconds(1);
            int i;
            for (i = 0; i < length; i++)
            {
                LeanTween.moveLocalX(CurrentLabel, nodes[i].transform.localPosition.x, .7f);
                LeanTween.moveLocalX(CurrentLink, nodes[i].transform.localPosition.x, .7f);
                LeanTween.color(nodes[i], Color.blue, 1f).setLoopPingPong(1);
                LeanTween.moveLocalX(links[i], links[i].transform.localPosition.x + 0.09f, 1f).setLoopPingPong(1);
                yield return new WaitForSeconds(1.1f);
                if (int.Parse(nodes[i].GetComponentInChildren<TextMeshPro>().text) == number)
                {
                    LeanTween.color(nodes[i], Color.green, 1f);
                    yield return new WaitForSeconds(1.5f);
                    break;
                }

                yield return new WaitForSeconds(1.5f);
            }

            if (i == length)
            {
                LeanTween.moveLocalX(CurrentLabel, NullText.transform.localPosition.x, .7f);
                LeanTween.moveLocalX(CurrentLink, NullText.transform.localPosition.x, .7f);
            }
            else
            {
                LeanTween.color(nodes[i], Color.white, 1f);
            }
            yield return new WaitForSeconds(2f);
            CurrentLabel.transform.SetParent(null);
            CurrentLink.transform.SetParent(null);
            Destroy(CurrentLabel);
            Destroy(CurrentLink);
        }
    }

    public void DeleteValue()
    {
        int number = int.Parse(NumberInputField.text);
        StartCoroutine(DeleteValueUtil(number));
    }

    private IEnumerator DeleteValueUtil(int number)
    {


        if (length == 0)
        {

        } else if (int.Parse(nodes[0].GetComponentInChildren<TextMeshPro>().text) == number)
        {
            DeleteFirst();
            yield break;
        }
        else
        {
            GameObject CurrentLabel;
            GameObject CurrentLink;
            GameObject previousLink;
            GameObject previousLabel;


            previousLabel = Instantiate(PreviousLBL, new Vector3(nodes[0].transform.localPosition.x, nodes[0].transform.localPosition.y - .9f, 0), Quaternion.identity);
            previousLabel.transform.localScale = new Vector3(1.2f, 1.2f, 0.001f);
            previousLabel.transform.SetParent(this.transform);
            previousLink = Instantiate(link, new Vector3(nodes[0].transform.localPosition.x, nodes[0].transform.localPosition.y - 0.55f, 0), Quaternion.identity);
            previousLink.transform.Rotate(0.0f, 0.0f, 90.0f);
            previousLink.transform.localScale = new Vector3(0.2f, 0.2f, 0.001f);
            previousLink.transform.SetParent(this.transform);
            previousLabel.transform.localPosition = new Vector3(nodes[0].transform.localPosition.x, nodes[0].transform.localPosition.y - .9f, 0);
            previousLink.transform.localPosition = new Vector3(nodes[0].transform.localPosition.x, nodes[0].transform.localPosition.y - 0.55f, 0);

            previousLabel.SetActive(false);
            previousLink.SetActive(false);

            CurrentLabel = GameObject.Instantiate(CurrentText, new Vector3(nodes[0].transform.localPosition.x, nodes[0].transform.localPosition.y - .9f, 0), Quaternion.identity);
            CurrentLabel.transform.localScale = new Vector3(1.2f, 1.2f, 0.001f);
            CurrentLabel.transform.SetParent(this.transform);
            CurrentLink = GameObject.Instantiate(link, new Vector3(nodes[0].transform.localPosition.x, nodes[0].transform.localPosition.y - 0.55f, 0), Quaternion.identity);
            CurrentLink.transform.Rotate(0.0f, 0.0f, 90.0f);
            CurrentLink.transform.localScale = new Vector3(0.2f, 0.2f, 0.001f);
            CurrentLink.transform.SetParent(this.transform);
            CurrentLabel.transform.localPosition = new Vector3(nodes[0].transform.localPosition.x, nodes[0].transform.localPosition.y - .9f, 0);
            CurrentLink.transform.localPosition = new Vector3(nodes[0].transform.localPosition.x, nodes[0].transform.localPosition.y - 0.55f, 0);

            yield return new WaitForSeconds(1);
            int i;

            for (i = 0; i < length; i++)
            {
                LeanTween.moveLocalX(CurrentLabel, nodes[i].transform.localPosition.x, .7f);
                LeanTween.moveLocalX(CurrentLink, nodes[i].transform.localPosition.x, .7f);
                LeanTween.color(nodes[i], Color.blue, 1f).setLoopPingPong(1);
                LeanTween.moveLocalX(links[i], links[i].transform.localPosition.x + 0.09f, 1f).setLoopPingPong(1);

                if (i == 1)
                {
                    yield return new WaitForSeconds(.8f);
                    previousLabel.SetActive(true);
                    previousLink.SetActive(true);
                } 

                if(i > 1)
                {
                    LeanTween.moveLocalX(previousLabel, nodes[i-1].transform.localPosition.x, .9f);
                    LeanTween.moveLocalX(previousLink, nodes[i-1].transform.localPosition.x, .9f);
                }

                if (int.Parse(nodes[i].GetComponentInChildren<TextMeshPro>().text) == number)
                {
                    yield return new WaitForSeconds(1.1f);
                    LeanTween.moveLocalY(nodes[i], nodes[i].transform.localPosition.y + 0.5f, 1f);
                    LeanTween.rotateZ(links[i], -60, 1f);
                    LeanTween.moveLocalY(links[i], nodes[i].transform.localPosition.y + 0.3f, 1f);
                    yield return new WaitForSeconds(1.5f);
                    LeanTween.scaleX(links[i - 1], 1.0f, 1f).setLoopPingPong(1);
                    LeanTween.moveLocalX(links[i - 1], links[i - 1].transform.localPosition.x + 0.6f, 1f).setLoopPingPong(1);
                    LeanTween.color(nodes[i], Color.red, 1f);
                    yield return new WaitForSeconds(1.1f);
                    nodes[i].transform.SetParent(null);
                    Destroy(nodes[i]);
                    links[i].transform.SetParent(null);
                    Destroy(links[i]);

                    if(i == length - 1)
                    {
                        LeanTween.moveLocalX(NullText, NullText.transform.localPosition.x - 1.2f, 1f);
                        LeanTween.moveLocalX(TailLabel, TailLabel.transform.localPosition.x - 1.2f, 1f);
                        LeanTween.moveLocalX(TailLink, TailLink.transform.localPosition.x - 1.2f, 1f);
                    }
                    else
                    {
                        for (int j = i + 1; j < length; j++)
                        {
                            LeanTween.moveLocalX(nodes[j], nodes[j].transform.localPosition.x - 1.2f, 1f);
                            LeanTween.moveLocalX(links[j], links[j].transform.localPosition.x - 1.2f, 1f);
                            nodes[j - 1] = nodes[j];
                            links[j - 1] = links[j];
                            if (j == length - 1)
                            {
                                LeanTween.moveLocalX(TailLabel, TailLabel.transform.localPosition.x - 1.2f, 1f);
                                LeanTween.moveLocalX(TailLink, TailLink.transform.localPosition.x - 1.2f, 1f);
                                LeanTween.moveLocalX(NullText, NullText.transform.localPosition.x - 1.2f, 1f);
                            }
                        }
                    }
                    
                    CurrentLabel.transform.SetParent(null);
                    CurrentLink.transform.SetParent(null);
                    Destroy(CurrentLabel);
                    Destroy(CurrentLink);
                    previousLabel.transform.SetParent(null);
                    previousLink.transform.SetParent(null);
                    Destroy(previousLabel);
                    Destroy(previousLink);

                    break;
                }

                yield return new WaitForSeconds(1.5f);
            }

            if(i == length)
            {
                CurrentLabel.transform.SetParent(null);
                CurrentLink.transform.SetParent(null);
                Destroy(CurrentLabel);
                Destroy(CurrentLink);
                previousLabel.transform.SetParent(null);
                previousLink.transform.SetParent(null);
                Destroy(previousLabel);
                Destroy(previousLink);
            }

            length--;
        }
    }


    public void DeleteAtPosition()
    {
        int position = int.Parse(IndexInputField.text);
        if (position == 0 || position > length) return;
        StartCoroutine(DeleteAtPositionUtil(position - 1));
    }

    private IEnumerator DeleteAtPositionUtil(int position)
    {


        if (length == 0)
        {

        }
        else if (position == 0)
        {
            DeleteFirst();
            yield break;
        }
        else
        {
            GameObject CurrentLabel;
            GameObject CurrentLink;
            GameObject previousLink;
            GameObject previousLabel;


            previousLabel = Instantiate(PreviousLBL, new Vector3(nodes[0].transform.localPosition.x, nodes[0].transform.localPosition.y - .9f, 0), Quaternion.identity);
            previousLabel.transform.localScale = new Vector3(1.2f, 1.2f, 0.001f);
            previousLabel.transform.SetParent(this.transform);
            previousLink = Instantiate(link, new Vector3(nodes[0].transform.localPosition.x, nodes[0].transform.localPosition.y - 0.55f, 0), Quaternion.identity);
            previousLink.transform.Rotate(0.0f, 0.0f, 90.0f);
            previousLink.transform.localScale = new Vector3(0.2f, 0.2f, 0.001f);
            previousLink.transform.SetParent(this.transform);
            previousLabel.transform.localPosition = new Vector3(nodes[0].transform.localPosition.x, nodes[0].transform.localPosition.y - .9f, 0);
            previousLink.transform.localPosition = new Vector3(nodes[0].transform.localPosition.x, nodes[0].transform.localPosition.y - 0.55f, 0);

            previousLabel.SetActive(false);
            previousLink.SetActive(false);

            CurrentLabel = GameObject.Instantiate(CurrentText, new Vector3(nodes[0].transform.localPosition.x, nodes[0].transform.localPosition.y - .9f, 0), Quaternion.identity);
            CurrentLabel.transform.localScale = new Vector3(1.2f, 1.2f, 0.001f);
            CurrentLabel.transform.SetParent(this.transform);
            CurrentLink = GameObject.Instantiate(link, new Vector3(nodes[0].transform.localPosition.x, nodes[0].transform.localPosition.y - 0.55f, 0), Quaternion.identity);
            CurrentLink.transform.Rotate(0.0f, 0.0f, 90.0f);
            CurrentLink.transform.localScale = new Vector3(0.2f, 0.2f, 0.001f);
            CurrentLink.transform.SetParent(this.transform);
            CurrentLabel.transform.localPosition = new Vector3(nodes[0].transform.localPosition.x, nodes[0].transform.localPosition.y - .9f, 0);
            CurrentLink.transform.localPosition = new Vector3(nodes[0].transform.localPosition.x, nodes[0].transform.localPosition.y - 0.55f, 0);

            yield return new WaitForSeconds(1);
            int i;

            for (i = 0; i < length; i++)
            {
                LeanTween.moveLocalX(CurrentLabel, nodes[i].transform.localPosition.x, .7f);
                LeanTween.moveLocalX(CurrentLink, nodes[i].transform.localPosition.x, .7f);
                LeanTween.color(nodes[i], Color.blue, 1f).setLoopPingPong(1);
                LeanTween.moveLocalX(links[i], links[i].transform.localPosition.x + 0.09f, 1f).setLoopPingPong(1);

                if (i == 1)
                {
                    yield return new WaitForSeconds(.8f);
                    previousLabel.SetActive(true);
                    previousLink.SetActive(true);
                }

                if (i > 1)
                {
                    LeanTween.moveLocalX(previousLabel, nodes[i - 1].transform.localPosition.x, .9f);
                    LeanTween.moveLocalX(previousLink, nodes[i - 1].transform.localPosition.x, .9f);
                }

                if (i == position)
                {
                    yield return new WaitForSeconds(1.1f);
                    LeanTween.moveLocalY(nodes[i], nodes[i].transform.localPosition.y + 0.5f, 1f);
                    LeanTween.rotateZ(links[i], -60, 1f);
                    LeanTween.moveLocalY(links[i], nodes[i].transform.localPosition.y + 0.3f, 1f);
                    yield return new WaitForSeconds(1.5f);
                    LeanTween.scaleX(links[i - 1], 1.0f, 1f).setLoopPingPong(1);
                    LeanTween.moveLocalX(links[i - 1], links[i - 1].transform.localPosition.x + 0.6f, 1f).setLoopPingPong(1);
                    LeanTween.color(nodes[i], Color.red, 1f);
                    yield return new WaitForSeconds(1.1f);
                    nodes[i].transform.SetParent(null);
                    Destroy(nodes[i]);
                    links[i].transform.SetParent(null);
                    Destroy(links[i]);

                    if (i == length - 1)
                    {
                        LeanTween.moveLocalX(NullText, NullText.transform.localPosition.x - 1.2f, 1f);
                        LeanTween.moveLocalX(TailLabel, TailLabel.transform.localPosition.x - 1.2f, 1f);
                        LeanTween.moveLocalX(TailLink, TailLink.transform.localPosition.x - 1.2f, 1f);
                    }
                    else
                    {
                        for (int j = i + 1; j < length; j++)
                        {
                            LeanTween.moveLocalX(nodes[j], nodes[j].transform.localPosition.x - 1.2f, 1f);
                            LeanTween.moveLocalX(links[j], links[j].transform.localPosition.x - 1.2f, 1f);
                            nodes[j - 1] = nodes[j];
                            links[j - 1] = links[j];
                            if (j == length - 1)
                            {
                                LeanTween.moveLocalX(TailLabel, TailLabel.transform.localPosition.x - 1.2f, 1f);
                                LeanTween.moveLocalX(TailLink, TailLink.transform.localPosition.x - 1.2f, 1f);
                                LeanTween.moveLocalX(NullText, NullText.transform.localPosition.x - 1.2f, 1f);
                            }
                        }
                    }

                    CurrentLabel.transform.SetParent(null);
                    CurrentLink.transform.SetParent(null);
                    Destroy(CurrentLabel);
                    Destroy(CurrentLink);
                    previousLabel.transform.SetParent(null);
                    previousLink.transform.SetParent(null);
                    Destroy(previousLabel);
                    Destroy(previousLink);

                    break;
                }

                yield return new WaitForSeconds(1.5f);
            }

            if (i == length)
            {
                CurrentLabel.transform.SetParent(null);
                CurrentLink.transform.SetParent(null);
                Destroy(CurrentLabel);
                Destroy(CurrentLink);
                previousLabel.transform.SetParent(null);
                previousLink.transform.SetParent(null);
                Destroy(previousLabel);
                Destroy(previousLink);
            }

            length--;
        }
    }


    public void InsertAtPosition()
    {
        int number = int.Parse(NumberInputField.text);
        int position = int.Parse(IndexInputField.text);
        if (position == 0 || position > length + 1) return;
        StartCoroutine(InsertAtPositionUtil(number, position-1));
    }

    private IEnumerator InsertAtPositionUtil(int number, int position)
    {

        if (position == 0 || length == 0)
        {
            Prepend();
            yield break;
        } else if(position == length) {
            Append();
            yield break;
        }
        else
        {
            GameObject CurrentLabel;
            GameObject CurrentLink;
            GameObject previousLink;
            GameObject previousLabel;
            GameObject newNode;
            GameObject newNodeLabel;
            GameObject newNodeLinker;

            previousLabel = Instantiate(PreviousLBL, new Vector3(nodes[0].transform.localPosition.x, nodes[0].transform.localPosition.y - .9f, 0), Quaternion.identity);
            previousLabel.transform.localScale = new Vector3(1.2f, 1.2f, 0.001f);
            previousLabel.transform.SetParent(this.transform);
            previousLink = Instantiate(link, new Vector3(nodes[0].transform.localPosition.x, nodes[0].transform.localPosition.y - 0.55f, 0), Quaternion.identity);
            previousLink.transform.Rotate(0.0f, 0.0f, 90.0f);
            previousLink.transform.localScale = new Vector3(0.2f, 0.2f, 0.001f);
            previousLink.transform.SetParent(this.transform);
            previousLabel.transform.localPosition = new Vector3(nodes[0].transform.localPosition.x, nodes[0].transform.localPosition.y - .9f, 0);
            previousLink.transform.localPosition = new Vector3(nodes[0].transform.localPosition.x, nodes[0].transform.localPosition.y - 0.55f, 0);

            previousLabel.SetActive(false);
            previousLink.SetActive(false);

            CurrentLabel = GameObject.Instantiate(CurrentText, new Vector3(nodes[0].transform.localPosition.x, nodes[0].transform.localPosition.y - .9f, 0), Quaternion.identity);
            CurrentLabel.transform.localScale = new Vector3(1.2f, 1.2f, 0.001f);
            CurrentLabel.transform.SetParent(this.transform);
            CurrentLink = GameObject.Instantiate(link, new Vector3(nodes[0].transform.localPosition.x, nodes[0].transform.localPosition.y - 0.55f, 0), Quaternion.identity);
            CurrentLink.transform.Rotate(0.0f, 0.0f, 90.0f);
            CurrentLink.transform.localScale = new Vector3(0.2f, 0.2f, 0.001f);
            CurrentLink.transform.SetParent(this.transform);
            CurrentLabel.transform.localPosition = new Vector3(nodes[0].transform.localPosition.x, nodes[0].transform.localPosition.y - .9f, 0);
            CurrentLink.transform.localPosition = new Vector3(nodes[0].transform.localPosition.x, nodes[0].transform.localPosition.y - 0.55f, 0);

            yield return new WaitForSeconds(1);
            int i;

            for (i = 0; i < length; i++)
            {
                LeanTween.moveLocalX(CurrentLabel, nodes[i].transform.localPosition.x, .7f);
                LeanTween.moveLocalX(CurrentLink, nodes[i].transform.localPosition.x, .7f);
                LeanTween.color(nodes[i], Color.blue, 1f).setLoopPingPong(1);
                LeanTween.moveLocalX(links[i], links[i].transform.localPosition.x + 0.09f, 1f).setLoopPingPong(1);

                if (i == 1)
                {
                    yield return new WaitForSeconds(.8f);
                    previousLabel.SetActive(true);
                    previousLink.SetActive(true);
                }

                if (i > 1)
                {
                    LeanTween.moveLocalX(previousLabel, nodes[i - 1].transform.localPosition.x, .9f);
                    LeanTween.moveLocalX(previousLink, nodes[i - 1].transform.localPosition.x, .9f);
                }

                if (i == position || i == length-1)
                {
                    yield return new WaitForSeconds(1.1f);

                    newNode = Instantiate(node, new Vector3(nodes[i].transform.localPosition.x, nodes[i].transform.localPosition.y + 1.2f, 0), Quaternion.identity);
                    newNode.transform.SetParent(this.transform);
                    newNode.transform.localScale = new Vector3(0.6f, 0.6f, 0.001f);
                    newNode.GetComponentInChildren<TextMeshPro>().text = number.ToString();
                    newNode.GetComponentInChildren<TextMeshPro>().color = Color.black;
                    newNode.transform.localPosition = new Vector3(nodes[i].transform.localPosition.x, nodes[i].transform.localPosition.y + 1.2f, 0);

                    newNodeLabel = Instantiate(newNodeText, new Vector3(newNode.transform.localPosition.x, newNode.transform.localPosition.y + .5f, 0), Quaternion.identity);
                    newNodeLabel.transform.localScale = new Vector3(.9f, .9f, 0.001f);
                    newNodeLabel.transform.SetParent(this.transform);
                    newNodeLabel.transform.localPosition = new Vector3(newNode.transform.localPosition.x, newNode.transform.localPosition.y + .5f, 0);

                    newNodeLinker = Instantiate(link, new Vector3(newNode.transform.localPosition.x, 1.6f, 0), Quaternion.identity);
                    newNodeLinker.transform.Rotate(0.0f, 0.0f, -90.0f);
                    newNodeLinker.transform.localScale = new Vector3(0.2f, 0.2f, 0.001f);
                    newNodeLinker.transform.SetParent(this.transform);
                    newNodeLinker.transform.localPosition = new Vector3(newNode.transform.localPosition.x, 1.6f, 0);

                    yield return new WaitForSeconds(1);

                    LeanTween.rotateZ(links[i - 1], 50f, 1f).setLoopPingPong(1);
                    LeanTween.moveLocalX(newNodeLinker, links[i].transform.localPosition.x, 1.2f);
                    LeanTween.moveLocalY(newNodeLinker, links[i].transform.localPosition.y, 1.2f);
                    LeanTween.rotateZ(newNodeLinker, 0, 1.2f);
                    LeanTween.moveLocalX(newNode, nodes[i].transform.localPosition.x, 1.2f);
                    LeanTween.moveLocalY(newNode, nodes[i].transform.localPosition.y, 1.2f);
                    LeanTween.moveLocalX(newNodeLabel, nodes[i].transform.localPosition.x, 1.2f);
                    LeanTween.moveLocalY(newNodeLabel, nodes[i].transform.localPosition.y + .5f, 1.2f);

                    for (int j = length; j > i; j--)
                    {
                        nodes[j] = nodes[j - 1];
                        links[j] = links[j - 1];
                        if (j == length)
                        {
                            LeanTween.moveLocalX(TailLabel, TailLabel.transform.localPosition.x + 1.2f, 1f);
                            LeanTween.moveLocalX(TailLink, TailLink.transform.localPosition.x + 1.2f, 1f);
                            LeanTween.moveLocalX(NullText, NullText.transform.localPosition.x + 1.2f, 1f);
                        } else if (j == i+1)
                        {
                            LeanTween.moveLocalX(CurrentLabel, nodes[j+1].transform.localPosition.x, 1.2f);
                            LeanTween.moveLocalX(CurrentLink, nodes[j+1].transform.localPosition.x, 1.2f);
                        }
                        LeanTween.moveLocalX(nodes[j], nodes[j].transform.localPosition.x + 1.2f, 1f);
                        LeanTween.moveLocalX(links[j], links[j].transform.localPosition.x + 1.2f, 1f);
                    }
                    yield return new WaitForSeconds(1.7f);
                    newNodeLabel.transform.SetParent(null);
                    Destroy(newNodeLabel);

                    nodes[i] = newNode;
                    links[i] = newNodeLinker;

                    CurrentLabel.transform.SetParent(null);
                    CurrentLink.transform.SetParent(null);
                    Destroy(CurrentLabel);
                    Destroy(CurrentLink);
                    previousLabel.transform.SetParent(null);
                    previousLink.transform.SetParent(null);
                    Destroy(previousLabel);
                    Destroy(previousLink);

                    break;
                }
                yield return new WaitForSeconds(1.5f);
            }


            CurrentLabel.transform.SetParent(null);
            CurrentLink.transform.SetParent(null);
            Destroy(CurrentLabel);
            Destroy(CurrentLink);
            previousLabel.transform.SetParent(null);
            previousLink.transform.SetParent(null);
            Destroy(previousLabel);
            Destroy(previousLink);
            

            length++;
        }
    }
}
