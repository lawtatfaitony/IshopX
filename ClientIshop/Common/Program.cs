using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using static Common.CommonBase;

namespace Common
{
    class Program
    {
        static void Main(string[] args)
        {

            string testIsJson = CommonBase.ReadConfigJson("testIsJson.json");

            if(ValidJson.IsJson(testIsJson))
            {
                Console.WriteLine("This is a  JSON!"); 
                Console.WriteLine(testIsJson);
            }
            else
            {
                Console.WriteLine("testIsJson.json Is not a json!");
                Console.WriteLine("Enter To continue........");
            }

            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Hello World!");
            Console.WriteLine(ReadFromAppSettings().Get<ConnectionConfig>().ConnectionString);

            string filename2 = LoggerQueueHelper.CheckLogFile(LoggerMode.DEBUG,10);

            CommonBase.OperateDateLoger("[xxxxxxxxxxxxxxxxx嘻嘻嘻嘻嘻嘻嘻嘻寻寻寻寻寻寻寻寻寻寻 检查log文件是否大于200k,否则开立新文件xxxxxxxxxxxxxxx", LoggerMode.DEBUG);
            CommonBase.OperateDateLoger("[巴巴爸爸不不不不不不不不不不不不不不不不不不不不不不不检查log文件是否大于200k,否则开立新文件", LoggerMode.DEBUG);
            CommonBase.OperateDateLoger("[反反复复反反复复反反复复反反复复反反复复吩咐付付付付付付付检查log文件是否大于200k,否则开立新文件", LoggerMode.DEBUG);

            Task.Run(() =>
            {
                int i = 0;
                while (i < 10000)
                {
                    CommonBase.OperateDateLoger("[检查log文件是否大于200k,否则开立新文件", LoggerMode.DEBUG);
                    i++;
                };
            });

            Task.Run(() =>
            {
                string filename = LoggerQueueHelper.CheckLogFile(LoggerMode.DEBUG,12);
                Console.WriteLine("[检查log文件是否大于200k,否则开立新文件{0}", filename);
            });

           
            Console.Read();
            Console.Read();
            Console.Read();
            Console.Read();


            Console.WriteLine("[log日志测试]LoggerQueueHelper.cs");
            Console.WriteLine("[log日志测试] [加入读写锁，测试通过，前置条件是单一exe在运行，如果是多个EXE同时执行一个file，这是操作系统级别的问题了，总体测试通过]");
            Thread t1 = new Thread(new ThreadStart(TestOperateDateLoger));
            Thread t2 = new Thread(new ThreadStart(TestOperateDateLoger));
            //Thread t2 = new Thread(new ParameterizedThreadStart(TestOperateDateLoger));
            t1.IsBackground = true;
            t2.IsBackground = true;
            t1.Start();
            Console.WriteLine("THREAD START......");

            Console.WriteLine("PRESS ANY KEY TO......");
            Console.ReadLine();

        }
        public static void TestOperateDateLoger()
        {
            Console.WriteLine("CTRL + C = BREAK");
            Random r = new Random();
            int num = r.Next(1, 10); 
            int i = 0;
            
            while (true)
            {
                string logline = string.Format("[{0}][I][Program Main OperateDateLoger Test {1}]", i, DateTime.Now);
                
                Task task = Task.Run(() =>
                {
                    CommonBase.OperateDateLoger(logline, LoggerMode.INFO);
                });

                Task task1 = Task.Run(() =>
                {
                    CommonBase.OperateDateLoger(logline, LoggerMode.ERROR);
                });
                Task task2 = Task.Run(() =>
                {
                    CommonBase.OperateDateLoger(logline, LoggerMode.FATAL);
                });

                Console.WriteLine(logline);
                i++;
                Thread.Sleep(num);
            } 
            
        }
        public static IConfigurationRoot ReadFromAppSettings()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT")}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();
        }
    }
}
