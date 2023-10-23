using System.Net.Http.Headers;
using System.Threading;

namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");

            // Take your line and use line.Split(',') to split it up into an array of strings, separated by the char ','
            var cells = line.Split(',');

            // If your array.Length is less than 3, something went wrong
            if (cells.Length < 3)
            {
                // Log that and return null
                // Do not fail if one record parsing fails, return null
                logger.LogInfo($"something went wrong, {cells.Length} returned.");
                return null; // TODO Implement
            }

            // grab the latitude from your array at index 0
            var latStr = cells[0];
            // grab the longitude from your array at index 1
            var longitudeStr = cells[1];
            // grab the name from your array at index 2
            var name = cells[2];

            // Your going to need to parse your string as a `double`
            // which is similar to parsing a string as an `int`
            var lat = double.Parse(latStr);
            var longitude = double.Parse(longitudeStr);

            // You'll need to create a TacoBell class
            // that conforms to ITrackable
            TacoBell tacoBell = new TacoBell();
            Point p = new Point();
            p.Latitude = lat;
            p.Longitude = longitude;
            tacoBell.Name = name;
            tacoBell.Location = p;

            // Then, you'll need an instance of the TacoBell class
            // With the name and point set correctly

            // Then, return the instance of your TacoBell class
            // Since it conforms to ITrackable

            return tacoBell;
        }
    }
}