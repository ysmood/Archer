using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Archer
{
	class Program
	{
		static void Main(string[] args)
		{
			Archer.HttpServer httpServer = new Archer.HttpServer();
			httpServer.Start();

			Archer.Core core = new Archer.Core();
			core.Start();
		}
	}
}
