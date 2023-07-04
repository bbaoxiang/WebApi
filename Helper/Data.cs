using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Helper
{
    /// <summary>
    /// 汇总类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResultData<T>
    {
        /// <summary>
        /// 1:succeed,0:fail
        /// </summary>
        public int code { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public T data { get; set; }

        /// <summary>
        /// 信息
        /// </summary>
        public string msg { get; set; }

        public override string ToString()
        {
            if (code == 0)
            {
                return $"[error msg]:{msg}";
            }
            else
            {
                return $"[result]:{JsonConvert.SerializeObject(data)}";
            }
        }
    }

    /// <summary>
    /// 分页类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PageResult<T> : ResultData<List<T>>
    {
        /// <summary>
        /// 总数
        /// </summary>
        public int totalNumber { get; set; }

        /// <summary>
        /// 页码
        /// </summary>
        public int pageIndex { get; set; }


        /// <summary>
        /// 每页多少条
        /// </summary>
        public int pageSize { get; set; }
    }



}