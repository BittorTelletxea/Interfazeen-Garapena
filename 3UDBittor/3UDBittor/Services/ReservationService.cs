using _3UDBittor.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace _3UDBittor.Services
{
    public class ReservationService
    {
        private const string FilePath = "Data/reservations.json";

        private Dictionary<string, Zone> _zones = new Dictionary<string, Zone>();

        public ReservationService()
        {
            LoadAllZones();
        }

        public Zone LoadZone(string mode)
        {
            if (!_zones.ContainsKey(mode))
            {
                int totalSeats = mode switch
                {
                    "Bus" => 15,
                    "Train" => 20,
                    "Airplane" => 25,
                    _ => 10
                };

                var zone = new Zone
                {
                    Name = mode,
                    Seats = new ObservableCollection<Seat>()
                };

                for (int i = 1; i <= totalSeats; i++)
                    zone.Seats.Add(new Seat { Id = $"{mode[0]}{i:D2}" });

                _zones[mode] = zone;

                SaveAllZones();
            }

            return _zones[mode];
        }

        public void SaveAllZones()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(FilePath)!);

            var jsonCompatibleDict = new Dictionary<string, object>();
            foreach (var kvp in _zones)
            {
                jsonCompatibleDict[kvp.Key] = new
                {
                    kvp.Value.Name,
                    Seats = new List<Seat>(kvp.Value.Seats)
                };
            }

            var json = JsonSerializer.Serialize(jsonCompatibleDict, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(FilePath, json);
        }

        public void LoadAllZones()
        {
            if (!File.Exists(FilePath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(FilePath)!);
                File.WriteAllText(FilePath, "{}");
                return;
            }

            var json = File.ReadAllText(FilePath);

            if (string.IsNullOrWhiteSpace(json))
            {
                File.WriteAllText(FilePath, "{}");
                return;
            }

            try
            {
                var dict = JsonSerializer.Deserialize<Dictionary<string, Zone>>(json);
                if (dict != null)
                {
                    _zones = dict;

                    foreach (var zone in _zones.Values)
                        zone.Seats = new ObservableCollection<Seat>(zone.Seats);
                }
            }
            catch (JsonException)
            {
                _zones.Clear();
                File.WriteAllText(FilePath, "{}");
            }
        }
    }
}
