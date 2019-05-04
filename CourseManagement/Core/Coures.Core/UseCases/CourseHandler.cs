using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coures.Core.ViewModels;
using CourseManagement.EF;
using AutoMapper;
using System.Data.Entity;
using Coures.Core.Gateways;

namespace Coures.Core.UseCases
{
    public class CourseHandler
    {

        private MapperConfiguration config;
        private IDataAccess<Course> dataAccess;

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

        public CourseHandler(IDataAccess<Course> dataAccess)
        {
            InitMapperConfig();
            this.dataAccess = dataAccess;
        }

        public List<CourseViewModel> List()
        {
            var course = this.dataAccess.List();

            List<CourseViewModel> models = config.ConvertModel<List<Course>, List<CourseViewModel>>(course);

            return models;
        }

        public void Create(CourseCreateViewModel vm)
        {

            Course course = config.ConvertModel<CourseCreateViewModel, Course>(vm);

            this.dataAccess.Add(course);

        }

        public CourseEditModel QueryById(long id)
        {

            Course c = this.dataAccess.Query(x => x.Id == id).Single();
            CourseEditModel course = config.ConvertModel<Course, CourseEditModel>(c);

            return course;

        }

        public void Update(CourseEditModel vm)
        {
            Course course = config.ConvertModel<CourseEditModel, Course>(vm);

            this.dataAccess.Update(course);

        }

        public void Delete(long id)
        {

            Course c = this.dataAccess.Query(x => x.Id == id).Single();
            this.dataAccess.Delete(c);

        }
    }
}
