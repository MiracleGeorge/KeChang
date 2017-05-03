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
        #region �����ʼ�
        /// <summary>
        /// �����ʼ�
        /// </summary>
        /// <param name="FromEmail">�����ߵ�ַ</param>
        /// <param name="strFromHost">smtp������ַ</param>
        /// <param name="strUserName">�û���</param>
        /// <param name="strPass">����</param>
        /// <param name="strPort">�˿ں�</param>
        /// <param name="ToEmail">�����ߵ�ַ</param>
        /// <param name="strTitle">����</param>
        /// <param name="strBody">����</param>
        /// <returns></returns>
        public static string SendEmail(string FromEmail, string strFromHost, string strUserName, string strPass, string strPort, string ToEmail, string strTitle, string strBody)
        {
            string strReturn = "�ʼ����ͳɹ���";
            try
            {
                //����һ��Mailʵ��
                MailMessage mail = new MailMessage();
                //������-ע��ʹ�õ���MailAddress��ʵ������װ�����ַ
                mail.From = new MailAddress(FromEmail);
                //�ռ���-��ͨ��Add����ʵ�ֶ���ռ��˵����
                mail.To.Add(new MailAddress(ToEmail));
                //�ʼ�����
                mail.Subject = strTitle;
                mail.IsBodyHtml = true;
                mail.BodyEncoding = System.Text.Encoding.GetEncoding("GB2312");//�ʼ����õı���
                mail.Priority = MailPriority.High;//�����ʼ������ȼ�Ϊ�� 
                //�ʼ�����
                mail.Body = strBody;
                //��Ӹ���
                //Attachment myfile = new Attachment(strAttachFilesName);
                //mail.Attachments.Add(myfile);
                //���͵���������
                //mail.CC.Add(new MailAddress(strCcEmail));
                //����һ���ʼ���������
                SmtpClient client = new SmtpClient();
                //��ȡSMTP������
                client.Host = strFromHost;
                //SMTPʹ�õĶ˿�-ע���ʽ��ת��
                client.Port = int.Parse(strPort);
                //ʹ�������¼�����������֤.
                client.Credentials = new NetworkCredential(strUserName, strPass);

                //����
                client.Send(mail);
            }
            catch (Exception e)
            {
                strReturn = "�ʼ�����ʧ�ܣ�" + e.Message;
            }
            return strReturn;
        } 
        #endregion
    }
}
