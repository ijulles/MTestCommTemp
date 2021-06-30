//以下三个特性是 .NET Framework 4.5新加入的，.NET Framework 4.0 通过以下方式定义也可以使用。

namespace System.Runtime.CompilerServices
{
    [AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
    public class CallerMemberNameAttribute : Attribute
    {

    }

    [AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
    public class CallerFilePathAttribute : Attribute
    {

    }

    [AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
    public class CallerLineNumberAttribute : Attribute
    {

    }
}