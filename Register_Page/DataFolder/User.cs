//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Register_Page.DataFolder
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public string Adress { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Therdname { get; set; }
        public string UserEmail { get; set; }
        public Nullable<int> GenderId { get; set; }
        public string Phone { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
    
        public virtual Gender Gender { get; set; }
        public virtual Role Role { get; set; }
    }
}
