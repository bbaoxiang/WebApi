using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using WebApi.Dto;
using WebApi.Helper;

namespace WebApi.Services
{
    /// <summary>
    /// BaseService
    /// </summary>
    public class BaseService
    {
        private LogHelper logHelper = new LogHelper();

        /// <summary>
        /// 根据日期获取当天信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ResultData<DayInfo> GetDayInfo(DateDto dto)
        {
            ResultData<DayInfo> result = new ResultData<DayInfo>() { code=1,msg="success"};
            result.data = new DayInfo();
            try
            {
                DateTime now = DateTime.Now;
                if (dto.date != null)
                {
                    now = Convert.ToDateTime(dto.date);
                    if (now.Year != 2023)
                    {
                        return new ResultData<DayInfo>() { data = null, code = 0, msg = "只能查询2023年内的信息！" };
                    }
                }

                CultureInfo cultureInfo = CultureInfo.CurrentCulture;
                DayOfWeek dayOfWeek = cultureInfo.Calendar.GetDayOfWeek(now);
                result.data.Week= cultureInfo.DateTimeFormat.GetDayName(dayOfWeek);
                result.data.IsHoliday = IsHoliday(now);
                return result;
            }catch(Exception ex)
            {
                logHelper.Error("GetDayInfo err:" + ex.Message);
                return new ResultData<DayInfo>() { data = null, code = 0, msg = ex.Message };
            }
        }

        /// <summary>
        /// 判断是否是假期
        /// 1：工作日，2：周末，3：法定假日
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public int IsHoliday(DateTime date)
        {
            // 法定假日的列表，根据需要进行修改
            DateTime[] holidays = new DateTime[]
            {
            new DateTime(2023, 1, 1), // 元旦
            new DateTime(2023, 1, 2), // 元旦
            new DateTime(2023, 1, 21), // 春节
            new DateTime(2023, 1, 22), // 春节
            new DateTime(2023, 1, 23), // 春节
            new DateTime(2023, 1, 24), // 春节
            new DateTime(2023, 1, 25), // 春节
            new DateTime(2023, 1, 26), // 春节
            new DateTime(2023, 1, 27), // 春节
            new DateTime(2023, 4, 5), // 清明节
            new DateTime(2023, 4, 29), // 劳动节
            new DateTime(2023, 4, 30), // 劳动节
            new DateTime(2023, 5, 1), // 劳动节
            new DateTime(2023, 5, 2), // 劳动节
            new DateTime(2023, 5, 3), // 劳动节
            new DateTime(2023, 6, 22), // 端午节
            new DateTime(2023, 6, 23), // 端午节
            new DateTime(2023, 6, 24), // 端午节
            new DateTime(2023, 9, 29), // 中秋/国庆节
            new DateTime(2023, 9, 30), // 中秋/国庆节
            new DateTime(2023, 10, 1), // 中秋/国庆节
            new DateTime(2023, 10, 2), // 中秋/国庆节
            new DateTime(2023, 10, 3), // 中秋/国庆节
            new DateTime(2023, 10, 4), // 中秋/国庆节
            new DateTime(2023, 10, 5), // 中秋/国庆节
            new DateTime(2023, 10, 6), // 中秋/国庆节
            };

            // 调休列表，根据需要进行修改
            DateTime[] fuckdays = new DateTime[]
            {
            new DateTime(2023, 1, 28), // 春节调休
            new DateTime(2023, 1, 29), // 春节调休
            new DateTime(2023, 4, 23), // 劳动节调休
            new DateTime(2023, 5, 6), // 劳动节调休
            new DateTime(2023, 6, 25), // 端午节调休
            new DateTime(2023, 10, 7), // 中秋/国庆节
            new DateTime(2023, 10, 8), // 中秋/国庆节
            };

            // 判断日期是否是法定假日
            bool isHoliday = Array.Exists(holidays, d => d.Date == date.Date);
            if (isHoliday)
            {
                return 3;
            }

            bool isfuckday = Array.Exists(fuckdays, d => d.Date == date.Date);
            if (isfuckday)
            {
                return 1;
            }

            // 判断日期是否是普通周末
            bool isWeekend = date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
            if (isfuckday)
            {
                return 2;
            }
            else
            {
                return 1;
            }
        }

        /// <summary>
        /// 获取ip信息
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public ResultData<IPInfo> GetIPInfo(string ip)
        {
            ResultData<IPInfo> result = new ResultData<IPInfo>() { code = 1, msg = "success" };
            result.data = new IPInfo();
            try
            {
                string url = String.Format("http://api.ip138.com/query/?ip={0}&datatype=jsonp", ip);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.Headers.Add("token", "d308053cad4e239eeb29a8f89753bb6f");
                request.AutomaticDecompression = DecompressionMethods.GZip;

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                string content = reader.ReadToEnd();
                IPResult iPResult = JsonConvert.DeserializeObject<IPResult>(content);
                if (iPResult.ret == "ok")
                {
                    // 获取归属地信息
                    result.data.Country = iPResult.data[0];
                    result.data.Province = iPResult.data[1];
                    result.data.City = iPResult.data[2];
                    result.data.Store = iPResult.data[3];
                    result.data.Postcode = iPResult.data[4];
                    result.data.Number = iPResult.data[5];
                    result.data.IP = ip;
                    return result;
                }
                else
                {
                    return new ResultData<IPInfo>() { code = 0, msg = content };
                }
            }
            catch(Exception ex)
            {
                logHelper.Error("GetIPInfo err:" + ex.Message);
                return new ResultData<IPInfo>() { data = null, code = 0, msg = ex.Message };
            }
        }


    }
}