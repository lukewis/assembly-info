using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;

class Program
{
    public static Task Main(string[] args)
    {
        //var path = @"/Volumes/Seagate4TB 1/Users/lawisnie/source/wishlist-blazor/bin/Debug/net5.0/wishlist-blazor.dll";
        //var path = @"/Volumes/Seagate4TB/Users/lawisnie/.nuget/packages/system.runtime/4.3.1/lib/net462/System.Runtime.dll";
        //var path = @"/Volumes/Seagate4TB 1/Users/lawisnie/Downloads/System.Runtime.Dev.dll";
        var path = args?.Length > 0 ? args[0] : @"/Volumes/Seagate4TB/Users/lawisnie/.nuget/packages/system.runtime/4.3.1/lib/net462/System.Runtime.dll";
        var assembly = Assembly.LoadFile(path);
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
    <assemblyIdentity name=""{name.Name}""  publicKeyToken=""{GetPublicKey(name)}"" culture=""{name.CultureInfo.Name}"" />  
    <bindingRedirect oldVersion=""0.0.0.0-{name.Version}"" newVersion=""{name.Version}""/>  
</dependentAssembly>  
");

        return Task.CompletedTask;
    }

    private static string GetPublicKey(AssemblyName name)
    {
        StringBuilder sb = new StringBuilder();
        var token = name.GetPublicKeyToken();
 
        for (int i = 0; i < token.GetLength(0); i++)
        {
            sb.Append(String.Format("{0:x2}", token[i]));
        }

        return sb.ToString();
    }
}
