# AzureFunctionTableStorageSample
A very simple project which currently demonstrates an issue with using Azure Functions and FSharp.Azure.Storage together

When trying to use this, it fails with "MethodNotFound" for the inTable function. I suspect this is because of a version mismatch. When used with the functions core tools two versions of the Microsoft.WindowsAzure.Storage, but they appear to be of the same version. 
