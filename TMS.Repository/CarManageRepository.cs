﻿using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TMS.Common.DB;
using TMS.IRepository;
using TMS.Model.Entity.BaseInfo;
using TMS.Common.DB;

namespace TMS.Repository
{
    public class CarManageRepository:ICarManageRepository
    {
        /// <summary>
        /// 车辆管理显示
        /// </summary>
        /// <returns></returns>
        public List<CarManage> CarShow()
        {
            string sql = $"select * from CarManage";
            return MySqlDapper.DapperQuery<CarManage>(sql, "");
        }


        public bool AddPositionManage(CarManage position)
        {
            string sql = "insert into CarManage values(null,@PositionName,@PositionParentId,@Alias,@PositionCreateDate)";
            return MySqlDapper.DapperExcute(sql, new
            {
                @PositionName = position.PositionName,
                @PositionParentId = position.PositionParentId,
                @Alias = position.Alias,
                @PositionCreateDate = position.PositionCreateDate
            });
        }


        /// <summary>
        /// 根据职位Id删除职位
        /// </summary>
        /// <param name="PositionManageId"></param>
        /// <returns></returns>
        public bool DeletePosition(int PositionManageId)
        {
            string sql = "DELETE FROM CarManage WHERE PositionManageId IN (@PositionManageId)";
            return MySqlDapper.DapperExcute(sql, new { @PositionManageId = PositionManageId });
        }


        /// <summary>
        /// 反填改职位
        /// </summary>
        /// <param name="PositionManageId"></param>
        /// <returns></returns>
        public PositionManage EditPositionManage(int PositionManageId)
        {
            string sql = $"select * from CarManage";
            return MySqlDapper.DapperQuery<PositionManage>(sql, new { @PositionManageId = PositionManageId }).FirstOrDefault();
        }

        /// <summary>
        /// 修改该职位
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public bool UpdatePosition(PositionManage position)
        {
            string sql = "UPDATE PositionManage SET PositionName = @PositionName,PositionParentId = @PositionParentId,Alias = @Alias,PositionCreateDate = @PositionCreateDate WHERE PositionManageId=@PositionManageId; ";
            return MySqlDapper.DapperExcute(sql, new
            {
                @PositionManageId = position.PositionManageId,
                @PositionName = position.PositionName,
                @PositionParentId = position.PositionParentId,
                @Alias = position.Alias,
                @PositionCreateDate = position.PositionCreateDate
            });
        }


    }
}
