# Usage
It is recommended you create a Task Scheduler task to run the program hidden on startup, automatically.

I use [run-hidden](https://github.com/stax76/run-hidden), a simple executable that launches console programs hidden.

Although, you can run it directly through the terminal, with logs and a quit option.


# Compilation
To compile, use the .NET SDK's `dotnet publish` command, like:
`dotnet publish -r win-x64`

It will compile into a single executable as `bin\Release\net8.0\win-x64\publish\WinHideDot.exe`
