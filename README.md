# Summary
This commandline application prints the full name of an assembly (including public key token) and also the name of all referenced assemblies.  It also provides an easy copy-paste output of a binding redirect for the specified assembly.  This can be useful when working in older dotnet solutions that require binding redirects in the config.

# Usage
Pass the full path to an assembly
```
dotnet run "<FullPathToAssembly>"
```

# Example Output
```
Name: System.Runtime.dll - System.Runtime, Version=4.1.1.1, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
Location: /Volumes/Seagate4TB/Users/lawisnie/.nuget/packages/system.runtime/4.3.1/lib/net462/System.Runtime.dll

References: 
  - mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
  - System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
  - System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
  - System.ComponentModel.Composition, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089

Binding Redirect:
<dependentAssembly>  
    <assemblyIdentity name="System.Runtime"  publicKeyToken="b03f5f7f11d50a3a" culture="" />  
    <bindingRedirect oldVersion="0.0.0.0-4.1.1.1" newVersion="4.1.1.1"/>  
</dependentAssembly>  
```