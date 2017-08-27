# Certly Scan
[![Build status](https://ci.appveyor.com/api/projects/status/p638h7gctr6rebhv?svg=true)](https://ci.appveyor.com/project/IanCarroll/cscan) 

[[Download x64]](https://s3-us-west-2.amazonaws.com/cscan/bin/Certly+Scan+x64.exe) [[Download x86]](https://s3-us-west-2.amazonaws.com/cscan/bin/Certly+Scan+x86.exe) [[Issues]](https://github.com/iangcarroll/cscan/issues) [[Documentation]](https://github.com/iangcarroll/cscan/wiki)

Certly Scan (or CScan) is a general-purpose scanning and repair tool for Windows computers. It enumerates many details about the system to aid in the detection of malware and has a simple domain-specific language for specifying what should be removed from the system. Because CScan internally structures the data it collects, its logs can be made machine readable. CScan is also notably fast, generally running in 3 seconds on most computers.

CScan supports Windows 7 and up, and may not function correctly on older systems. CScan tracks the latest version of the .NET framework, which may result in issues when running on older systems. You should install the latest runtime and, if applicable, the development pack, from [Microsoft's site](https://www.microsoft.com/net/targeting).

It is currently under active development and lacks many features that may be needed in order to effectively detect and remove malware. CScan is not intended to run on a hostile system; malware can prevent it from executing and, in the case of rootkits, feed it false data. Tools like RKill and RogueKiller can be used to halt malware.
