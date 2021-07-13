using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgsImplementation
{
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


    }
}
