﻿using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace GBCSporting2021_ACH.Models
{
    public static class SessionExtensions
    {
        public static void SetObject<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObject<T>(this ISession session, string key)
        {
            var jsonstring = session.GetString(key);
            if (string.IsNullOrEmpty(jsonstring))
            {
                return default(T);
            }
            else
            {
                return JsonConvert.DeserializeObject<T>(jsonstring);
            }
        }
    }
}
