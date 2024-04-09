using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TestPostgresDocker.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PersonController : ControllerBase
{
    private readonly DataContext _dataContext;

    public PersonController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Person>>> GetAll()
    {
        return await _dataContext.Person.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Person>> Add(Person person)
    {
        var entity = await _dataContext.Person.AddAsync(person);
        _dataContext.SaveChanges();
        return entity.Entity;
    }
}
