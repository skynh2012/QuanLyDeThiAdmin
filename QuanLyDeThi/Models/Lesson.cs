//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyDeThi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Lesson
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Lesson()
        {
            this.Questions = new HashSet<Question>();
        }
    
        public int Id { get; set; }
        public string LessonName { get; set; }
        public Nullable<int> AnswerTime { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
        public Nullable<int> UserCreatedId { get; set; }
    
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Question> Questions { get; set; }
    }
}
