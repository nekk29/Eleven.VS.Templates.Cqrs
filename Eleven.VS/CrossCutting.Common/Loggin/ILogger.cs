using System;

namespace $ext_safesolutionname$.CrossCutting.Common.Loggin
{
    public interface ILogger
    {
        void Info(object message);
        void Warn(object message);
        void Error(object message);
        void Error(object message, Exception exception);
        void Error(Exception exception);
    }
}
