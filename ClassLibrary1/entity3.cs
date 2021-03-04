using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibrary3
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
       
         [ForeignKey("teachId")]
        public int teachId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<TeacherClassroom> TeacherClassrooms { get; set; }
    }
    public class Classroom
    {
        [Key]

        public int Id { get; set; }
        [ForeignKey("classId")]

        public int classId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<TeacherClassroom> TeacherClassrooms { get; set; }
    }
    public class TeacherClassroom
    {
        [Key]
        public int Id { get; set; }
        public int ClassroomId { get; set; }
        public int TeacherId { get; set; }

        public virtual Classroom Classroom { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
