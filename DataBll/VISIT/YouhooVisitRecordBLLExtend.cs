using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouHoo.DataTools;

namespace YouHoo.DataBll
{
    public class YouhooVisitRecordBLLExtend
    {
        public static string CacheName = "YouhooVisitRecordDAL-";
        /// <summary>
        /// 审核或弃审拜访记录
        /// </summary>
        /// <param name="RecordId"></param>
        /// <param name="ConfirmOrCancel">1审核0弃审</param>
        /// <returns></returns>
        public int VeriftyVisitRecord(string[] RecordId,int ConfirmOrCancel)
        {
            try
            {

                CacheHelper.RemoveSearchCache(CacheName);
                //转换数组类型
                List<int> listRecordId = new List<int>();
                foreach (var item in RecordId)
                {
                    listRecordId.Add(Convert.ToInt32(item));
                }
                int[] iRecordId = listRecordId.ToArray();
                //审核操作
                VISIT.VisitDataContext vd = new VISIT.VisitDataContext();
                var ret = vd.youhoo_Visit_Record.Where(x => iRecordId.Contains(x.visit_id));
               
                foreach (var item in ret)
                {
                    item.verifi_state = ConfirmOrCancel;
                }
                //提交
                vd.SubmitChanges();
                return 1;
            }
            catch (Exception e)
            {
                return -1;
                throw new Exception(e.Message);
            }
        }

        public VISIT.v_VisitRecordWay GetVisitRecordModel(int visitId)
        {
            DataBll.VISIT.VisitDataContext vc = new VISIT.VisitDataContext();

            var ret= vc.v_VisitRecordWay.FirstOrDefault(x=>x.visit_id==visitId);

            return ret == null ? new VISIT.v_VisitRecordWay() : ret;
            
        }
    }
}
