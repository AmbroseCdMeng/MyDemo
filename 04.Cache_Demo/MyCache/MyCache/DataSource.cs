using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MyCache {
    public class DataSource {
        /// <summary>
        /// 模拟数据库耗时请求
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static int QueryByDB(int t) {
            Console.WriteLine($"{nameof(QueryByDB)}");
            int iResult = 0;
            //模拟消耗 CPU 资源
            for (int i = t + 3; i < 1000000; i++) {
                iResult += i;
            }
            // 模拟消耗时间
            Thread.Sleep(2000);
            return iResult;
        }

        /// <summary>
        /// 模拟接口耗时请求
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static int QueryByRemote(int t) {
            Console.WriteLine($"{nameof(QueryByRemote)}");
            int iResult = 0;
            //模拟消耗 CPU 资源
            for (int i = t + 2; i < 1000000; i++) {
                iResult += i;
            }
            // 模拟消耗时间
            Thread.Sleep(2000);
            return iResult;
        }

        /// <summary>
        /// 模拟硬盘耗时请求
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static int QueryByDisk(int t) {
            Console.WriteLine($"{nameof(QueryByDisk)}");
            int iResult = 0;
            //模拟消耗 CPU 资源
            for (int i = t + 1; i < 1000000; i++) {
                iResult += i;
            }
            // 模拟消耗时间
            Thread.Sleep(2000);
            return iResult;
        }
    }
}
