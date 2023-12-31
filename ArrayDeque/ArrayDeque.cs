﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayDeque
{

    public class ArrayDeque<T>
    {
        private int head = -1;
        private int tail = -1;
        private T[] array;

        public ArrayDeque()
        {
            array = new T[8];
        }

        //Add to the end of the deque
        public void Offer(T value)
        {
            //Check for null value insertions
            if (value == null)
            {
                throw new ArgumentNullException("value is not allowed to be null");
            }

            //Add to pos 0 if deque is null
            if (Size() == 0)
            {
                array[0] = value;
                head = 0;
                tail = 0;
                return;
            }

            //Create a new array if the current array is full
            if (IsResizeNecessary())
            {
                array = CreateNewArray(array);
            }

            //Do a wrap around if necessary
            if (IsWrapAroundForOfferNecessary())
            {
                array[0] = value;
                tail = 0;
            }
            else
            {
                //Add to one pos after the tail
                array[tail + 1] = value;
                tail += 1;
            }
        }

        //Add to the beginning of the deque
        public void Push(T value)
        {
            //Check for null value insertions
            if (value == null)
            {
                throw new ArgumentNullException("value is not allowed to be null");
            }
            //Add to pos 0 if deque is null
            if (Size() == 0)
            {
                array[0] = value;
                head = 0;
                tail = 0;
                return;
            }

            //Create a new array if the current array is full
            if (IsResizeNecessary())
            {
                array = CreateNewArray(array);
            }

            //Do a wrap around if necessary
            if (IsWrapAroundForPushNecessary())
            {
                array[Capacity() - 1] = value;
                head = Capacity() - 1;
            }
            else
            {
                //Add to one pos before the head
                array[head - 1] = value;
                head -= 1;

            }
        }

        //Delete the first element of the deque
        public bool? Poll()
        {
            if (Size() == 0)
            {
                return null;
            }
            else
            {
                array[head] = default(T);

                if (head == tail)
                {
                    head = tail = -1;
                }
                else
                {
                    if (head == array.Length - 1)
                    {
                        head = 0;
                    }
                    else
                    {
                        head += 1;
                    }
                }
                return true;
            }
        }

        //Delete the last element of the deque
        public bool? PollLast()
        {
            if (Size() == 0)
            {
                return null;
            }
            else
            {
                array[tail] = default(T);

                if (tail == head)
                {
                    tail = head = -1;
                }
                else
                {
                    if (tail == 0)
                    {
                        tail = array.Length - 1;
                    }
                    else
                    {
                        tail -= 1;
                    }
                }
                return false;
            }
        }

        //Return the last element of the deque
        public T PeekFirst()
        {
            if (Size() == 0)
            {
                return default(T);
            }
            else
            {
                return array[head];
            }
        }

        //Return the last element of the deque
        public T PeekLast()
        {
            if (Size() == 0)
            {
                return default(T);
            }
            else
            {
                return array[tail];
            }
        }

        //Return the number of elements in the deque
        public int Size()
        {
            int size;
            if (head == -1 || tail == -1)
            {
                return 0;
            }
            else if (head < tail)
            {
                size = tail - head + 1;
            }
            else if (head == tail)
            {
                return 1;
            }
            else
            {
                size = (Capacity() - head) + (tail + 1);
            }

            //foreach (T item in array)
            //{
            //    if (item != null)
            //    {
            //        if (!item.Equals(default(T)))
            //        {
            //            size++;
            //        }
            //    }
            //}
            return size;
        }

        //Return the current capacity of the array
        public int Capacity()
        {
            return array.Length;
        }

        //Check if current array is full
        private bool IsResizeNecessary()
        {
            if (Capacity() == Size())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Check if a wrap around is necessary for the push method
        private bool IsWrapAroundForPushNecessary()
        {
            if (head == 0 && array[Capacity() - 1] == null)
            {
                return true;
            }
            else if (head == 0 && array[Capacity() - 1].Equals(default(T)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Check if a wrap around is necessary for the offer method
        private bool IsWrapAroundForOfferNecessary()
        {
            if (tail == Capacity() - 1 && array[0] == null)
            {
                return true;
            }
            else if (tail == Capacity() - 1 && array[0].Equals(default(T)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Create a new array with double the space
        private T[] CreateNewArray(T[] array)
        {
            T[] tempArray = new T[array.Length * 2];

            //Copy the current array to the temporary one

            //Check if the current array is already in the correct order and copy
            if (head == 0 && tail == array.Length - 1)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    tempArray[i] = array[i];
                }
            }
            else
            {
                int counter = 0;

                //Copy from head to last element
                for (int i = head; i < array.Length; i++)
                {
                    tempArray[i - head] = array[i];
                    counter++;
                }

                //Copy from tail to head
                for (int i = 0; i < head; i++)
                {
                    tempArray[counter + i] = array[i];
                }
            }

            //Adapt head and tail for the new array
            head = 0;
            tail = array.Length - 1;

            //Recopy the new array to the original array
            array = new T[tempArray.Length];
            for (int i = 0; i < tempArray.Length / 2; i++)
            {
                array[i] = tempArray[i];
            };

            //Delete the temporaray array
            return array;
        }
    }
}
