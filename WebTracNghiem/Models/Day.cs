//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebTracNghiem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Day
    {
        public int IdGiaoVien { get; set; }
        public int IdMonHoc { get; set; }
        public Nullable<byte> DaXoa { get; set; }
    
        public virtual GiaoVien GiaoVien { get; set; }
        public virtual MonHoc MonHoc { get; set; }
    }
}
