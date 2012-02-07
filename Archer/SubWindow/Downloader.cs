using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace Archer
{
	public partial class Downloader : Form
	{
		public Downloader()
		{
			InitializeComponent();

			this.Font = Resource.MainFont;
		}

		public void StartDownload(string u, string f, string ex = "")
		{
			url = u;
			file = f;
			tempExtension = ex;

			bwManager.RunWorkerAsync();
		}
		public event EventHandler Completed;

		private string file;
		private string url;
		private string tempExtension;
		private bool completed = true;

		private void bwManager_DoWork(object sender, DoWorkEventArgs e)
		{
			try
			{
				HttpWebRequest request = (HttpWebRequest)System.Net.HttpWebRequest.Create(url);
				HttpWebResponse response = (HttpWebResponse)request.GetResponse();
				long totalBytes = response.ContentLength;

				int stepLength = 1024;
				Stream from = response.GetResponseStream();
				from.ReadTimeout = 5000;
				Stream to = new FileStream(file + tempExtension, FileMode.Create);
				byte[] step = new byte[stepLength];
				while ((stepLength = from.Read(step, 0, step.Length)) > 0)
				{
					if (bwManager.CancellationPending)
					{
						completed = false;
						break;
					}

					to.Write(step, 0, stepLength);

					bwManager.ReportProgress((int)(to.Length * 100 / totalBytes));
				}

				to.Close();
				from.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(Resource.Exception_DownloadFailed + "\n\n" + ex.Message);
			}
		}

		private void bwManager_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			progressBar.Value = e.ProgressPercentage;
		}

		private void bwManager_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (completed)
			{
				File.Move(file + tempExtension, file);

				if (Completed != null)
					Completed(sender, e);
			}
			else
			{
				try
				{
					File.Delete(file + tempExtension);
				}
				catch (Exception)
				{
				}
			}
			this.Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			bwManager.CancelAsync();
			
			btnCancel.Enabled = false;
		}
	}
}
