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
    
    public partial class Auto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Auto()
        {
            this.Order = new HashSet<Order>();
        }
    
        public int AutoId { get; set; }
        public int ClientId { get; set; }
        public string GosNomer { get; set; }
        public string VIN { get; set; }
        public int Mileage { get; set; }
        public int Age { get; set; }
        public Nullable<int> FullAutoId { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual FullAuto FullAuto { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Order { get; set; }
    }
}
