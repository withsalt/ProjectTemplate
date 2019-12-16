using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WithsaltWebApiDemo.Logger;

namespace WithsaltWebApiDemo.Controllers.v2
{
    /// <summary>
    /// 用户信息管理
    /// </summary>
    [ApiVersion("2")]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// 获取全部用户信息
        /// Get v1/user
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<UserInfo> Get()
        {
            Log.Info("You are get a user info from v2 api.");

            return new List<UserInfo>
            {
                new UserInfo()
                {
                    Id ="1",
                    Name = "Withsalt",
                    Sex = "女",
                    Describe = "这是V2版本的API返回的用户信息列表"
                }
            };
        }

        // 
        /// <summary>
        /// 更具ID获取用户信息
        /// exp: GET: api/User/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "Get")]
        public UserInfo Get(string id)
        {
            if (id == "1")
            {
                return new UserInfo()
                {
                    Id = "1",
                    Name = "Withsalt",
                    Sex = "女",
                    Describe = "这是V1版本的API返回的用户信息列表"
                };
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 修改用户信息
        /// exp: POST: api/User
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        public IActionResult Post([FromBody] UserInfo value)
        {
            return new JsonResult(new UserInfo()
            {
                Id = value.Id,
                Name = value.Name,
                Sex = value.Sex,
                Describe = "这是V2版本的API修改后的用户信息"
            });
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
