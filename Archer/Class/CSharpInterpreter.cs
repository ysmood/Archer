using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.CodeDom.Compiler;
using Microsoft.CSharp;

namespace CSharpInterpreter
{
	/// <summary>
	/// C#解释器
	/// </summary>
	public class CSharpInterpreter
	{
		private CSharpInterpreter() { }

		/// <summary>
		/// 执行源代码
		/// 类必须命名为 CSharpExecutor.Executor 且具有方法 public Execute(string[] list)
		/// </summary>
		/// <param name="source">源代码</param>
		/// <param name="reference">引用程序集, eg. System.Xml</param>
		/// <param name="list">参数</param>
		public static string RunFromSrc(string source, string[] reference, string[] args)
		{
			CompilerResults compilerResults = GetProvider.CompileAssemblyFromSource(GetCompileParam(reference), source);
			return Run(compilerResults, args);
		}

		/// <summary>
		/// 执行源代码文件
		/// 类必须命名为 CSharpExecutor.Executor 且具有方法 public Execute(string[] list)
		/// </summary>
		/// <param name="filePath">要编译的文件路径</param>
		/// <param name="reference">引用程序集, eg. System.Xml</param>
		/// <param name="list">参数</param>
		public static string RunFromSrcFile(string filePath, string[] reference, string[] args)
		{
			string src = System.IO.File.ReadAllText(filePath);
			return RunFromSrc(src, reference, args);
		}

		/// <summary>
		/// 执行脚本，无需命名空间、类、方法声明，无需显式return
		/// re为返回值变量
		/// </summary>
		/// <param name="script">单一方法内容</param>
		/// <param name="reference">引用程序集, eg. System.Xml</param>
		/// <param name="list">参数</param>
		/// <returns></returns>
		public static string RunFromScript(string script, string[] reference, string[] args)
		{
			string src = "using System;using System.Collections.Generic;using System.Text;using System.IO;using System.Linq;using Common;using System.Windows.Forms;" +
					"namespace CSharpExecutor{public class Executor{public string Execute(string[] args){object re=null;" + script + ";if (re!=null)return re.ToString();else return null;}}}";
			return RunFromSrc(src, reference, args);
		}

		/// <summary>
		/// 执行脚本文件，无需命名空间、类、方法声明，无需显式return
		/// re为返回值变量
		/// </summary>
		/// <param name="scriptFilePath">单一方法内容文件路径</param>
		/// <param name="reference">引用程序集, eg. System.Xml</param>
		/// <param name="list">参数</param>
		/// <returns></returns>
		public static string RunFromScriptFile(string scriptFilePath, string[] reference, string[] args)
		{
			string script = System.IO.File.ReadAllText(scriptFilePath);
			return RunFromScript(script, reference, args);
		}

		/// <summary>
		/// 使用参数执行
		/// </summary>
		/// <param name="result"></param>
		/// <param name="list"></param>
		private static string Run(CompilerResults result, string[] args)
		{
			if (result.Errors.Count == 0)
			{
				Assembly asm = result.CompiledAssembly;
				Type type = asm.GetType("CSharpExecutor.Executor", false, true);
				if (type == null)
				{
					throw new ExecuteException("Execute failed, the class must be named as \"CSharpExecutor.Executor\"");
				}

				bool hasArg = true;
				MethodInfo methodInfo = type.GetMethod("Execute", new Type[]{ typeof(string[]) });
				if (methodInfo == null)
				{
					methodInfo = type.GetMethod("Execute", Type.EmptyTypes);
					hasArg = false;
					if (methodInfo == null)
						throw new ExecuteException("Execute failed, the class must have a method declared as \"public Execute()\" or \"public Execute(string[] args)\"");
				}

				object obj = System.Activator.CreateInstance(type);

				try
				{
					object[] ar = null;
					if (hasArg)
						ar = new object[] { args };
					object re = methodInfo.Invoke(obj, ar);
					if (re != null)
						return re.ToString();
					else return null;
				}
				catch (Exception ex)
				{
					throw new ExecuteException("Execute failed, see inner exception for details:\n\n" + ex.InnerException, ex);
				}
			}
			else
			{
				//如果出错则返回错误文本
				string errorMessage = "";

				//int i = 1;
				foreach (CompilerError error in result.Errors)
				{
					errorMessage += "Line " + error.Line + ": " + error.ErrorText + System.Environment.NewLine;
				}

				throw new CompileException(errorMessage);
			}
		}

		private static CodeDomProvider GetProvider
		{
			get
			{
				CodeDomProvider codeCompiler = new CSharpCodeProvider(new Dictionary<string, string>() { { "CompilerVersion", "v3.5" } });
				return codeCompiler;
			}
		}

		private static CompilerParameters GetCompileParam(string[] referDlls)
		{
			CompilerParameters compilerParameters = new CompilerParameters()
				{
					GenerateInMemory = true,
					GenerateExecutable = false
				};
			compilerParameters.ReferencedAssemblies.Add("System.Core.dll");
			compilerParameters.ReferencedAssemblies.Add("system.dll");
			compilerParameters.ReferencedAssemblies.Add("System.Drawing.dll");
			compilerParameters.ReferencedAssemblies.Add("System.Web.dll");
			compilerParameters.ReferencedAssemblies.Add("System.Windows.Forms.dll");

			if (referDlls != null && referDlls.Length > 0)
				compilerParameters.ReferencedAssemblies.AddRange(referDlls);

			return compilerParameters;
		}
	}

	/// <summary>
	/// 编译异常
	/// </summary>
	[Serializable]
	public class CompileException : Exception {
		public CompileException() { }
		public CompileException(string message) : base(message) { }
		public CompileException(string message, Exception inner) : base(message, inner) { }
		public CompileException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}

	/// <summary>
	/// 执行异常
	/// </summary>
	[Serializable]
	public class ExecuteException : Exception
	{
		public ExecuteException() { }
		public ExecuteException(string message) : base(message) { }
		public ExecuteException(string message, Exception inner) : base(message, inner) { }
		public ExecuteException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
