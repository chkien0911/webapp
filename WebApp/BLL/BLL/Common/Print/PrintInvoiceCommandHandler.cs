using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ivs.Core.Common;
using Ivs.Core.Interface;
using Ivs.BLL.Invoice;
using Ivs.DTO.Invoice;
using Ivs.Core.Data;

namespace Ivs.BLL.Common.Print
{
    public class PrintInvoiceCommandHandler : PrintCommandHandler
    {
        public override bool BeforePrint()
        {
            #region To do something

            INV_InvoiceBl invoiceBl = new INV_InvoiceBl();
            INV_InvoiceHeaderDto updateDto = ((INV_InvoiceHeaderDto)this.Dto);
            updateDto.Status = CommonData.InvoiceStatus.Printed;
            InvoiceResult result = invoiceBl.UpdateInvoiceData(updateDto);

            #endregion

            //recognized variable to handle result
            this.ReturnCode = result.ReturnCode;

            if (result.ReturnCode == CommonData.DbReturnCode.Succeed)
            {
                return true;
            }
            return false;
        }
    }
}
