using Microsoft.AspNetCore.Mvc;
[Route("api/[controller]")]
[ApiController]
public class ClientesController : ControllerBase
{
    private static List<Cliente> clientes = new List<Cliente>();
    [HttpGet]
    public ActionResult<List<Cliente>> Get()
    {
        return clientes;
    }
    [HttpGet("{id}")]
    public ActionResult<Cliente> Get(int id)
    {
        Cliente cliente = null;
        foreach (var c in clientes)
        {
            if (c.Id == id)
            {
                cliente = c;
                break;
            }
        }

        if(cliente == null)
        {
            return NotFound();
        }
        return cliente;
    }
    [HttpPost]
    public ActionResult Post(Cliente cliente)
    {
        clientes.Add(cliente);
        return Created();
    }
    [HttpPut("{id}")]
    public IActionResult Put(int id, Cliente clienteAtualizado)
    {
        Cliente cliente = null;
        foreach (var c in clientes)
        {
            if (c.Id == id)
            {
                cliente = c;
                break;
            }
        }

        if(cliente == null)
        {
            return NotFound();
        }
        
        cliente.Nome = clienteAtualizado.Nome;
        cliente.Email = clienteAtualizado.Email;
        cliente.Telefone = clienteAtualizado.Telefone;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        Cliente cliente = null;
        foreach (var c in clientes)
        {
            if (c.Id == id)
            {
                cliente = c;
                break;
            }
        }

        if(cliente == null)
        {
            return NotFound();
        }
        
        clientes.Remove(cliente);

        return NoContent();
    }
}
