using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

// kendi modelimiz türünde session oluşturmak için yazdığımız helper sınıfı
namespace CookiesNSession
{
    public static class SessionExtension
    {
          // bu methodları kullanırken ilk parametreyi yazmayız
          // çünkü ilk parametre bu methodun hangi class'a ekleneceğini bildirir
        public static void Set<T>(this ISession session,string key, T value){
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T Get<T>(this ISession session,string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonSerializer.Deserialize<T>(value);
        }
    }
}
