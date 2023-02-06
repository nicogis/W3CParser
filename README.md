### W3CParser

This project is [W3CParser](https://github.com/AlexNolasco/SO32120528) 

I have added functionality to query CryptProtocol, CryptCipher, CryptHash, CryptKeyexchange

Set server variable in log IIS [New IIS functionality to help identify weak TLS usage](https://www.microsoft.com/en-us/security/blog/2017/09/07/new-iis-functionality-to-help-identify-weak-tls-usage/)


```

	using TextReader textReader = new StreamReader(@"C:\inetpub\logs\LogFiles\W3SVC1\u_ex230202_x.log");
	
	var reader = new W3CReader(textReader);
	foreach (var webevent in reader.Read().Where(r => r.CryptProtocol != W3CParser.Enumerators.dwProtocol.SP_PROT_TLS1_2_SERVER)
			 .OrderBy(w => w.Status)
			 .ThenBy(w => w.Date)
			 .ThenBy(w => w.UriStem)
			 .ThenBy(w => w.UriQuery))
	{
		Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}", webevent.Status.ToString(), webevent.ToLocalTime(),
			webevent.UriStem, webevent.UriQuery,webevent.ClientIpAddress, webevent.CryptProtocol, webevent.CryptCipher, webevent.CryptHash, webevent.CryptKeyexchange );
			
	}

```


dotnet add package W3CParser --version 1.0.0


