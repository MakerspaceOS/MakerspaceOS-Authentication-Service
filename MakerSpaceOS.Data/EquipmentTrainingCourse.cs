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
    
    public partial class EquipmentTrainingCourse
    {
        public int EquipmentID { get; set; }
        public int TrainingCourseID { get; set; }
        public bool RequiredForUse { get; set; }
    
        public virtual Equipment Equipment { get; set; }
        public virtual TrainingCourse TrainingCourse { get; set; }
    }
}