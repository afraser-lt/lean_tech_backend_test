using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;

namespace Demo.Services
{
    public class ImportExportService
    {
        // see https://www.youtube.com/watch?v=afTiNU6EoA8 for more references
        static readonly string[] Scopes = { SheetsService.Scope.Spreadsheets };
        static readonly string ApplicationName = "Demo";
        static readonly string SpreadSheetId = "1cjL5-OijhkhbbOylZmrKtYl5EpXoZnE2";
        static readonly string sheet = "Sheet1";
        public static SheetsService service;

        private readonly IConfiguration configuration;

        public ImportExportService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void Export()
        {
            GoogleCredential credential;
            using (var stream = new FileStream("client_screts.json", FileMode.Open, FileAccess.Read))
            {
                credential = GoogleCredential.FromStream(stream)
                    .CreateScoped(Scopes);
            }

            service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName
            });
        }

        /// <summary>
        /// 
        /// </summary>
        public void ReadEntries()
        {
            var ragne = $"{sheet}!A1:F10";
            var request = service.Spreadsheets.Values.Get(SpreadSheetId, ragne);

            var response = request.Execute();
            var values = response.Values;
            if (values != null)
            {
                foreach (var row in values)
                {
                    var val = row[1];  // row[n]...
                    // code...
                }
            }
        }

        public void WriteEntry()
        {
            var ragne = $"{sheet}!A:F";
            var valueRange = new ValueRange();

            // todo: add values data
            // moves methods to a service
            valueRange.Values = new List<IList<object>> { null };

            var appendRequest = service.Spreadsheets.Values.Append(valueRange, SpreadSheetId, ragne);
            appendRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
            var appendResponse = appendRequest.Execute();

            var request = service.Spreadsheets.Values.Get(SpreadSheetId, ragne);

            var response = request.Execute();
            var values = response.Values;
            if (values != null)
            {
                foreach (var row in values)
                {
                    var val = row[1];  // row[n]...
                    // code...
                }
            }
        }

        public void UpdateEntry()
        {
            var ragne = $"{sheet}!A1";
            var valueRange = new ValueRange();

            // todo: add values data
            // moves methods to a service
            valueRange.Values = new List<IList<object>> { null };

            var updateRequest = service.Spreadsheets.Values.Update(valueRange, SpreadSheetId, ragne);
            updateRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
            var appendResponse = updateRequest.Execute();

            var request = service.Spreadsheets.Values.Get(SpreadSheetId, ragne);

            var response = request.Execute();
            var values = response.Values;
            if (values != null)
            {
                foreach (var row in values)
                {
                    var val = row[1];  // row[n]...
                    // code...
                }
            }
        }
    }
}
