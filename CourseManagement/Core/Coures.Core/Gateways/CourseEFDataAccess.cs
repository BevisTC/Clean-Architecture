using CourseManagement.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;

namespace Coures.Core.Gateways
{
    public class CourseEFDataAccess : IDataAccess<Course>
    {

        public CourseEFDataAccess()
        {

        }

        public Course Add(Course t)
        {
            using (CourseManagementEntities entity = new CourseManagementEntities())
            {
                Course c = entity.Course.Add(t);
                entity.SaveChanges();

                return c;
            }
        }

        public void Delete(Course course)
        {
            using (CourseManagementEntities entity = new CourseManagementEntities())
            {
                Course c = entity.Course.Where(x => x.Id == course.Id).Single();
                entity.Entry(c).State = EntityState.Deleted;
                entity.Course.Remove(c);
                entity.SaveChanges();

            }
        }

        public List<Course> List()
        {
            using (CourseManagementEntities entity = new CourseManagementEntities())
            {
                var course = entity.Course.ToList();

                return course;

            }
        }

        public List<Course> Query(Expression<Func<Course, bool>> predicate)
        {
            using (CourseManagementEntities entity = new CourseManagementEntities())
            {
                List<Course> courseList = entity.Course.Where(predicate).ToList();
                return courseList;

            }
        }

        public Course Update(Course course)
        {
            using (CourseManagementEntities entity = new CourseManagementEntities())
            {
                entity.Entry(course).State = EntityState.Modified;

                entity.SaveChanges();

                return course;

            }
        }
    }
}
