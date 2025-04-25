using Library.Request;
using System.Reflection.PortableExecutable;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using System.Threading;

namespace Library.Request
{
    public class AuthorizationeRequest
    {
        public string Login { get; set; } = null!;

        public string? Password { get; set; }
    }
}