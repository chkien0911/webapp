using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ivs.Controls.CustomControls.WinForm;
using Ivs.Core.Common;
using Ivs.Core.Data;

namespace Ivs.Controls.Forms
{
    public partial class ProcessingForm : Ivs.Controls.CustomControls.WinForm.IVSForm
    {
        #region Private members

        //Services.Services service = new Ivs.Core.Services.Services();
        private List<IvsTimer> lstTimer = new List<IvsTimer>();

        private List<ProgressBarBaseControl> lstProgressBar = new List<ProgressBarBaseControl>();

        #endregion Private members

        #region Properties

        public int TipTimeOut
        {
            get
            {
                return 1000;
            }
        }

        public string TipTitle
        {
            get
            {
                string title = CommonData.StringEmpty;
                if (UserSession.LangId.Equals(CommonData.Language.English))
                {
                    title = "Server's Task";
                }
                else if (UserSession.LangId.Equals(CommonData.Language.VietNamese))
                {
                    title = "Tác vụ của máy chủ";
                }
                else if (UserSession.LangId.Equals(CommonData.Language.Japanese))
                {
                    title = "Server's Task";
                }
                return title;
            }
        }

        public string TipText
        {
            get
            {
                string text = CommonData.StringEmpty;
                if (UserSession.LangId.Equals(CommonData.Language.English))
                {
                    text = "Server is processing " + this.NumOfProcess + " task";
                }
                else if (UserSession.LangId.Equals(CommonData.Language.VietNamese))
                {
                    text = "Máy chủ đang xử lí " + this.NumOfProcess + " tác vụ";
                }
                else if (UserSession.LangId.Equals(CommonData.Language.Japanese))
                {
                    text = "Server is processing " + this.NumOfProcess + " task";
                }
                return text;
            }
        }

        public ToolTipIcon TipIcon
        {
            get
            {
                return ToolTipIcon.Info;
            }
        }

        public string CreatedDate
        {
            get
            {
                string createdDate = CommonData.StringEmpty;
                //if (UserSession.LangId.Equals(CommonData.Language.English))
                //{
                //    createdDate = CommonData.SystemDate.ToString(CommonData.DateFormat.MMddyyyyHHmmss);
                //}
                //else if (UserSession.LangId.Equals(CommonData.Language.VietNamese))
                //{
                //    createdDate = CommonData.SystemDate.ToString(CommonData.DateFormat.MMddyyyyHHmmss);
                //}
                //else if (UserSession.LangId.Equals(CommonData.Language.Japanese))
                //{
                //    createdDate = CommonData.SystemDate.ToString(CommonData.DateFormat.Yyyy_MM_ddHHmmss);
                //}
                return createdDate;
            }
        }

        public int NumOfProcess
        {
            get
            {
                return this.listViewProgress.Items.Count;
            }
        }

        #endregion Properties

        public ProcessingForm()
        {
            InitializeComponent();

            #region Events

            this.Resize += new EventHandler(ProcessingForm_Resize);
            this.DoubleClick += new EventHandler(ProcessingForm_DoubleClick);
            this.FormClosing += new FormClosingEventHandler(ProcessingForm_FormClosing);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            //this.notifyIcon1.MouseDown += new MouseEventHandler(notifyIcon1_MouseDown);

            #endregion Events

            #region SetLanguage

            this.SetLanguage();

            #endregion SetLanguage
        }

        #region Methods

        /// <summary>
        /// Add a processing item to the listview
        /// </summary>
        /// <param name="name">Name of item</param>
        /// <param name="message">IvsMessage of item</param>
        public void AddProcess(string name, string message, CommonData.ProgressBarType progressBarType)
        {
            ListViewItem item = new ListViewItem(message);
            item.SubItems.Add(this.CreatedDate);
            item.Name = name;
            listViewProgress.Items.Add(item);
            // Embed the ProgressBar
            if (progressBarType == CommonData.ProgressBarType.Marquee)
            {
                MarqueeProgressBarControl progressBar = new MarqueeProgressBarControl();
                progressBar.Name = name;
                progressBar.Tag = CommonData.ProgressBarType.Marquee.ToString();
                this.lstProgressBar.Add(progressBar);
                this.listViewProgress.AddEmbeddedControl(progressBar, 2, this.NumOfProcess - 1);
            }
            else
            {
                ProgressBarControl progressBar = new ProgressBarControl();
                progressBar.Properties.Step = 1;
                progressBar.Properties.ShowTitle = true;
                progressBar.Properties.PercentView = true;
                progressBar.Properties.Maximum = 100;
                progressBar.Properties.Minimum = 0;
                progressBar.Name = name;
                progressBar.Tag = CommonData.ProgressBarType.Progress.ToString();
                this.lstProgressBar.Add(progressBar);
                this.listViewProgress.AddEmbeddedControl(progressBar, 2, this.NumOfProcess - 1);
            }
            //Add timer to get percent
            IvsTimer timer = new IvsTimer();
            timer.Name = name;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            timer.Enabled = true;
            timer.Interval = 500;
            this.lstTimer.Add(timer);
            //start timer
            timer.Start();
        }

        /// <summary>
        /// Add a processing item to the listview
        /// </summary>
        /// <param name="name">Name of item</param>
        /// <param name="message">IvsMessage of item</param>
        public void AddProcess(string name, string message)
        {
            this.AddProcess(name, message, CommonData.ProgressBarType.Progress);
        }

        /// <summary>
        /// Remove a processing item from the listview
        /// </summary>
        /// <param name="row">Index of item</param>
        public void RemoveProcess(int row)
        {
            if (row >= 0 && row < this.NumOfProcess)
            {
                //Remove listviews item
                this.listViewProgress.Items.RemoveAt(row);
                //Remove listviews embeddedcontrol
                this.listViewProgress.RemoveEmbeddedControl(row);
                //Remove lists progressbar
                this.lstProgressBar.RemoveAt(row);

                ////Remove lists timer
                //this.lstTimer[row].Stop();
                //this.lstTimer[row].Enabled = false;
                //this.lstTimer.RemoveAt(row);

                //Hide Form if no more process
                if (this.NumOfProcess == 0)
                {
                    this.ShowTaskBar();
                }
            }
        }

        public void RemoveProcessAll()
        {
            while (lstProgressBar.Count > 0)
                RemoveProcess(lstProgressBar.Count - 1);
        }

        /// <summary>
        /// Remove a processing item from the listview
        /// </summary>
        /// <param name="name">name of item in listview</param>
        public void RemoveProcess(string name)
        {
            for (int i = this.listViewProgress.Items.Count - 1; i >= 0; i--)
            {
                if (listViewProgress.Items[i].Name.Equals(name))
                {
                    //Remore items in list
                    RemoveProcess(i);
                    break;
                }
            }
            for (int i = lstTimer.Count - 1; i >= 0; i--)
            {
                if (lstTimer[i].Name.Equals(name))
                {
                    lstTimer[i].Stop();
                    lstTimer.RemoveAt(i);
                }
            }
        }

        /// <summary>
        /// Show notifyicon in taskbar & hide processing form
        /// </summary>
        private void ShowTaskBar()
        {
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.ShowBalloonTip(TipTimeOut, TipTitle, TipText, TipIcon);
            this.notifyIcon1.Text = TipText;
            this.Hide();
        }

        /// <summary>
        /// Show processing form & hide notifyicon
        /// </summary>
        private void ShowForm()
        {
            this.notifyIcon1.Visible = false;
            this.SetLanguage();
            this.Show();
        }

        /// <summary>
        /// Set Language for screen
        /// </summary>
        public virtual void SetLanguage()
        {
            //create I18n class object
            I18n i18n = new I18n(CommonData.FunctionId.ProcessingForm);
            this.Text = i18n.GetString(this.Name);
            this.colDate.Text = i18n.GetString(this.colDate.Name);
            this.colName.Text = i18n.GetString(this.colName.Name);
            this.colProgress.Text = i18n.GetString(this.colProgress.Name);
        }

        #endregion Methods

        #region Events

        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            IvsTimer timer = ((IvsTimer)sender);
            string name = timer.Name;
            string percent = CommonData.StringEmpty;
            try
            {
                //if (service.GetTaskProgress(CommonData.GetFullPath(DbConfig.TempFolder, name, "txt"), ref percent))
                //{
                //    ProgressBarBaseControl progressBarBase = this.GetProgressBar(this.lstProgressBar, name);
                //    //Tag = 1 - Using marquee bar control
                //    //Tag = 2 - Using progress bar control
                //    if (progressBarBase != null && progressBarBase.Tag != null && progressBarBase.Tag.ToString().Equals(CommonData.ProgressBarType.Progress.ToString()))
                //    {
                //        ProgressBarControl progressBar = (ProgressBarControl)progressBarBase;
                //        if (progressBar != null)
                //        {
                //            int perCent = CommonMethod.ParseInt(percent);
                //            //process task with step by step
                //            if (progressBar.Position < perCent)
                //            {
                //                if (this.InvokeRequired)
                //                {
                //                    this.BeginInvoke(new Action(progressBar.PerformStep));
                //                    this.BeginInvoke(new Action(progressBar.Update));
                //                }
                //                else
                //                {
                //                    progressBar.PerformStep();
                //                    progressBar.Update();
                //                }

                //            }
                //            //process task with progress
                //            if ((perCent > 25 && progressBar.Position < 25)
                //                || (perCent > 50 && progressBar.Position < 50)
                //                || (perCent > 75 && progressBar.Position < 75)
                //                || (perCent == 100))
                //            {
                //                if (this.InvokeRequired)
                //                {
                //                    this.BeginInvoke(new Action<int>(progressBar.Increment), perCent);
                //                    this.BeginInvoke(new Action(progressBar.Update));
                //                }
                //                else
                //                {
                //                    progressBar.Increment(perCent);
                //                    progressBar.Update();
                //                }

                //                //finish task
                //                if (perCent == 100)
                //                {
                //                    timer.Stop();
                //                    timer.Enabled = false;
                //                }
                //            }
                //        }
                //    }
                //}
            }
            catch (Exception)
            {
                timer.Stop();
                timer.Enabled = false;
            }
        }

        private void ProcessingForm_Resize(object sender, EventArgs e)
        {
            this.colDate.Width = 200;
            this.colProgress.Width = 200;
            this.colName.Width = listViewProgress.Width - this.colDate.Width - this.colProgress.Width;
        }

        private void ProcessingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.ShowTaskBar();
        }

        private void ProcessingForm_DoubleClick(object sender, EventArgs e)
        {
            this.ShowTaskBar();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.ShowForm();
        }

        private void notifyIcon1_MouseDown(object sender, MouseEventArgs e)
        {
            this.notifyIcon1.ShowBalloonTip(TipTimeOut, TipTitle, TipText, TipIcon);
        }

        private ProgressBarBaseControl GetProgressBar(List<ProgressBarBaseControl> lstProgressBar, string name)
        {
            return lstProgressBar.Find(p => p.Name.Equals(name));
        }

        #endregion Events
    }
}