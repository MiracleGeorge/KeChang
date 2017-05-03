using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.IO;

namespace YouHoo.DataTools
{
    public class EmailHelper
    {
        #region 发送邮件
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="FromEmail">发送者地址</param>
        /// <param name="strFromHost">smtp主机地址</param>
        /// <param name="strUserName">用户名</param>
        /// <param name="strPass">密码</param>
        /// <param name="strPort">端口号</param>
        /// <param name="ToEmail">接收者地址</param>
        /// <param name="strTitle">标题</param>
        /// <param name="strBody">主体</param>
        /// <returns></returns>
        public static string SendEmail(string FromEmail, string strFromHost, string strUserName, string strPass, string strPort, string ToEmail, string strTitle, string strBody)
        {
            string strReturn = "邮件发送成功！";
            try
            {
                //创建一个Mail实体
                MailMessage mail = new MailMessage();
                //发件人-注意使用的是MailAddress的实例来包装邮箱地址
                mail.From = new MailAddress(FromEmail);
                //收件人-可通过Add方法实现多个收件人的添加
                mail.To.Add(new MailAddress(ToEmail));
                //邮件主题
                mail.Subject = strTitle;
                mail.IsBodyHtml = true;
                mail.BodyEncoding = System.Text.Encoding.GetEncoding("GB2312");//邮件采用的编码
                mail.Priority = MailPriority.High;//设置邮件的优先级为高 
                //邮件内容
                mail.Body = strBody;
                //添加附件
                //Attachment myfile = new Attachment(strAttachFilesName);
                //mail.Attachments.Add(myfile);
                //抄送到其它邮箱
                //mail.CC.Add(new MailAddress(strCcEmail));
                //创建一个邮件服务器类
                SmtpClient client = new SmtpClient();
                //获取SMTP服务器
                client.Host = strFromHost;
                //SMTP使用的端口-注意格式的转换
                client.Port = int.Parse(strPort);
                //使用邮箱登录名和密码的验证.
                client.Credentials = new NetworkCredential(strUserName, strPass);

                //发送
                client.Send(mail);
            }
            catch (Exception e)
            {
                strReturn = "邮件发送失败！" + e.Message;
            }
            return strReturn;
        } 
        #endregion
    }
}
