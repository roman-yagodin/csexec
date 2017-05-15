# About csexec

`csexec` is command-line tool to run C# source files as scripts in Linux environments using Mono framework. 
It is evolved from the original idea described here on [StackOverflow](http://stackoverflow.com/questions/20392243/run-c-sharp-code-on-linux-terminal).

## Features

Major features if `csexec`, not available in the Mono C# REPL (`csharp`):

* Full C# language features at your fingers!
* Ability to run script in a terminal emulator.
* Ability to pass command-line arguments to the script ([csharp also supports this since Mono 5.0.0](http://www.mono-project.com/docs/about-mono/releases/5.0.0/#csharp)).
* Script source file name is available as a first argument.

## License

[![GPLv3](https://www.gnu.org/graphics/gplv3-127x51.png)](https://www.gnu.org/licenses/gpl-3.0.html)

The *csexec* is free software: you can redistribute it and/or modify it under the terms of 
the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, 
or (at your option) any later version.

## Install & prepare scripts

1. Make `csexec` executable and copy it to the `/usr/bin`:
```Shell
chmod +x csexec
sudo cp -f csexec /usr/bin
```
2. Add `#!/usr/bin/csexec` line at the beginning of C# source file.
3. Make C# source file executable.
4. Optionally, change C# source file extension to something like `.csx`.

Note what `csexec` writes compiler messages to `csexec.log` file in its current working directory, 
which may be not the same as a script source directory!

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
to pause script before it quits.

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

`csexec` allow reference file assemblies from the `~/.config/csharp` directory (same as with Mono C# shell). 
Note that you still need to reference them with `-r:` compiler option to be able to use their features in the code.

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

`csexec` works better along with [R7.Scripting](https://github.com/roman-yagodin/R7.Scripting) library, 
which provides various components to simpify C# scripting and easily integrate your scripts with 
*Nautilus* / *Nemo* / *Caja* file managers.
