using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebApi.Dto;
using WebApi.Helper;
using WebApi.Services;

namespace WebApi.Controllers
{
    /// <summary>
    /// BaseController
    /// </summary>
    public class BaseController : ApiController
    {
        /// <summary>
        /// 根据日期获取当天信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public ResultData<DayInfo> GetDayInfo(DateDto dto)
        {
            return new BaseService().GetDayInfo(dto);
        }

        /// <summary>
        /// 获取ip信息
        /// </summary>
        /// <returns></returns>
        //[HttpPost]
        //public ResultData<IPInfo> GetIPInfo()
        //{
        //    string ipAddress = HttpContext.Current.Request.UserHostAddress;
        //    return new BaseService().GetIPInfo(ipAddress);
        //}

    }
}