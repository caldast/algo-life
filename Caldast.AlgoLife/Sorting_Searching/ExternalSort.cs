using System;
using System.IO;

namespace Caldast.AlgoLife.Sorting
{
    class ExternalSort
    {

        public void Sort()
        {
            int recordSize = 100;
            int runSize = 10;
            int chunkSize = recordSize / runSize;

            var random = new Random();
            int[] arr = new int[recordSize];
            int i = 0;
            while (i < arr.Length)
            {                
                arr[i] = random.Next(0, 9);
                i++;
            }
            string inputFile = "input.txt";

            WriteToFile(inputFile,arr);

            string[] fileArr = new string[chunkSize];

            i = 0;

            // Read from input file based on runSize, sort and write to output files
            using (var reader = new StreamReader(inputFile))
            {

                for (i = 0; i < chunkSize; i++)
                {
                    int[] temp = new int[runSize];

                    int j = 0;
                    while (j < runSize)
                    {
                        char s = (char) reader.Read();
                        temp[j] = Convert.ToInt32(s.ToString());
                        j++;
                    }                    

                    QuickSort.SortRecursive(temp, 0, runSize - 1);

                    string outputFile = "output_" + i + ".txt";

                    WriteToFile(outputFile, temp);

                    fileArr[i] = outputFile;

                }
                reader.Close();
            }

            // k - way merge

            MinHeapNode[] chunkArray = new MinHeapNode[chunkSize];
            int[] outputArray = new int[runSize];

           
            i = 0;
            for (i = 0; i < chunkSize; i++)
            {
                FetchFromInputFileToHeapNodeArray(fileArr[i], 0, i, chunkArray);
                    
            }

            var minHeap = new MinHeap(chunkArray);
            
            int count = 0;
            string finalOutputFile = "output.txt";

            using (var writer = new StreamWriter(finalOutputFile))
            {
                

                while (count != chunkSize)
                {
                    MinHeapNode min = minHeap.Minimum();

                   writer.Write(min.Element);

                    if (min.NextIndex < runSize)
                    {
                        MinHeapNode nextMin = FetchFromInputFile(fileArr[min.Index], min.Index, min.NextIndex);
                        minHeap.ReplaceMin(nextMin);
                    }
                    else
                    {
                        minHeap.ReplaceMin(new MinHeapNode(int.MaxValue, min.Index, min.NextIndex));
                        count++;
                    }
                }

                writer.Flush();
                writer.Close();
            }
        

        }

        private MinHeapNode FetchFromInputFile(string filename, int minIndex, int nextIndex)
        {
            using (var reader = new StreamReader(filename))
            {
                int j = 0;
                char value;
                do
                {
                    value = (char)reader.Read();
                    j++;
                }while (j <= nextIndex && !reader.EndOfStream);
               
                int val = Convert.ToInt32(value.ToString());
                MinHeapNode node = new MinHeapNode(val, minIndex, nextIndex + 1);
                  
                reader.Close();
                return node;
            }

        }

        private void FetchFromInputFileToHeapNodeArray(string filename, int start, int end, MinHeapNode[] arr)
        {
            using (var reader = new StreamReader(filename))
            {               
               
                char i = (char)reader.Read();                    
                arr[end] = new MinHeapNode(Convert.ToInt32(i.ToString()), end, start+1);
                    
                
                reader.Close();
            }

        }

        private void FetchFromInputFile(string filename, int start, int end, int [] arr)
        {
            using (var reader = new StreamReader(filename))
            {                
                int j = 0;
                while (end >= start)
                {

                    char i = (char)reader.Read();             
                    arr[j++] = Convert.ToInt32(i.ToString());
                    start++;
                   
                                   
                }
                reader.Close();
            }
           
        }

        private void WriteToFile(string filename, int[] arr)
        {
            using (var writer = new StreamWriter(filename))
            {
                int i = 0;
                while (i < arr.Length)
                {
                    writer.Write(arr[i]);                    
                    i++;
                }
                writer.Flush();
                writer.Close();
            }

        }

        

    }

    public class MinHeap
    {
        private MinHeapNode[] heapArray = null;
        public MinHeap(MinHeapNode[] arr)
        {
            heapArray = arr;
            int heapSize = heapArray.Length;
            for (int i = heapSize / 2 - 1; i >= 0; i--)
            {
                Heapify(i, heapSize);
            }
        }

        public int Count => heapArray.Length;
      

        public void ReplaceMin(MinHeapNode val)
        {
            heapArray[0] = val;
            Heapify(0, Count);
        }

        public MinHeapNode Minimum()
        {
            return heapArray[0];
        }

       

        public void Heapify(int index, int heapSize)
        {
            int left = Left(index);
            int right = Right(index);
            int smallest = index;

            if (left < heapSize && heapArray[index].Element > heapArray[left].Element)
            {
                smallest = left;
            }

            if (right < heapSize && heapArray[smallest].Element > heapArray[right].Element)
            {
                smallest = right;
            }

            if (index != smallest)
            {
                Swap(heapArray, index, smallest);
                Heapify(smallest, heapSize);
            }


        }
        private void Swap(MinHeapNode[] arr, int i, int j)
        {
            MinHeapNode temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
        public int Parent(int index)
        {
            return index % 2 == 0 ? index / 2 - 1 : index / 2;
        }

        public int Left(int index)
        {
            return 2 * index + 1;
        }
        public int Right(int index)
        {
            return 2 * index + 2;
        }

    }
    public class MinHeapNode
    {
        public MinHeapNode(int element, int index, int nextIndex)
        {
            Element = element;
            Index = index;
            NextIndex = nextIndex;
        }
        public int Element { get; set; }
        public int Index { get; set; }

        public int NextIndex { get; set; }

    }
}
