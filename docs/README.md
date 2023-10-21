# Samsung.SmartTv.Client

## Project description
Set of libraries that allow you to connect to Samsung smart TV over web sockets and issue standard remote
control commands.

## Usage

### Reference NuGet package
```powershell
dotnet add package Samsung.SmartTv.Client.WebSockets 
```

### Basic
```csharp
const string AppName = "TestRemote";
const string IpAddress = "192.168.2.10";
// Default web socket service port
const int Port = 8002; 
    
var tvIpEndPoint = IPEndPoint.Parse($"{IpAddress}:{Port}");

// Register your application as remote control on the TV.
// After this call your TV should prompt you to allow your program to be registered as a remote control.
// After successful registration there is no need for subsequent ones, just store and use the token you got here.
var token =  await AppRegistryClientFactory.Create(tvIpEndPoint, useConsoleLogger: true).RegisterAppAsync(AppName).ConfigureAwait(false);

using var remoteControlClient =RemoteControlClientFactory.Create(tvIpEndPoint, AppName, token!, useConsoleLogger: true);

// Open the websocket connection
await remoteControlClient.ConnectAsync().ConfigureAwait(false);

// Predefined keys
await remoteControlClient.SendKeyAsync(Key.Mute).ConfigureAwait(false);
await Task.Delay(5000);
await remoteControlClient.SendKeyAsync(Key.VolumeUp).ConfigureAwait(false);
await Task.Delay(5000);
await remoteControlClient.SendKeyAsync(Key.ChannelUp).ConfigureAwait(false);
await Task.Delay(5000);
await remoteControlClient.SendKeyAsync(Key.ChannelDown).ConfigureAwait(false);

// Custom channel number.
var channel01 = Key.GetChannelNumericKey(1);
await remoteControlClient.SendKeyAsync(channel01).ConfigureAwait(false);

// Close the connection
await remoteControlClient.DisconnectAsync().ConfigureAwait(false);
```

### Custom device certificate validation  
```csharp
// In case that you want to validate certificate used for TLS by the TV, implement interface IRemoteCertificateValidator.
// Provide instance of your own validator to factories that are creating app registry and remote control clients.
// If you not provide your own implementation, remote certificate will always be considered valid.
class CustomCertValidator : IRemoteCertificateValidator
{
    public bool Validate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
    {
        return true;
    }
}

var token =  await AppRegistryClientFactory.Create
(
   tvIpEndPoint,
   remoteCertificateValidator: new CustomCertValidator()

).RegisterAppAsync(AppName).ConfigureAwait(false);

using var remoteControlClient = RemoteControlClientFactory.Create
(
    tvIpEndPoint, 
    AppName, token!,
    remoteCertificateValidator: new CustomCertValidator()
);
```

### Custom logging
```csharp
// You can introduce custom logging by implementing interface ILogger.
// If you want to use already built in console logger, when creating clients set useConsoleLogger to true.
// Provide instance of your own logger to factories that are creating app registry and remote control clients.
// If you don't provide your own implementation, logging will be disabled.
class CustomLogger : ILogger
{
    public void Debug(string message) => Console.WriteLine($"DEBUG: {message}");

    public void Error(string message) => Console.WriteLine($"ERROR: {message}");

    public void Error(string message, Exception exception) => Console.WriteLine($"ERROR: {message}");

    public void Info(string message) => Console.WriteLine($"INFO: {message}");

    public void Warn(string message) =>Console.WriteLine($"WARN: {message}");
}

var token =  await AppRegistryClientFactory.Create
(
    tvIpEndPoint, 
    logger: new CustomLogger(),

).RegisterAppAsync(AppName).ConfigureAwait(false);

using var remoteControlClient = RemoteControlClientFactory.Create
(
    tvIpEndPoint, 
    AppName, token!,
    logger: new CustomLogger()
);
```

## Remarks
This library is product of home automation effort and it is tested on only two devices:  
UE32M5572AU (2017)  
UE50TU8002K (2020)
