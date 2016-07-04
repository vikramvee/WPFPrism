using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Equality
{
    class Program
    {
        static void Main(string[] args)
        {

            string str1 = "string1";
            string str2 = "string1";
            //Console.WriteLine(str1.Equals(str2)); //true

            float f1 = 6.45f;
            float f2 = 0.55f;
            Console.WriteLine(f1 + f2 == 7.0f); //false

            float f3 = 7.0f;

            float f4 = f1 + f2;

            

            //object str1 = "string";
            //object str2 = string.Copy((string)str1);

            //Console.WriteLine(ReferenceEquals(str1, str2)); //fasle
            //Console.WriteLine(str1.Equals(str2)); //true
            //Console.WriteLine(str1 == str2); //false
            //Console.WriteLine(object.Equals(str1, str2)); //true

            Console.Read();

        }

        public void TestMethod([CallerMemberName] string name = "")
        {

        }
    }

    public class Person
    {
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (ReferenceEquals(obj, this))
                return true;
            if (obj.GetType() != this.GetType())
                return false;

            Person per = obj as Person;
            return this.Name == per.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        //public static bool operator ==(Person x, Person y)
        //{
        //    return object.Equals(x, y);
        //}

        //public static bool operator !=(Person x, Person y)
        //{
        //    return !object.Equals(x, y);
        //}



        //public override int GetHashCode()
        //{
        //    return Name.GetHashCode();
        //}
    }


}
