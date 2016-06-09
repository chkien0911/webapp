using System.Reflection;
using System;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.Utils.Menu;
namespace Ivs.Controls.CustomControls.WinForm
{
    public class IvsPictureEdit : DevExpress.XtraEditors.PictureEdit
    {
        #region Pirvate Variables

        //An instance of error provider
        private IvsErrorProvider _errorProvider = new IvsErrorProvider();

      
      
       
        #endregion Pirvate Variables

        #region Methods About Setting Message

        /// <summary>
        /// Set error IvsMessage and icon for textbox control
        /// </summary>
        /// <param name="messageText">
        /// Content of message
        /// </param>
        public void SetError(string messageText)
        {
            _errorProvider.SetError(this, messageText, DevExpress.XtraEditors.DXErrorProvider.ErrorType.User1);
            _errorProvider.SetIconAlignment(this, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
        }

        /// <summary>
        /// Set warning IvsMessage and icon for textbox control
        /// </summary>
        /// <param name="messageText">
        /// Content of message
        /// </param>
        public void SetWarning(string messageText)
        {
            _errorProvider.SetError(this, messageText, DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning);
            _errorProvider.SetIconAlignment(this, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
        }

        /// <summary>
        /// Set information IvsMessage and icon for textbox control
        /// </summary>
        /// <param name="messageText">
        /// Content of message
        /// </param>
        public void SetInfo(string messageText)
        {
            _errorProvider.SetError(this, messageText, DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
            _errorProvider.SetIconAlignment(this, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
        }

        #endregion Methods About Setting Message

        #region Methods About Clearing Message

        /// <summary>
        ///Clear error IvsMessage and icon for textbox control
        /// </summary>
        public void ClearErrors()
        {
            if (_errorProvider.HasErrors)
            {
                _errorProvider.ClearErrors();
            }
        }


        #endregion Methods About Clearing Message

        #region CreateContextMenu



        ContextMenuStrip context = new ContextMenuStrip();

        private DevExpress.XtraEditors.Controls.PictureMenu GetMenu(DevExpress.XtraEditors.PictureEdit edit)
        {
            PropertyInfo pi = typeof(DevExpress.XtraEditors.PictureEdit).GetProperty("Menu", BindingFlags.NonPublic | BindingFlags.Instance);
            if (pi != null)
                return pi.GetValue(edit, null) as DevExpress.XtraEditors.Controls.PictureMenu;
            return null;
        }


        private void InvokeMenuMethod(DevExpress.XtraEditors.Controls.PictureMenu menu, String name)
        {
            MethodInfo mi = typeof(DevExpress.XtraEditors.Controls.PictureMenu).GetMethod(name, BindingFlags.NonPublic | BindingFlags.Instance);
            if (mi != null && menu != null)
                mi.Invoke(menu, new object[] { menu, new EventArgs() });
        }

        public ContextMenuStrip CreateContextMenu()
        {
            context = new ContextMenuStrip();
            PictureMenu pictureMenu = GetMenu(this);
            for (int i = 0; i < 6; i++)
            {
                if (i > pictureMenu.Items.Count - 1 )
                    break;
                DXMenuItem dxMenuItem = pictureMenu.Items[i];
                ToolStripMenuItem menuItem = new ToolStripMenuItem();
                menuItem.Text = dxMenuItem.Caption;
                menuItem.Image = dxMenuItem.Image;

                if (i == 4)
                    context.Items.Add(new ToolStripSeparator());
                switch (i)
                {
                    case 0:
                        menuItem.Click += new EventHandler(CutMenuItem_Click);
                        break;
                    case 1:
                        menuItem.Click += new EventHandler(CopyMenuItem_Click);
                        break;
                    case 2:
                        menuItem.Click += new EventHandler(PasteMenuItem_Click);
                        break;
                    case 3:
                        menuItem.Click += new EventHandler(DeleteMenuItem_Click);
                        break;
                    case 4:
                        menuItem.Click += new EventHandler(LoadMenuItem_Click);
                        break;
                    case 5:
                        menuItem.Click += new EventHandler(SaveMenuItem_Click);
                        break;
                   
                }
                context.Items.Add(menuItem);
            }
         
            return context;
            

        }

        private void CopyMenuItem_Click(object sender, EventArgs e)
        {

            InvokeMenuMethod(GetMenu(this), "OnClickedCopy");
        }
        private void CutMenuItem_Click(object sender, EventArgs e)
        {
            InvokeMenuMethod(GetMenu(this), "OnClickedCut");
        }
        private void DeleteMenuItem_Click(object sender, EventArgs e)
        {
            InvokeMenuMethod(GetMenu(this), "OnClickedDelete");
        }
        private void LoadMenuItem_Click(object sender, EventArgs e)
        {
            InvokeMenuMethod(GetMenu(this), "OnClickedLoad");
        }
        private void PasteMenuItem_Click(object sender, EventArgs e)
        {
            InvokeMenuMethod(GetMenu(this), "OnClickedPaste");
        }
        private void SaveMenuItem_Click(object sender, EventArgs e)
        {
            InvokeMenuMethod(GetMenu(this), "OnClickedSave");
        }


        #endregion
    }
}