# W3CParser

`W3CParser` is a .NET library for parsing IIS W3C log files.

This fork adds support for IIS TLS-related fields:

- `crypt-protocol`
- `crypt-cipher`
- `crypt-hash`
- `crypt-keyexchange`

Protocol values now include **TLS 1.3**.

## Features

- Parses standard IIS W3C log fields
- Extracts TLS and crypto metadata from IIS logs
- Supports filtering and ordering of parsed events

## Requirements

To populate the TLS-related fields in IIS logs, enable the corresponding server variables in IIS:

- [New IIS functionality to help identify weak TLS usage](https://www.microsoft.com/en-us/security/blog/2017/09/07/new-iis-functionality-to-help-identify-weak-tls-usage/)

## Installation

~~~bash
dotnet add package W3CParser --version 1.1.0
~~~

## Usage Example

~~~csharp
using System;
using System.IO;
using System.Linq;
using W3CParser.Enumerators;
using W3CParser.Parser;

using TextReader textReader = new StreamReader(@"C:\inetpub\logs\LogFiles\W3SVC1\u_ex230202_x.log");

var reader = new W3CReader(textReader);

foreach (var webEvent in reader.Read()
    .Where(x => x.CryptProtocol is not dwProtocol.SP_PROT_TLS1_2_SERVER
        and not dwProtocol.SP_PROT_TLS1_3_SERVER)
    .OrderBy(x => x.Status)
    .ThenBy(x => x.Date)
    .ThenBy(x => x.Time)
    .ThenBy(x => x.UriStem)
    .ThenBy(x => x.UriQuery))
{
    Console.WriteLine(
        "{0}\t{1:yyyy-MM-dd}\t{2:HH:mm:ss}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}",
        webEvent.Status,
        webEvent.Date,
        webEvent.Time,
        webEvent.UriStem,
        webEvent.UriQuery,
        webEvent.ClientIpAddress,
        webEvent.CryptProtocol,
        webEvent.CryptCipher,
        webEvent.CryptHash,
        webEvent.CryptKeyexchange);
}
~~~

## References

- [Original W3CParser project](https://github.com/AlexNolasco/SO32120528)
- [IIS: Identify weak TLS usage](https://www.microsoft.com/en-us/security/blog/2017/09/07/new-iis-functionality-to-help-identify-weak-tls-usage/)
