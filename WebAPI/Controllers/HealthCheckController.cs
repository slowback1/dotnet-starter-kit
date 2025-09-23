using Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

public class HealthCheckResult
{
    public string Status { get; set; }
    public DateTime ResponseDate { get; set; } = DateTime.Now;
}

[Route("HealthCheck")]
public class HealthCheckController : ApplicationController
{
    public HealthCheckController(ICrudFactory factory) : base(factory)
    {
    }

    [HttpGet]
    [Route("")]
    public ActionResult HealthCheck()
    {
        return Ok(new HealthCheckResult { Status = "Healthy" });
    }
}