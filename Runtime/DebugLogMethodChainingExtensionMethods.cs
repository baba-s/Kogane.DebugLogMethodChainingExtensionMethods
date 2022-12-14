using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Kogane
{
    public static class DebugLogMethodChainingExtensionMethods
    {
        public delegate void LogDelegate( object item );

        public static LogDelegate OnLog        { get; set; } = item => Debug.Log( item );
        public static LogDelegate OnLogWarning { get; set; } = item => Debug.LogWarning( item );
        public static LogDelegate OnLogError   { get; set; } = item => Debug.LogError( item );

        public static T DebugLog<T>( this T self )
        {
            OnLog?.Invoke( self );
            return self;
        }

        public static T DebugLog<T>
        (
            this      T               self,
            [NotNull] Func<T, object> selector
        )
        {
            if ( selector == null ) throw new ArgumentNullException( nameof( selector ) );

            OnLog?.Invoke( selector( self ) );
            return self;
        }

        public static T DebugLogWarning<T>( this T self )
        {
            OnLogWarning?.Invoke( self );
            return self;
        }

        public static T DebugLogWarning<T>
        (
            this      T               self,
            [NotNull] Func<T, object> selector
        )
        {
            if ( selector == null ) throw new ArgumentNullException( nameof( selector ) );

            OnLogWarning?.Invoke( selector( self ) );
            return self;
        }

        public static T DebugLogError<T>( this T self )
        {
            OnLogError?.Invoke( self );
            return self;
        }

        public static T DebugLogError<T>
        (
            this      T               self,
            [NotNull] Func<T, object> selector
        )
        {
            if ( selector == null ) throw new ArgumentNullException( nameof( selector ) );

            OnLogError?.Invoke( selector( self ) );
            return self;
        }
    }
}