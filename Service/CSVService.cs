using Hospital_Management_System_Web_Api.Entities;
using Hospital_Management_System_Web_Api.Interface;
using CsvHelper;
using CsvHelper.Configuration;

namespace Hospital_Management_System_Web_Api.Service
{
    //public class CSVService : ICSVService
    //{
    //    public IEnumerable<Doctor> ReadCSV<Doctor>(Stream file)
    //    {
    //        var reader = new StreamReader(file);
    //        var csv = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture);


    //        var records = csv.GetRecords<Doctor>();
    //        return records;
    //    }

    //    public void WriteCSV<Doctor>(List<Doctor> records)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    //public void WriteCSV<Doctor>(List<Doctor> records)
    //{
    //    using (var writer = new StreamWriter("F:\\Aplicatie\\Hospital Management System_Web Api\\CSV"))
    //    using (var csv = new CsvWriter(writer, System.Globalization.CultureInfo.InvariantCulture))
    //    {
    //        csv.WriteRecords(records);
    //    }



        //the StreamWriter is used to create and write files in the path specified in the parameter. 
        //The CsvWriter is used to create the actual CSV files using the StreamWriter instance created.
        //The WriteRecords method writes all the data into the files.
    //}
}
