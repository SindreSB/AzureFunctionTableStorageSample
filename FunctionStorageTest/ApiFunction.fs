namespace FunctionApp1

open System
open Microsoft.Azure.WebJobs
open Microsoft.Azure.WebJobs.Host
open System;
open System.IO;
open System.Threading.Tasks;
open Microsoft.AspNetCore.Mvc;
open Microsoft.Azure.WebJobs;
open Microsoft.Azure.WebJobs.Extensions.Http;
open Microsoft.AspNetCore.Http;
open Microsoft.Extensions.Logging;
open Microsoft.WindowsAzure.Storage.Table
open FSharp.Azure.Storage.Table

module Function1 =
    type TestRecord = {
        [<PartitionKey>] PK: string
        [<RowKey>] RK: string
        Payload : string
    }

    [<FunctionName("Function1")>]
    let Run ([<HttpTrigger(AuthorizationLevel.Anonymous, [|"post"|])>] req: HttpRequest) ([<Table("test")>] table: CloudTable) (log: ILogger) = 
        async {
            let record = {
                PK = "testdata"
                RK = Guid.NewGuid().ToString()
                Payload = "data"
            }

            return record |> Insert |> inTable table.ServiceClient table.Name
        }
        |> Async.StartAsTask