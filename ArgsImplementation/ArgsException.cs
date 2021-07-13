using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgsImplementation
{
   
    public class ArgsException: Exception
    {
        private char errorArgumentId = '\0';
        private string errorParameter = null;
        private ErrorCode errorCode = ErrorCode.OK;
         
        public ArgsException()
        {

        }

        public ArgsException(string message)
        {
            
        }

        public ArgsException(ErrorCode errorCode)
        {
            this.errorCode = errorCode;
        }

        public ArgsException(ErrorCode errorCode, string errorParameter) 
        {
            this.errorCode = errorCode;
            this.errorParameter = errorParameter;
        }
        public ArgsException(ErrorCode errorCode, char errorArgumentId, string errorParameter)
        {
            this.errorCode = errorCode;
            this.errorParameter = errorParameter;
            this.errorArgumentId = errorArgumentId;
        }

        public char GetErrorArgumentId()
        {
            return errorArgumentId;
        }

        public void SetErrorArgumentId(char errorArgumentId)
        {
            this.errorArgumentId = errorArgumentId;
        }

        public string GetErrorParameter()
        {
            return errorParameter;
        }

        private void SetErrorParameter(string errorParameter)
        {
            this.errorParameter = errorParameter;
        }

        public ErrorCode GetErrorCode()
        {
            return errorCode;
        }

        public void SetErrorCode(ErrorCode errorCode)
        {
            this.errorCode = errorCode;
        }

        public string ErrorMessage()
        {
            switch (errorCode)
            {
                case ErrorCode.OK:
                    throw new Exception("TILT: Should not get here.");
                case ErrorCode.UNEXPECTED_ARGUMENT:
                    return $"Argument -{errorArgumentId} unexpected.";
                case ErrorCode.MISSING_STRING:
                    return $"Could not find string parameter for -{errorArgumentId}.";
                case ErrorCode.INVALID_INTEGER:
                    return $"Argument -{errorArgumentId} expects an integer but was '{errorParameter}'.";
                case ErrorCode.MISSING_INTEGER:
                    return $"Could not find integer parameter for -{errorArgumentId}.";
                case ErrorCode.INVALID_DOUBLE:
                    return $"Argument -{errorArgumentId} expects a double but was '{errorParameter}'.";
                case ErrorCode.MISSING_DOUBLE:
                    return $"Could not find double parameter for -{errorArgumentId}.";
            }
            return "";
        }
        public enum ErrorCode
        {
            OK,
            INVALID_ARGUMENT_FORMAT,
            UNEXPECTED_ARGUMENT,
            INVALID_ARGUMENT_NAME,
            MISSING_STRING,
            MISSING_INTEGER,
            INVALID_INTEGER,
            MISSING_DOUBLE,
            INVALID_DOUBLE
        }

    }
}
