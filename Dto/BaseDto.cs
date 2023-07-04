using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Dto
{
    /// <summary>
    /// 当天信息
    /// </summary>
    public class DayInfo
    {
        /// <summary>
        /// 周几
        /// </summary>
        public string Week { set; get; }

        /// <summary>
        /// 是否放假，1：工作日，2：周末，3：法定假日
        /// </summary>
        public int IsHoliday { set; get; }
    }

    /// <summary>
    /// 日期基础类
    /// </summary>
    public class DateDto
    {
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime? date { set; get; }
    }

    /// <summary>
    /// ip信息
    /// </summary>
    public class IPInfo
    {
        /// <summary>
        /// ip地址
        /// </summary>
        public string IP { set; get; }

        /// <summary>
        /// ip所属国家
        /// </summary>
        public string Country { set; get; }

        /// <summary>
        /// ip所属省份
        /// </summary>
        public string Province { set; get; }

        /// <summary>
        /// ip所属城市
        /// </summary>
        public string City { set; get; }

        /// <summary>
        /// ip所属区县
        /// </summary>
       // public string Area { set; get; }

        /// <summary>
        /// ip所属运营商
        /// </summary>
        public string Store { set; get; }

        /// <summary>
        /// ip所属邮编
        /// </summary>
        public string Postcode { set; get; }

        /// <summary>
        /// ip所属地区区号
        /// </summary>
        public string Number { set; get; }
    }

    public class IPResult
    {
        public string ret { set; get; }
        public string ip { set; get; }
        public string[] data { set; get; }
    }

}