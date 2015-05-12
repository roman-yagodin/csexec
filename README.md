# About csexec

`csexec` is command-line tool to run C# source files as scripts in Linux environments using Mono framework. It evolved from the original idea described on [StackOverflow](http://stackoverflow.com/questions/20392243/run-c-sharp-code-on-linux-terminal).

## Features

Major features if `csexec`, not presented in the Mono C# shell:

* Full C# language features.
* Ability to pass arguments to the script.
* Script name passed as first argument.

## Install & prepare scripts

1. Make `csexec` executable and copy to the `/usr/bin`:
```Shell
chmod +x csexec
sudo cp -f csexec /usr/bin
```
2. Add `#!/usr/bin/csexec` at the beginning of C# source file.
3. Make C# source file executable.
4. Optionally change C# source file extension to ``.csx`.

Compiler output (error, warining, etc.) logged into `csexec.log` file
in the current directory.

## Basic console script

```C#
#!/usr/bin/csexec

using System;

public class Program
{
    public static void Main (string [] args)
    {
        Console.WriteLine ("Hello, world!");
        Console.WriteLine ("Arguments: " + string.Join (", ", args));
    }
}
```

## Run in the terminal emulator

Use `-t` switch to run script in terminal emulator window.
Consider add `Console.ReadKey ()` to the end of the program
to pause script before quit.

```C#
#!/usr/bin/csexec -t

using System;

public class Program
{
    public static void Main (string [] args)
    {
        Console.WriteLine ("Hello, world!");
        Console.WriteLine ("Arguments: " + string.Join (", ", args));

        Console.Write ("Press any key to quit...");
        Console.ReadKey (true);
    }
}
```

## Reference GAC assemblies

Use `-r:` compiler option to reference GAC assemblies:

```C#
#!/usr/bin/csexec -r:System.Windows.Forms.dll -r:System.Drawing.dll

using System;
using System.Drawing;
using System.Windows.Forms;

public class Program
{
    public static void Main (string [] args)
    {
        MessageBox.Show ("Hello, world!");
    }
}
```

## Reference file assemblies

`csexec` allow reference file assemblies from the `~/.config/csharp` directory (same as with Mono C# shell). You still need to reference them with `-r:` compiler option before use in the code.

```C#
#!/usr/bin/csexec -r:MyLibrary.dll

using System;
using MyLibrary;

public class Program
{
    public static void Main (string [] args)
    {
        var myObject = new MyClass ();
        Console.WriteLine (myObject);
    }
}
```

## Template scripts

See template scripts in the `templates` directory.

## R7.Scripting

`csexec` works better with [R7.Scripting](https://github.com/roman-yagodin/R7.Scripting) library, which provides various components to simpify C# scripting and easily integrate scripts with Nautilus / Nemo file managers.
