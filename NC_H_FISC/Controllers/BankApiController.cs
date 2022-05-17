using Microsoft.AspNetCore.Mvc;
using NC_H_FISC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace NC_H_FISC.Controllers
{
    [ApiController]
    public class BankApiController : ControllerBase
    {
        protected readonly NC_H_FISCContext db = new NC_H_FISCContext();

        public BankApiController()
        {
            db = new NC_H_FISCContext();
        }

        [Route("api/v1/fisc/bank")]
        [HttpPost]
        public ModelResult<InsertModelReq, InsertModelRsp> Insert(InsertModelReq req)
        {
            db.Banktab.Add(new Banktab
            {
                Bankcode = req.bankCode,
                Bankname = req.bankName,
                Telzone = req.telZone,
                Telno = req.telNo,
                Updatedate = DateTime.Now.ToString("yyyyMMdd")
            });
            db.SaveChanges();
            return new ModelResult<InsertModelReq, InsertModelRsp> { Req = req, Rsp = new InsertModelRsp() };
        }

        [Route("api/v1/fisc/bank/{bankCode}")]
        [HttpGet]
        public ModelResult<GetModelReq, GetModelRsp> Get(GetModelReq req)
        {
            var model = db.Banktab.Where(e => e.Bankcode == req.bankCode).FirstOrDefault();
            var result = new GetModelRsp
            {
                bankCode = model.Bankcode,
                bankName = model.Bankname,
                telZone = model.Telzone,
                telNo = model.Telno
            };
            return new ModelResult<GetModelReq, GetModelRsp> { Req = null, Rsp = result };
        }

        [Route("api/v1/fisc/bank")]
        [HttpGet]
        public ModelResult<GetManyModelReq, GetManyModelRsp> GetMany(GetManyModelReq req)
        {
            var models = db.Banktab.AsQueryable();
            if (!string.IsNullOrWhiteSpace(req.bankCode))
            {
                models = models.Where(e => e.Bankcode == req.bankCode);
            }
            if (!string.IsNullOrWhiteSpace(req.telZone))
            {
                models = models.Where(e => e.Telzone == req.telZone);
            }
            var result = new GetManyModelRsp
            {
                data = new List<GetManyModelData>()
            };
            foreach(var item in models)
            {
                result.data.Add(new GetManyModelData
                {
                    bankCode = item.Bankcode,
                    bankName = item.Bankname,
                    telZone = item.Telzone,
                    telNo = item.Telno
                });
            }
            return new ModelResult<GetManyModelReq, GetManyModelRsp> { Req = null, Rsp = result };
        }

        [Route("api/v1/fisc/bank/{bankCode}")]
        [HttpDelete]
        public ModelResult<DeleteModelReq, DeleteModelRsp> Delete(DeleteModelReq req)
        {
            var model = db.Banktab.Where(e => e.Bankcode == req.bankCode).FirstOrDefault();
            db.Banktab.Remove(model);
            db.SaveChanges();
            return new ModelResult<DeleteModelReq, DeleteModelRsp> { Req = null, Rsp = new DeleteModelRsp() };
        }

        [Route("api/v1/fisc/bank/{bankCode}")]
        [HttpPut]
        public ModelResult<UpdateModelReq, UpdateModelRsp> Update(UpdateModelReq req)
        {
            var model = db.Banktab.Where(e => e.Bankcode == req.bankCode).FirstOrDefault();
            model.Bankcode = req.bankCode;
            model.Bankname = req.bankName;
            model.Telzone = req.telZone;
            model.Telno = req.telNo;
            model.Updatedate = DateTime.Now.ToString("yyyyMMdd");
            db.SaveChanges();
            return new ModelResult<UpdateModelReq, UpdateModelRsp> { Req = req, Rsp = new UpdateModelRsp() };
        }
    }
}
