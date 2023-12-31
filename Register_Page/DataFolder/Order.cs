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
    
    public partial class Order
    {
        public int OrderId { get; set; }
        public int ClientId { get; set; }
        public int AutoId { get; set; }
        public int StatusId { get; set; }
        public int ServiceId { get; set; }
        public Nullable<decimal> Price { get; set; }
        public System.DateTime StartDate { get; set; }
        public int WorkerId { get; set; }
    
        public virtual Auto Auto { get; set; }
        public virtual Client Client { get; set; }
        public virtual Service Service { get; set; }
        public virtual Status Status { get; set; }
        public virtual Worker Worker { get; set; }
    }
}
