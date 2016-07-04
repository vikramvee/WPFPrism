using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Testing.MyNewStaticClass;
using static Testing.MyStaticClass;

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {

            //Publisher classIns = new Publisher();
            //classIns.handler += (object s,EventArgs e) => {
            //    Console.WriteLine("Event trigger " + s.ToString());
            //};

            //Console.WriteLine("Raise the event");
            //classIns.OnCalled();

            C cint = new C();
            cint.Foo();

            //MyNewStaticClass.HeyThere();

            //Publisher pub = new Publisher();
            //Subscriber sub = new Subscriber(pub);
            //SubscriberNew subnew = new SubscriberNew(pub);

            //pub.OnCalled();

            Console.Read();
            

            //IList<int> intList = new List<int>();
            //int t = Convert.ToInt32(Console.ReadLine());
            //if (t >= 1 && t < 11)
            //{
            //    for (int a0 = 0; a0 < t; a0++)
            //    {
            //        int n = Convert.ToInt32(Console.ReadLine());
            //        intList.Add(GetHeight(n));
            //    }
            //}

            //Console.WriteLine();

            //foreach (var item in intList)
            //{
            //    Console.WriteLine(item);
            //}

            DataSource sqlDS = new MsSqlDataSource("DEV");
            sqlDS.OpenAndReturnConnection();

            Console.Read();

        }

        private static void Method(DataSource source)
        {

        }

        private static int GetHeight(int numberOfCycles)
        {
            if (numberOfCycles < 0 && numberOfCycles > 60)
                return -1;

            int height = 1;          
            for (int i = 0; i < numberOfCycles; i++)
            {              
                       
                if (i % 2 == 0)
                {
                    height = height * 2;
                }
                else 
                {
                    ++height;
                }
            }

            return height;
        }
    }

    public class C
    {
        // inner struct S
        struct S
        {
            public byte mb;
        }
        public void Foo()
        {
            S s1;
            S s2 = new S();
            s1.mb = s2.mb = 20; // initialize s1, s2

            // a List of S initialized with s1,s2
            var ls = new List<S> { s1, s2 };
        }
        private int mi = 10; // A member of C
    }


    public abstract class DataSource
    {
        protected string dataSourceName;
        private string environment;
        protected DataSource(string environment, string dsName)
        {
            this.environment = environment;
            this.dataSourceName = dsName;

            GetDataSourceCredentials();
        }

        /// <summary>
        /// This is the function which is used to provide common functionality of providing the connection 
        /// string to all the instaces of the derived classes
        /// </summary>
        private void GetDataSourceCredentials()
        {
            Console.WriteLine(string.Format("Get {0}'s connection setting for {1} environment from config file", dataSourceName, environment));
        }

        /// <summary>
        /// This function is used to create the Connection to the datasource based on the connection string returned from GetDataSourceCredentials() 
        /// method. Each and every derived class need to have implementation of this function.
        /// </summary>
        public abstract void OpenAndReturnConnection();
    }

    public class MsSqlDataSource : DataSource
    {
        public MsSqlDataSource(string environment) : base(environment, "MsSQL")
        {
            
        }

        public override void OpenAndReturnConnection()
        {
            Console.WriteLine(string.Format("Create and return Connection for {0} dataSource", dataSourceName));
        }
    }

    public class OracleDataSource : DataSource
    {
        public OracleDataSource(string environment) : base(environment, "Oracle")
        {
        }

        public override void OpenAndReturnConnection()
        {
            Console.WriteLine(string.Format("Create and return Connection for {0} dataSource", dataSourceName));
        }
    }

    
    public class Publisher
    {
        public event EventHandler handler;

        public void OnCalled()
        {
            if(handler != null)
            {
                handler(this, new EventArgs());
            }
        }
    }

    public class Subscriber
    {
        public Subscriber(Publisher pub)
        {
            pub.handler += Pub_handler;
        }

        private void Pub_handler(object sender, EventArgs e)
        {
            Console.WriteLine("Handled at Subscriber 1 " + sender.ToString());
        }
    }

    public class SubscriberNew
    {
        public SubscriberNew(Publisher pub)
        {
            pub.handler += Pub_handler;
        }

        private void Pub_handler(object sender, EventArgs e)
        {
            Console.WriteLine("Handled at Subscriber new " + sender.ToString());
        }
    }

    public static class MyStaticClass
    {
        public static void HeyThere()
        {
            Console.WriteLine("Hey There");
        }
    }

    public static class MyNewStaticClass
    {
        public static void HeyThere()
        {
            Console.WriteLine("Hey There New");
        }
    }
}
