using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace Trivia_csharp.Completed
{
    public static class NotifyHelper
    {
        public static bool SetField<T,F>(this T target,ref F field, F value, Action<T> callback)
        {
            field = value;
            callback?.Invoke(target);
            return true;
        }
    }
}
