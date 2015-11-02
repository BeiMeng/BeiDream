using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeiDream.Demo.Domain.Queries;
using BeiDream.Demo.Service.Contracts;
using BeiDream.Demo.Service.Dtos;
using BeiDream.Demo.Service.Impl;
using BeiDream.Demo.Web.Areas.Systems.Models.User;
using BeiDream.Utils.PagerHelper;

namespace BeiDream.Demo.Web.Areas.Systems.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: Systems/User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Save(VmUserAddorEdit vm)
        {
            _userService.AddorUpdate(VmToDto(vm));
            return Json(new { Code = 1, Message = "保存成功！" });
        }

        private UserDto VmToDto(VmUserAddorEdit vm)
        {
            return new UserDto()
            {
                Id=vm.Id,
                Name=vm.Name,
                Password=vm.Password,
                DisplayName=vm.DisplayName,
                Email=vm.Email,
                Enabled=vm.Enabled,
                Version=vm.Version
            };
        }

        public PartialViewResult Edit(Guid id)
        {
            var dto = _userService.Find(id);
            return PartialView("Parts/Form", ToFormVm(dto));
        }
        private VmUserAddorEdit ToFormVm(UserDto dto)
        {
            return new VmUserAddorEdit(dto.Id)
            {
                Id = dto.Id,
                Name = dto.Name,
                Password=dto.Password,
                Email = dto.Email,
                DisplayName = dto.DisplayName,
                Enabled = dto.Enabled,
                Version=dto.Version
            };
        }
        public PartialViewResult Add()
        {
            Guid addId = Guid.NewGuid();
            return PartialView("Parts/Form", new VmUserAddorEdit(addId));
        }
        [HttpPost]
        public ActionResult Delete(string ids)
        {
            _userService.Delete(new Guid(ids));
            return Json(new { Code = 1, Message = "删除成功！" });
        }
        [HttpPost]
        public ActionResult Query(UserQuery query)
        {
            SetPage(query);
            var result = _userService.Query(query).Convert(ToVm);
            return Json(new { total = result.TotalCount, rows = result });
        }

        private VmUserGrid ToVm(UserDto dto)
        {
            return new VmUserGrid
            {
                Id = dto.Id,
                Name = dto.Name,
                Email = dto.Email,
                DisplayName = dto.DisplayName,
                Enabled = dto.Enabled,
                DateCreated = dto.DateCreated
            };
        }

        /// <summary>
        /// 设置分页
        /// </summary>
        /// <param name="query">查询实体</param>
        protected void SetPage(IPager query)
        {
            query.Page = GetPageIndex();
            query.PageSize = GetPageSize();
            query.Order = GetOrder();
        }
        /// <summary>
        /// 获取分页的页索引
        /// </summary>
        protected int GetPageIndex()
        {
            var page = Convert.ToInt32(Request["page"]);
            return page > 0 ? page : 1;
        }

        /// <summary>
        /// 获取分页大小
        /// </summary>
        protected int GetPageSize()
        {
            var pageSize =Convert.ToInt32( Request["rows"]);
            return pageSize > 0 ? pageSize : 20;
        }

        /// <summary>
        /// 获取排序
        /// </summary>
        protected string GetOrder()
        {
            return string.Format("{0} {1}", Convert.ToString(Request["sort"]), Convert.ToString(Request["order"]));
        }

        public PartialViewResult EditRoles(Guid id)
        {
            return PartialView("Parts/UserRoles", id);
        }
        public ActionResult SetRoles(Guid userId,string ids)
        {
            _userService.SetRoles(userId, ToList<Guid>(ids));
            return Json(new { Code = 1, Message = "保存成功！" });
        }
        #region 通用转换

        /// <summary>
        /// 转换为目标元素
        /// </summary>
        /// <typeparam name="T">目标类型</typeparam>
        /// <param name="data">数据</param>
        public static T To<T>(object data)
        {
            if (data == null)
                return default(T);
            if (data is string && string.IsNullOrWhiteSpace(data.ToString()))
                return default(T);
            Type type = GetType<T>();
            try
            {
                if (type.Name.ToLower() == "guid")
                    return (T)(object)new Guid(data.ToString());
                if (data is IConvertible)
                    return (T)Convert.ChangeType(data, type);
                return (T)data;
            }
            catch
            {
                return default(T);
            }
        }

        /// <summary>
        /// 转换为目标元素集合
        /// </summary>
        /// <typeparam name="T">目标元素类型</typeparam>
        /// <param name="list">元素集合字符串，范例:83B0233C-A24F-49FD-8083-1337209EBC9A,EAB523C6-2FE7-47BE-89D5-C6D440C3033A</param>
        public static List<T> ToList<T>(string list)
        {
            var result = new List<T>();
            if (string.IsNullOrWhiteSpace(list))
                return result;
            var array = list.Split(',');
            result.AddRange(from each in array where !string.IsNullOrWhiteSpace(each) select To<T>(each));
            return result;
        }
        #region GetType(获取类型)

        /// <summary>
        /// 获取类型,对可空类型进行处理
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        public static Type GetType<T>()
        {
            return Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T);
        }

        #endregion
        #endregion
    }
}