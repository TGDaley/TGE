using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiltedGlobe.Common.Models.ThirdParty.TINCheck
{
    public class NameResponse
    {
        public sbyte TINNameCode { get; set; }
        public string TINNameDetails { get; set; }
        public sbyte DMFCode { get; set; }
        public string DMFDetails { get; set; }
        public string DMFData { get; set; }

        public enum TINNameCodeEnum
        {
            ValidationNotProcessed = -1,
            CombinationDoesNotMatchIRSRecords = 0,
            CombinationMatchesIRSRecords = 1,
            TINNotIssued = 5,
            CombinationMatchesSSNRecords = 6,
            CombinationMatchesEINRecords = 7,
            CombinationMatchesSSNandEINRecords = 8,
            LoginDeniedInvalidLoginOrPassword = 10,
            InvalidData = 11,
            InvalidConfiguration = 12,
            InvalidTinMatchingRequest = 13,
            DuplicateRequest = 14,
            ConnectionProblem = 15,
            IRSConnectionProblem = 16,
            IRSValidationTemporarilyUnavailable = 17,
            NoMoreChecks = 18,
            ProcessingError = 20,
            IRSProcessingError = 21,
            InvalidIRSLogin = 22,
            LoginDeniedInvalidUser = 23,
            LoginDeniedInvalidPassword = 24,
            LoginDeniedAccountLocked = 25,
            LoginDeniedAccountLocked24Hrs = 26,
            LoginDeniedTermsNotAccepted = 27,
            LoginDeniedAccountExpired = 28,
            LoginDeniedNoSecurityRights = 29
        }

        public enum DMFCodeEnum
        {
            DMFNotProcessed = -1,
            NoDMFRecordFound = 0,
            PossibleDMFMatchFound = 1,
            LoginDeniedInvalidLoginOrPassword = 10,
            InvalidData = 11,
            InvalidConfiguration = 12,
            InvalidDMFRequest = 13,
            ConnectionProblem = 15,
            DMFConnectionProblem = 16,
            DMFMatchTemporarilyUnavailable = 17,
            NoMoreChecks = 18,
            ProcessingError = 20,
            DMFProcessingError = 21,
            LoginDeniedInvalidUser = 23,
            LoginDeniedInvalidPassword = 24,
            LoginDeniedAccountLocked = 25,
            LoginDeniedAccountLocked24Hrs = 26,
            LoginDeniedTermsNotAccepted = 27,
            LoginDeniedAccountExpired = 28,
            LoginDeniedNoSecurityRights = 29
        }
    }
}
