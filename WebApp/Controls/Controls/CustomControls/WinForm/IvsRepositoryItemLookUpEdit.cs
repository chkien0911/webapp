using Ivs.BLL.Common;
using Ivs.Core.Common;
using Ivs.Core.Data;
using System.ComponentModel;
using DevExpress.XtraEditors.Controls;

namespace Ivs.Controls.CustomControls.WinForm
{
    public class IvsRepositoryItemLookUpEdit : DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    {       

        #region public Method

        protected virtual void FillData()
        {

        }

        public virtual void ReloadData()
        {
            this.FillData();
        }

        #endregion public Method
    }
}