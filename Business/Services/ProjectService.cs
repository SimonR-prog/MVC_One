﻿using Business.Models;
using Domain.Interfaces;
using Domain.Models;

namespace Business.Services;

public class ProjectService
{
    public async Task<IResponse> CreateAsyncProject(AddProjectForm form)
    {
        try
        {
            if (await _projectRepository.ExistsAsync(x => x.ProjectName == form.ProjectName))
                return Response.AlreadyExists("Project already exists.");



            return Response.Ok();
        }
        catch
        {
            return Response.Error("Project already exists.");
        }
    }



}
