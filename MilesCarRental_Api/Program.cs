using System;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using MilesCarRental_Api.Model;
using MilesCarRental_Api.Controllers;

try
{
    IConfigurationRoot configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .Build();

    string apiUrl = configuration.GetSection("ServiceSettings:ApiUrl").Value;

    Reservation reservation = new Reservation();

    Console.ForegroundColor = ConsoleColor.Magenta;

    Console.WriteLine("Hello, Wellcome To Miles Car Rental!");
    Console.WriteLine("");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("Please select your Pick-Up Location for your rent:");
    
    Console.ForegroundColor = ConsoleColor.Cyan;
    List<Location> locations = await new LocationController().GetLocations(apiUrl);
    foreach (Location loc in locations)
    {
        Console.WriteLine($"{loc.LocationId} - {loc.LocationName}");
    }

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("");
    string pickuplocation = Console.ReadLine();
    reservation.PickUpLocationId = int.Parse(pickuplocation);
    Console.WriteLine("");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("Please select your Drop-Off Location for your rent:");

    Console.ForegroundColor = ConsoleColor.Cyan;
    List<Location> dropofflocations = await new LocationController().GetDropOffLocations(apiUrl, pickuplocation);
    foreach (Location loc in dropofflocations)
    {
        Console.WriteLine($"{loc.LocationId} - {loc.LocationName}");
    }

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("");
    string dropofflocation = Console.ReadLine();
    reservation.DropOffLocationId = int.Parse(dropofflocation);
    Console.WriteLine("");

    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("Please insert your Pick-Up Date for your rent: (mm/dd/yyyy)");
    Console.ForegroundColor = ConsoleColor.Yellow;
    string pickupdate = Console.ReadLine();
    string format = "MM/dd/yyyy";
    reservation.StartDate = DateTime.ParseExact(pickupdate, format, System.Globalization.CultureInfo.InvariantCulture);
    Console.WriteLine("");

    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("Please insert your Drop-Off Date for your rent: (mm/dd/yyyy)");
    Console.ForegroundColor = ConsoleColor.Yellow;
    string dropoffdate = Console.ReadLine();
    reservation.EndDate = DateTime.ParseExact(dropoffdate, format, System.Globalization.CultureInfo.InvariantCulture);
    Console.WriteLine("");

    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("These are the vehicles available for your rent, please select just one:");

    Console.ForegroundColor = ConsoleColor.Cyan;
    List<VehicleCategory> vehiclecategory = await new VehicleController().GetVehicleTypeEnables(apiUrl, pickuplocation,pickupdate,dropoffdate);
    List<int> vechicletype = new List<int>();
    foreach (VehicleCategory ve in vehiclecategory.OrderBy(x => x.CategoryId))
    {
        if (!vechicletype.Contains(ve.Type.TypeId))
        {
            Console.WriteLine($"{ve.Type.TypeName}:");
            vechicletype.Add(ve.Type.TypeId);
        }
        Console.WriteLine($"  {ve.CategoryId} - {ve.CategoryName}");
    }

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("");
    string category = Console.ReadLine();
    Console.WriteLine("");

    Vehicle vehicle = await new VehicleController().GetVehicleEnable(apiUrl, pickuplocation, pickupdate, dropoffdate, category);

    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("Your enable vehicle is:");
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine($" Reference: {vehicle.VehicleId}");
    Console.WriteLine($" Brand: {vehicle.Brand}");
    Console.WriteLine($" Model: {vehicle.Model}");
    Console.WriteLine($" Manufacturing Year: {vehicle.ManufacturingYear}");
    Console.WriteLine($" Mileage: {vehicle.Mileage}");
    Console.WriteLine($" Daily Price: {vehicle.DailyPrice}");
    Console.WriteLine("");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("Do you want to confirm the reservation? (Y/N):");
    Console.ForegroundColor = ConsoleColor.Yellow;
    string confirmation = Console.ReadLine();

    if(confirmation.ToUpper() == "Y")
    {
        reservation.VehicleId = vehicle.VehicleId;
        reservation.Vehicle = vehicle;
        Customer customer = new Customer();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Please insert your Name:");
        Console.ForegroundColor = ConsoleColor.Yellow;
        customer.Name = Console.ReadLine();
        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Please insert your Licence Number:");
        Console.ForegroundColor = ConsoleColor.Yellow;
        customer.Licence = Console.ReadLine();
        customer.Document = customer.Licence;
        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Please insert your Phone Number:");
        Console.ForegroundColor = ConsoleColor.Yellow;
        customer.Phone = Console.ReadLine();
        Console.WriteLine("");
        reservation.Customer = customer;

        Reservation reservationresult = await new ReservationController().PostReservation(apiUrl,reservation);

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Your reservation is confirm, please save reservation data:");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($" Reference Reservation: {reservationresult.ReservationId}");
        Console.WriteLine($" Reference: {vehicle.VehicleId}");
        Console.WriteLine($" Brand: {vehicle.Brand}");
        Console.WriteLine($" Model: {vehicle.Model}");
        Console.WriteLine($" Pick-Up Location: {locations.Where(x => x.LocationId == reservationresult.PickUpLocationId).Select(x => x.LocationName).FirstOrDefault()}");
        Console.WriteLine($" Drop-Off Location: {locations.Where(x => x.LocationId == reservationresult.DropOffLocationId).Select(x => x.LocationName).FirstOrDefault()}");
        Console.WriteLine($" Pick-Up Date: {reservationresult.StartDate.ToString("MM/dd/yyyy")}");
        Console.WriteLine($" Drop-Off Date: {reservationresult.EndDate.ToString("MM/dd/yyyy")}");
        Console.WriteLine($" Total Rate: {reservationresult.TotalRate}");
        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Thank you for renting with us. Bye bye.");
    }
    else
    {

    }
    
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

    
