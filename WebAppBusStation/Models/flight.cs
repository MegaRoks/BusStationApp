//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAppBusStation.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class flight
    {
        public int ID_flight { get; set; }
        public string driver { get; set; }
        public int ID_bus { get; set; }
        public int ID_route { get; set; }
    
        public virtual bus bus { get; set; }
        public virtual route route { get; set; }
    }
}
