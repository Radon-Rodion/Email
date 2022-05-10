using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using DataAcessLayer.Entities;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.Recievers
{
    public class POP3Reciever : System.Net.Sockets.TcpClient
    {
        public void ConnectPOP(string serverName, string userEmail, string password)
        {
            string message, result;
            Connect(serverName, 110);

            result = Response();
            if (result.Substring(0, 3) != "+OK")
                throw new POPException(result);

            message = $"USER {userEmail}\r\n";

            Write(message);

            result = Response();
            if (result.Substring(0, 3) != "+OK")
                throw new POPException(result);

            message = $"PASS {password}\r\n";

            Write(message);

            result = Response();
            if (result.Substring(0, 3) != "+OK")
                throw new POPException(result);
        }

        public void DisconnectPOP()
        {
            string message, result;

            message = "QUIT\r\n";
            Write(message);

            result = Response();
            if (result.Substring(0, 3) != "+OK")
                throw new POPException(result);
        }

        public ArrayList ListMessages()
        {
            string message, result;

            var returnValue = new ArrayList();

            message = "LIST\r\n";
            Write(message);

            result = Response();
            if (result.Substring(0, 3) != "+OK")
                throw new POPException(result);

            while (true)
            {
                result = Response();
                if (result == ".\r\n")
                    return returnValue;
                else
                {
                    var mailMessage = new Mail();

                    char[] sep = { ' ' };

                    string[] values = result.Split(sep);

                    mailMessage.Id = Int32.Parse(values[0]);
                    mailMessage.MsgSize = Int32.Parse(values[1]);
                    mailMessage.MsgRecieved = false;
                    returnValue.Add(mailMessage);
                    continue;
                }
            }
        }

        public Mail RetrieveMessage(Mail msgRetr)
        {
            string message, result;

            var mailMessage = new Mail();
            mailMessage.MsgSize = msgRetr.MsgSize;
            mailMessage.Id = msgRetr.Id;

            message = $"RETR {msgRetr.Id}\r\n";
            Write(message);

            result = Response();
            if (result.Substring(0, 3) != "+OK")
                throw new POPException(result);

            mailMessage.MsgRecieved = true;

            while (true)
            {
                result = Response();
                if (result == ".\r\n")
                    break;
                else
                    mailMessage.MsgContent = result;
            }

            return mailMessage;
        }

        public void DeleteMessage(Mail msgDel)
        {
            string message, result;

            message = $"DELE {msgDel.Id}\r\n";
            Write(message);

            result=Response();
            if (result.Substring(0, 3) != "+OK")
                throw new POPException(result);
        }

        private void Write(string message)
        {
            System.Text.ASCIIEncoding oEncodedData = new System.Text.ASCIIEncoding();

            byte[] writeBuffer = new byte[1024];
            writeBuffer = oEncodedData.GetBytes(message);

            NetworkStream netStream = GetStream();
            netStream.Write(writeBuffer, 0, writeBuffer.Length);
        }
        private string Response()
        {
            System.Text.ASCIIEncoding oEncodedData = new System.Text.ASCIIEncoding();
            byte[] serverBuffer = new byte[1024];
            NetworkStream netStream = GetStream();
            int count = 0;

            while (true)
            {
                byte[] buff = new byte[2];
                int bytes = netStream.Read(buff, 0, 1);

                if(bytes == 1)
                {
                    serverBuffer[count] = buff[0];
                    count++;

                    if(buff[0] == '\n')
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            string returnValue = oEncodedData.GetString(serverBuffer, 0, count);
            return returnValue;
        }

        public class POPException: System.ApplicationException
        {
            public POPException(string str) : base(str) { }
        }
    }
}
