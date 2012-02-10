//#define _debug

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Web;
using System.Collections;
using System.Threading;

namespace Archer
{
	/// <summary>
	/// Singleton object
	/// </summary>
	public class HttpServer
	{
		public HttpServer(int port = 2357, string charset = "utf-8")
		{
			if (Instance == null)
			{
				Instance = this;
			}
			else
			{
				throw new Exception("Only one object instance is allowed");
			}

			server = bindSocket("127.0.0.1", port);
			messageQueue = Queue.Synchronized(new Queue());		// thread safe
			encoder = Encoding.GetEncoding(charset);
		}

		public static HttpServer Instance;
		public int Port
		{
			get { return ((IPEndPoint)server.LocalEndPoint).Port; }
		}
		public Queue MessageQueue
		{
			get
			{
				return messageQueue;
			}
		}

		public void Start()
		{
			Thread main = new Thread(new ThreadStart(Main));
			main.Start();
		}

		private void Main()
		{
			server.Listen(5);
			while (true)
			{
				Socket c = server.Accept();
				try
				{
					int bytes = 0;
					byte[] buffer = new byte[c.ReceiveBufferSize];

					bytes = c.Receive(buffer);
					Array.Resize(ref buffer, bytes);
					RequestInfo ri = parseRequest(buffer);

					c.Send(Response(ri));
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
				finally
				{
					c.Close();
				}
			}
		}

		private class RequestInfo
		{
			public RequestInfo(string raw)
			{
				StringReader sr = new StringReader(raw);
				string line = sr.ReadLine();
				string key, value;
				int index;

				string[] paras = line.Split(' ');
				Method = paras[0];
				Selector = paras[1];
				Version = paras[2];

				// parse Selector
				Get = new Dictionary<string, string>();
				index = Selector.IndexOf('?');
				if (index >= 0)
				{
					Url = Selector.Remove(index);
					foreach (var item in Selector.Substring(index).TrimStart('?').Split('&'))
					{
						if (item.Length == 0) continue;

						index = item.IndexOf('=');
						if (index < 0)
						{
							key = HttpUtility.UrlDecode(item);
							value = "";
						}
						else
						{
							key = HttpUtility.UrlDecode(item.Remove(index));
							value = HttpUtility.UrlDecode(item.Substring(index).TrimStart('='));
						}

						Get.Add(key, value);
					}
				}
				else
				{
					Url = Selector;
				}

				// parse Headers
				Header = new Dictionary<string, string>();
				while ((line = sr.ReadLine()) != "")
				{
					index = line.IndexOf(':');
					Header.Add(line.Remove(index), line.Substring(index).TrimStart(':').Trim());
				}

				// parse Body
				Post = new Dictionary<string, string>();
				Body = sr.ReadToEnd() ?? "";
				foreach (var item in Body.Split('&'))
				{
					if (item.Length == 0) continue;

					index = item.IndexOf('=');
					if (index < 0)
					{
						key = HttpUtility.UrlDecode(item);
						value = "";
					}
					else
					{
						key = HttpUtility.UrlDecode(item.Remove(index));
						value = HttpUtility.UrlDecode(item.Substring(index).TrimStart('='));
					}

					Post.Add(key, value);
				}
			}

			public string Method;
			public string Selector;
			public string Version;
			public string Url;
			public Dictionary<string, string> Header;
			public string Body;
			public Dictionary<string, string> Get;
			public Dictionary<string, string> Post;
		}
		private byte[] Response(RequestInfo ri)
		{
			string ret;
			if (ri.Get.ContainsKey("Name"))
			{
				messageQueue.Enqueue(ri.Get);
				ret = DateTime.Now.ToString("u");
			}
			else
				ret = "Null";

#if _debug
			Console.WriteLine(ri.Selector);
#endif

			return constructResponse(ret);
		}

		private RequestInfo parseRequest(byte[] r)
		{
			string c = encoder.GetString(r);			

			RequestInfo ri = new RequestInfo(c);

			return ri;
		}

		private byte[] constructResponse(string c)
		{
			string sep = "\r\n";
			string strHeader = "";
			Dictionary<string, string> dictHeader = new Dictionary<string, string>();

			dictHeader.Add("Content-Type", "text/html");
			dictHeader.Add("Content-Length", encoder.GetBytes(c).Length.ToString());

			foreach (var item in dictHeader)
			{
				strHeader += item.Key + ": " + item.Value + sep;
			}

			return encoder.GetBytes("HTTP/1.1 200 OK" + sep + strHeader + sep + c);
		}

		private static Socket bindSocket(string server, int port)
		{
			Socket s = null;
			IPHostEntry hostEntry = null;

			// Get host related information.
			hostEntry = Dns.GetHostEntry(server);

			// Loop through the AddressList to obtain the supported AddressFamily. This is to avoid
			// an exception that occurs when the host IP Address is not compatible with the address family
			// (typical in the IPv6 case).
			foreach (IPAddress address in hostEntry.AddressList)
			{
				IPEndPoint ipe = new IPEndPoint(address, port);
				Socket tempSocket =
					new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

				tempSocket.Bind(ipe);

				s = tempSocket;
			}
			return s;
		}

		private Socket server;
		private Queue messageQueue;
		private Encoding encoder;
	}
}
