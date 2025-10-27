using LekuErreserba.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LekuErreserba.Services
{
     public class ReservationService
{
    private readonly string filePath = Path.Combine("Data", "reservations.json");

    public List<Zone> LoadZones()
    {
        if (!File.Exists(filePath))
        {
            var zones = CreateDefaultZones();
            SaveZones(zones);
            return zones;
        }

        var json = File.ReadAllText(filePath);
        var result = JsonSerializer.Deserialize<List<Zone>>(json);
        return result ?? new List<Zone>();
    }

    public void SaveZones(List<Zone> zones)
    {
        var json = JsonSerializer.Serialize(zones, new JsonSerializerOptions { WriteIndented = true });
        Directory.CreateDirectory("Data");
        File.WriteAllText(filePath, json);
    }

    private List<Zone> CreateDefaultZones()
    {
        return new List<Zone>
            {
                new Zone
                {
                    Name = "Autobusa",
                    Transport = TransportType.Bus,
                    Seats = GenerateSeats(20)
                },
                new Zone
                {
                    Name = "Trena",
                    Transport = TransportType.Train,
                    Seats = GenerateSeats(30)
                },
                new Zone
                {
                    Name = "Hegazkina",
                    Transport = TransportType.Plane,
                    Seats = GenerateSeats(40)
                }
            };
    }

    private List<Seat> GenerateSeats(int count)
    {
        var seats = new List<Seat>();
        for (int i = 1; i <= count; i++)
            seats.Add(new Seat { Id = i, Label = i.ToString(), Status = SeatStatus.Available });
        return seats;
    }
}
}
