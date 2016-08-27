using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets._Project.Scripts
{
    public class ComponentDependencyMissingException<T> : Exception
    {
        public ComponentDependencyMissingException(UnityEngine.Object obj)
            :base("'" + obj.name + "' is missing required dependency '" + typeof(T).Name + "'")
        {
        }
    }

    public static class ComponentDependencyMissingExceptionExtensions
    {
        public static void Ensure<T>(this UnityEngine.Object instance, T value)
        {
            if (value == null)
                throw new ComponentDependencyMissingException<T>(instance);
        }
    }

}
