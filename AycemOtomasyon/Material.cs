//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AycemOtomasyon
{
    using System;
    using System.Collections.Generic;
    
    public partial class Material
    {
        public System.Guid MaterialId { get; set; }
        public int MaterialQuantity { get; set; }
        public string MaterialName { get; set; }
        public decimal MaterialPrice { get; set; }
        public Nullable<System.Guid> ColourId { get; set; }
    
        public virtual Colour Colour { get; set; }
    }
}
