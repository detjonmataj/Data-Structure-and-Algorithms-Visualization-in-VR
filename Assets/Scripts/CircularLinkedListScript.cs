using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class CircularLinkedListScript : MonoBehaviour
{
    // private readonly int maxLength = 10;
    private readonly int maxNumber = 999;
    private readonly int minNumber = -999;

    //this are the two arrays which will store nodes and linkes
    private GameObject[] nodes;
    private GameObject[] links;


    //the arrow that will be used to point the head
    public GameObject head_pointer;
    private GameObject head_pointer2;

    public GameObject straightline;
    private GameObject straightlinebegining;
    private GameObject straightlineend;

    //public GameObject duplicate_of_head_pointer;

    //used during insertion of new nodes -> temp
    public GameObject node;
    public GameObject link;

    //
    public GameObject newNodeText;
    public GameObject nullTxt;

    //centials 
    public GameObject Head;
    public GameObject Tail;

    public GameObject CurrentText;
    public GameObject PreviousLBL;
    public TMP_InputField NumberInputField;
    public TMP_InputField IndexInputField;



    //this is the part where we handel the start and end 
    //private GameObject HeadLink;
    private GameObject TailLink;
    //private GameObject HeadLabel;
    private GameObject TailLabel;
    private readonly GameObject NullText;

    //used to store the nubmer of nodes in the Linked List
    private int length = 0;

    private bool hasObject = false;

    // Start is called before the first frame update
    void Start()
    {
        InitializeRandom();

        //Done
        //Prepend();
        //Append();
        // Rotate();
        //DeleteValue();
        //DeleteAtPosition();
        //InsertAtPosition();
        //Search();
        //final()

    }

    // public void final()
    // {
    //     StartCoroutine( tessss());
    // }
    // public IEnumerator tessss()
    // {
    //     //yield return StartCoroutine(AppendUtil(12));
    //     yield return StartCoroutine(AppendUtil(12));
    //     //yield return StartCoroutine(DeleteLastUtil());
    //     //yield return StartCoroutine(DeleteValueUtil(12));
    //     yield return StartCoroutine(DeleteAtPositionUtil(length-1));
    // }



    public void initializing_the_returing_arrow(float x, float y,float z)
    {
        Debug.Log("we are intializing the array here again with " +length / 2f + " because the length is::: "+ length);
        head_pointer2 = Instantiate(straightline, new Vector3(x, y, z),Quaternion.identity);
        head_pointer2.transform.SetParent(this.transform);
        head_pointer2.transform.localScale = new Vector3(1, 0.3f, 1);

        //we are streching the line based on a specific formula that we have derived
        LeanTween.scaleX(head_pointer2, (length-1)*0.353f, 0.1f);
        

        // head_pointer2.transform.localScale = new Vector3(1 * length / 2f, 1, 1);
        Debug.Log("we are The length after initializing is::: " + length);

        straightlinebegining = Instantiate(link, new Vector3(this.transform.localPosition.x, this.transform.localPosition.y +0.3f,0), Quaternion.identity);

        //we have two options here
        straightlinebegining.transform.Rotate(new Vector3(0f, 0f, +90.0f), Space.Self);
        straightlinebegining.transform.SetParent(this.transform);
        straightlinebegining.transform.localScale = new Vector3(0.3f, 0.5f, 1);


        straightlineend = Instantiate(straightline, new Vector3(this.transform.localPosition.x + (length-1) * 1.2f, this.transform.localPosition.y+0.3f, 0), Quaternion.identity);

        straightlineend.transform.Rotate(new Vector3(0f, 0f, +90.0f), Space.Self);

        straightlineend.transform.SetParent(this.transform);

        straightlineend.transform.localScale = new Vector3(0.2f, 0.3f, 1);

        Debug.Log("we are in the last element with nr:: " + length + " || and its position is:: " + straightline.transform.localPosition.x);


    }

 
    public void InitializeRandom()
    {
        if (hasObject)
        {
            CleanObjects();
        }

        //initlaize the lhe list and its length
        hasObject = true;
        length = UnityEngine.Random.Range(3, 7);
        //length = 10;
        nodes = new GameObject[100];
        links = new GameObject[100];


        int randomNumber;


        for (int i = 0; i < length; i++)
        {

            randomNumber = UnityEngine.Random.Range(minNumber, maxNumber);

            // For Testing Purposes
            // if (i == 3){ randomNumber = 1; }
            // if (i == length - 1){ randomNumber = 0; 
            //

            //we instantiate the array b starting at local position 0
            //the length of a node+ one arrow is 1.2f and we start from 0.6f
            nodes[i] = GameObject.Instantiate(node, new Vector3((i * 1.2f) + 0.6f, 1.0f, 0), Quaternion.identity);

            nodes[i].transform.SetParent(this.transform);
            nodes[i].transform.localScale = new Vector3(0.6f, 0.6f, 0.001f);

            nodes[i].GetComponentInChildren<TextMeshPro>().text = randomNumber.ToString();
            nodes[i].GetComponentInChildren<TextMeshPro>().color = Color.black;
            nodes[i].transform.localPosition = new Vector3((i * 1.2f) + 0.6f, 1.0f, 0);


            //creating the linkes for every node
            if (i < length - 1)
            {
                //this is where we instatiate the links of the array
                links[i] = GameObject.Instantiate(link, new Vector3(nodes[i].transform.localPosition.x, 1.0f, 0), Quaternion.identity);
                links[i].transform.localScale = new Vector3(0.2f, 0.2f, 0.001f);
                links[i].transform.SetParent(this.transform);
                links[i].transform.localPosition = new Vector3((i * 1.2f) + 1.2f, 1.0f, 0);
            }

            //if (i == 0)
            //{
            //    HeadLabel = GameObject.Instantiate(Head, new Vector3((i * 1.2f), 2f, 0), Quaternion.identity);
            //    HeadLabel.transform.localScale = new Vector3(1.2f, 1.2f, 0.001f);
            //    HeadLabel.transform.SetParent(this.transform);
            //    HeadLink = GameObject.Instantiate(link, new Vector3((i * 1.2f), 1.6f, 0), Quaternion.identity);
            //    HeadLink.transform.Rotate(0.0f, 0.0f, -90.0f);
            //    HeadLink.transform.localScale = new Vector3(0.2f, 0.2f, 0.001f);
            //    HeadLink.transform.SetParent(this.transform);

            //    HeadLabel.transform.localPosition = new Vector3((i * 1.2f) + 0.6f, 2f, 0);
            //    HeadLink.transform.localPosition = new Vector3((i * 1.2f) + 0.6f, 1.6f, 0);
            //}

            if (i == length - 1)
            {
                //NullText = GameObject.Instantiate(nullTxt, new Vector3(nodes[i].transform.localPosition.x + 0.8f, 0.95f, 0), Quaternion.identity);
                //NullText.transform.localScale = new Vector3(1.5f, 1.5f, 0.001f);
                //NullText.transform.SetParent(this.transform);
                //NullText.transform.localPosition = new Vector3(nodes[i].transform.localPosition.x + 1.4f, 0.95f, 0);

                TailLabel = GameObject.Instantiate(Tail, new Vector3((i * 1.2f), 2f, 0), Quaternion.identity);
                TailLabel.transform.localScale = new Vector3(1.2f, 1.2f, 0.001f);
                TailLabel.transform.SetParent(this.transform);
                TailLabel.transform.localPosition = new Vector3((i * 1.2f) + 0.6f, 2f, 0);

                TailLink = GameObject.Instantiate(link, new Vector3(i * 1.2f, 1.6f, 0), Quaternion.identity);
                TailLink.transform.Rotate(0.0f, 0.0f, -90.0f);
                TailLink.transform.localScale = new Vector3(0.2f, 0.2f, 0.001f);
                TailLink.transform.SetParent(this.transform);
                TailLink.transform.localPosition = new Vector3((i * 1.2f) + 0.6f, 1.6f, 0);
            }

           
        }

        transform.position = new Vector3(-length / 2, 5 / 2f, 0);
        initializing_the_returing_arrow(this.transform.localPosition.x + length * 0.6f - 0.6f, this.transform.localPosition.y, this.transform.position.z);
    }



    public void Rotate()
    {
            StartCoroutine(RotateUtil());
    }

    private IEnumerator RotateUtil()
    {

        if (length  <2 )
        {

        }
        else
        {
            LeanTween.moveLocalX(TailLabel, nodes[length - 2].transform.localPosition.x, 1.5f);
            LeanTween.moveLocalX(TailLink, nodes[length - 2].transform.localPosition.x, 1.5f);
            yield return new WaitForSeconds(1.5f);

            LeanTween.moveLocalY(nodes[length - 1], -1.0f, 1.4f);
            LeanTween.moveLocalY(links[length - 2], -1.0f, 1.4f);
            yield return new WaitForSeconds(1.4f);

            LeanTween.moveLocalX(nodes[length - 1], nodes[0].transform.localPosition.x - 1.2f, 2.0f);
            LeanTween.moveLocalX(links[length - 2], nodes[0].transform.localPosition.x - 0.6f, 2.0f);
            
            //we are adjasting the returning array here
            //the base
            LeanTween.moveLocalX(head_pointer2, head_pointer2.transform.localPosition.x - 1.2f, 2.0f);
            //the poll
            LeanTween.moveLocalX(straightlinebegining, straightlinebegining.transform.localPosition.x - 1.2f, 2.0f);
            LeanTween.moveLocalX(straightlineend, straightlineend.transform.localPosition.x - 1.2f, 2.0f);
            Debug.Log("We are moving up now 1");

            yield return new WaitForSeconds(2.0f);

            Debug.Log("We are moving up now2");

            LeanTween.moveLocalY(links[length - 2], 1.0f, 1.4f);
            LeanTween.moveLocalY(nodes[length - 1], 1.0f, 1.4f);
            yield return new WaitForSeconds(1.4f);



            GameObject tempnode = nodes[length - 1];
            GameObject templink = links[length - 2];
            for (int i = length - 1; i >0 ; i--)
            {
                if (i == length - 1)
                {
                    nodes[i] = nodes[i - 1];
                }
                else
                {
                    nodes[i] = nodes[i - 1];
                    links[i] = links[i - 1];
                }
            }
            nodes[0] = tempnode;
            links[0] = templink;
        }
    }

    public void DeleteFirst()
    {
        StartCoroutine(DeleteFirstUtil());
    }

    private IEnumerator DeleteFirstUtil()
    {
        if (length == 0 || length < 2)
        {

        }
        else
        {
            int tt = length - 1;
            //LeanTween.moveLocalX(HeadLabel, nodes[1].transform.localPosition.x, 1.5f);
            //LeanTween.moveLocalX(HeadLink, nodes[1].transform.localPosition.x, 1.5f);
            //yield return new WaitForSeconds(1f);

            LeanTween.color(nodes[0], Color.red, 1f);
            yield return new WaitForSeconds(2f);

            //delete first
            nodes[0].transform.SetParent(null);
            links[0].transform.SetParent(null);
            Destroy(links[0]);
            Destroy(nodes[0]);

            //we are adjasting the returning array here
            //the base
            LeanTween.moveLocalX(head_pointer2, head_pointer2.transform.localPosition.x + 0.6f, 1.5f);
            LeanTween.scaleX(head_pointer2, (tt / 2.0f) - 0.5f, 1.5f);
            //the poll
            LeanTween.moveLocalX(straightlinebegining, straightline.transform.localPosition.x + 1.2f, 1.5f);

            for (int i = 1; i < length; i++)
            {
                if (i < length - 2)
                {
                    nodes[i - 1] = nodes[i];
                    links[i - 1] = links[i];
                }
                else
                {
                    nodes[i - 1] = nodes[i];
                }
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
        if (length == 0 || length <2)
        {

        }
        else
        {
            
            // GameObject tempNull;
            GameObject CurrentLabel;
            GameObject CurrentLink;


            CurrentLabel = GameObject.Instantiate(CurrentText, new Vector3(nodes[0].transform.localPosition.x, nodes[0].transform.localPosition.y + 0.9f, 0), Quaternion.identity);
            CurrentLabel.transform.localScale = new Vector3(1.2f, 1.2f, 0.001f);
            CurrentLabel.transform.SetParent(this.transform);
            CurrentLabel.transform.localPosition = new Vector3(nodes[0].transform.localPosition.x, nodes[0].transform.localPosition.y + 0.9f, 0);

            CurrentLink = GameObject.Instantiate(link, new Vector3(nodes[0].transform.localPosition.x, nodes[0].transform.localPosition.y + 0.55f, 0), Quaternion.identity);
            CurrentLink.transform.Rotate(0.0f, 0.0f, -90.0f);
            CurrentLink.transform.localScale = new Vector3(0.2f, 0.2f, 0.001f);
            CurrentLink.transform.SetParent(this.transform);
            CurrentLink.transform.localPosition = new Vector3(nodes[0].transform.localPosition.x, nodes[0].transform.localPosition.y + 0.55f, 0);


            for (int i = 0; i < length - 1; i++)
            {
                    LeanTween.moveLocalX(CurrentLabel, nodes[i].transform.localPosition.x, .7f);
                    LeanTween.moveLocalX(CurrentLink, nodes[i].transform.localPosition.x, .7f);
                    LeanTween.color(nodes[i], Color.blue, 1f).setLoopPingPong(1);
                  
                yield return new WaitForSeconds(1.5f);
            }

                LeanTween.moveLocalX(CurrentLabel, nodes[length-1].transform.localPosition.x, .7f);
                LeanTween.moveLocalX(CurrentLink, nodes[length-1].transform.localPosition.x, .7f);
                LeanTween.color(nodes[length-1], Color.blue, 1f).setLoopPingPong(1);

                LeanTween.moveLocalX(TailLabel, nodes[length - 2].transform.localPosition.x, .7f);
                LeanTween.moveLocalX(TailLink, nodes[length - 2].transform.localPosition.x, .7f);

            yield return new WaitForSeconds(1.7f);


            //tempNull = Instantiate(NullText, new Vector3(TailLink.transform.localPosition.x + .8f, TailLink.transform.localPosition.y - .2f, 0), Quaternion.identity);
            //tempNull.transform.localScale = new Vector3(1.5f, 1.5f, 0.001f);
            //tempNull.transform.SetParent(this.transform);
            //tempNull.transform.localPosition = new Vector3(TailLink.transform.localPosition.x + .8f, TailLink.transform.localPosition.y - .2f, 0);

            LeanTween.color(nodes[length - 1], Color.red, 2f);

            yield return new WaitForSeconds(1f);

            LeanTween.moveLocalY(CurrentLink, CurrentLink.transform.localPosition.y + 0.6f, 0.7f);
            LeanTween.moveLocalY( CurrentLabel, CurrentLabel.transform.localPosition.y + 0.6f, 0.7f);

            LeanTween.rotateZ(links[length - 2], 45, .7f).setLoopPingPong(1);
            LeanTween.moveLocalY(links[length - 2], links[length - 2].transform.localPosition.y + .3f, .7f);
            LeanTween.moveLocalY(nodes[length - 1], nodes[length - 1].transform.localPosition.y + 0.6f, 0.7f);
          
            yield return new WaitForSeconds(.7f);

            //NullText.transform.SetParent(null);
            //Destroy(NullText);
            nodes[length - 1].transform.SetParent(null);
            links[length - 2].transform.SetParent(null);
            Destroy(links[length - 2]);
            Destroy(nodes[length - 1]);


            //we are adjasting the returning array here
            //the base
            LeanTween.moveLocalX(head_pointer2, head_pointer2.transform.localPosition.x - 0.6f, 1.5f);
            //we are rescaling#
            //we are also decrementing the number of nodes here
            LeanTween.scaleX(head_pointer2, (length - 2) * 0.353f, 1.5f);
            //the poll
            LeanTween.moveLocalX(straightlineend, straightlineend.transform.localPosition.x - 1.2f, 1.5f);


            //here we destroy the cirrent lable
            CurrentLabel.transform.SetParent(null);
            CurrentLink.transform.SetParent(null);
            Destroy(CurrentLabel);
            Destroy(CurrentLink);

            //LeanTween.moveLocalX(tempNull, nodes[length - 2].transform.localPosition.x + 1.4f, 1.5f);
            //LeanTween.moveLocalY(tempNull, .95f, 1.5f);

            // yield return new WaitForSeconds(2f);

            //NullText = tempNull;
            //length--;

            Debug.Log("the length is:::: " + length);
            length--;
        }
    }


    public void Append()
    {
        int number = int.Parse(NumberInputField.text);
        //int number = 10;
        StartCoroutine(AppendUtil(number));
    }

   
    //this will be good!!!
    private IEnumerator AppendUtil(int number)
    {
        if (length == 0)
        {

        }
        else
        {
            
            GameObject newNode;
            GameObject newNodeLabel;
            GameObject newNodeLinker;
            GameObject TempNull;


            //initializing the new node that will be added
            newNode = Instantiate(node, new Vector3(nodes[length - 1].transform.localPosition.x+1.2f, -0.14f, 0), Quaternion.identity);
            newNode.transform.SetParent(this.transform);
            newNode.transform.localScale = new Vector3(0.6f, 0.6f, 0.001f);
            newNode.GetComponentInChildren<TextMeshPro>().text = number.ToString();
            newNode.GetComponentInChildren<TextMeshPro>().color = Color.black;
            newNode.transform.localPosition = new Vector3(nodes[length - 1].transform.localPosition.x + 1.2f, -0.14f, 0);

            //text that shows the createion of the new node
            newNodeLabel = Instantiate(newNodeText, new Vector3(nodes[length - 1].transform.localPosition.x + 0.9f, -0.14f, 0), Quaternion.identity);
            newNodeLabel.transform.localScale = new Vector3(.9f, .9f, 0.001f);
            newNodeLabel.transform.SetParent(this.transform);
            newNodeLabel.transform.localPosition = new Vector3(nodes[length - 1].transform.localPosition.x+1.2f, newNode.transform.localPosition.y - 0.5f, 0);

            //
            newNodeLinker = Instantiate(link, new Vector3(newNode.transform.localPosition.x, 1.0f, 0), Quaternion.identity);
            newNodeLinker.transform.localScale = new Vector3(0.2f, 0.2f, 0.001f);
            newNodeLinker.transform.SetParent(this.transform);
            newNodeLinker.transform.localPosition = new Vector3(newNode.transform.localPosition.x + 0.6f, newNode.transform.localPosition.y, 0);


            TempNull = Instantiate(nullTxt, new Vector3(newNode.transform.localPosition.x + 1.4f, newNode.transform.localPosition.y, 0), Quaternion.identity);
            TempNull.transform.localScale = new Vector3(1.5f, 1.5f, 0.001f);
            TempNull.transform.SetParent(this.transform);
            TempNull.transform.localPosition = new Vector3(newNode.transform.localPosition.x + 1.4f, newNode.transform.localPosition.y, 0);


            yield return new WaitForSeconds(1f);

            //NullText.transform.SetParent(null);
            //Destroy(NullText);
            //NullText = TempNull;

            TempNull.transform.SetParent(null);
            Destroy(TempNull);


            //We dont need this because we dont have a last pointer, at the end that van be used to perfrom this manouever!!
            //LeanTween.moveLocalX(links[length - 2], newNode.transform.localPosition.x, 1.5f).setLoopPingPong(1);
            //LeanTween.moveLocalY(links[length - 2], nodes[length - 1].transform.localPosition.y - .55f, 1.5f).setLoopPingPong(1);
            //LeanTween.rotateZ(links[length - 2], -90, 1.5f).setLoopPingPong(1);

            //but we do have some thing else
            //we are adjasting the returning array here
            //the base
            LeanTween.moveLocalX(head_pointer2, head_pointer2.transform.localPosition.x + 0.6f, 1.5f);
            //we are rescaling#
           
            LeanTween.scaleX(head_pointer2, (length ) * 0.353f, 1.5f);
            yield return new WaitForSeconds(1.5f);

            GameObject FinalNewLink = Instantiate(link, new Vector3(nodes[length - 1].transform.localPosition.x, nodes[length - 1].transform.localPosition.y-0.6f, nodes[length - 1].transform.localPosition.z),Quaternion.identity);
            FinalNewLink.transform.localScale = new Vector3(0.2f, 0.2f, 0.001f);
            FinalNewLink.transform.SetParent(this.transform);
            FinalNewLink.transform.localPosition= (new Vector3(nodes[length - 1].transform.localPosition.x, nodes[length - 1].transform.localPosition.y - 0.6f, nodes[length - 1].transform.localPosition.z));
            FinalNewLink.transform.Rotate(0.0f, 0.0f, -90.0f);
            
     
            straightlineend.SetActive(false);

            yield return new WaitForSeconds(1.5f);

            LeanTween.moveLocalX(newNode, nodes[length - 1].transform.localPosition.x + 1.2f, 1.5f);
            LeanTween.moveLocalY(newNode, 1f, 1.5f);
            //LeanTween.rotateZ(newNodeLinker, 0, 1.5f);

            LeanTween.moveLocalY(newNodeLinker, 0.4f, 1.5f);
            LeanTween.moveLocalX(newNodeLinker, newNode.transform.localPosition.x, 1.5f);
            LeanTween.rotate(newNodeLinker, new Vector3(0.0f, 0.0f, -90.0f), 1.5f);
            //LeanTween.moveLocalX(newNodeLinker, newNode.transform.localPosition.x + 1.8f, 1.5f);

            //LeanTween.moveLocalY(TempNull, .95f, 1.5f);
            //LeanTween.moveLocalX(TempNull, newNode.transform.localPosition.x + 2.5f, 1.5f);

            LeanTween.moveLocalX(newNodeLabel, newNode.transform.localPosition.x + 1.2f, 1.5f);
            LeanTween.moveLocalY(newNodeLabel, 0.5f, 1.5f);

            LeanTween.moveLocalX(FinalNewLink, nodes[length - 1].transform.localPosition.x + 0.6f, 1.5f);
            LeanTween.moveLocalY(FinalNewLink, nodes[length - 1].transform.localPosition.y, 1.5f);
            LeanTween.rotate(FinalNewLink, new Vector3(0.0f, 0.0f, 0.0f), 1.5f);

            yield return new WaitForSeconds(1.8f);
            LeanTween.moveLocalX(TailLabel, nodes[length - 1].transform.localPosition.x + 1.2f, 1.5f);
            LeanTween.moveLocalX(TailLink, nodes[length - 1].transform.localPosition.x + 1.2f, 1.5f);
            
            
            //the poll that connects the last node with the first one
            LeanTween.moveLocalX(straightlineend, straightlineend.transform.localPosition.x + 1.2f, 1.5f);
            yield return new WaitForSeconds(1.8f);

            straightlineend.SetActive(true);

            

            newNodeLabel.transform.parent = null;
            Destroy(newNodeLabel);

            newNodeLinker.transform.SetParent(null);
            Destroy(newNodeLinker);

            int positionL = length - 1;
            links[positionL] = FinalNewLink;
            nodes[length] = newNode;
            
            length++;

        }
    }
    public void Prepend()
    {
        int number = int.Parse(NumberInputField.text);
        StartCoroutine(PrependUtil(number));
    }
  
    private IEnumerator PrependUtil(int number)
    {
        Debug.Log("We are prepanding something with number:: "+ number);
        if (length == 0)
        {
        }
        else
        {
            length++;
            GameObject newNode;
            GameObject newNodeLabel;
            GameObject newNodeLinker;
            GameObject TempNull;

            //we create a new Node here
            newNode = Instantiate(node, new Vector3(nodes[0].transform.localPosition.x-2.0f, -0.14f, 0), Quaternion.identity);
            newNode.transform.SetParent(this.transform);
            newNode.transform.localScale = new Vector3(0.6f, 0.6f, 0.001f);
            newNode.GetComponentInChildren<TextMeshPro>().text = number.ToString();
            newNode.GetComponentInChildren<TextMeshPro>().color = Color.black;
            newNode.transform.localPosition = new Vector3(nodes[0].transform.localPosition.x - 2.0f, -0.14f, 0);

            //we create the new node lable
            newNodeLabel = Instantiate(newNodeText, new Vector3(nodes[0].transform.localPosition.x - 2.0f, -0.14f, 0), Quaternion.identity);
            newNodeLabel.transform.localScale = new Vector3(.9f, .9f, 0.001f);
            newNodeLabel.transform.SetParent(this.transform);
            newNodeLabel.transform.localPosition = new Vector3(nodes[0].transform.localPosition.x - 2.0f, newNode.transform.localPosition.y - 0.5f, 0);

            //here there was some code for newNodeLinker

            //we create the new node linker, we will work with this later on
            newNodeLinker = Instantiate(link, new Vector3(newNode.transform.localPosition.x, 1.0f, 0), Quaternion.identity);
            newNodeLinker.transform.localScale = new Vector3(0.2f, 0.2f, 0.001f);
            newNodeLinker.transform.SetParent(this.transform);
            newNodeLinker.transform.localPosition = new Vector3(newNode.transform.localPosition.x + 0.6f, newNode.transform.localPosition.y, 0);

            //temp null message that will be deleted soon after
            TempNull = Instantiate(nullTxt, new Vector3(newNode.transform.localPosition.x + 1.4f, newNode.transform.localPosition.y, 0), Quaternion.identity);
            TempNull.transform.localScale = new Vector3(1.5f, 1.5f, 0.001f);
            TempNull.transform.SetParent(this.transform);
            TempNull.transform.localPosition = new Vector3(newNode.transform.localPosition.x + 1.4f, newNode.transform.localPosition.y, 0);
            yield return new WaitForSeconds(1f);


            TempNull.transform.parent = null;
            Destroy(TempNull);

            //LeanTween.moveLocalX(newNodeLinker, nodes[0].transform.localPosition.x, 1.5f);
            //LeanTween.moveLocalY(newNodeLinker, nodes[0].transform.localPosition.y - 0.55f, 1.5f);
            LeanTween.scale(newNodeLinker, new Vector3(0.5f, 0.5f, 0.0f), 1.0f);
            LeanTween.moveLocalX(newNodeLinker, newNodeLinker.transform.localPosition.x + 0.4f, 1.0f);
            LeanTween.moveLocalY(newNodeLinker, newNodeLinker.transform.localPosition.y + 0.4f, 1.0f);
            LeanTween.rotateZ(newNodeLinker, 35, 1.0f);

            yield return new WaitForSeconds(1.5f);

            newNodeLabel.transform.parent = null;
            Destroy(newNodeLabel);

            LeanTween.moveLocalX(newNode, nodes[0].transform.localPosition.x - 1.2f, 1.5f);
            LeanTween.moveLocalY(newNode, 1f, 1.5f);
            LeanTween.rotateZ(newNodeLinker, 0, 1.5f);
            LeanTween.moveLocalY(newNodeLinker, 1f, 1.5f);
            LeanTween.moveLocalX(newNodeLinker, nodes[0].transform.localPosition.x - 0.6f, 1.5f);
            LeanTween.moveLocalX(newNodeLabel, nodes[0].transform.localPosition.x - 1.2f, 1.5f);
            LeanTween.moveLocalY(newNodeLabel, 0.5f, 1.5f);
            LeanTween.scale(newNodeLinker, new Vector3(0.2f, 0.2f, 0.0f), 1.0f);


            // yield return new WaitForSeconds(1.8f);
            //we are adjasting the returning array here
            //the base
            LeanTween.moveLocalX(head_pointer2, head_pointer2.transform.localPosition.x - 0.6f, 1.5f);
            //we are rescaling#
            LeanTween.scaleX(head_pointer2, (length - 1) * 0.353f, 1.5f);
            //the poll
            LeanTween.moveLocalX(straightlinebegining, straightlinebegining.transform.localPosition.x - 1.2f, 1.5f);
            yield return new WaitForSeconds(1.8f);

            for (int i = length; i > 0; i--)
            {
                nodes[i] = nodes[i - 1];
                links[i] = links[i - 1];
            }
            nodes[0] = newNode;
            links[0] = newNodeLinker;
           
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

            //HeadLink.transform.parent = null;
            //Destroy(HeadLink);
            TailLink.transform.parent = null;
            Destroy(TailLink);
            //HeadLabel.transform.parent = null;
            //Destroy(HeadLabel);
            TailLabel.transform.parent = null;
            Destroy(TailLabel);
            NullText.transform.parent = null;
            Destroy(NullText);

            straightline.transform.parent = null;
            straightlinebegining.transform.SetParent(null);
            straightlineend.transform.SetParent(null);

            Destroy(straightline);
            Destroy(straightlinebegining);
            Destroy(straightlineend);

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
        //int number = 12;
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

            CurrentLabel = GameObject.Instantiate(CurrentText, new Vector3(nodes[0].transform.localPosition.x, nodes[0].transform.localPosition.y + .9f, 0), Quaternion.identity);
            CurrentLabel.transform.localScale = new Vector3(1.2f, 1.2f, 0.001f);
            CurrentLabel.transform.SetParent(this.transform);
            CurrentLink = GameObject.Instantiate(link, new Vector3(nodes[0].transform.localPosition.x, nodes[0].transform.localPosition.y + 0.55f, 0), Quaternion.identity);
            CurrentLink.transform.Rotate(0.0f, 0.0f, -90.0f);
            CurrentLink.transform.localScale = new Vector3(0.2f, 0.2f, 0.001f);
            CurrentLink.transform.SetParent(this.transform);
            CurrentLabel.transform.localPosition = new Vector3(nodes[0].transform.localPosition.x, nodes[0].transform.localPosition.y + .9f, 0);
            CurrentLink.transform.localPosition = new Vector3(nodes[0].transform.localPosition.x, nodes[0].transform.localPosition.y + 0.55f, 0);

            yield return new WaitForSeconds(1);
            int i;
            for (i = 0; i < length; i++)
            {

                if (i == length - 1)
                {

                    LeanTween.moveLocalX(TailLabel, TailLabel.transform.localPosition.x + 1f, .7f);
                    LeanTween.moveLocalX(TailLink, TailLink.transform.localPosition.x + 0.5f,.7f);
                    LeanTween.rotate(TailLink, new Vector3(0f, 0f, -135f), 1f);
                }
                LeanTween.moveLocalX(CurrentLabel, nodes[i].transform.localPosition.x, .7f);
                LeanTween.moveLocalX(CurrentLink, nodes[i].transform.localPosition.x, .7f);
                LeanTween.color(nodes[i], Color.blue, 1f).setLoopPingPong(1);
                
                if(i<length-1)
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
                //LeanTween.moveLocalX(CurrentLabel, NullText.transform.localPosition.x, .7f);
                //LeanTween.moveLocalX(CurrentLink, NullText.transform.localPosition.x, .7f);
            }
            else
            {
                LeanTween.color(nodes[i], Color.white, 1f);
            }
            yield return new WaitForSeconds(2f);
            LeanTween.moveLocalX(TailLabel, TailLabel.transform.localPosition.x - 1f, 1f);
            LeanTween.moveLocalX(TailLink, TailLink.transform.localPosition.x - 0.5f, 1f);
            LeanTween.rotate(TailLink, new Vector3(0f, 0f, -90), 1f);

            CurrentLabel.transform.SetParent(null);
            CurrentLink.transform.SetParent(null);
            Destroy(CurrentLabel);
            Destroy(CurrentLink);
        }
    }

    public void DeleteValue()
    {
        int number = int.Parse(NumberInputField.text);
        //int number = 12;
        StartCoroutine(DeleteValueUtil(number));
    }

    private IEnumerator DeleteValueUtil(int number)
    {

        bool last_elemet = false;
        if (length == 0 || length<2)
        {

        }
        else if (int.Parse(nodes[0].GetComponentInChildren<TextMeshPro>().text) == number)
        {
            DeleteFirst();
            yield break;
        }else if (int.Parse(nodes[length-1].GetComponentInChildren<TextMeshPro>().text) == number)
        {
            DeleteLast();
            yield break;
        }
        else
        {
            GameObject CurrentLabel;
            GameObject CurrentLink;

            GameObject previousLink;
            GameObject previousLabel;


            previousLabel = Instantiate(PreviousLBL, new Vector3(nodes[0].transform.localPosition.x, nodes[0].transform.localPosition.y + .9f, 0), Quaternion.identity);
            previousLabel.transform.localScale = new Vector3(1.2f, 1.2f, 0.001f);
            previousLabel.transform.SetParent(this.transform);
            previousLabel.transform.localPosition = new Vector3(nodes[0].transform.localPosition.x, nodes[0].transform.localPosition.y + .9f, 0);

            previousLink = Instantiate(link, new Vector3(nodes[0].transform.localPosition.x, nodes[0].transform.localPosition.y + 0.55f, 0), Quaternion.identity);
            previousLink.transform.Rotate(0.0f, 0.0f, -90.0f);
            previousLink.transform.localScale = new Vector3(0.2f, 0.2f, 0.001f);
            previousLink.transform.SetParent(this.transform);
            previousLink.transform.localPosition = new Vector3(nodes[0].transform.localPosition.x, nodes[0].transform.localPosition.y + 0.55f, 0);

            previousLabel.SetActive(false);
            previousLink.SetActive(false);

            CurrentLabel = GameObject.Instantiate(CurrentText, new Vector3(nodes[0].transform.localPosition.x, nodes[0].transform.localPosition.y + .9f, 0), Quaternion.identity);
            CurrentLabel.transform.localScale = new Vector3(1.2f, 1.2f, 0.001f);
            CurrentLabel.transform.SetParent(this.transform);
            CurrentLabel.transform.localPosition = new Vector3(nodes[0].transform.localPosition.x, nodes[0].transform.localPosition.y + .9f, 0);

            CurrentLink = GameObject.Instantiate(link, new Vector3(nodes[0].transform.localPosition.x, nodes[0].transform.localPosition.y + 0.55f, 0), Quaternion.identity);
            CurrentLink.transform.Rotate(0.0f, 0.0f, -90.0f);
            CurrentLink.transform.localScale = new Vector3(0.2f, 0.2f, 0.001f);
            CurrentLink.transform.SetParent(this.transform);
            CurrentLink.transform.localPosition = new Vector3(nodes[0].transform.localPosition.x, nodes[0].transform.localPosition.y + 0.55f, 0);

            yield return new WaitForSeconds(1);
            
            int i;

            for (i = 0; i < length; i++)
            {
                LeanTween.moveLocalX(CurrentLabel, nodes[i].transform.localPosition.x, .7f);
                LeanTween.moveLocalX(CurrentLink, nodes[i].transform.localPosition.x, .7f);
                LeanTween.color(nodes[i], Color.blue, 1f).setLoopPingPong(1);
                
                //here we need to keep in minde that we will hvae one  link lass than we have nodes
                if(i<length-1)
                   LeanTween.moveLocalX(links[i], links[i].transform.localPosition.x + 0.09f, 1f).setLoopPingPong(1);

                if (i == 1)
                {
                    yield return new WaitForSeconds(.8f);
                    previousLabel.SetActive(true);
                    previousLink.SetActive(true);
                }

                //adjasting for changes
                if (i == length - 1)
                {
                    last_elemet = true;
                    LeanTween.moveLocalX(TailLabel, TailLabel.transform.localPosition.x + 1.0f, .7f);
                    LeanTween.moveLocalX(TailLink, TailLink.transform.localPosition.x + 0.5f, .7f);
                    LeanTween.rotate(TailLink, new Vector3(0.0f, .0f, -135.0f), .7f);
                }

                if (i > 1)
                {
                    LeanTween.moveLocalX(previousLabel, nodes[i - 1].transform.localPosition.x, .9f);
                    LeanTween.moveLocalX(previousLink, nodes[i - 1].transform.localPosition.x, .9f);
                }


                if (int.Parse(nodes[i].GetComponentInChildren<TextMeshPro>().text) == number)
                {

                    yield return new WaitForSeconds(1.1f);

                    LeanTween.moveLocalY(nodes[i], nodes[i].transform.localPosition.y + 0.5f, 1f);
                    LeanTween.rotateZ(links[i-1], +60, 1f);
                    LeanTween.moveLocalY(links[i-1], nodes[i].transform.localPosition.y + 0.3f, 1f);
                    LeanTween.moveLocalY(CurrentLabel, CurrentLabel.transform.localPosition.y + 0.5f,1f);
                    LeanTween.moveLocalY(CurrentLink, CurrentLink.transform.localPosition.y + 0.5f, 1f);
                    yield return new WaitForSeconds(1.5f);

                    if (!(i == length - 1))
                    {
                        LeanTween.rotateZ(links[i - 1], 0, 1f);
                        LeanTween.moveLocalY(links[i - 1], links[i - 1].transform.localPosition.y - 0.3f, 1f);
                        yield return new WaitForSeconds(1f);

                        LeanTween.scaleX(links[i - 1], 1.0f, 1.4f).setLoopPingPong(1);
                        LeanTween.moveLocalX(links[i - 1], links[i - 1].transform.localPosition.x + 0.6f, 1.4f).setLoopPingPong(1);
                    }

                    LeanTween.color(nodes[i], Color.red, 1f);
                    yield return new WaitForSeconds(1.1f);
                    nodes[i].transform.SetParent(null);
                    Destroy(nodes[i]);

                    if (i < length - 1)
                    {
                        links[i].transform.SetParent(null);
                        Destroy(links[i]);
                    }

                    CurrentLabel.transform.SetParent(null);
                    CurrentLink.transform.SetParent(null);
                    Destroy(CurrentLabel);
                    Destroy(CurrentLink);
                    previousLabel.transform.SetParent(null);
                    previousLink.transform.SetParent(null);
                    Destroy(previousLabel);
                    Destroy(previousLink);

                    if (last_elemet)
                    {
                        LeanTween.moveLocalX(TailLabel, TailLabel.transform.localPosition.x - 1.0f, .7f);
                        LeanTween.moveLocalX(TailLink, TailLink.transform.localPosition.x - 0.5f, .7f);
                        LeanTween.rotate(TailLink, new Vector3(0.0f, .0f, -90), .7f);
                    }

                    yield return new WaitForSeconds(.7f);


                    if (i == length - 1)
                    {
                        //LeanTween.moveLocalX(NullText, NullText.transform.localPosition.x - 1.2f, 1f);
                        LeanTween.moveLocalX(TailLabel, TailLabel.transform.localPosition.x - 1.2f, 1f);
                        LeanTween.moveLocalX(TailLink, TailLink.transform.localPosition.x - 1.2f, 1f);
                    }
                    else
                    {
                        for (int j = i + 1; j < length; j++)
                        {
                            LeanTween.moveLocalX(nodes[j], nodes[j].transform.localPosition.x - 1.2f, 1f);
                            
                            if(j<length-1)
                            LeanTween.moveLocalX(links[j], links[j].transform.localPosition.x - 1.2f, 1f);
                            nodes[j - 1] = nodes[j];
                            links[j - 1] = links[j];

                            if (j == length - 1)
                            {
                                LeanTween.moveLocalX(TailLabel, TailLabel.transform.localPosition.x - 1.2f, 1f);
                                LeanTween.moveLocalX(TailLink, TailLink.transform.localPosition.x - 1.2f, 1f);
                                //LeanTween.moveLocalX(NullText, NullText.transform.localPosition.x - 1.2f, 1f);
                            }
                        }
                    }


                    //we are adjasting the returning array here
                    //the base
                    LeanTween.moveLocalX(head_pointer2, head_pointer2.transform.localPosition.x - 0.6f, 1f);
                    //we are rescaling#
                    LeanTween.scaleX(head_pointer2, (length - 2) * 0.353f, 1f);
                    //the poll
                    LeanTween.moveLocalX(straightlineend, straightlineend.transform.localPosition.x - 1.2f, 1f);
                    //yield return new WaitForSeconds(1.8f);

                    yield return new WaitForSeconds(.7f);
                         
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

                LeanTween.moveLocalX(TailLabel, TailLabel.transform.localPosition.x - 1.0f, .7f);
                LeanTween.moveLocalX(TailLink, TailLink.transform.localPosition.x - 0.5f, .7f);
                LeanTween.rotate(TailLink, new Vector3(0.0f, .0f, -90f), .7f);
                yield return new WaitForSeconds(.7f);

            }

            length--;
        }
    }


    public void DeleteAtPosition()
    {
        //int position = int.Parse(IndexInputField.text);
        int position = 2;
        if (position == 0 || position > length) return;
        StartCoroutine(DeleteAtPositionUtil(position - 1));
    }

    private IEnumerator DeleteAtPositionUtil(int position)
    {


        if (length == 0 || length < 2)
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


            previousLabel = Instantiate(PreviousLBL, new Vector3(nodes[0].transform.localPosition.x, nodes[0].transform.localPosition.y + .9f, 0), Quaternion.identity);
            previousLabel.transform.localScale = new Vector3(1.2f, 1.2f, 0.001f);
            previousLabel.transform.SetParent(this.transform);
            previousLink = Instantiate(link, new Vector3(nodes[0].transform.localPosition.x, nodes[0].transform.localPosition.y + 0.55f, 0), Quaternion.identity);
            previousLink.transform.Rotate(0.0f, 0.0f, -90.0f);
            previousLink.transform.localScale = new Vector3(0.2f, 0.2f, 0.001f);
            previousLink.transform.SetParent(this.transform);
            previousLabel.transform.localPosition = new Vector3(nodes[0].transform.localPosition.x, nodes[0].transform.localPosition.y + .9f, 0);
            previousLink.transform.localPosition = new Vector3(nodes[0].transform.localPosition.x, nodes[0].transform.localPosition.y + 0.55f, 0);

            previousLabel.SetActive(false);
            previousLink.SetActive(false);

            CurrentLabel = GameObject.Instantiate(CurrentText, new Vector3(nodes[0].transform.localPosition.x, nodes[0].transform.localPosition.y + .9f, 0), Quaternion.identity);
            CurrentLabel.transform.localScale = new Vector3(1.2f, 1.2f, 0.001f);
            CurrentLabel.transform.SetParent(this.transform);
            CurrentLink = GameObject.Instantiate(link, new Vector3(nodes[0].transform.localPosition.x, nodes[0].transform.localPosition.y + 0.55f, 0), Quaternion.identity);
            CurrentLink.transform.Rotate(0.0f, 0.0f, -90.0f);
            CurrentLink.transform.localScale = new Vector3(0.2f, 0.2f, 0.001f);
            CurrentLink.transform.SetParent(this.transform);
            CurrentLabel.transform.localPosition = new Vector3(nodes[0].transform.localPosition.x, nodes[0].transform.localPosition.y + .9f, 0);
            CurrentLink.transform.localPosition = new Vector3(nodes[0].transform.localPosition.x, nodes[0].transform.localPosition.y + 0.55f, 0);

            yield return new WaitForSeconds(1);
            int i;

            for (i = 0; i < length; i++)
            {
                LeanTween.moveLocalX(CurrentLabel, nodes[i].transform.localPosition.x, .7f);
                LeanTween.moveLocalX(CurrentLink, nodes[i].transform.localPosition.x, .7f);
                LeanTween.color(nodes[i], Color.blue, 1f).setLoopPingPong(1);
                
                if(i<length-1)
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
                    LeanTween.moveLocalY(CurrentLabel, CurrentLabel.transform.localPosition.y + 0.5f, 1f);
                    LeanTween.moveLocalY(CurrentLink, CurrentLink.transform.localPosition.y + 0.5f, 1f);
                    LeanTween.moveLocalY(nodes[i], nodes[i].transform.localPosition.y + 0.5f, 1f);
                    LeanTween.rotateZ(links[i], -60, 1f);
                    LeanTween.moveLocalY(links[i], nodes[i].transform.localPosition.y + 0.3f, 1f);   
                    yield return new WaitForSeconds(1.5f);


                    if (i < length - 1)
                    {
                        LeanTween.scaleX(links[i - 1], 1.0f, 1f).setLoopPingPong(1);
                        LeanTween.moveLocalX(links[i - 1], links[i - 1].transform.localPosition.x + 0.6f, 1f).setLoopPingPong(1);
                    }
                    else
                    {
                        links[i - 1].transform.SetParent(null);
                        Destroy(links[i - 1]);
                    }

                    LeanTween.color(nodes[i], Color.red, 1f);
                    yield return new WaitForSeconds(1.1f);


                    nodes[i].transform.SetParent(null);
                    Destroy(nodes[i]);
                    if (i < length - 1)
                    {
                        links[i].transform.SetParent(null);
                        Destroy(links[i]);
                    }


                    //LeanTween.moveLocalX(NullText, NullText.transform.localPosition.x - 1.2f, 1f);
                    //LeanTween.moveLocalX(TailLabel, TailLabel.transform.localPosition.x - 1.2f, 1f);
                    //LeanTween.moveLocalX(TailLink, TailLink.transform.localPosition.x - 1.2f, 1f);


                    for (int j = i + 1; j < length; j++)
                        {
                            LeanTween.moveLocalX(nodes[j], nodes[j].transform.localPosition.x - 1.2f, 1f);
                            nodes[j - 1] = nodes[j];

                        if (j < length - 1)
                        {
                            LeanTween.moveLocalX(links[j], links[j].transform.localPosition.x - 1.2f, 1f);
                            links[j - 1] = links[j];
                        }

                    } 
                        LeanTween.moveLocalX(TailLabel, TailLabel.transform.localPosition.x - 1.2f, 1f);
                        LeanTween.moveLocalX(TailLink, TailLink.transform.localPosition.x - 1.2f, 1f);
                       
                      //we are adjasting the returning array here
                            //the base
                            LeanTween.moveLocalX(head_pointer2, head_pointer2.transform.localPosition.x - 0.6f, 1f);
                            //we are rescaling#
                            LeanTween.scaleX(head_pointer2, (length - 2) * 0.353f, 1f);
                            //the poll
                            LeanTween.moveLocalX(straightlineend, straightlineend.transform.localPosition.x - 1.2f, 1f);
                            //yield return new WaitForSeconds(1.8f);

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
        //int number = int.Parse(NumberInputField.text);
        //int position = int.Parse(IndexInputField.text);
        int number = 12;
        int position = 2;
        if (position == 0 || position > length + 1) return;
        StartCoroutine(InsertAtPositionUtil(number, position - 1));
    }

    private IEnumerator InsertAtPositionUtil(int number, int position)
    {


        if (length == 0)
        {

        }
        else if (position == 0)
        {
            Prepend();
            yield break;
        }
        else if (position == length)
        {
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

            previousLabel = Instantiate(PreviousLBL, new Vector3(nodes[0].transform.localPosition.x, nodes[0].transform.localPosition.y + .9f, 0), Quaternion.identity);
            previousLabel.transform.localScale = new Vector3(1.2f, 1.2f, 0.001f);
            previousLabel.transform.SetParent(this.transform);
            previousLink = Instantiate(link, new Vector3(nodes[0].transform.localPosition.x, nodes[0].transform.localPosition.y + 0.55f, 0), Quaternion.identity);
            previousLink.transform.Rotate(0.0f, 0.0f, -90.0f);
            previousLink.transform.localScale = new Vector3(0.2f, 0.2f, 0.001f);
            previousLink.transform.SetParent(this.transform);
            previousLabel.transform.localPosition = new Vector3(nodes[0].transform.localPosition.x, nodes[0].transform.localPosition.y + .9f, 0);
            previousLink.transform.localPosition = new Vector3(nodes[0].transform.localPosition.x, nodes[0].transform.localPosition.y + 0.55f, 0);

            previousLabel.SetActive(false);
            previousLink.SetActive(false);

            CurrentLabel = GameObject.Instantiate(CurrentText, new Vector3(nodes[0].transform.localPosition.x, nodes[0].transform.localPosition.y + .9f, 0), Quaternion.identity);
            CurrentLabel.transform.localScale = new Vector3(1.2f, 1.2f, 0.001f);
            CurrentLabel.transform.SetParent(this.transform);
            CurrentLink = GameObject.Instantiate(link, new Vector3(nodes[0].transform.localPosition.x, nodes[0].transform.localPosition.y + 0.55f, 0), Quaternion.identity);
            CurrentLink.transform.Rotate(0.0f, 0.0f, -90.0f);
            CurrentLink.transform.localScale = new Vector3(0.2f, 0.2f, 0.001f);
            CurrentLink.transform.SetParent(this.transform);
            CurrentLabel.transform.localPosition = new Vector3(nodes[0].transform.localPosition.x, nodes[0].transform.localPosition.y + .9f, 0);
            CurrentLink.transform.localPosition = new Vector3(nodes[0].transform.localPosition.x, nodes[0].transform.localPosition.y + 0.55f, 0);

            yield return new WaitForSeconds(1);
            int i;

            for (i = 0; i < length; i++)
            {
                
                LeanTween.moveLocalX(CurrentLabel, nodes[i].transform.localPosition.x, .7f);
                LeanTween.moveLocalX(CurrentLink, nodes[i].transform.localPosition.x, .7f);
                LeanTween.color(nodes[i], Color.blue, 1f).setLoopPingPong(1);
                
                if(i<length-1)
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

                if (i == position )
                {
                    if (position == length - 1)
                    {
                        DeleteLast();
                        yield break;

                    }
                    yield return new WaitForSeconds(1.1f);

                    //LeanTween.moveLocalY(CurrentLabel, CurrentLabel.transform.localPosition.y + 1.8f, 1f);
                    //LeanTween.moveLocalY(CurrentLink, CurrentLink.transform.localPosition.y + 1.8f, 1f);

                    //yield return new WaitForSeconds(1f);
                        CurrentLabel.transform.SetParent(null);
                        CurrentLink.transform.SetParent(null);
                        Destroy(CurrentLabel);
                        Destroy(CurrentLink);
                        

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

                    previousLabel.transform.SetParent(null);
                    previousLink.transform.SetParent(null);
                    Destroy(previousLabel);
                    Destroy(previousLink);

                    yield return new WaitForSeconds(0.3f);



                    //we are using the possitions of the allready placed nodes
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
                        //if(j<length)
                        links[j] = links[j - 1];

                        if (j == length)
                        {
                            LeanTween.moveLocalX(TailLabel, TailLabel.transform.localPosition.x + 1.2f, 1f);
                            LeanTween.moveLocalX(TailLink, TailLink.transform.localPosition.x + 1.2f, 1f);
                            //LeanTween.moveLocalX(NullText, NullText.transform.localPosition.x + 1.2f, 1f);
                        }
                        else if (j == i + 1)
                        {
                            LeanTween.moveLocalX(CurrentLabel, nodes[j + 1].transform.localPosition.x, 1.2f);
                            LeanTween.moveLocalX(CurrentLink, nodes[j + 1].transform.localPosition.x, 1.2f);
                        }
                        LeanTween.moveLocalX(nodes[j], nodes[j].transform.localPosition.x + 1.2f, 1f);
                        
                        //the same problem with links i guess,
                        if(j<=length-1)
                        LeanTween.moveLocalX(links[j], links[j].transform.localPosition.x + 1.2f, 1f);

                    }

                    //we are adjasting the returning array here
                    //the base
                    LeanTween.moveLocalX(head_pointer2, head_pointer2.transform.localPosition.x + 0.6f, 1f);
                    //we are rescaling#
                    LeanTween.scaleX(head_pointer2, (length ) * 0.353f, 1f);
                    //the poll
                    LeanTween.moveLocalX(straightlineend, straightlineend.transform.localPosition.x + 1.2f, 1f);
                    //yield return new WaitForSeconds(1.8f);
                    yield return new WaitForSeconds(1.7f);
                    newNodeLabel.transform.SetParent(null);
                    Destroy(newNodeLabel);

                    nodes[i] = newNode;
                    links[i] = newNodeLinker;


                    


                    length++;

                    yield break;
                    //break;
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



    //this has been used during testing, but are irrelevant now
    /*
   public IEnumerator moving_returing_array(bool move_left)
    {
        Debug.Log("We are reajasting it!!");
        //used to shift tha arrow left
        if (move_left) { 
            LeanTween.moveLocalX(head_pointer2, head_pointer2.transform.localPosition.x-0.6f,1.5f);
            
            //LeanTween will change the location for us, so we dont need to change its position
            //head_pointer2.transform.localPosition = new Vector3(head_pointer2.transform.localPosition.x - 0.6f, head_pointer2.transform.localPosition.y);
            LeanTween.moveLocalX(straightlinebegining, straightline.transform.localPosition.x - 1.2f, 1.5f);
            //straightlinebegining.transform.localPosition = new Vector3(straightline.transform.localPosition.x - 1.2f,straightlinebegining.transform.localPosition.y);

        }
        else
        {
            LeanTween.moveLocalX(head_pointer2, head_pointer2.transform.localPosition.x+0.6f,1.5f);
            //head_pointer2.transform.localPosition = new Vector3(head_pointer2.transform.localPosition.x + 0.6f, head_pointer2.transform.localPosition.y);
        }
        yield return new WaitForSeconds(1f);
    }

    public IEnumerator rescaling_returingi_array(bool scaling_up)
    {

        float size = (length - 1)/2 -1;
        Debug.Log("we are scaling it with this factor::::: "+ ((length) / 2f)+ " having a number of elements of::: "+ length+ " and size "+ size );

        //Debug.Break();

        if (scaling_up)
        {
            LeanTween.scaleX(head_pointer2, (length) / 2f+0.5f, 1.5f);
            //(size-3)/3f-0.6f
        }
        else
        {
            LeanTween.scaleX(head_pointer2, ((size* 2.4f) - 2.4f) / (size* 2.4f), 1.5f);
        }
        yield return null;
    }
    */

}
