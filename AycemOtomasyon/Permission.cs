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
    
    public partial class Permission
    {
        public int PermissionId { get; set; }
        public System.Guid RoleId { get; set; }
        public System.Guid PageId { get; set; }
    
        public virtual Page Page { get; set; }
        public virtual Role Role { get; set; }
    }
}
