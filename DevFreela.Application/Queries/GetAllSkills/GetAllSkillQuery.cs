﻿using DevFreela.Application.ViewModels;
using DevFreela.Core.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetAllSkills
{
    public class GetAllSkillQuery : IRequest<List<SkillDTO>>
    {
    }
}
