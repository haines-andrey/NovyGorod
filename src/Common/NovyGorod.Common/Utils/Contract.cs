namespace NovyGorod.Common.Utils;

public static class Contract
{
    public static void IsNull<TException>(object obj, params object[] exceptionArgs)
        where TException : Exception
    {
        if (obj is null)
        {
            return;
        }

        ThrowException<TException>(exceptionArgs);
    }

    public static void IsNull<TException>(object obj, Func<object[]> exceptionArgsBuilder)
        where TException : Exception
    {
        if (obj is null)
        {
            return;
        }

        ThrowException<TException>(exceptionArgsBuilder());
    }
    
    public static void IsNotNull<TException>(object obj, params object[] exceptionArgs)
        where TException : Exception
    {
        if (obj is not null)
        {
            return;
        }

        ThrowException<TException>(exceptionArgs);
    }

    public static void IsNotNull<TException>(object obj, Func<object[]> exceptionArgsBuilder)
        where TException : Exception
    {
        if (obj is not null)
        {
            return;
        }

        ThrowException<TException>(exceptionArgsBuilder());
    }

    public static void IsTrue<TException>(bool condition, params object[] exceptionArgs)
        where TException : Exception
    {
        if (condition)
        {
            return;
        }
        
        ThrowException<TException>(exceptionArgs);
    }
    
    public static void IsTrue<TException>(bool condition, Func<object[]> exceptionArgsBuilder)
        where TException : Exception
    {
        if (condition)
        {
            return;
        }
        
        ThrowException<TException>(exceptionArgsBuilder());
    }
    
    public static void IsFalse<TException>(bool condition, params object[] exceptionArgs)
        where TException : Exception
    {
        if (!condition)
        {
            return;
        }
        
        ThrowException<TException>(exceptionArgs);
    }
    
    public static void IsFalse<TException>(bool condition, Func<object[]> exceptionArgsBuilder)
        where TException : Exception
    {
        if (!condition)
        {
            return;
        }
        
        ThrowException<TException>(exceptionArgsBuilder());
    }

    private static void ThrowException<TException>(object[] exceptionArgs)
        where TException : Exception
    {
        var exception = (Exception)Activator.CreateInstance(typeof(TException), exceptionArgs);
        
        throw exception;
    }
}