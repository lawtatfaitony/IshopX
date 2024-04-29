using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppMailTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Begin Sending..................");

            SendEmail126X("13392226@qq.com",  $"SUBJECT{DateTime.Now:F}", $"bodyContent{DateTime.Now:F} ===========================================");


            Console.WriteLine("End==============================================any key to end");
            Console.ReadKey();
        
        }


        public static void SendEmail126X(string to ,string subject,string bodyContent)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var emailAcount = "xguard@126.com";//邮箱号
            var emailPassword = "SAHMIMINZLHDRXSD";//POP3/SMTP/IMAP服务密码 或 邮箱密码

            try
            { 
                var reciver = to;//收信邮箱
                //var content = "这个是邮件内容,程序发送邮件测试...";//邮件内容
                var content = bodyContent;//邮件内容
                MailMessage message = new MailMessage();
                //设置发件人,发件人需要与设置的邮件发送服务器的邮箱一致
                MailAddress fromAddr = new MailAddress(emailAcount);
                message.From = fromAddr;
                //设置收件人,可添加多个,添加方法与下面的一样
                message.To.Add(reciver);
                //设置抄送人
#if DEBUG
                message.Bcc.Add("caihaili82@gmail.com");
#endif 
                //设置邮件标题 
                message.Subject = subject;
                //设置邮件内容
                message.Body = content;
                //设置邮件发送服务器,服务器根据你使用的邮箱而不同,可以到相应的 邮箱管理后台查看
                SmtpClient client = new SmtpClient("smtp.126.com", 25);
                //启用ssl,也就是安全发送
                client.EnableSsl = false;
                client.UseDefaultCredentials = false;
                //设置发送人的邮箱账号和密码
                client.Credentials = new NetworkCredential(emailAcount, emailPassword);
                //发送邮件
                client.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[{DateTime.Now:F}] [EXCEPTION] [ {to} ] SEND MAIL FAIL : {subject} {ex.Message}");
                throw ex;
            }
            finally
            {
                string loggerLine = string.Format("[{0:yyyy-MM-dd HH:mm:ss}] [126 MAIL] [TO :{1} FROM : {2}] [SUCCESS {3}Milliseconds]", DateTime.Now, to, emailAcount, sw.Elapsed.Milliseconds);
                Console.WriteLine(loggerLine);
                 
                sw.Stop();
            }


        }
    }
}
