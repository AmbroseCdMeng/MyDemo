using System;

namespace MyCache {

    /// <summary>
    /// 缓存
    ///     系统性能优化的第一步：使用缓存
    ///     缓存：获取到数据后，临时保存在一个地方，下次需要使用时，直接获取，避免 重复查询，提升性能
    ///         
    ///     Web访问步骤：浏览器 --> DNS 解析 --> 反向代理 --> 服务器 --> DB --> 返回到浏览器
    ///     每一步都有对应的缓存：
    ///         浏览器：客户端缓存（本地硬盘或浏览器内存）
    ///         DNS：CND 缓存
    ///         反向代理：反向代理缓存
    ///         服务器：服务器本地缓存（内存）| 分布式缓存      
    ///             ☆ 服务器本地缓存：进程内存空间有限，多服务器之间不能共享
    ///             ★ 分布式缓存：多服务器之间可共享
    ///         DB：DB缓存
    ///
    /// </summary>
    class Program {
        static void Main(string[] args) {
            try {
                Console.WriteLine("Hello World!");
                for (int i = 0; i < 5; i++) {
                    Console.WriteLine($"第 {i} 次请求 Start");
                    //调用模拟耗时数据库请求
                    int iResult = 0;
                    string key = "";

                    #region 以下缓存 Demo 调用逻辑封装到 Cache.cs 中
                    /*
                    //如果缓存区中不存在该条数据
                    if (!Cache.Exists(key)) {
                        //调用DB查询
                        iResult = DataSource.QueryByDB(100);
                        //将查询结果写入缓存区
                        Cache.Add(key, iResult);
                        //如果缓存区存在该条数据
                    } else {
                        //直接从缓存区获取结果
                        iResult = Cache.Get<int>(key);
                    }
                    Console.WriteLine($"第 {i} 次请求 End");
                    */
                    /*
                     ★ 如上这种基本的缓存 Demo 有一个限制：
                        数据变化问题，即当 key 的 value 发生改变时，缓存区的 key 对应的 value 还是旧的 value
                        这个问题需要后期优化：
                            一般采用的做法：指定条件下更新缓存区
                    */
                    #endregion

                    iResult = Cache.Get<int>(key, () => DataSource.QueryByDB(100));
                }
            } catch (Exception e) {

                Console.WriteLine(e.Message);
            }
            Console.Read();
        }
    }
}
