using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using Ivs.Core.Common;
using Ivs.Core.Data;
using Ivs.Core.Interface;
using Ivs.Core.Validation;

namespace Ivs.Controls.Forms
{
    public class Validator
    {
        protected System.Resources.ResourceManager _resourceManager;

        public Validator(System.Resources.ResourceManager resourceManager)
        {
            this._resourceManager = resourceManager;
        }

        public Validator()
        {
        }

        public CommonData.IsValid IsTime(string valStr)
        {
            return new Regex(@"^([0-9]{2,3}):([0-5][0-9]):([0-5][0-9])$").IsMatch(valStr)
                ? CommonData.IsValid.Successful : CommonData.IsValid.Failed;
        }

        public CommonData.IsValid IsNumber(string valStr)
        {
            string pattern = @"[\D]";
            Regex myRegex = new Regex(pattern);
            if (myRegex.IsMatch(valStr))
            {
                return CommonData.IsValid.Failed;
            }
            return CommonData.IsValid.Successful;
        }

        public CommonData.IsValid IsNumberWithSymbol(string valStr)
        {
            string pattern = @"[\D]";
            Regex myRegex = new Regex(pattern);
            if (myRegex.IsMatch(valStr))
            {
                return CommonData.IsValid.Failed;
            }
            return CommonData.IsValid.Successful;
        }

        public CommonData.IsValid IsDate(string valStr, string formater)
        {
            DateTime parsed;

            bool valid = DateTime.TryParseExact(valStr, formater,
                                                System.Globalization.CultureInfo.InvariantCulture,
                                                DateTimeStyles.None,
                                                out parsed);
            if (valid == true)
            {
                return CommonData.IsValid.Successful;
            }
            else
            {
                return CommonData.IsValid.Failed;
            }
        }

        public CommonData.IsValid IsMail(string valStr)
        {
            string pattern = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex myRegex = new Regex(pattern);
            if (!myRegex.IsMatch(valStr))
            {
                return CommonData.IsValid.Failed;
            }
            return CommonData.IsValid.Successful;
        }

        public CommonData.IsValid IsNotEmpty(string valStr)
        {
            if (string.IsNullOrEmpty(valStr))
            {
                return CommonData.IsValid.Failed;
            }

            return CommonData.IsValid.Successful;
        }

        public CommonData.IsValid IsZero(string valStr)
        {
            try
            {
                if (Int64.Parse(valStr) == 0 && valStr.Length < 18)
                {
                    return CommonData.IsValid.Failed;
                }
            }
            catch (OverflowException)
            {
                return CommonData.IsValid.Failed;
            }
            catch (Exception)
            {
                return CommonData.IsValid.Failed;
            }
            return CommonData.IsValid.Successful;
        }

        public CommonData.IsValid IsYear(string valStr)
        {
            return CommonData.IsValid.Successful;
        }

        public CommonData.IsValid IsValidLength(int length)
        {
            if (length <= 1000)
                return CommonData.IsValid.Successful;
            else
                return CommonData.IsValid.Failed;
        }

        public CommonData.IsValid IsEqual(string valStr1, string valStr2)
        {
            if (valStr1 == valStr2)
            {
                return CommonData.IsValid.Successful;
            }
            return CommonData.IsValid.Failed;
        }

        public CommonData.IsValid IsLess(string valStr1, string valStr2)
        {
            return CommonData.IsValid.Successful;
        }

        public CommonData.IsValid IsGreater(string valStr1, string valStr2)
        {
            return CommonData.IsValid.Successful;
        }

        public CommonData.IsValid IsLessEqual(string valStr1, string valStr2)
        {
            return CommonData.IsValid.Successful;
        }

        public CommonData.IsValid IsGreater(decimal valLong1, decimal valLong2)
        {
            return (valLong1 > valLong2) ? CommonData.IsValid.Successful : CommonData.IsValid.Failed;
        }

        public CommonData.IsValid IsLessEqual(long valLong1, long valLong2)
        {
            return (valLong1 <= valLong2) ? CommonData.IsValid.Successful : CommonData.IsValid.Failed;
        }

        public CommonData.IsValid IsGreaterEqual(string valStr1, string valStr2)
        {
            return CommonData.IsValid.Successful;
        }

        public CommonData.IsValid IsFromTo(DateTime valDt1, DateTime valDt2)
        {
            return CommonData.IsValid.Successful;
        }

        public virtual List<ValidationResult> Validate(IDto dto)
        {
            return new List<ValidationResult>();
        }

        public virtual List<ValidationResult> Validate(IDto valueDto, IDto controlDto)
        {
            return new List<ValidationResult>();
        }

        public List<ValidationResult> ProcessDeActiveCheckResult(int returnCode, List<CommonData.DeActiveResult> checkResults)
        {
            List<ValidationResult> validationResults = new List<ValidationResult>();
            ValidationResult result;
            if (returnCode == CommonData.DbReturnCode.Succeed)
            {
                #region in case DB accesss OK

                foreach (CommonData.DeActiveResult checkResult in checkResults)
                {
                    result = null;
                    switch (checkResult)
                    {
                        case CommonData.DeActiveResult.MsDepartments:
                            result = new ValidationResult("MsDepartments",
                                                                          CommonData.IsValid.Failed,
                                                                          new IvsMessage("CMN028"));
                            break;

                        case CommonData.DeActiveResult.MsFingerMachines:
                            result = new ValidationResult("MsFingerMachines",
                                                                          CommonData.IsValid.Failed,
                                                                          new IvsMessage("CMN029"));
                            break;

                        case CommonData.DeActiveResult.MsGroupsAssign:
                            result = new ValidationResult("MsGroupsAssign",
                                                                          CommonData.IsValid.Failed,
                                                                          new IvsMessage("CMN030"));
                            break;

                        case CommonData.DeActiveResult.MsOperations:
                            result = new ValidationResult("MsOperations",
                                                                          CommonData.IsValid.Failed,
                                                                          new IvsMessage("CMN031"));
                            break;

                        case CommonData.DeActiveResult.MsPermissionsAssign:
                            result = new ValidationResult("MsPermissionsAssign",
                                                                          CommonData.IsValid.Failed,
                                                                          new IvsMessage("CMN032"));
                            break;

                        case CommonData.DeActiveResult.MsPositions:
                            result = new ValidationResult("MsPositions",
                                                                          CommonData.IsValid.Failed,
                                                                          new IvsMessage("CMN033"));
                            break;

                        case CommonData.DeActiveResult.MsProjects:
                            result = new ValidationResult("MsProjects",
                                                                          CommonData.IsValid.Failed,
                                                                          new IvsMessage("CMN034"));
                            break;

                        case CommonData.DeActiveResult.MsRotateScheduledSetting:
                            result = new ValidationResult("MsRotateScheduledSetting",
                                                                          CommonData.IsValid.Failed,
                                                                          new IvsMessage("CMN035"));
                            break;

                        case CommonData.DeActiveResult.MsRoutes:
                            result = new ValidationResult("MsRoutes",
                                                                          CommonData.IsValid.Failed,
                                                                          new IvsMessage("CMN036"));
                            break;

                        case CommonData.DeActiveResult.MsSections:
                            result = new ValidationResult("MsSections",
                                                                          CommonData.IsValid.Failed,
                                                                          new IvsMessage("CMN037"));
                            break;

                        case CommonData.DeActiveResult.MsShifts:
                            result = new ValidationResult("MsShifts",
                                                                          CommonData.IsValid.Failed,
                                                                          new IvsMessage("CMN038"));
                            break;

                        case CommonData.DeActiveResult.MsTeams:
                            result = new ValidationResult("MsTeams",
                                                                          CommonData.IsValid.Failed,
                                                                          new IvsMessage("CMN039"));
                            break;

                        case CommonData.DeActiveResult.AtAttendanceErrors:
                            result = new ValidationResult("AtAttendanceErrors",
                                                                          CommonData.IsValid.Failed,
                                                                          new IvsMessage("CMN040"));
                            break;

                        case CommonData.DeActiveResult.AtInOut:
                            result = new ValidationResult("AtInOut",
                                                                          CommonData.IsValid.Failed,
                                                                          new IvsMessage("CMN041"));
                            break;

                        case CommonData.DeActiveResult.AtLeavePlanning:
                            result = new ValidationResult("AtLeavePlanning",
                                                                          CommonData.IsValid.Failed,
                                                                          new IvsMessage("CMN042"));
                            break;

                        case CommonData.DeActiveResult.AtTimeSheetHistories:
                            result = new ValidationResult("AtTimeSheetHistories",
                                                                          CommonData.IsValid.Failed,
                                                                          new IvsMessage("CMN043"));
                            break;

                        case CommonData.DeActiveResult.AtWorkingScheduling:
                            result = new ValidationResult("AtWorkingScheduling",
                                                                          CommonData.IsValid.Failed,
                                                                          new IvsMessage("CMN044"));
                            break;

                        case CommonData.DeActiveResult.HrEmpAllowances:
                            result = new ValidationResult("HrEmpAllowances",
                                                                          CommonData.IsValid.Failed,
                                                                          new IvsMessage("CMN045"));
                            break;

                        case CommonData.DeActiveResult.HrEmployees:
                            result = new ValidationResult("HrEmployees",
                                                                          CommonData.IsValid.Failed,
                                                                          new IvsMessage("CMN046"));
                            break;

                        case CommonData.DeActiveResult.HrManagerAssignment:
                            result = new ValidationResult("HrManagerAssignment",
                                                                          CommonData.IsValid.Failed,
                                                                          new IvsMessage("CMN047"));
                            break;

                        case CommonData.DeActiveResult.HrRotateAssignment:
                            result = new ValidationResult("HrRotateAssignment",
                                                                          CommonData.IsValid.Failed,
                                                                          new IvsMessage("CMN048"));
                            break;

                        case CommonData.DeActiveResult.HrTraining:
                            result = new ValidationResult("HrTraining",
                                                                          CommonData.IsValid.Failed,
                                                                          new IvsMessage("CMN049"));
                            break;

                        case CommonData.DeActiveResult.MsFormOfWages:
                            result = new ValidationResult("MsFormOfWages",
                                                                          CommonData.IsValid.Failed,
                                                                          new IvsMessage("CMN050"));
                            break;

                        case CommonData.DeActiveResult.PrAllowances:
                            result = new ValidationResult("PrAllowances",
                                                                          CommonData.IsValid.Failed,
                                                                          new IvsMessage("CMN069"));
                            break;
                    }
                    validationResults.Add(result);
                }

                #endregion in case DB accesss OK
            }
            else
            {
                result = null;
                switch (returnCode)
                {
                    case CommonData.DbReturnCode.AccessDenied:
                        result = new ValidationResult("", CommonData.IsValid.Failed,
                                                        new IvsMessage("CMN017"));
                        break;

                    case CommonData.DbReturnCode.InvalidHost:
                        result = new ValidationResult("", CommonData.IsValid.Failed,
                                                        new IvsMessage("CMN018"));
                        break;

                    case CommonData.DbReturnCode.InvalidDatabase:
                        result = new ValidationResult("", CommonData.IsValid.Failed,
                                                        new IvsMessage("CMN019"));
                        break;

                    case CommonData.DbReturnCode.LostConnection:
                        result = new ValidationResult("", CommonData.IsValid.Failed,
                                                        new IvsMessage("CMN020"));
                        break;

                    case CommonData.DbReturnCode.DuplicateKey:
                        result = new ValidationResult("", CommonData.IsValid.Failed,
                                                        new IvsMessage("CMN014"));
                        break;

                    case CommonData.DbReturnCode.ForgeignKeyNotExist:
                        result = new ValidationResult("", CommonData.IsValid.Failed,
                                                        new IvsMessage("CMN022"));
                        break;

                    case CommonData.DbReturnCode.ForeignKeyViolation:
                        result = new ValidationResult("", CommonData.IsValid.Failed,
                                                        new IvsMessage("CMN023"));
                        break;

                    case CommonData.DbReturnCode.DataNotFound:
                        result = new ValidationResult("", CommonData.IsValid.Failed,
                                                        new IvsMessage("CMN024"));
                        break;

                    case CommonData.DbReturnCode.ExceptionOccured:
                        result = new ValidationResult("", CommonData.IsValid.Failed,
                                                        new IvsMessage("CMN025"));
                        break;
                }
                validationResults.Add(result);
            }

            return validationResults;
        }

        public ValidationResult ProcessDbCheckResult(int returnCode)
        {
            ValidationResult result = null;

            switch (returnCode)
            {
                case CommonData.DbReturnCode.AccessDenied:
                    result = new ValidationResult("", CommonData.IsValid.Failed,
                                                    new IvsMessage("CMN017"));
                    break;

                case CommonData.DbReturnCode.InvalidHost:
                    result = new ValidationResult("", CommonData.IsValid.Failed,
                                                    new IvsMessage("CMN018"));
                    break;

                case CommonData.DbReturnCode.InvalidDatabase:
                    result = new ValidationResult("", CommonData.IsValid.Failed,
                                                    new IvsMessage("CMN019"));
                    break;

                case CommonData.DbReturnCode.LostConnection:
                    result = new ValidationResult("", CommonData.IsValid.Failed,
                                                    new IvsMessage("CMN020"));
                    break;

                case CommonData.DbReturnCode.DuplicateKey:
                    result = new ValidationResult("", CommonData.IsValid.Failed,
                                                    new IvsMessage("CMN014"));
                    break;

                case CommonData.DbReturnCode.ForgeignKeyNotExist:
                    result = new ValidationResult("", CommonData.IsValid.Failed,
                                                    new IvsMessage("CMN022"));
                    break;

                case CommonData.DbReturnCode.ForeignKeyViolation:
                    result = new ValidationResult("", CommonData.IsValid.Failed,
                                                    new IvsMessage("CMN023"));
                    break;

                case CommonData.DbReturnCode.DataNotFound:
                    result = new ValidationResult("", CommonData.IsValid.Failed,
                                                    new IvsMessage("CMN024"));
                    break;

                case CommonData.DbReturnCode.ExceptionOccured:
                    result = new ValidationResult("", CommonData.IsValid.Failed,
                                                    new IvsMessage("CMN025"));
                    break;
            }

            return result;
        }
    }
}