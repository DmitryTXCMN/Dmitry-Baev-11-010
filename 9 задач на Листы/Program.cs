using System;
using System.IO;
using System.Collections.Generic;
namespace lister
{
    class Program​
    {
        public LinkedList<string/*book*/> AddBook(LinkedList<string> bookList, string addBook)
        {
            LinkedListNode<string> now = bookList.First;
            while (addBook[0] < now.Value[0]/*Условие упорядоченности*/ && now.Next != null)
                now = now.Next;
            bookList.AddAfter(now, addBook);
            return bookList;
        }

        public LinkedList<int> CombineLists(LinkedList<int> list1, LinkedList<int> list2)
        {
            LinkedList<int> newList = new LinkedList<int>();
            LinkedListNode<int> now1 = list1.First;
            LinkedListNode<int> now2 = list2.First;
            while (now1 != null && now2 != null)
                if ((now1.Value < now2.Value/*Условие упорядоченности*/ && now1 != null) || now2 == null)
                {
                    newList.AddLast(now1.Value);
                    now1 = now1.Next;
                }
                else
                {
                    newList.AddLast(now2.Value);
                    now2 = now2.Next;
                }
            return newList;
        }

        public LinkedList<int> SortNumListA(LinkedList<int> list)
        {
            LinkedList<int> newList = new LinkedList<int>();
            newList.AddLast(-1);
            LinkedListNode<int> now = list.First;
            //Сортировка в новый list
            while (now != null)
            {
                if (now.Value > 0)
                {
                    LinkedListNode<int> nowSort = newList.First;
                    while (now.Value < nowSort.Value && now.Next != null)
                        nowSort = nowSort.Next;
                    newList.AddAfter(nowSort, now.Value);
                }
                now = now.Next;
            }
            newList.Remove(newList.Find(-1));
            //Запись в исходный list
            LinkedListNode<int> nowNew = newList.First;
            now = list.First; 
            while (now != null)
            {
                if (now.Value > 0)
                {
                    list.AddAfter(now, nowNew.Value);
                    nowNew = nowNew.Next;
                    now = now.Next.Next;
                    list.Remove(now.Previous.Previous);
                }
            }
            return list;
        }

        public LinkedList<int> SortNumListB(LinkedList<int> list)
        {
            LinkedList<int> newList = new LinkedList<int>();
            newList.AddLast(-1);
            LinkedListNode<int> now = list.First;
            //Сортировка в новый list
            bool even = false;
            while (now != null)
            {
                if (even == true)
                {
                    LinkedListNode<int> nowSort = newList.First;
                    while (now.Value < nowSort.Value && now.Next != null)
                        nowSort = nowSort.Next;
                    newList.AddAfter(nowSort, now.Value);
                }
                even = !even;
                now = now.Next;
            }
            newList.Remove(newList.Find(-1));
            //Запись в исходный list
            LinkedListNode<int> nowNew = newList.First;
            now = list.First;
            even = false;
            while (now != null)
            {
                if (even == true)
                {
                    list.AddAfter(now, nowNew.Value);
                    nowNew = nowNew.Next;
                    now = now.Next.Next;
                    list.Remove(now.Previous.Previous);
                    
                }
                else
                {
                    now = now.Next;
                }
                even = !even;
            }
            return list;
        }

        public bool Compare(LinkedList<int> list1, LinkedList<int> list2)
        {
            if (list1.Count != list2.Count)
                return false;
            LinkedListNode<int> now1 = list1.First;
            LinkedListNode<int> now2 = list2.First;
            while (now1 != null)
            {
                if (now1.Value != now2.Value)
                    return false;
                now1 = now1.Next;
                now2 = now2.Next;
            }
            return true;
        }

        public LinkedList<int> Five(LinkedList<int> list)
        {
            LinkedListNode<int> now = list.Last;
            while (now != null)
            {
                LinkedListNode<int> nowTemp = list.First;
                while (nowTemp != now)
                {
                    list.AddAfter(now, nowTemp.Value);
                    nowTemp = nowTemp.Next;
                }
                now = now.Previous;
            }
            return list;
        }

        public LinkedList<char> TransformText(LinkedList<char> list)
        {
            const string itmath = "itmathrepetitor";
            const string silence = "silence";
            LinkedListNode<char> now = list.First;
            while (now != null)
            {
                bool equal = true;
                LinkedListNode<char> nowIn = now;
                for (int i = 0; i < itmath.Length && nowIn != null; i++)
                {
                    if (nowIn.Value != itmath[i])
                    {
                        equal = false;
                        break;
                    }
                    nowIn = nowIn.Next;
                }
                if (equal)
                {
                    for (int i = 0; i < itmath.Length - 1; i++)
                        list.Remove(now.Next);
                    for (int i = 0; i < silence.Length; i++)
                        list.AddAfter(now, silence[i]);
                    now = now.Next;
                    list.Remove(now.Previous);
                }
                else
                    now = now.Next;
            }
            return list;
        }

        public LinkedList<int> ReadFile(string fileWay)
        {
            LinkedList<int> list = new LinkedList<int>();
            using (StreamReader sr = new StreamReader(fileWay))
            {
                while (sr.Peek() != -1)
                list.AddLast(sr.ReadLine().Length);
            }
            return list;
        }

        public void Facultet()
        {
            LinkedList<List<string/*Person*/>> groups = new LinkedList<List<string>>();
            List<string> g11_010 = new List<string> { "Адиев Адель", "Ахматов Мансур", "Баев Дмитрий" };
            groups.AddLast(g11_010);
        }
        static void Main()
        {
            
        }
    }
}