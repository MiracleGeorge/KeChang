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
    
    public partial class youhoo_rebate_sale
    {
        public int Rebate_id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string remark { get; set; }
        public Nullable<int> flag { get; set; }
        public int user_id { get; set; }
        public string createoperator { get; set; }
        public Nullable<System.DateTime> createdate { get; set; }
        public string updateoperator { get; set; }
        public Nullable<System.DateTime> updatedate { get; set; }
    }
}
