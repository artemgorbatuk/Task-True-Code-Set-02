using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Functionality;

public class RequestResult<T>
{
    public T? Data { get; set; } = default!;
    public string MessageText { get; set; } = default!;
    public string MessageType { get; set; } = default!;
}