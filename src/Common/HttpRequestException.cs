// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace UnityHttp.Net.Http
{
    public class HttpRequestException : Exception
    {
        public HttpRequestException()
            : this(null, null)
        { }

        public HttpRequestException(string message)
            : this(message, null)
        { }

        public HttpRequestException(string message, Exception inner)
            : base(message, inner)
        {
            if (inner != null)
            {
                HResult = inner.HResult;
            }
        }
    }
}
