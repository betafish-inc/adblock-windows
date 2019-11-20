# adblock-windows

AdBlock Windows App

.NET C# basic UI for adblocking demo.

Uses a named shared memory `AdBlockStats` for pulling live statistics from
the `adblockd` engine. There currently is no error recovery for the case when
the UI is run without the engine running (the shared memory won't be available).
If the current design is used moving forward, we will immediately need to make
the UI behave when the shared memory is not available.

# Setup Enviromnent

Install Visual Studio 2019 with C++ and .NET development.
