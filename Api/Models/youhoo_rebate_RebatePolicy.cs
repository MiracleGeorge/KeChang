//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Api.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class youhoo_rebate_RebatePolicy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public youhoo_rebate_RebatePolicy()
        {
            this.youhoo_rebate_RebatePolicys = new HashSet<youhoo_rebate_RebatePolicys>();
        }
    
        public int id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public Nullable<int> channel_id { get; set; }
        public Nullable<int> price_id { get; set; }
        public Nullable<int> region_id { get; set; }
        public Nullable<int> sort_id_id { get; set; }
        public Nullable<int> SupportWay_id { get; set; }
        public Nullable<int> SupportPrice_id { get; set; }
        public Nullable<int> RebateType_id { get; set; }
        public Nullable<int> time_id { get; set; }
        public string remark { get; set; }
        public Nullable<int> flag { get; set; }
        public int user_id { get; set; }
        public string createoperator { get; set; }
        public Nullable<System.DateTime> createdate { get; set; }
        public string updateoperator { get; set; }
        public Nullable<System.DateTime> updatedate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<youhoo_rebate_RebatePolicys> youhoo_rebate_RebatePolicys { get; set; }
    }
}
