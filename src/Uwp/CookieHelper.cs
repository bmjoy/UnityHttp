// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

#if NETFX_CORE
using System.Collections.Generic;
using UnityHttp.Net.Internal;

using InternalCookieException = UnityHttp.Net.Internal.CookieException;

namespace UnityHttp.Net
{
    internal static class CookieHelper 
    {
        internal static IEnumerable<string> GetCookiesFromHeader(string setCookieHeader) 
        {
            List<string> cookieStrings = new List<string>();
            
            try
            {
                CookieParser parser = new CookieParser(setCookieHeader);
                string cookieString;

                while ((cookieString = parser.GetString()) != null)
                {
                    cookieStrings.Add(cookieString);
                }
            }
            catch (InternalCookieException)
            {
                // TODO (#7856): We should log this.  But there isn't much we can do about it other
                // than to drop the rest of the cookies.
            }
            
            return cookieStrings;
        }
    }
}
#endif