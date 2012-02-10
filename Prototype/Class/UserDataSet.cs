using System.Data.SQLite;
using System.Collections.Generic;
using System;
using System.Data;
using System.IO;

namespace Archer
{	
	public partial class UserDataSet
	{
		partial class SettingDataTable
		{
			public static string DefaultBrowser { get; set; }
			public static string DefaultEditor { get; set; }
			public static string StrokeProperty { get; set; }
			public static string NotifyIcon { get; set; }
			public static string UserName { get; set; }
			public static string Password = string.Empty;

			public static void OpenFileWithEidtor(string filePath)
			{
				string editorPath = ys.Path.GetFileFullPath(DefaultEditor);
				if (File.Exists(editorPath))
					ys.Path.Start(editorPath, filePath);
				else
					Core.Report(Archer.Resource.Exception_EditorOpen);
			}
		}
	
		partial class ArrowDataTable
		{
		}
	
		public static void CheckAndFix()
		{
			UserDataSetTableAdapters.ArrowTableAdapter da = new UserDataSetTableAdapters.ArrowTableAdapter();

			da.Adapter.SelectCommand = da.Connection.CreateCommand();
			da.Adapter.SelectCommand.CommandText =
@"create table if not exists Arrow (
Name  varchar(50) NOT NULL,
Cmd  text NOT NULL,
Arg  varchar(500),
Tag  varchar(500),
HotKey  varchar(500),
Count  int NOT NULL DEFAULT 0,
Enabled  tinyint NOT NULL DEFAULT 0,
Encrypted  tinyint NOT NULL DEFAULT 0,
Timestamp  datetime NOT NULL,
GUID  char(50) NOT NULL,
PRIMARY KEY (Name)
);";
			da.Connection.Open();
			da.Adapter.SelectCommand.ExecuteNonQuery();
			da.Connection.Close();
		}
	}
}

namespace Archer.UserDataSetTableAdapters
{
	
	
	public partial class ArrowTableAdapter
	{
		public UserDataSet.ArrowDataTable GetData(string query, Dictionary<string, object> paras)
		{
			UserDataSet.ArrowDataTable dt = new UserDataSet.ArrowDataTable();

			SQLiteCommand cmd = new SQLiteCommand(query, this.Connection);

			foreach (var item in paras)
			{
				cmd.Parameters.Add(
					new SQLiteParameter(item.Key, item.Value)
				);
			}

			Adapter.SelectCommand = cmd;
			Adapter.Fill(dt);

			return dt;
		}

		public int Update(string query, Dictionary<string, object> paras)
		{
			ConnectionState state = this.Connection.State;

			SQLiteCommand cmd = new SQLiteCommand(query, this.Connection);

			foreach (var item in paras)
			{
				cmd.Parameters.Add(
					new SQLiteParameter(item.Key, item.Value)
				);
			}

			if (state != ConnectionState.Open) cmd.Connection.Open();
			int affected = cmd.ExecuteNonQuery();
			if (state != ConnectionState.Open) cmd.Connection.Close();

			return affected;
		}
	}
}
