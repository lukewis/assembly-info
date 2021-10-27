using System;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;

namespace AssemblyInfo 
{
    class Program
    {
        public static Task Main(string[] args)
        {
            var path = args?.Length > 0 ? args[0] : null;
            var defaultAssembly = typeof(Task).Assembly;
            var assembly = path != null ? Assembly.LoadFile(path) : defaultAssembly;
            if (path == null)
            {
                path = defaultAssembly.Location;
            }
            var name = assembly.GetName();

            var fileName = System.IO.Path.GetFileName(path);

            Console.WriteLine($"Name: {fileName} - {name.FullName}");
            Console.WriteLine($"Location: {path}");

            var refs = assembly.GetReferencedAssemblies();
            if (refs.Any())
            {
                Console.WriteLine();
                Console.WriteLine("References: ");
                foreach(var reference in refs)
                {
                    Console.WriteLine($"  - {reference}");
                }
            }

            Console.WriteLine();
            Console.Write("Binding Redirect:");
            Console.WriteLine(@$"
    <dependentAssembly>  
        <assemblyIdentity name=""{name.Name}""  publicKeyToken=""{GetPublicKey(name)}"" culture=""{name.CultureInfo?.Name}"" />  
        <bindingRedirect oldVersion=""0.0.0.0-{name.Version}"" newVersion=""{name.Version}""/>  
    </dependentAssembly>  
    ");

            return Task.CompletedTask;
        }

        private static string GetPublicKey(AssemblyName name)
        {
            StringBuilder sb = new StringBuilder();
            var token = name.GetPublicKeyToken();
    
            if (token != null)
            {
                for (int i = 0; i < token.GetLength(0); i++)
                {
                    sb.Append(String.Format("{0:x2}", token[i]));
                }
            }

            return sb.ToString();
        }
}

}