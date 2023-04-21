using System;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace HRMAPI.Controllers;
[ApiController]
[Microsoft.AspNetCore.Components.Route("[candidate_controller]")]

public class CandidateController : ControllerBase
{
    private readonly ICandidateService _Cs;
    public CandidateController(ICandidateService candidateservice)
    {
        _Cs = candidateservice;
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        List<Candidate> candidates = _Cs.GetAllCandidate().ToList();
        return Ok(candidates);
    }

    [HttpPost]
    public IActionResult Insert(string firstName, string lastName, string email, string resumeUrl)
    {

        var candidate = new Candidate { FirstName = firstName, LastName = lastName, Email = email, ResumeURL = resumeUrl };
        _Cs.InsertCandidate(candidate);
        return Ok(candidate);
    }
}

