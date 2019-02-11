using System.Linq;
using System.Data.Entity;
namespace Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new PlutoContext();

            //LINQ SyntX

            //var query =
            //    from c in context.Courses
            //    where c.Level == 1
            //    orderby c.Level descending, c.Name
            //    select new { Name = c.Name, Author = c.Author.Name };

            ////Groupeby
            //var query2 =
            //    from c in context.Courses
            //    group c by c.Level
            //    into g
            //    select g;

            //foreach (var group in query2)
            //{
            //    //foreach (var course in group)
            //    //{
            //    // System.Console.WriteLine("{0} ({1})",group.Key,group.Count());

            //    //}
            //}


            //// Inner Joining

            //var query3 =
            //    from c in context.Courses
            //    select new { CourseName = c.Name, AuthorName = c.Author.Name };

            ////Inner Joining
            ////if we dont have Author Prop in Course We can join Like below
            //var query4 =
            //     from c in context.Courses
            //     join a in context.Authors on c.AuthorId equals a.Id
            //     select new { CourseName = c.Name, AuthorName = a.Name };



            ////Group Join == Left Join in SQL
            //var query5 =
            //    from a in context.Authors
            //    join c in context.Courses on a.Id equals c.AuthorId into g
            //    select new { AuthorName = a.Name, Courses = g.Count() };


            //foreach (var x in query5)
            //{
            //    // System.Console.WriteLine("{0} ({1})",x.AuthorName , x.Courses);
            //}

            ////Cross Join
            //var query6 =
            //    from a in context.Authors
            //    from c in context.Courses
            //    select new { AuthorName = a.Name, CourseName = c.Name };

            //foreach (var x in query6)
            //{
            //    //      System.Console.WriteLine("{0} - ({1})",x.AuthorName,x.CourseName);
            //}

            ////LINQ Extension => lambda

            ////Restrinction
            //var courses = context.Courses.Where(c => c.Level == 1);

            ////Ordering
            //var Orderingcourses = context.Courses.Where(c => c.Level == 1).OrderBy(c => c.Name).ThenBy(c => c.Level);

            //var DescendingOrderingcourses = context.Courses
            //    .Where(c => c.Level == 1)
            //    .OrderByDescending(c => c.Name)
            //    .ThenByDescending(c => c.Level);


            ////Projection

            //var ProjectionDescendingOrderingcourses = context.Courses
            //   .Where(c => c.Level == 1)
            //   .OrderByDescending(c => c.Name)
            //   .ThenByDescending(c => c.Level)
            //   .Select(c => new { CourseName = c.Name, AuthorName = c.Author.Name });

            ////Projection II
            //var ProjectionTags = context.Courses
            //    .Where(c => c.Level == 1)
            //    .OrderByDescending(c => c.Name)
            //    .ThenByDescending(c => c.Level)
            //    .Select(t => t.Tags);

            //foreach (var c in ProjectionTags)
            //{
            //    foreach (var tag in c)
            //    {
            //        // System.Console.WriteLine(tag.Name);
            //    }
            //}


            ////Projection III Flat4 Distinct (Not Repeating)

            //var ProjectionTagsFlat = context.Courses
            //    .Where(c => c.Level == 1)
            //    .OrderByDescending(c => c.Name)
            //    .ThenByDescending(c => c.Level)
            //    .SelectMany(t => t.Tags)
            //    .Distinct();

            //foreach (var tag in ProjectionTagsFlat)
            //{
            //    // System.Console.WriteLine(tag.Name);

            //}


            ////Grouping by Extension

            //var groups = context.Courses.GroupBy(c => c.Level);

            //foreach (var group in groups)
            //{
            //    // System.Console.WriteLine(group.Key);

            //    foreach (var g in group)
            //    {
            //        //   System.Console.WriteLine(course.Name);
            //    }
            //}


            ////JOINS
            ////Inner Join

            ////context.Courses.Join(context.Authors,
            ////    c => c.AuthorId,
            ////    a => a.Id,
            ////    (course, author) => new
            ////    {
            ////        courseName = course.Name,
            ////        AuthorName = author.Name
            ////    });


            ////Group Join Number of AuthorCourses

            //var AuthorCoursesCount = context.Authors.GroupJoin(context.Courses, a => a.Id, c => c.AuthorId, (author, courses2) => new

            //{
            //    Author = author,
            //    Courses = courses2.Count()
            //});

            //foreach (var Author in AuthorCoursesCount)
            //{
            //    // System.Console.WriteLine( Author.Author.Name + " " +  Author.Courses );

            //}

            ////Cross Join

            ////var crossjoin = context.Authors.SelectMany(a => context.Courses, (author, course) => new
            ////{
            ////    AuthorName = author.Name,
            ////    CourseName = course.Name
            ////});


            //foreach (var item in crossjoin)
            //{
            //    //  System.Console.WriteLine(item.AuthorName + " " + item.CourseName);
            //}


            ////Partitioning

            //var CoursesQuery = context.Courses.Skip(10).Take(10);

            ////Element Operators

            //context.Courses.OrderBy(c => c.Level).First();
            //context.Courses.OrderBy(c => c.Level).FirstOrDefault(c => c.FullPrice > 100);

            //context.Courses.Single(c => c.Id == 1);


            ////Quantifing
            //var AreAllAbove10Dollars = context.Courses.All(c => c.FullPrice > 10);
            //context.Courses.Any(c => c.Level == 1);


            ////Aggregating

            //var count = context.Courses.Count();
            ////System.Console.WriteLine(context.Courses.Max(c => c.FullPrice));
            ////System.Console.WriteLine(context.Courses.Min(c => c.FullPrice));
            ////System.Console.WriteLine(context.Courses.Average(c => c.FullPrice));

            ////Deferred Execution

            //var DefCourses = context.Courses;

            //foreach (var c in DefCourses)
            //{
            //    System.Console.WriteLine(c.Name);
            //}


            ////Eager Loading
            //// var EagerCourses = context.Courses.Include("Author").ToList();

            //var EagerCourses = context.Courses.Include(c => c.Author).ToList();

            ////Explicit Loading
            ////MSDN way
            //var author = context.Authors.Single(a => a.Id == 1);
            //context.Entry(author).Collection(a => a.Courses).Query().Where(c => c.FullPrice == 0).Load();

            ////My Way
            //context.Courses.Where(c => c.AuthorId == author.Id && c.FullPrice == 0).Load();


            //var authors = context.Authors.ToList();
            //var AuthorIds = authors.Select(a => a.Id);

            ////Explicit Fillterd
            //context.Courses.Where(c => AuthorIds.Contains(c.AuthorId) && c.FullPrice == 0).Load();


            //ADD or Insert Object

            ////var author = context.Authors.Single(a => a.Id == 6);
            ////var course = new Course
            ////{
            ////    Name = "New Course 2",
            ////    Description = "New Description",
            ////    FullPrice = 19095f,
            ////    Level = 1,
            ////    Author = author
            ////};

            ////context.Courses.Add(course);
            ////context.SaveChanges();


            //Updating Objects

            ////var course = context.Courses.Find(11); //Single(c=>c.id == 4)

            ////course.Name= "New UpdatedCourse";
            ////course.AuthorId = 1;

            ////context.SaveChanges();

            //Deleting Object without cascading


            //var course = context.Courses.Find(11);
            //context.Courses.Remove(course);

            //context.SaveChanges();


            //deleting object with cascading
            //author.IsDeleted = true;
            ////var author = context.Authors.Include(c=>c.Courses).Single(a=>a.Id ==6);
            ////context.Courses.RemoveRange(author.Courses);
            ////context.Authors.Remove(author);

            ////context.SaveChanges();






        }
    }
}
