using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CourseManagement.EF;
using System.Linq;

namespace Coures.Core.Test
{
    internal class FakeCourseDataAccess : Gateways.IDataAccess<Course>
    {
        private FakeDataBase dataBase;

        public FakeCourseDataAccess(FakeDataBase dataBase)
        {
            this.dataBase = dataBase;
        }

        public Course Add(Course t)
        {
            var list = this.dataBase.GetDataBase();

            list.Add(t);

            return t;
        }

        public void Delete(Course t)
        {

           var list =  this.dataBase.GetDataBase();

            list.Remove(t);

        }

        public List<Course> List()
        {
            return this.dataBase.GetDataBase(); 
        }

        public List<Course> Query(Expression<Func<Course, bool>> predicate)
        {
            List<Course> list = this.dataBase.GetDataBase();

            return list.AsQueryable().Where(predicate).ToList();

        }

        public Course Update(Course t)
        {
            var list = this.dataBase.GetDataBase();

            list.Remove(t);

            list.Add(t);

            return t;
        }
    }
}