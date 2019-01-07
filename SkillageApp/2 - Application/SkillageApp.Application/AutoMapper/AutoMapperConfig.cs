﻿using AutoMapper;

namespace SkillageApp.App.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DomainToViewModelMappingProfile>();
                x.AddProfile<ViewModelToDomainMappingProfile>();
            });

            //Mapper.Configuration.AssertConfigurationIsValid();
        }
    }
}