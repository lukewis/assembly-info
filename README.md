# Summary
This commandline application prints the full name of an assembly (including public key token) and also the name of all referenced assemblies.  It also provides an easy copy-paste output of a binding redirect for the specified assembly.  This can be useful when working in older dotnet solutions that require binding redirects in the config.

# Usage
Pass the full path to an assembly
```
dotnet run "<FullPathToAssembly>"
```

# Example Output
```
Name: System.Private.CoreLib.dll - System.Private.CoreLib, Version=6.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e
Location: /usr/local/share/dotnet/shared/Microsoft.NETCore.App/6.0.0-preview.7.21377.19/System.Private.CoreLib.dll

Binding Redirect:
    <dependentAssembly>  
        <assemblyIdentity name="System.Private.CoreLib"  publicKeyToken="7cec85d7bea7798e" culture="" />  
        <bindingRedirect oldVersion="0.0.0.0-6.0.0.0" newVersion="6.0.0.0"/>  
    </dependentAssembly>
```