//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLNSTL
{
    using System;
    using System.Collections.Generic;
    
    public partial class LUONGTHANG
    {
        public string MANV { get; set; }
        public int THANG { get; set; }
        public int NAM { get; set; }
        public Nullable<double> LUONGCB_LUCTINHLUONG { get; set; }
        public Nullable<double> HESO_LUCTINHLUONG { get; set; }
        public Nullable<double> TIENPHUCAP_LUCTINHLUONG { get; set; }
        public Nullable<int> SONGAYCONG { get; set; }
        public Nullable<double> TIENBAOHIEM_LUCTINHLUONG { get; set; }
        public Nullable<double> TIENKHENTHUONG_LUCTINHLUONG { get; set; }
        public Nullable<double> TIENKYLUAT_LUCTINHLUONG { get; set; }
        public Nullable<double> TIENTAMUNG_LUCTHANGTINHLUONG { get; set; }
        public Nullable<double> TONGLUONG { get; set; }
    
        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
