using System;

namespace Exceptions
{
    public sealed class SceneNameNotFoundException : Exception
    {
        private const string ErrorMessage = "Scene name is not correct. Please make sure to use the same scene names as in the enum.";
        
        public SceneNameNotFoundException() : base(ErrorMessage) { }
    }
}