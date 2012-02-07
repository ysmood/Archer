using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Text;

namespace Archer
{
	public partial class Browser : Form
	{
		// ******** Public Part ******** 

		public Browser()
		{
			InitializeComponent();

			this.Font = Resource.MainFont;

			scriptInterface = new ScriptInterface(this);
			webBrowser.ObjectForScripting = scriptInterface;
		}

		public bool NavigateOnStartup = true;
		public string Argument = string.Empty;
		public string AdditionalScript;
		public bool jQuery = false;

		public void InjectAndRunScript(string code)
		{
			// Basic check, insert some basic elements.
			if (string.IsNullOrEmpty(code))
				return;
			if (webBrowser.Document == null)
				webBrowser.DocumentText = "<html><head></head></html>";

			HtmlElementCollection elements = webBrowser.Document.GetElementsByTagName("head");
			if (elements.Count == 0)
			{
				HtmlElementCollection html = webBrowser.Document.GetElementsByTagName("html");
				if (html.Count == 0)
					webBrowser.DocumentText = "<html><head></head></html>";
				else
				{
					html[0].AppendChild(webBrowser.Document.CreateElement("head"));
				}
			}

			HtmlElement scriptElement = webBrowser.Document.GetElementById(sctiptMainID);
			if (scriptElement != null)
			{
				// First remove the script rectMarker.
				scriptElement.OuterHtml = string.Empty;
			}
			// Create a new script rectMarker.
			scriptElement = webBrowser.Document.CreateElement("script");
			scriptElement.SetAttribute("id", sctiptMainID);
			scriptElement.SetAttribute("text", code);

			// Insert.
			if (elements.Count > 0)
				webBrowser.Document.GetElementsByTagName("head")[0].AppendChild(scriptElement);
		}
		public void ShowOutput(string output = null, bool topMost = false)
		{
			if (outputWindow == null || outputWindow.IsDisposed) outputWindow = new Output();
			outputWindow.Show();

			if(topMost)	outputWindow.TopMost = topMost;

			if (output != null)
				outputWindow.Append(output);
			if (!outputWindow.Focused)
				outputWindow.Activate();
		}
		public string CurrentHost
		{
			get { return webBrowser.Url.Host; }
		}


		// ******** Private Part ******** 

		private ScriptInterface scriptInterface;
		private string sctiptMainID = Guid.NewGuid().ToString();
		private List<ScriptConsole> scriptConsoles;
		private Output outputWindow;
		private HtmlElement rectMarker;

		private void Start(object sender, EventArgs e)
		{
			string[] args = ys.Common.GetArgs((string)Argument);

			if (args.Length < 1) return;
			
			// Set fullCmd list.
			for (int i = 0; i < args.Length - 1; i++)
			{
				Script script = new Script(args[i]);
				ScriptList.Add(script);
				btnRunScript.DropDownItems.Insert(
					btnRunScript.DropDownItems.Count - 1,
					CreatePathMenuItem(script)
				);
			}

			if (NavigateOnStartup)
			{
				webBrowser.Navigate(args[args.Length - 1]);
				cbAddress.Text = args[args.Length - 1].Replace("?", "");
			}
		}
		private void SetFavicon()
		{
			string faviconPath = ys.Common.GetPathForCachedFile("http://" + webBrowser.Url.Host + "/favicon.ico");
			if (faviconPath != null)
				this.Icon = new Icon(faviconPath);
			else
				this.Icon = Archer.Properties.Resources.ArcherIcon;
		}

		// Key Control
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			switch (keyData)
			{
				case Keys.Escape:
					if (webBrowser.Url != null
						&& cbAddress.Focused)
					{
						cbAddress.Text = webBrowser.Url.AbsoluteUri;
					}
					break;

				case Keys.Enter:
					if (webBrowser.Url != null
						&& cbAddress.Focused)
					{
						btnRefresh_Click(null, null);
					}
					break;

				case Keys.F2:
					RunAllScript(null, null);
					return true;

				case Keys.F11:
					btnFullScreen_Click(null, null);
					break;

				case Keys.F10:
					webBrowser.Document.MouseDown += (o, e) =>
					{
						Main.Report();
					};
					break;

				case Keys.F12:
					ShowScriptConsole(null, null);
					return true;
			}
			return base.ProcessCmdKey(ref msg, keyData);
		}

		// Script
		private List<Script> ScriptList = new List<Script>();
		private ToolStripMenuItem CreatePathMenuItem(Script script)
		{
			ToolStripMenuItem mit = new ToolStripMenuItem()
			{
				AutoToolTip = true,
				Text = script.FileName,
				ToolTipText = script.FilePath,
			};
			if (!script.AutoRun) mit.ForeColor = Color.Violet;

			mit.MouseDown += (o, e) =>
			{
				if (!File.Exists(script.FilePath))
				{
					Main.Report(Resource.CannotFindFile);
					btnRunScript.DropDownItems.Remove(mit);
					return;
				}

				if (e.Button == System.Windows.Forms.MouseButtons.Left)
				{
					if (jQuery)
						InjectAndRunScript(Properties.Resources.jquery + script.Code);
					else
						InjectAndRunScript(script.Code);
				}
				else if (e.Button == System.Windows.Forms.MouseButtons.Right)
				{
					Main.Setting.OpenFileWithEidtor(script.FilePath);
				}
			};

			btnRunScript.Text = ScriptList.Count.ToString();
			btnRunScript.Width = btnRunScript.Image.Width * 2 + btnRunScript.Text.Length * 12;
			
			return mit;
		}
		private void AddScriptPath(object sender, EventArgs e)
		{
			string newPath;
			if (sender is string)
				newPath = sender as string;
			else if (toolStripTxtAddPath.Text != "Add New Path")
				newPath = toolStripTxtAddPath.Text;
			else return;

			if (File.Exists(newPath))
			{
				Script script = new Script(newPath);
				ScriptList.Add(script);

				btnRunScript.DropDownItems.Insert(
					btnRunScript.DropDownItems.Count - 1,
					CreatePathMenuItem(script)
				);
			}
			else
				Main.Report(newPath + "\n\n" + Resource.Exception_FileNotFound);

			toolStripTxtAddPath.Text = Resource.AddNewPath;
		}
		private void RunAllScript(object sender, EventArgs e)
		{
			string AllCode = string.Empty;

			// Install jQuery
			if (jQuery) AllCode += Properties.Resources.jquery;

			for (int i = 0; i < ScriptList.Count; i++)
			{
				if (ScriptList[i].AutoRun)
				{
					try
					{
						AllCode += '\n' + ScriptList[i].Code;
					}
					catch (Exception ex)
					{
						Main.Report(ex.Message);
						btnRunScript.DropDownItems.RemoveAt(i);
					}
				}
			}

			AllCode += "\n" + AdditionalScript;

			InjectAndRunScript(AllCode);
		}
		private void DocumentCompleted()
		{
			string title = webBrowser.Document.GetElementsByTagName("title")[0].InnerText;
			cbAddress.Text = webBrowser.Url.AbsoluteUri;
			this.Text = title + " " + webBrowser.Url.AbsoluteUri;

			string info = title + " ━ " + webBrowser.Url.AbsoluteUri;
			if (!cbAddress.Items.Contains(info))
				cbAddress.Items.Add(info);

			RunAllScript(null, null);

			SetFavicon();
		}

		// UI Events
		private void webBrowser_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
		{
			if (e.MaximumProgress != 0)
			{
				if (!pbarLoadingProgress.Visible) pbarLoadingProgress.Visible = true;
				pbarLoadingProgress.Value = (int)(e.CurrentProgress * 100 / e.MaximumProgress);
			}
			else
			{
				pbarLoadingProgress.Value = 100;
				pbarLoadingProgress.Visible = false;
			}
		}
		private void cbAddress_TextChanged(object sender, EventArgs e)
		{
			if (webBrowser.Url == null) return;

			if (cbAddress.Text != webBrowser.Url.AbsoluteUri
				&& btnRefresh.Image != Properties.Resources.Arrow_Right)
				btnRefresh.Image = Properties.Resources.OK;
			else if (btnRefresh.Image != Properties.Resources.Refresh)
				btnRefresh.Image = Properties.Resources.Refresh;
		}
		private void btnBackward_Click(object sender, EventArgs e)
		{
			webBrowser.GoBack();
		}
		private void btnForward_Click(object sender, EventArgs e)
		{
			webBrowser.GoForward();
		}
		private void btnRefresh_Click(object sender, EventArgs e)
		{
			Regex r = new Regex(" ━ ((http:|about:).+)$", RegexOptions.IgnoreCase);
			if (string.IsNullOrEmpty(r.Match(cbAddress.Text).Groups[1].Value))
				webBrowser.Navigate(cbAddress.Text);
			else
				webBrowser.Navigate(r.Match(cbAddress.Text).Groups[1].Value);
		}
		private void Browser_DragEnter(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.All;
		}
		private void Browser_DragDrop(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				foreach (var path in (e.Data.GetData(DataFormats.FileDrop) as String[]))
				{
					AddScriptPath(path, null); 
				}
			}
			RunAllScript(null, null);
		}
		private void Browser_FormClosing(object sender, FormClosingEventArgs e)
		{
			if(scriptConsoles != null)
				foreach (var item in scriptConsoles)
				{
					item.Close();
				}

			if (outputWindow != null)
				outputWindow.Close();
		}
		private void webBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
		{
			cbAddress.Text = webBrowser.Url.AbsoluteUri;
		}
		private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
		{
			if (e.Url == webBrowser.Url)
				DocumentCompleted();

			btnBackward.Enabled = webBrowser.CanGoBack;
			btnForward.Enabled = webBrowser.CanGoForward;

			SelectDOMCancel(null, null);
		}
		private void webBrowser_DocumentCompleted_Refresh(object sender, WebBrowserDocumentCompletedEventArgs e)
		{
			if (e.Url.AbsoluteUri == "about:blank")
				DocumentCompleted();
			webBrowser.DocumentCompleted -= webBrowser_DocumentCompleted_Refresh;
		}
		private void webBrowser_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			if (e.KeyCode == Keys.F5)
			{
				webBrowser.Navigate(webBrowser.Url.AbsoluteUri);
				webBrowser.DocumentCompleted += webBrowser_DocumentCompleted_Refresh;
			}
		}
		private void webBrowser_NewWindow2(object sender, ys.NewWindow2EventArgs e)
		{
			Browser browser = new Browser()
			{
				NavigateOnStartup = false,
				Argument = this.Argument,
				jQuery = this.jQuery,
				AdditionalScript = this.AdditionalScript,
			};
			browser.Show();
			e.PPDisp = browser.webBrowser.Application;
		}
		private void btnShowError_Click(object sender, EventArgs e)
		{
			webBrowser.ScriptErrorsSuppressed = btnShowError.Checked;
			btnShowError.Checked = !btnShowError.Checked;
		}
		private void ShowScriptConsole(object sender, EventArgs e)
		{
			if (scriptConsoles == null) scriptConsoles = new List<ScriptConsole>();
			ScriptConsole scriptConsole;

			if (sender is string)
				scriptConsole = new ScriptConsole(this, (string)sender);
			else
				scriptConsole = new ScriptConsole(this);

			scriptConsole.Show();

			scriptConsoles.Add(scriptConsole);
		}
		private void btnFullScreen_Click(object sender, EventArgs e)
		{
			if (this.FormBorderStyle != System.Windows.Forms.FormBorderStyle.None)
			{
				this.TopMost = true;
				this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
				this.WindowState = FormWindowState.Maximized;
			}
			else
			{
				this.TopMost = false;
				this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
				this.WindowState = FormWindowState.Normal;
			}
		}

		// Visual select DOM
		private void btnSelectDOM_Click(object sender, EventArgs e)
		{
			btnSelectDOM.Checked = !btnSelectDOM.Checked;
			if (btnSelectDOM.Checked)
			{
				rectMarker = webBrowser.Document.CreateElement("div");

				webBrowser.Document.Body.AppendChild(rectMarker);

				webBrowser.Document.MouseMove += SelectDOMMove;
				webBrowser.Document.MouseDown += SelectDOMCancel;
			}
			else
			{
				SelectDOMCancel(null, null);
			}
		}
		private void SelectDOMMove(object sender, HtmlElementEventArgs e)
		{
			if (btnSelectDOM.Checked)
			{
				HtmlElement element = webBrowser.Document.GetElementFromPoint(e.ClientMousePosition);

				if (element == rectMarker) return;

				Rectangle rect = GetAbsoluteRect(element);

				rectMarker.Style =
					"left:" + --rect.X + "px;" +
					"top:" + --rect.Y + "px;" +
					"height:" + rect.Height + "px;" +
					"width:" + rect.Width + "px;" +
					"position: absolute;" +
					"border: 1px solid #5588ee;";

				cbAddress.Text = GetCSSPath(element).ToLower();
				
				e.ReturnValue = false;
			}
		}
		private void SelectDOMCancel(object sender, HtmlElementEventArgs e)
		{
			btnSelectDOM.Checked = false;
			rectMarker.OuterHtml = null;

			webBrowser.Document.MouseMove -= SelectDOMMove;
			webBrowser.Document.MouseDown -= SelectDOMCancel;

			if(e != null) e.ReturnValue = false;
		}
		private Rectangle GetAbsoluteRect(HtmlElement element)
		{
			//get rectMarker pos 
			int x = element.OffsetRectangle.Left;
			int y = element.OffsetRectangle.Top;
			int w = element.OffsetRectangle.Width;
			int h = element.OffsetRectangle.Height;

			//get the parents pos 
			HtmlElement tempEl = element.OffsetParent;
			while (tempEl != null)
			{
				x += tempEl.OffsetRectangle.Left;
				y += tempEl.OffsetRectangle.Top;

				tempEl = tempEl.OffsetParent;
			}

			return new Rectangle(x, y, w, h);
		}
		private string GetCSSPath(HtmlElement element)
		{
			string CSSPath = string.Empty;
			string currentTagName;
			string className;

			while (element != null)
			{
				currentTagName = element.TagName;

				if (!string.IsNullOrEmpty(element.Id))
				{
					CSSPath = element.TagName + "#" + element.Id + " " + CSSPath;
				}
				else if (!string.IsNullOrEmpty(className = element.GetAttribute("classname")))
				{
					CSSPath = element.TagName + "." + className.Replace(" ", ".") + " " + CSSPath;
				}
				else
				{
					CSSPath = element.TagName + " " + CSSPath;
				}

				element = element.Parent;
			}

			return CSSPath;
		}
	}
}
