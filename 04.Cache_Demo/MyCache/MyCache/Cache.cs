using System;
using System.Collections.Generic;
using System.Text;

namespace MyCache {
    /// <summary>
    /// 模拟缓存。静态存储，不会被 JC 回收
    /// </summary>
    public class Cache {

        /// <summary>
        /// static: 不会被回收。除非程序重启
        /// Dictionary：保存多项数据。读写速率较高
        /// </summary>
        private static Dictionary<string, object> CustomCacheDictionary = new Dictionary<string, object>();

        /// <summary>
        /// 添加 key value 键值对
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void Add(string key, object value) {
            CustomCacheDictionary.Add(key, value);
        }

        /// <summary>
        /// 根据 key 获取 value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T Get<T>(string key) {
            return (T)CustomCacheDictionary[key];
        }

        /// <summary>
        /// 判断 key 是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool Exists(string key) {
            return CustomCacheDictionary.ContainsKey(key);
        }

        /// <summary>
        /// 缓存 Demo 使用逻辑封装
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static T Get<T>(string key, Func<T> func) {
            T t = default(T);
            if (!Cache.Exists(key)) {
                t = func.Invoke();
            } else {
                t = Cache.Get<T>(key);
            }
            return t;
        }
    }
}
