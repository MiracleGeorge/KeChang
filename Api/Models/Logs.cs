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
    
    public partial class Logs
    {
        public int log_id { get; set; }
        public string tablename { get; set; }
        public string olddata { get; set; }
        public string newdata { get; set; }
        public string datatype { get; set; }
        public string cname { get; set; }
        public Nullable<System.DateTime> createdate { get; set; }
    }
}
