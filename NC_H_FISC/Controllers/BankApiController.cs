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
            try
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
                return BuildResponse<InsertModelReq, InsertModelRsp>(true, null, req, new InsertModelRsp());
            }
            catch (Exception ex)
            {
                return BuildResponse<InsertModelReq, InsertModelRsp>(false, ex.Message, null, null);
            }
        }

        [Route("api/v1/fisc/bank/{bankCode}")]
        [HttpGet]
        public ModelResult<GetModelReq, GetModelRsp> Get(GetModelReq req)
        {
            try
            {
                var model = db.Banktab.Where(e => e.Bankcode == req.bankCode).FirstOrDefault();
                var result = new GetModelRsp
                {
                    bankCode = model.Bankcode,
                    bankName = model.Bankname,
                    telZone = model.Telzone,
                    telNo = model.Telno
                };
                return BuildResponse<GetModelReq, GetModelRsp>(true, null, null, result);
            }
            catch (Exception ex)
            {
                return BuildResponse<GetModelReq, GetModelRsp>(false, ex.Message, null, null);
            }
        }

        [Route("api/v1/fisc/bank")]
        [HttpGet]
        public ModelResult<GetManyModelReq, GetManyModelRsp> GetMany(GetManyModelReq req)
        {
            try
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
                foreach (var item in models)
                {
                    result.data.Add(new GetManyModelData
                    {
                        bankCode = item.Bankcode,
                        bankName = item.Bankname,
                        telZone = item.Telzone,
                        telNo = item.Telno
                    });
                }
                return BuildResponse<GetManyModelReq, GetManyModelRsp>(true, null, null, result);
            }
            catch (Exception ex)
            {
                return BuildResponse<GetManyModelReq, GetManyModelRsp>(false, ex.Message, null, null);
            }
        }

        [Route("api/v1/fisc/bank/{bankCode}")]
        [HttpDelete]
        public ModelResult<DeleteModelReq, DeleteModelRsp> Delete(DeleteModelReq req)
        {
            try
            {
                var model = db.Banktab.Where(e => e.Bankcode == req.bankCode).FirstOrDefault();
                db.Banktab.Remove(model);
                db.SaveChanges();
                return BuildResponse<DeleteModelReq, DeleteModelRsp>(true, null, null, new DeleteModelRsp());
            }
            catch (Exception ex)
            {
                return BuildResponse<DeleteModelReq, DeleteModelRsp>(false, ex.Message, null, null);
            }
        }

        [Route("api/v1/fisc/bank/{bankCode}")]
        [HttpPut]
        public ModelResult<UpdateModelReq, UpdateModelRsp> Update(UpdateModelReq req)
        {
            try
            {
                var model = db.Banktab.Where(e => e.Bankcode == req.bankCode).FirstOrDefault();
                model.Bankcode = req.bankCode;
                model.Bankname = req.bankName;
                model.Telzone = req.telZone;
                model.Telno = req.telNo;
                model.Updatedate = DateTime.Now.ToString("yyyyMMdd");
                db.SaveChanges();
                return BuildResponse<UpdateModelReq, UpdateModelRsp>(true, null, req, new UpdateModelRsp());
            }
            catch (Exception ex)
            {
                return BuildResponse<UpdateModelReq, UpdateModelRsp>(false, ex.Message, null, null);
            }
        }

        private ModelResult<TReq, TRsp> BuildResponse<TReq, TRsp>(bool success, string errorMsg, TReq req, TRsp rsp)
        {
            return new ModelResult<TReq, TRsp>
            {
                Success = success,
                ErrorMessage = errorMsg,
                Data = new ModelData<TReq, TRsp>
                {
                    Req = req,
                    Rsp = rsp
                }
            };
        }
    }
}
