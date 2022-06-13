using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Utillity
{
    public class DoublyLinkedList : MonoBehaviour
    {
        private Node head;
        private Node tail;

        private class Node
        {
            public int data;
            public Node next;
            public Node previous;

            public Node(int data)
            {
                this.data = data;
            }
        }

        public void addFirst(int data)
        {
            Node newNode = new Node(data);

            if (head == null)
            {
                head = newNode;
                tail = head;
            }
            else
            {

                Node previousFirst = head.next;
                newNode.next = previousFirst;
                previousFirst.previous = newNode;
                head.next = newNode;
            }
        }

        public void addLast(int data)
        {
            Node newNode = new Node(data);

            if (tail == null)
            {
                tail = newNode;
                head = tail;
            }
            else
            {
                Node previousLast = tail.next;
                newNode.previous = previousLast;
                previousLast.next = newNode;
                tail.next = newNode;
            }
        }

        public void addAfter(int index, int data)
        {
            if (head == null)
            {
                throw new System.InvalidOperationException("List is empty !");
            }

            Node current = head;
            for (int i = -1; i < index; i++)
            {
                current = current.next;
            }

            Node newNode = new Node(data);
            Node next = current.next;
            newNode.previous = current;
            newNode.next = next;
            current.next = newNode;
        }

        public void addBefore(int index, int data)
        {
            if (head == null)
            {
                throw new System.InvalidOperationException("List is empty !");
            }

            Node current = head;
            for (int i = -1; i < index; i++)
            {
                current = current.next;
            }

            Node newNode = new Node(data);
            Node previous = current.previous;
            newNode.next = current;
            newNode.previous = previous;
            current.previous = newNode;
        }


        public int removeFirst()
        {
            if (head == null)
            {
                throw new System.InvalidOperationException("List is empty !");
            }

            Node removed = head.next;
            head = removed.next;

            return removed.data;
        }

        public int removeLast()
        {
            if (head == null)
            {
                throw new System.InvalidOperationException("List is empty !");
            }

            Node removed = tail.next;
            tail = removed.previous;

            return removed.data;
        }

        public int removeAfter(int index)
        {
            if (head == null)
            {
                throw new System.InvalidOperationException("List is empty !");
            }

            Node current = head;
            for (int i = -1; i < index; i++)
            {
                current = current.next;
            }

            Node removed = current.next;
            Node next = removed.next;
            current.next = next;
            next.previous = current;

            return removed.data;
        }

        public int removeBefore(int index)
        {
            if (head == null)
            {
                throw new System.InvalidOperationException("List is empty !");
            }

            Node current = head;
            for (int i = -1; i < index; i++)
            {
                current = current.next;
            }

            Node removed = current.previous;
            Node previous = removed.previous;
            current.previous = previous;
            previous.next = current;

            return removed.data;
        }
    }
}