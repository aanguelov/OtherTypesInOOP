using System;

namespace _03_GenericList
{
    class GenericListMain
    {
        static void Main()
        {
            GenericList<string> stringList = new GenericList<string>();
            Console.WriteLine("Capacity: {0}, count: {1}",stringList.Capacity, stringList.Count);

            stringList.Add("Pesho");
            stringList.Add("Maria");
            Console.WriteLine(stringList);
            Console.WriteLine("Capacity: {0}, count: {1}", stringList.Capacity, stringList.Count);
            stringList.InsertElementAtPos(1, "Gosho");
            Console.WriteLine(stringList);
            Console.WriteLine(stringList.CheckIfContains("Ivan"));
            Console.WriteLine(stringList.FindIndexOfElement("Maria"));
            stringList.RemoveElementByIndex(0);
            Console.WriteLine(stringList);
            Console.WriteLine(Min(stringList));
            stringList.Add("Yavor");
            Console.WriteLine(Max(stringList));

            Type type = typeof(GenericList<>);
            foreach (object attribute in type.GetCustomAttributes(false))
            {
                Console.WriteLine(attribute);
            }
        }

        public static T Min<T>(GenericList<T> list)
            where T : IComparable<T>
        {
            T min = default(T);
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i - 1].CompareTo(list[i]) <= 0)
                {
                    min = list[i - 1];
                }
            }
            return min;
        }

        public static T Max<T>(GenericList<T> list)
            where T : IComparable<T>
        {
            T max = default(T);
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i - 1].CompareTo(list[i]) <= 0)
                {
                    max = list[i];
                }
            }
            return max;
        } 
    }
}
