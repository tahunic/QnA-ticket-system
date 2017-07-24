using AutoMapper;
using QA.Model.Models;
using QA.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QA.Web.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<City, CityVM>();
            Mapper.CreateMap<Question, QuestionsDisplayVM>()
                .ForMember(q => q.Subject, map => map.MapFrom(vm => vm.Subject.Title));
            Mapper.CreateMap<Question, QuestionEditVM>()
                .ForMember(q => q.Subject, map => map.MapFrom(vm => vm.Subject.Title));
            //Mapper.CreateMap<Gadget, GadgetViewModel>();
        }
    }
}