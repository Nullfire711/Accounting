//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Accounting.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class History
    {
        public int ID { get; set; }
        public string EmployeeName { get; set; }
        public string Event { get; set; }
        public Nullable<int> OldPosition { get; set; }
        public Nullable<int> NewPosition { get; set; }
        public System.DateTime Date { get; set; }
    }
}