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
        /// ip所属城市
        /// </summary>
        public string City { set; get; }
    }

}