using ClassLibrary2;
using ClassLibrary3;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class SampleContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }


        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Classroom> Classroom { get; set; }
        public DbSet<TeacherClassroom> TeacherClassroom { get; set; }

        public DbSet<Menu> Menu { get; set; }
        public DbSet<Route> Route { get; set; }

        public DbSet<Yazar> Yazar { get; set; }
        public DbSet<Kitap> Kitap { get; set; }
        public DbSet<YazarKitap> YazarKitap { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(LocalDB)\\v11.0;Database=SampleTest;Trusted_Connection=True;Connect Timeout=30;MultipleActiveResultSets=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookCategory>().HasKey(bc => new { bc.BookId, bc.CategoryId });

            modelBuilder.Entity<BookCategory>()
                .HasOne(bc => bc.Book)
                .WithMany(b => b.BookCategories)
                .HasForeignKey(bc => bc.BookId);

            modelBuilder.Entity<BookCategory>()
                .HasOne(bc => bc.Category)
                .WithMany(c => c.BookCategories)
                .HasForeignKey(bc => bc.CategoryId);

            modelBuilder.Entity<StudentCourse>().HasKey(sc => new { sc.StudentId, sc.CourseId });
         
            modelBuilder.Entity<StudentCourse>()
    .HasOne<Student>(sc => sc.Student)
    .WithMany(s => s.StudentCourses)
    .HasForeignKey(sc => sc.StudentId);

            modelBuilder.Entity<StudentCourse>()
           .HasOne<Course>(sc => sc.Course)
           .WithMany(s => s.StudentCourses)
           .HasForeignKey(sc => sc.CourseId);




            modelBuilder.Entity<Teacher>().HasMany(m => m.TeacherClassrooms)
    .WithOne(m => m.Teacher).HasForeignKey(k => k.TeacherId);

            modelBuilder.Entity < Classroom >().HasMany(m => m.TeacherClassrooms)
                .WithOne(m => m.Classroom).HasForeignKey(k => k.ClassroomId);

            modelBuilder.Entity <TeacherClassroom >().HasOne(m => m.Classroom)
                .WithMany(m => m.TeacherClassrooms).HasForeignKey(k => k.ClassroomId);

            modelBuilder.Entity <TeacherClassroom>().HasOne(m => m.Teacher)
                .WithMany(m => m.TeacherClassrooms).HasForeignKey(k => k.TeacherId);


            modelBuilder.Entity<Teacher>().HasIndex(u => u.teachId).IsUnique();
            modelBuilder.Entity<Classroom>().HasIndex(u => u.classId).IsUnique();


       


            modelBuilder.Entity<Menu>()
.HasOne(x => x.Route)
.WithOne(x => x.Menu)
.HasPrincipalKey<Menu>(x => x.MenuCode)
.HasForeignKey<Route>(x => x.MenuCode);




            modelBuilder.Entity<YazarKitap>()
              .HasOne(bc => bc.Yazar)
              .WithMany(b => b.YazarKitap)
               .HasForeignKey(bc => bc.TcKimlikNo)
               .HasPrincipalKey(bc => bc.TcKimlikNo);

            modelBuilder.Entity<YazarKitap>()
                .HasOne(bc => bc.Kitap)
                .WithMany(c => c.YazarKitap)
                .HasForeignKey(bc => bc.ISBN)
                           .HasPrincipalKey(bc => bc.ISBN);





            //BookAuthor
            modelBuilder.Entity<BookAuthor2>().HasKey(ba => new { ba.IdentityNumber, ba.IsbnNo });
            modelBuilder.Entity<BookAuthor2>().HasOne(p => p.Book2)
                .WithMany(p => p.BookAuthors2)
                .HasForeignKey(p => p.IsbnNo);

            modelBuilder.Entity<BookAuthor2>().HasOne(p => p.Author2)
                .WithMany(p => p.BookAuthors2)
                .HasForeignKey(p => p.IdentityNumber);


            //Book
            modelBuilder.Entity<Book2>().HasKey(p => new { p.IsbnNo });
            modelBuilder.Entity<Book2>().Property(p => p.Id)
                .UseIdentityColumn(1, 1);

            modelBuilder.Entity<Book2>().Property(p => p.Name)
                .HasColumnType("varchar(20)");
            modelBuilder.Entity<Book2>().Property(p => p.IsbnNo)
                .HasColumnType("char(3)");

            //Author
            modelBuilder.Entity<Author2>().HasKey(p => new { p.IdentityNumber });
            modelBuilder.Entity<Author2>().Property(p => p.Id)
                .UseIdentityColumn(1, 1);
            modelBuilder.Entity<Author2>().Property(p => p.Name)
                .HasColumnType("varchar(20)");
            modelBuilder.Entity<Author2>().Property(p => p.IdentityNumber)
                .HasColumnType("char(12)");

        }

    }
}
