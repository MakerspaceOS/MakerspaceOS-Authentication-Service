//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MakerSpaceOS.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Equipment
    {
        public Equipment()
        {
            this.EquipmentTrainingCourses = new HashSet<EquipmentTrainingCourse>();
        }
    
        public int EquipmentID { get; set; }
        public string EquipmentSiteUniqueID { get; set; }
        public string EquipmentName { get; set; }
        public Nullable<int> EquipmentTypeID { get; set; }
        public bool RequiresTrainingCourse { get; set; }
        public int TimeLimitMinutes { get; set; }
        public Nullable<int> AmpsWhenOn { get; set; }
    
        public virtual EquipmentType EquipmentType { get; set; }
        public virtual ICollection<EquipmentTrainingCourse> EquipmentTrainingCourses { get; set; }
    }
}
