using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coures.Core.ViewModels;
using CourseManagement.EF;
using AutoMapper;
using System.Data.Entity;

namespace Coures.Core.UseCases
{
    public class CourseHandler
    {

        private MapperConfiguration config;

        private void InitMapperConfig()
        {
            config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Course, CourseViewModel>();
                cfg.CreateMap<CourseViewModel, Course>();
                cfg.CreateMap<CourseCreateViewModel, Course>();
                cfg.CreateMap<Course, CourseEditModel>();
            });
        }


        public CourseHandler()
        {
            InitMapperConfig();
        }


        public List<CourseViewModel> List()
        {
            using (CourseManagementEntities entity = new CourseManagementEntities())
            {
                var course = entity.Course.ToList();

                List<CourseViewModel> models = config.ConvertModel<List<Course>, List<CourseViewModel>>(course);

                return models;
            }


        }

        public void Create(CourseCreateViewModel vm)
        {
            using (CourseManagementEntities entity = new CourseManagementEntities())
            {
                Course course = config.ConvertModel<CourseCreateViewModel, Course>(vm);

                Course c = entity.Course.Add(course);
                entity.SaveChanges();

            }
        }

        public CourseEditModel QueryById(long id)
        {
            using (CourseManagementEntities entity = new CourseManagementEntities())
            {


                Course c = entity.Course.Where(x => x.Id == id).Single();

                CourseEditModel course = config.ConvertModel<Course, CourseEditModel>(c);

                return course;

            }
        }

        public void Update(CourseEditModel vm)
        {
            using (CourseManagementEntities entity = new CourseManagementEntities())
            {
                Course course = config.ConvertModel<CourseEditModel, Course>(vm);

                entity.Entry(course).State = EntityState.Modified;

                entity.SaveChanges();

            }
        }

        public void Delete(long id)
        {
            using (CourseManagementEntities entity = new CourseManagementEntities())
            {
                Course c = entity.Course.Where(x => x.Id == id).Single();
                entity.Entry(c).State = EntityState.Deleted;
                entity.Course.Remove(c);
                entity.SaveChanges();

            }
        }
    }
}
