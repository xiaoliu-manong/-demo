using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Common
{
    public class CookiesHelper
    {
        #region 获取Cookie
        /// <summary>
        /// 获取cookie的值
        /// </summary>
        /// <param name="cookieName"></param>
        /// <returns></returns>
        public static string GetCookieValue(string cookieName)
        {
            return GetCookieValue(cookieName, null);
        }
        /// <summary>
        /// 获取cookie的值
        /// </summary>
        /// <param name="cookieName"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetCookieValue(string cookieName, string key)
        {
            HttpRequest request = HttpContext.Current.Request;
            if (request != null)
            {
                return GetCookieValue(request.Cookies[cookieName], key);
            }
            return "";
        }
        /// <summary>
        /// 获取cookie的子健值
        /// </summary>
        /// <param name="cookie"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetCookieValue(HttpCookie cookie, string key)
        {
            if (cookie != null)
            {
                if (!string.IsNullOrEmpty(key) && cookie.HasKeys)
                    return cookie.Values[key];
                else
                    return cookie.Value;
            }
            return "";
        }
        /// <summary>
        /// 获取Cookie
        /// </summary>
        /// <param name="cookieName"></param>
        /// <returns></returns>
        public static HttpCookie GetCookies(string cookieName)
        {
            HttpRequest request = HttpContext.Current.Request;
            if (request != null)
            {
                return request.Cookies[cookieName];
            }
            return null;
        }
        #endregion

        #region 删除Cookie
        /// <summary>
        /// 删除cookie
        /// </summary>
        /// <param name="cookieName"></param>
        public static void RemoveCookie(string cookieName)
        {
            RemoveCookie(cookieName, null);
        }
        /// <summary>
        /// 删除cookies中的子健
        /// </summary>
        /// <param name="cookieName"></param>
        /// <param name="key"></param>
        public static void RemoveCookie(string cookieName, string key)
        {
            HttpResponse response = HttpContext.Current.Response;
            if (response != null)
            {
                HttpCookie cookie = response.Cookies[cookieName];
                if (cookie != null)
                {
                    if (!string.IsNullOrEmpty(key) && cookie.HasKeys)
                        cookie.Values.Remove(key);
                    else
                    {
                        cookie.Expires = DateTime.Now.AddDays(-1);
                        response.Cookies.Add(cookie);
                    }
                }
            }
        }
        #endregion

        #region 设置/修改Cookie
        /// <summary>
        /// 设置cookie子健的值
        /// </summary>
        /// <param name="cookieName"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void SetCookie(string cookieName, string key, string value)
        {
            SetCookie(cookieName, key, value, null);
        }
        /// <summary>
        /// 设置cookie值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void SetCookie(string key, string value)
        {
            SetCookie(key, null, value, null);
        }
        /// <summary>
        /// 设置cookie值或过期时间
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expires"></param>
        public static void SetCookie(string key, string value, DateTime expires)
        {
            SetCookie(key, null, value, expires);
        }
        /// <summary>
        /// 设置cookie的过期时间
        /// </summary>
        /// <param name="cookieName"></param>
        /// <param name="expires"></param>
        public static void SetCookie(string cookieName, DateTime expires)
        {
            SetCookie(cookieName, null, null, expires);
        }
        /// <summary>
        /// 设置cookie
        /// </summary>
        /// <param name="cookieName"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expires"></param>
        private static void SetCookie(string cookieName, string key, string value, DateTime? expires)
        {
            HttpResponse response = HttpContext.Current.Response;
            if (response != null)
            {
                HttpCookie cookie = response.Cookies[cookieName];
                if (cookie != null)
                {
                    if (!string.IsNullOrEmpty(key) && cookie.HasKeys)
                        cookie.Values.Set(key, value);
                    else
                        if (!string.IsNullOrEmpty(value))
                        cookie.Value = value;
                    if (expires != null)
                        cookie.Expires = expires.Value;
                    response.SetCookie(cookie);
                }

            }
        }
        #endregion

        #region 添加Cookie

        public static void AddCookie(string key, string value)
        {
            AddCookie(new HttpCookie(key, value));
        }

        public static void AddCookie(string key, string value, DateTime expires)
        {
            HttpCookie cookie = new HttpCookie(key, value);
            cookie.Expires = expires;
            AddCookie(cookie);
        }

        public static void AddCookie(string cookieName, string key, string value)
        {
            HttpCookie cookie = new HttpCookie(cookieName);
            cookie.Values.Add(key, value);
            AddCookie(cookie);
        }

        public static void AddCookie(string cookieName, DateTime expires)
        {
            HttpCookie cookie = new HttpCookie(cookieName);
            cookie.Expires = expires;
            AddCookie(cookie);
        }

        public static void AddCookie(string cookieName, string key, string value, DateTime expires)
        {
            HttpCookie cookie = new HttpCookie(cookieName);
            cookie.Values.Add(key, value);
            cookie.Expires = expires;
            AddCookie(cookie);
        }

        private static void AddCookie(HttpCookie cookie)
        {
            HttpResponse response = HttpContext.Current.Response;
            if (response != null)
            {
                //指定客户端脚本是否可以访问（默认为false）
                cookie.HttpOnly = true;
                //指定统一的Path，一遍能通存通取
                cookie.Path = "/";
                //cookie.Domain = "chinesecoo.com";
                response.AppendCookie(cookie);
            }
        }
        #endregion
    }
}
